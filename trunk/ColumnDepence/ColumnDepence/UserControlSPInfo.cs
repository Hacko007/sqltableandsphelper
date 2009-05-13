﻿using System;
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

		private delegate SqlRichTextBox GetRichTextBoxDelegate();
		private SqlRichTextBox GetRichTextBox()
		{
			return m_RichTextBoxDefinition;
		}


		public SqlRichTextBox RichTextBoxDefinition
		{
			get
			{
				if (m_RichTextBoxDefinition.InvokeRequired)
				{
					return (SqlRichTextBox)m_RichTextBoxDefinition.Invoke(new GetRichTextBoxDelegate(GetRichTextBox));
				}
				else
				{
					return m_RichTextBoxDefinition;
				}
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
				return RichTextBoxDefinition.Text;
			}
			set
			{
				RichTextBoxDefinition.Text = value;
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
			RichTextBoxDefinition.AutoWordSelection = true;			
			RichTextBoxDefinition.ZoomFactor = 1.2f;
			ShowDependenciesInfo = false;
			m_SplitContainerMain.Panel1Collapsed = true;
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

		public void SyntaxHighLight()
		{
			if (m_RichTextBoxDefinition.InvokeRequired)
			{
				m_RichTextBoxDefinition.Invoke(new MethodInvoker(SyntaxHighLight));
			}
			else
			{
				FormMain.StatusInfo1 = "Syntax highligting";
				Application.DoEvents();				
				RichTextBoxDefinition.ApplySyntaxHighlighting();
				FormMain.StatusInfo1 = "";

			}
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
			if(SpName == "")return;
			if(ConnectionFactory.OpenConnection()== false) return;

			const string sqlStr = "	Declare @id int "
			                       + @"
SELECT top 1 " + "@id = id     FROM syscomments WHERE colid=1 AND  [text] LIKE @SPSEARCH AND OBJECTPROPERTY(id, 'IsProcedure') = 1 "
			                       + @"
 SELECT [text]    FROM syscomments     "
			                       + " WHERE id= @id ";

			SqlCommand com = new SqlCommand(sqlStr, ConnectionFactory.Instance);
			com.Parameters.Add("@SPSEARCH", SqlDbType.NVarChar);
			com.Parameters["@SPSEARCH"].Value = "%" + SpName + "%";

			RichTextBoxDefinition.Text = "";

			FormMain.StatusInfo1 = "Loading SP definition ...";
			FormMain.StatusInfo2 = m_tryToLoadCounter + " try";
			Application.DoEvents();

			try
			{				
				SqlDataReader reader = com.ExecuteReader();
				if (reader == null)
				{
					return;
				}
				try
				{
					while (reader.Read())
					{
						RichTextBoxDefinition.Text += reader[0];
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

		private void ToolStripTextBoxFind_TextChanged(object sender, EventArgs e)
		{
			RichTextBoxDefinition.FindText(m_toolStripTextBoxFind.Text);
		}

		private void ToolStripButtonExecSp_Click(object sender, EventArgs e)
		{
			FormRunSp formRunSp = new FormRunSp {SpInfo = SpInfo};
			formRunSp.InitDataGridView();
			formRunSp.Show();
		}

	}


}
