﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ColumnDepence
{
	/// <summary>
	/// Show inforamtion about stored procedures.
	/// </summary>
	public partial class UserControlSPInfo : UserControl
	{
		public event TabPageDelegate CloseTabPage;
		public event OpenTableDelegate OpenTableTab;
		public event OpenSPDelegate OpenSpTab;


		public ColumnDependencies FormMain
		{
			get
			{				
				return ColumnDependencies.FormMain;
			}
		}

		/// <summary>
		/// Get or Sets Stored Procedures Name
		/// </summary>
		public string SPName { get; set; }


		public UserControlSPInfo()
		{
			InitializeComponent();
			SPName = (SPName == null) ? "" : SPName;

			m_richTextBox_Definition.AutoWordSelection = true;			
			m_richTextBox_Definition.ZoomFactor = 1.2f;
			
		}

		protected virtual void RaiseCloseTabPage()
		{
			if (CloseTabPage != null)
			{
				CloseTabPage(SPName);
			}
		}
		protected virtual void RaiseOpenTableTab(string tableName, bool isDefinitionShown)
		{
			if (OpenTableTab != null)
			{
				OpenTableTab(this, tableName, isDefinitionShown);
			}
		}
		protected virtual void RaiseOpenSpTab(string spName)
		{
			if (OpenSpTab != null)
			{
				OpenSpTab(this, spName);
			}
		}

		private int tryToLoadCounter = 1;

		/// <summary>
		/// Refreshes textbox with SPs definition.
		/// </summary>
		void FillSPDefinition()
		{			
			string sql_str = "	Declare @id int "
		+ @"
SELECT " + "@id = id     FROM syscomments WHERE [text] LIKE @SPSEARCH AND OBJECTPROPERTY(id, 'IsProcedure') = 1 "
		+ @"
 SELECT [text]    FROM syscomments     "
		+ " WHERE id= @id ";

			SqlCommand com = new SqlCommand(sql_str, ConnectionFactory.Instance);
			com.Parameters.Add("@SPSEARCH", SqlDbType.NVarChar);
			com.Parameters["@SPSEARCH"].Value = "%" + SPName + "%";

			m_richTextBox_Definition.Text = "";

			FormMain.StatusInfo1 = "Loading SP definition ...";
			FormMain.StatusInfo2 = tryToLoadCounter + " try";
			Application.DoEvents();

			try
			{
				ConnectionFactory.Instance.Open();
				SqlDataReader reader = com.ExecuteReader();
				if (reader == null)
				{
					return;
				}
				try
				{
					while (reader.Read())
					{
						m_richTextBox_Definition.Text += reader[0];
						Application.DoEvents();
					}
				}
				finally
				{
					// Always call Close when done reading.
					reader.Close();
					tryToLoadCounter = 1;
				}
			}catch
			{
				if(tryToLoadCounter <4)
				{
					Application.DoEvents();
					tryToLoadCounter++;
					FillSPDefinition();		
					return;
				}
				
			}
			ConnectionFactory.Instance.Close();
			FormMain.StatusInfo1 = "Syntax highligting";			
			SyntaxHighLight();
			FormMain.StatusInfo1 = "";
			FormMain.StatusInfo2 = "";

		}

		/// <summary>
		/// Fill datagrid with inforamtion about SP's parameters
		/// </summary>
		void FillParameters() {
			string sql_str = @"SELECT 
			PARAMETER_NAME ,
			DATA_TYPE, 
		CASE 
			WHEN CHARACTER_MAXIMUM_LENGTH is not null THEN CHARACTER_MAXIMUM_LENGTH
			ELSE NUMERIC_PRECISION END AS [LENGTH], PARAMETER_MODE 
		FROM INFORMATION_SCHEMA.PARAMETERS "
		+ "WHERE SPECIFIC_NAME LIKE @SPSEARCH Order by ORDINAL_POSITION ";

			DataSet ds = FillDataSet(sql_str);
			if (ds != null && ds.Tables.Count > 0)
			{
				m_dataGridView_Params.DataSource = ds.Tables[0];
				m_dataGridView_Params.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				m_dataGridView_Params.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				//m_dataGridView_Params.Columns[1].ContextMenuStrip = m_contextMenuStrip_ShowTable;
			}
		}

		/// <summary>
		/// Fill datagrid with inforamtion about SP's dependencies
		/// </summary>
		void FillDependecies()
		{

			try
			{
				if (ConnectionFactory.Instance.State != ConnectionState.Open)
				{
					ConnectionFactory.Instance.Open();
				}

				SqlCommand com = new SqlCommand("sp_depends", ConnectionFactory.Instance);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.Add("@objname", SqlDbType.NVarChar, 517);
				com.Parameters[0].Value = SPName;

				using (SqlDataAdapter adapter = new SqlDataAdapter(com))
				{
					DataSet ds = new DataSet();
					adapter.Fill(ds);


					if (ds.Tables.Count > 0)
					{

						DataTable dt = ds.Tables[0];

						dt.Columns.Add("MyUpd", typeof(bool), "IIF(updated = 'yes', 1 , 0)");
						dt.Columns.Add("MySel", typeof(bool), "IIF(selected = 'yes', 1 , 0)");
						dt.Columns.Add("MyType", typeof(string), "IIF(type = 'stored procedure', 'SP' , 'TAB')");

						m_dataGridView_DepTables.DataSource = dt;
						m_dataGridView_DepTables.Columns["type"].Visible = false;
						m_dataGridView_DepTables.Columns["updated"].Visible = false;
						m_dataGridView_DepTables.Columns["selected"].Visible = false;
						m_dataGridView_DepTables.Columns["MyUpd"].HeaderText = "Updated";
						m_dataGridView_DepTables.Columns["MySel"].HeaderText = "Selected";
						m_dataGridView_DepTables.Columns["MyType"].HeaderText = "Type";

						m_dataGridView_DepTables.Columns["name"].HeaderText = "Dependent Object";
						m_dataGridView_DepTables.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
						m_dataGridView_DepTables.Columns["name"].ContextMenuStrip = m_ContextMenuStrip_ShowDefinition;

						m_dataGridView_DepTables.Columns["column"].HeaderText = "Column";
						m_dataGridView_DepTables.Columns["column"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

					}
				}
			}
			catch (SqlException sexc)
			{
				MessageBox.Show("Checke if " + SPName + " exists in database");
			}
			catch { }
			finally
			{
				ConnectionFactory.Instance.Close();
			}

			
			
		}


		/// <summary>
		/// Execute sql string and return result in DataSet
		/// </summary>
		/// <param name="sql_cmd_str">SQL to execute</param>
		/// <returns>Result of SQL executtion</returns>
		DataSet FillDataSet(string sql_cmd_str)
		{
			try
			{
				if (ConnectionFactory.Instance.State != ConnectionState.Open)
				{
					ConnectionFactory.Instance.Open();
				}

				SqlCommand com = new SqlCommand(sql_cmd_str, ConnectionFactory.Instance);
				if (sql_cmd_str.IndexOf("@SPSEARCH") > -1)
				{
					com.Parameters.Add("@SPSEARCH", SqlDbType.NVarChar);
					com.Parameters["@SPSEARCH"].Value = SPName;
				}
				using (SqlDataAdapter adapter = new SqlDataAdapter(com))
				{
					DataSet ds = new DataSet();
					adapter.Fill(ds);
					return ds;
				}

			}
			catch {
				return null;
			}
			finally
			{
				ConnectionFactory.Instance.Close();
			}
		}

		/// <summary>
		/// Fill controls values
		/// </summary>
		internal void InitControl()
		{
			this.SPName = this.SPName.Replace("dbo.", "");
			Cursor = Cursors.WaitCursor;
			Application.DoEvents();
			FillParameters();
			Application.DoEvents();
			FillDependecies();
			Application.DoEvents();
			FillSPDefinition();
			Cursor = Cursors.Default;			
		}

		/// <summary>
		/// Apply syntax highlighting on SP's definition
		/// </summary>
		private void SyntaxHighLight()
		{
			int start = 0;
			int end = m_richTextBox_Definition.Text.Length;
			/// 
			/// Backup the users current selection point.
			/// 
			int selectionStart = m_richTextBox_Definition.SelectionStart;
			int selectionLength = m_richTextBox_Definition.SelectionLength;
			/// 
			/// Split the text into tokens.
			/// 
			Regex r = new Regex(@"([ \t{}();\n,])|(--.*\n)", RegexOptions.Compiled| RegexOptions.IgnorePatternWhitespace);			
			string[] tokens = r.Split(m_richTextBox_Definition.Text);
			int index = start;
			foreach (string token in tokens)
			{
				/// Set the token's default color and font.
				m_richTextBox_Definition.SelectionStart = index;
				m_richTextBox_Definition.SelectionLength = token.Length;
				m_richTextBox_Definition.SelectionColor = Color.Black;
				m_richTextBox_Definition.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);

				bool colored = false;
				/// 
				/// Check whether the token is a keyword. 
				/// 
				String[] keywords = { "exec","execute", "if", "then","begin", "end","else","case", "null", "use"
									, "return","create","table","declare" ,"transaction" , "commit","rollback"
									,"as", "set" ,"goto","drop" ,"go","while","next","open","for","cursor"
									,"fetch","close","cast", "primary" , "key" , "rowcount","procedure"};
				for (int i = 0; i < keywords.Length; i++)
				{
					if (keywords[i] == token.ToLower())
					{
						// Apply alternative color and font to highlight keyword. 
						m_richTextBox_Definition.SelectionColor = Color.Blue;
						m_richTextBox_Definition.SelectionFont = new Font("Courier New", 10,
						FontStyle.Bold);
						colored = true;
						break;
					}
				}

				/// 
				/// Check whether the token is a types. 
				/// 
				String[] types = { "int", "date", "datetime", "char", "nchar", "nvarchar", "bit", "collate","float" };
				if(!colored)
				for (int i = 0; i < types.Length; i++)
				{
					if (types[i] == token.ToLower())
					{
						// Apply alternative color and font to highlight keyword. 
						m_richTextBox_Definition.SelectionColor = Color.DarkGreen;
						m_richTextBox_Definition.SelectionFont = new Font("Courier New", 10,FontStyle.Bold);
						colored = true;
						break;
					}
				}

				/// 
				/// SQL keywords
				/// 
				String[] sql = { "select", "from", "where", "not", "exists", "and", "or", "insert", "into"
								   ,"values","update","delete","inner","left","join" };
				if (!colored)
					for (int i = 0; i < sql.Length; i++)
					{
						if (sql[i] == token.ToLower())
						{
							// Apply alternative color and font to highlight keyword. 
							m_richTextBox_Definition.SelectionColor = Color.Green;
							m_richTextBox_Definition.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
							colored = true;
							break;
						}
					}
				/// 
				/// One line comments
				/// 
				if(token.StartsWith("--")){
					m_richTextBox_Definition.SelectionColor = Color.Gray;
					m_richTextBox_Definition.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
				}

				index += token.Length;
			}
			// Restore the users current selection point. 
			m_richTextBox_Definition.SelectionStart = selectionStart;
			m_richTextBox_Definition.SelectionLength = selectionLength;
			
		}

		private void ShowDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (m_dataGridView_DepTables.SelectedCells.Count > 0)
				{
					string val = m_dataGridView_DepTables.SelectedCells[0].Value.ToString();
					bool is_sp = "SP" == m_dataGridView_DepTables.SelectedCells[0].OwningRow.Cells["MyType"].Value.ToString();

					if (is_sp) {
						RaiseOpenSpTab(val);
					}
					else
					{
						RaiseOpenTableTab(val, true);
					}
				}
			}
			catch { }

		}


	}


}
