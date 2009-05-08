using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using ColumnDepence.DbInfo;

namespace ColumnDepence
{

	public delegate void TabPageDelegate(string tabPageKey);
	public delegate void OpenTableDelegate(object sender, string tableName, bool isDefinitionShown);
	public delegate void OpenTableFilteredDelegate(object sender, string tableName, bool isDefinitionShown, TableFilterData cellInfo);
	public delegate void OpenSpDelegate(object sender, string spName);


	public partial class ColumnDependencies : Form
	{
		public static ColumnDependencies FormMain { get; set; }

		public ColumnDependencies()
		{
			InitializeComponent();
			m_userControlHistoryList_Tables.SettingName = "LastUsedTables";
			m_userControlHistoryList_Sp.SettingName = "LastUsedSPs";
			Application.DoEvents();
			FillAutoCompleteCustomSource();
			SetTitle();
			FormMain = this;
		}


		public string TableName { get { return txtTableName.Text.Trim(); } }


		public static bool TableExists(string tableName) {
			try
			{
				if (tableName == "") return false;

				const string sqlStr = @"SELECT CASE WHEN EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME LIKE @TableName ) THEN cast(1 as BIT) ELSE cast(0 as BIT) END";
				SqlCommand cmd = new SqlCommand(sqlStr, ConnectionFactory.Instance);
				cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 150);
				cmd.Parameters["@TableName"].Value = tableName;
				
				if (ConnectionFactory.Instance == null) return false;
				if (ConnectionFactory.Instance.State != ConnectionState.Open)
					ConnectionFactory.Instance.Open();

				bool tableExists = (bool)cmd.ExecuteScalar();

				return tableExists;
			}catch{
				return false;
			}
			finally
			{
				ConnectionFactory.CloseConnection();
			}
			
		}

		public static bool StoredProcedureExists(string tableName)
		{
			try
			{
				if (tableName == "") return false;

				if (ConnectionFactory.Instance == null) return false;
				if (ConnectionFactory.Instance.State != ConnectionState.Open)
					ConnectionFactory.Instance.Open();

				SqlCommand com = new SqlCommand("sp_depends", ConnectionFactory.Instance)
				                 	{
				                 		CommandType = CommandType.StoredProcedure
				                 	};
				com.Parameters.Add("@objname", SqlDbType.NVarChar, 517);
				com.Parameters[0].Value = tableName;

				using (SqlDataAdapter adapter = new SqlDataAdapter(com))
				{
					DataSet ds = new DataSet();
					adapter.Fill(ds);
					return (ds.Tables.Count > 0);
				}
			}
			catch
			{
				return false;
			}
			finally
			{
				ConnectionFactory.CloseConnection();
			}

		}

		public void FillAutoCompleteCustomSource()
		{
			/// 
			/// Table auto complete
			/// 
			string sqlStr = @"SELECT DISTINCT TB.TABLE_NAME  FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TB  ORDER BY TB.TABLE_NAME";

			DataSet ds = FillDataSet(sqlStr);

			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				DataTable dt = ds.Tables[0];
				AutoCompleteStringCollection tabStrs = new AutoCompleteStringCollection();
				foreach (DataRow row in dt.Rows)
				{
					try
					{
						tabStrs.Add(row[0].ToString());
					}
					catch { }
				}
				txtTableName.AutoCompleteCustomSource = tabStrs;
			}

			/// 
			/// SP auto complete
			/// 

