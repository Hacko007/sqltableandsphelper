using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.ComponentModel;
using ColumnDepence.DbInfo;

namespace ColumnDepence
{
	/// <summary>
	/// Show inforamtion about stored procedures.
	/// </summary>
	public partial class UserControlSpInfo : UserControl
	{
		public event TabPageDelegate CloseTabPage;
		public event OpenTableDelegate OpenTableTab;
		public event OpenSpDelegate OpenSpTab;

		#region Properties

		public SpInfo SpInfo { get; set; }

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
		public string SpName { get; set; }
		public string SpDefinition
		{
			get
			{
				return m_RichTextBoxDefinition.Text;
			}
			set
			{
				m_RichTextBoxDefinition.Text = value;
			}
		}
		public object DataViewParamsDataSource
		{
			get {
				return m_DataGridViewParams == null ? null : m_DataGridViewParams.DataSource;
			}
			set
			{
				if (m_DataGridViewParams == null) return;
				m_DataGridViewParams.DataSource = value;
			}
		}
		public object DataViewDependentTablesDataSource
		{
			get {
				return m_DataGridViewDepTables== null ? null : m_DataGridViewDepTables.DataSource;
			}
			set
			{
				if (m_DataGridViewDepTables== null) return;
				m_DataGridViewDepTables.DataSource = value;
			}
		}
		public bool ShowDependenciesInfo 
		{
			get { return m_toolStripButtonShowParamInfo.Checked; }
			set { m_toolStripButtonShowParamInfo.Checked = value; }
		}

		#endregion Properties

		public UserControlSpInfo()
		{
			InitializeComponent();
			SpName = SpName ?? "";
			SpInfo = new SpInfo(SpName);
			m_tryToLoadCounter = 1;
			m_RichTextBoxDefinition.AutoWordSelection = true;			
			m_RichTextBoxDefinition.ZoomFactor = 1.2f;
			ShowDependenciesInfo = false;
			m_SplitContainerMain.Panel1Collapsed = true;
			
			m_BackgroundWorkerFindText.DoWork += BackgroundWorkerFindTextDoWork;
			m_BackgroundWorkerFindText.WorkerSupportsCancellation = true;
		}

		/// <summary>
		/// Fill controls values
		/// </summary>
		internal void InitControl()
		{
			SpName = SpName.Replace("dbo.", "");
			SpInfo = new SpInfo(SpName);

			Cursor = Cursors.WaitCursor;
			Application.DoEvents();
			FillParameters();
			Application.DoEvents();
			FillDependecies();
			Application.DoEvents();
			FillSpDefinition();
			Cursor = Cursors.Default;
			m_toolStripLabelConnection.Text = ConnectionFactory.ShortConnectionName;
		}


		internal UserControlSpInfo Clone()
		{
			UserControlSpInfo sp = new UserControlSpInfo
			                       	{
										SpName = SpName,
										SpInfo= SpInfo,
			                       		SpDefinition = SpDefinition,
			                       		DataViewDependentTablesDataSource = DataViewDependentTablesDataSource,
			                       		DataViewParamsDataSource = DataViewParamsDataSource,
			                       		ShowDependenciesInfo = ShowDependenciesInfo
			                       	};
			sp.SyntaxHighLight();
			sp.InitCoulomnsInDvDepTables();
			return sp;
		}
	