			sqlStr = "SELECT ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE='PROCEDURE' ORDER BY ROUTINE_NAME";
			ds = FillDataSet(sqlStr);

			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				DataTable dt = ds.Tables[0];
				AutoCompleteStringCollection tabStrsSp = new AutoCompleteStringCollection();
				foreach (DataRow row in dt.Rows)
				{
					try
					{
						tabStrsSp.Add(row[0].ToString());
					}
					catch { }
				}
				m_textBox_SpSearch.AutoCompleteCustomSource = tabStrsSp;
			}
		}

		public DataSet FillDataSet(string sqlCmdStr)
		{
			try
			{
				if (ConnectionFactory.OpenConnection())
				{
					SqlCommand com = new SqlCommand(sqlCmdStr, ConnectionFactory.Instance);
					if (sqlCmdStr.IndexOf("@TABSEARCH") > -1)
					{
						com.Parameters.Add("@TABSEARCH", SqlDbType.NVarChar);
						com.Parameters["@TABSEARCH"].Value = TableName;
					}
					using (SqlDataAdapter adapter = new SqlDataAdapter(com))
					{
						DataSet ds = new DataSet();
						adapter.Fill(ds);
						return ds;
					}
				}
			}
			finally
			{
				ConnectionFactory.CloseConnection();
			}
			return null;
		}
		

		private void ButtonGetAllRows_Click(object sender, EventArgs e)
		{
			if(TableName == "") return;
			CreateTabPageWithValues(TableName,null);
		}

		private void ButtonTableDefinition_Click(object sender, EventArgs e)
		{
			if (TableName == "") return;
			CreateTabPageWithDefinition(TableName,null);
		}

		public UserControlAllTableInfo GetSelectedAllTableInfo()
		{
			try
			{
				TabPage tp = tabControl_TableInfo.SelectedTab;
				return ((UserControlAllTableInfo)tp.Controls[0]);
			}
			catch { }
			return null;			
		}

		public void CreateSpTabPage(string spName)
		{
			CreateSpTabPage( spName, null);
		}

		public void CreateSpTabPage(string spName, UserControlSpInfo spInfo)
		{
			if(spName == "") return;

			m_textBox_SpSearch.Enabled = false;

			if (tabControl_TableInfo.TabPages.ContainsKey(spName))
			{
				tabControl_TableInfo.SelectedTab = tabControl_TableInfo.TabPages[spName];
			}
			else
			{
				if (spInfo == null)
				{
					spInfo = new UserControlSpInfo {SpName = spName};
					spInfo.InitControl();
				}
				spInfo.Dock = DockStyle.Fill;

				spInfo.OpenSpTab += OpenSpTab;
				spInfo.OpenTableTab += OpenTableTab;
				spInfo.CloseTabPage += CloseTabPage;

				tabControl_TableInfo.TabPages.Add(spName, spName);
				tabControl_TableInfo.TabPages[spName].Controls.Add(spInfo);
				tabControl_TableInfo.SelectedTab = tabControl_TableInfo.TabPages[spName];

				m_userControlHistoryList_Sp.AddValue(spName);

			}
			m_textBox_SpSearch.Enabled = true;
		}

		void OpenTableFilteredTab(object sender, string tableName, bool isDefinitionShown,TableFilterData cellInfo)
		{
			if (tableName == null) return;

			tableName = tableName.Replace("dbo.", "");
			if (isDefinitionShown)
			{
				CreateTabPageWithDefinition(tableName, cellInfo);
			}
			else
			{
				CreateTabPageWithValues(tableName, cellInfo);
			}
		}

		void OpenTableTab(object sender, string tableName, bool isDefinitionShown)
		{
			if (tableName == null) return;

			tableName = tableName.Replace("dbo.", "");
			if (isDefinitionShown)
			{
				CreateTabPageWithDefinition(tableName,null);
			}
			else
			{
				CreateTabPageWithValues(tableName,null);
			}
		}

		void OpenSpTab(object sender, string spName)
		{
			CreateSpTabPage(spName.Replace("dbo.", ""));
		}


		public UserControlAllTableInfo GetAllTableInfoByTableName(string tableName)
		{
			try
			{
				TabPage tp = GetTabPage(tableName,null);
				tabControl_TableInfo.SelectedTab = tp;
				return ((UserControlAllTableInfo)tp.Controls[0]);
			}
			catch { }
			return null;
		}

		public TabPage GetTabPage(string tableName, TableFilterData filter)
		{
			CreateTabPage(tableName, filter);
			return tabControl_TableInfo.SelectedTab;			
		}

		public void CreateTabPage(string tableName, TableFilterData filter)
		{
			if (tabControl_TableInfo.TabPages.ContainsKey(tableName))
			{
				tabControl_TableInfo.SelectedTab = tabControl_TableInfo.TabPages[tableName];
				try
				{
					if (filter == null || ((tabControl_TableInfo.SelectedTab.Controls[0] is UserControlAllTableInfo) == false)) 
						return;
			
					UserControlAllTableInfo allInfo = tabControl_TableInfo.SelectedTab.Controls[0] as UserControlAllTableInfo;
					if (allInfo != null) allInfo.SetFilter(filter);
				}
				catch { }
			}
			else
			{
				UserControlAllTableInfo allInfo = new UserControlAllTableInfo {Dock = DockStyle.Fill};
				allInfo.CloseTabPage += CloseTabPage;
				allInfo.OpenSpTab += OpenSpTab;
				allInfo.OpenTableTab += OpenTableTab;
				allInfo.OpenTableFilteredTab += OpenTableFilteredTab;
				allInfo.SetFilter(filter);

				tabControl_TableInfo.TabPages.Add(tableName, tableName);
				tabControl_TableInfo.TabPages[tableName].Controls.Add(allInfo);
				tabControl_TableInfo.SelectedTab = tabControl_TableInfo.TabPages[tableName];
			}
		}

		public void CreateTabPageWithValues(string tableName, TableFilterData filter)
		{
			try
			{
				TabPage tp = GetTabPage(tableName, filter);
				tabControl_TableInfo.SelectedTab = tp;
				((UserControlAllTableInfo)tp.Controls[0]).InitControl(tableName, false, this);
				m_userControlHistoryList_Tables.AddValue(tableName );
			}
			catch { }
		}

		public void CreateTabPageWithDefinition(string tableName, TableFilterData filter)
		{
			try
			{
				TabPage tp = GetTabPage(tableName, filter);
				tabControl_TableInfo.SelectedTab = tp;
				((UserControlAllTableInfo)tp.Controls[0]).InitControl(tableName, true, this);
				m_userControlHistoryList_Tables.AddValue(tableName);
			}
			catch { }
		}


		void CloseTabPage(string tabPageKey)
		{
			if(tabControl_TableInfo.TabPages.ContainsKey(tabPageKey))
				tabControl_TableInfo.TabPages.RemoveByKey(tabPageKey);			
		}

		#region TabControl ContexMenu Actions
		private void closeAllTabsButThisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (TabPage item in tabControl_TableInfo.TabPages)
			{
				if (item != tabControl_TableInfo.SelectedTab)
				{
					tabControl_TableInfo.TabPages.Remove(item);
				}
			}
		}

		private void closeAllTabsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl_TableInfo.TabPages.Clear();
		}

		private void closeActiveTabToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl_TableInfo.TabPages.Remove(tabControl_TableInfo.SelectedTab);
		}
		#endregion

		private void ColumnDependencies_FormClosed(object sender, FormClosedEventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		private void ColumnDependencies_KeyPress(object sender, KeyPressEventArgs e)
		{
			Console.WriteLine(e.KeyChar);
		}
		

		private void Button_SPDef_Click(object sender, EventArgs e)
		{
			CreateSpTabPage(m_textBox_SpSearch.Text.Trim());
		}

		private void m_userControlHistoryList_Tables_SelectedIndexChanged(object sender, string value)
		{
			txtTableName.Text = value.Trim();
		}

		private void m_userControlHistoryList_Sp_SelectedIndexChanged(object sender, string value)
		{
			m_textBox_SpSearch.Text = value.Trim().Replace("dba.", "");
		}

		#region Status

		public string StatusInfo1 { 
			get { return m_toolStripStatusLabel_First.Text;}
			set
			{
				m_toolStripStatusLabel_First.Text = value;
				Application.DoEvents();
			}
		}

		public string StatusInfo2
		{
			get { return m_toolStripStatusLabel_Second.Text; }
			set
			{
				m_toolStripStatusLabel_Second.Text = value;
				Application.DoEvents();
			}
		}
		#endregion
		protected override bool ProcessDialogKey(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.F5:
					m_tabControl_Search.SelectedTab = m_tabPage_TabSearch;
					ButtonTableDefinition_Click(button_TabDef, EventArgs.Empty);
					break;
				case Keys.F6:
					m_tabControl_Search.SelectedTab = m_tabPage_SpSearch;
					Button_SPDef_Click(m_button_SpDef, EventArgs.Empty);
					break;
				case Keys.F9:
					m_UserControlConnection.Focus();
					break;
			}

			return base.ProcessDialogKey(keyData);
		}


		private void TextBoxTableName_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Shift) return;
			if (e.KeyValue == 13  /* Keys.Return ||  Keys.Enter*/ )
			{
				txtTableName.Enabled = false;
				button_TabDef.Enabled = false;
				button_GetAllRows.Enabled = false;
				if (TableExists(TableName))
				{
					if (e.Control)
					{
						m_tabControl_Search.SelectedTab = m_tabPage_TabSearch;
						CreateTabPageWithValues(TableName,null);
					}
					else
					{
						m_tabControl_Search.SelectedTab = m_tabPage_TabSearch;
						CreateTabPageWithDefinition(TableName,null);
					}
				}
				txtTableName.Enabled = true;
				button_TabDef.Enabled = true;
				button_GetAllRows.Enabled = true;
				txtTableName.Focus();
			}
		}

		private void TextBoxSpSearch_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Shift) return;
			if (e.KeyValue == 13  /* Keys.Return ||  Keys.Enter*/ )
			{
				if (StoredProcedureExists(TableName))
				{
					CreateSpTabPage(m_textBox_SpSearch.Text.Trim());
					m_textBox_SpSearch.Focus();
				}
			}
		}

		internal void SetTitle()
		{
			if (ConnectionFactory.Instance == null)
			{
				Text = " DB Info ";
			}
			else
			{
				Text = " DB Info  -   " + ConnectionFactory.ShortConnectionName;
			}
		}
	}
}