		#region Raise on event
		protected virtual void RaiseCloseTabPage()
		{
			if (CloseTabPage != null)
			{
				CloseTabPage(SpName);
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
		#endregion Raise on event

		#region Get data from DB
		/// <summary>
		/// Refreshes textbox with SPs definition.
		/// </summary>
		void FillSpDefinition()
		{			
			const string sqlStr = "	Declare @id int "
			                       + @"
SELECT top 1 " + "@id = id     FROM syscomments WHERE colid=1 AND  [text] LIKE @SPSEARCH AND OBJECTPROPERTY(id, 'IsProcedure') = 1 "
			                       + @"
 SELECT [text]    FROM syscomments     "
			                       + " WHERE id= @id ";

			SqlCommand com = new SqlCommand(sqlStr, ConnectionFactory.Instance);
			com.Parameters.Add("@SPSEARCH", SqlDbType.NVarChar);
			com.Parameters["@SPSEARCH"].Value = "%" + SpName + "%";

			m_RichTextBoxDefinition.Text = "";

			FormMain.StatusInfo1 = "Loading SP definition ...";
			FormMain.StatusInfo2 = m_tryToLoadCounter + " try";
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
						m_RichTextBoxDefinition.Text += reader[0];
						Application.DoEvents();
					}
				}
				finally
				{
					// Always call Close when done reading.
					reader.Close();
					m_tryToLoadCounter = 1;
				}
			}catch
			{
				if(m_tryToLoadCounter <4)
				{
					Application.DoEvents();
					m_tryToLoadCounter++;
					FillSpDefinition();		
					return;
				}
				
			}
			ConnectionFactory.CloseConnection();
			FormMain.StatusInfo1 = "Syntax highligting";
			Application.DoEvents();		
			SyntaxHighLight();
			FormMain.StatusInfo1 = "";
			FormMain.StatusInfo2 = "";

		}

		/// <summary>
		/// Fill datagrid with inforamtion about SP's parameters
		/// </summary>
		void FillParameters() {
			m_DataGridViewParams.DataSource = SpInfo.ParameterInfo;
		}

		/// <summary>
		/// Fill datagrid with inforamtion about SP's dependencies
		/// </summary>
		void FillDependecies()
		{
			m_DataGridViewDepTables.DataSource = SpInfo.Dependencies;
		}

		internal void InitCoulomnsInDvDepTables()
		{
			m_DataGridViewDepTables.Columns["type"].Visible = false;
			m_DataGridViewDepTables.Columns["updated"].Visible = false;
			m_DataGridViewDepTables.Columns["selected"].Visible = false;
			m_DataGridViewDepTables.Columns["MyUpd"].HeaderText = "Updated";
			m_DataGridViewDepTables.Columns["MySel"].HeaderText = "Selected";
			m_DataGridViewDepTables.Columns["MyType"].HeaderText = "Type";

			m_DataGridViewDepTables.Columns["name"].HeaderText = "Dependent Object";
			m_DataGridViewDepTables.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			m_DataGridViewDepTables.Columns["name"].ContextMenuStrip = m_ContextMenuStripShowDefinition;

			m_DataGridViewDepTables.Columns["column"].HeaderText = "Column";
			m_DataGridViewDepTables.Columns["column"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		}


		/// <summary>
		/// Execute sql string and return result in DataSet
		/// </summary>
		/// <param name="sqlCmdStr">SQL to execute</param>
		/// <returns>Result of SQL executtion</returns>
		DataSet FillDataSet(string sqlCmdStr)
		{
			try
			{
				if (ConnectionFactory.Instance.State != ConnectionState.Open)
				{
					ConnectionFactory.Instance.Open();
				}

				SqlCommand com = new SqlCommand(sqlCmdStr, ConnectionFactory.Instance);
				if (sqlCmdStr.IndexOf("@SPSEARCH") > -1)
				{
					com.Parameters.Add("@SPSEARCH", SqlDbType.NVarChar);
					com.Parameters["@SPSEARCH"].Value = SpName;
				}
				using (SqlDataAdapter adapter = new SqlDataAdapter(com))
				{
					DataSet ds = new DataSet();
					adapter.Fill(ds);
					return ds;
				}

			}
			catch
			{
				return null;
			}
			finally
			{
				ConnectionFactory.CloseConnection();
			}
		}
		
		#endregion Get data from DB

		/// <summary>
		/// Apply syntax highlighting on SP's definition
		/// </summary>
		private void SyntaxHighLight()
		{
			const int start = 0;
			
			/// 
			/// Backup the users current selection point.
			/// 
			int selectionStart = m_RichTextBoxDefinition.SelectionStart;
			int selectionLength = m_RichTextBoxDefinition.SelectionLength;
			/// 
			/// Split the text into tokens.
			/// 
			Regex r = new Regex(@"([ \t{}();\n,])|(--.*\n)", RegexOptions.Compiled| RegexOptions.IgnorePatternWhitespace);			
			string[] tokens = r.Split(m_RichTextBoxDefinition.Text);
			int index = start;
			foreach (string token in tokens)
			{
				/// Set the token's default color and font.
				m_RichTextBoxDefinition.SelectionStart = index;
				m_RichTextBoxDefinition.SelectionLength = token.Length;
				m_RichTextBoxDefinition.SelectionColor = Color.Black;
				m_RichTextBoxDefinition.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);

				bool colored = false;
				/// 
				/// Check whether the token is a keyword. 
				/// 
				String[] keywords = { "exec","execute", "if", "then","begin", "end","else","case", "null", "use"
									, "return","create","table","declare" ,"transaction" , "commit","rollback"
									,"as", "set" ,"goto","drop" ,"go","while","next","open","for","cursor"
									,"fetch","close","cast", "primary" , "key" , "rowcount","procedure"
									,"nocount" , "on"};
				for (int i = 0; i < keywords.Length; i++)
				{
					if (keywords[i] == token.ToLower())
					{
						// Apply alternative color and font to highlight keyword. 
						m_RichTextBoxDefinition.SelectionColor = Color.Blue;
						m_RichTextBoxDefinition.SelectionFont = new Font("Courier New", 10,
						FontStyle.Bold);
						colored = true;
						break;
					}
				}

				/// 
				/// Check whether the token is a types. 
				/// 
				String[] types = { "int", "date", "datetime", "char", "nchar", "nvarchar", "bit", "collate","float","xml" };
				if(!colored)
				for (int i = 0; i < types.Length; i++)
				{
					if (types[i] != token.ToLower()) continue;

					// Apply alternative color and font to highlight keyword. 
					m_RichTextBoxDefinition.SelectionColor = Color.DarkGreen;
					m_RichTextBoxDefinition.SelectionFont = new Font("Courier New", 10,FontStyle.Bold);
					colored = true;
					break;
				}

				/// 
				/// SQL keywords
				/// 
				String[] sql = { "select", "from", "where", "not", "exists", "and", "or", "insert", "into"
								   ,"values","update","delete","inner","left","join" , "order", "by" ,"having"
							   , "out","in", "output","asc","desc"};
				if (!colored)
					for (int i = 0; i < sql.Length; i++)
					{
						if (sql[i] != token.ToLower()) continue;

						// Apply alternative color and font to highlight keyword. 
						m_RichTextBoxDefinition.SelectionColor = Color.Green;
						m_RichTextBoxDefinition.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);						
						break;
					}
				/// 
				/// One line comments
				/// 
				if(token.StartsWith("--")){
					m_RichTextBoxDefinition.SelectionColor = Color.Gray;
					m_RichTextBoxDefinition.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
				}else

				/// 
				/// Variable
				/// 
				if (token.StartsWith("@"))
				{
					m_RichTextBoxDefinition.SelectionColor = Color.DarkBlue;
					m_RichTextBoxDefinition.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
				}

				index += token.Length;
			}
			// Restore the users current selection point. 
			m_RichTextBoxDefinition.SelectionStart = selectionStart;
			m_RichTextBoxDefinition.SelectionLength = selectionLength;

		}


		#region ToolStripMenuItem events
		private void ShowDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (m_DataGridViewDepTables.SelectedCells.Count > 0)
				{
					string val = m_DataGridViewDepTables.SelectedCells[0].Value.ToString();
					bool isSp = "SP" == m_DataGridViewDepTables.SelectedCells[0].OwningRow.Cells["MyType"].Value.ToString();

					if (isSp) {
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


		private void ToolStripButtonShowAsToolBox_Click(object sender, EventArgs e)
		{
			if (m_Toolbox == null)
			{
				m_Toolbox = new Form
				          	{
				          		Text = SpName
				          	};
				m_toolStripButtonClose.Visible = false;
				m_toolStripButtonShowAsToolBox.Text = "Show as tab page";
				Dock = DockStyle.Fill;
				m_Toolbox.Controls.Add(this);
				m_Toolbox.FormBorderStyle = FormBorderStyle.SizableToolWindow;
				m_Toolbox.Size = new Size(800, 600);
				m_Toolbox.Show();
				RaiseCloseTabPage();
				m_Toolbox.Owner = FormMain;
			}
			else
			{
				try
				{
					if (m_Toolbox.Controls.Count > 0 && m_Toolbox.Controls[0] is UserControlSpInfo)
					{
						UserControlSpInfo spClone = ((UserControlSpInfo)m_Toolbox.Controls[0]).Clone();
						m_Toolbox.Close();
						FormMain.CreateSpTabPage(SpName, spClone);
					}
				}
				catch
				{
					FormMain.CreateSpTabPage(SpName);
				}
			}
		}

		private void ToolStripButtonClose_Click(object sender, EventArgs e)
		{
			RaiseCloseTabPage();
		}		

		private void ToolStripButtonShowParamInfo_CheckedChanged(object sender, EventArgs e)
		{
			m_SplitContainerMain.Panel1Collapsed = !m_toolStripButtonShowParamInfo.Checked;
		}

		#endregion ToolStripMenuItem events

		#region FindText methods
		private void ToolStripTextBoxFind_TextChanged(object sender, EventArgs e)
		{			
			m_BackgroundWorkerFindText.CancelAsync();
			
			m_RichTextBoxDefinition.SelectAll();
			m_RichTextBoxDefinition.SelectionBackColor = Color.White;

			if (m_toolStripTextBoxFind.Text.Trim().Length == 0)
			{
				LastFindIndex = 0;
				return;
			}

			if (m_BackgroundWorkerFindText.IsBusy == false)
				m_BackgroundWorkerFindText.RunWorkerAsync(m_toolStripTextBoxFind.Text);

		}

		private void BackgroundWorkerFindTextDoWork(object sender, DoWorkEventArgs e)
		{
			if (m_RichTextBoxDefinition != null)
				m_RichTextBoxDefinition.Invoke(new FindTextDelegate(FindText), new object[] { e.Argument.ToString(), 0, true, sender as BackgroundWorker,e});
		}

		private delegate void FindTextDelegate(string searchString, int startingFrom, bool scrollToString, BackgroundWorker worker, DoWorkEventArgs e);

		private void FindText(string searchString, int startingFrom, bool scrollToString, BackgroundWorker worker, DoWorkEventArgs e)
		{
			try
			{
				if (worker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}


				LastFindIndex = m_RichTextBoxDefinition.Find(searchString, startingFrom, RichTextBoxFinds.None);

				/// Add color
				if (LastFindIndex >= 0)
				{
					m_RichTextBoxDefinition.SelectionStart = LastFindIndex;
					m_RichTextBoxDefinition.SelectionLength = searchString.Length;
					m_RichTextBoxDefinition.SelectionBackColor = Color.LightGreen;
					if (scrollToString)
						m_RichTextBoxDefinition.ScrollToCaret();

					FindText(searchString, LastFindIndex + 1, false, worker,e);
				}
			}
			catch { }
		}		

		public int LastFindIndex { get; set; }

		#endregion FindText methods

		private void ToolStripButtonExecSp_Click(object sender, EventArgs e)
		{
			FormRunSp formRunSp = new FormRunSp {SpInfo = SpInfo};
			formRunSp.InitDataGridView();
			formRunSp.Show();
		}

	}


}
