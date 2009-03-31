using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Permissions;
using ColumnDepence.DbInfo;

namespace ColumnDepence
{
	
	public partial class UserControlAllTableInfo : UserControl
	{

		public event TabPageDelegate CloseTabPage;
		public event OpenTableDelegate OpenTableTab;
		public event OpenTableFilteredDelegate OpenTableFilteredTab;
		public event OpenSPDelegate OpenSpTab;

		private ColumnDependencies m_parentForm;
		string m_TableName = "";
		Form toolbox = null;		
		
		public UserControlAllTableInfo()
		{
			InitializeComponent();
			m_userControlValues.ShownColumnsChanged += new EventHandler(UserControlValues_ShownColumnsChanged);
			m_userControlValues.OpenTableFilteredTab += new OpenTableFilteredDelegate(UserControlValues_OpenTableFilteredTab);
			TableInfo = new TableInfo();
		}


		public TableInfo TableInfo { get; set; }


		public void SetFilter(TableFilterData cellInfo) {
			m_userControlValues.SetFilter(cellInfo);
		}

		void UserControlValues_ShownColumnsChanged(object sender, EventArgs e)
		{
			FillDataGridValues(m_userControlValues.ValuesDataGrid);
		}

		void UserControlValues_OpenTableFilteredTab(object sender, string tableName, bool isDefinitionShown, TableFilterData cellInfo)
		{
			if (OpenTableFilteredTab != null) {
				OpenTableFilteredTab(sender, tableName, isDefinitionShown, cellInfo);
			}
		}

		public void InitControl(string tableName, bool showAllData ,ColumnDependencies parentForm) {
			this.ShowAllTableInfo = showAllData;
			this.Connection = ConnectionFactory.Instance;
			this.TableName = tableName;
			this.m_parentForm = parentForm;

			SetToolStripLabel();

			if (showAllData)
			{
				UpdateAllInfo();
			}
			else
			{
				UpdateValuesOnly(false);
			}
		}

		private void SetToolStripLabel()
		{
			this.toolStripLabel_DB.Text = ConnectionFactory.Instance.DataSource + " ." + ConnectionFactory.Instance.Database + " . ";
			this.toolStripLabel_TableName.Text = this.TableName;
		}

		
		public void UpdateAllInfo()
		{
			SetToolStripLabel();
			Cursor.Current = Cursors.WaitCursor;
			ColumnDependencies.FormMain.StatusInfo1 = "Loading table definition ...";
			ColumnDependencies.FormMain.StatusInfo2 = this.TableName;

			this.panel_DataView.Controls.Clear();
			this.panel_DataView.Controls.Add(this.splitContainer_Main);
			Application.DoEvents();
			this.FillColumnDataGrid();
			Application.DoEvents();
			this.splitContainer_left.Panel2.Controls.Clear();
			this.m_userControlValues.Dock = DockStyle.Fill;
			this.splitContainer_left.Panel2.Controls.Add(this.m_userControlValues);
			this.m_userControlValues.TableCount = this.GetTableCountStr();
			Application.DoEvents();
			this.FillDataGridValues(this.m_userControlValues.ValuesDataGrid);
			Application.DoEvents();			

			TableInfo.LoadTableInfo(TableName);
			RefreshDataGrids();
			Application.DoEvents();
			FillSPDependecies();
			this.m_userControlValues.TableInfo = this.TableInfo;
			Application.DoEvents();
			this.InitDataGridsStyle();
			Cursor.Current = Cursors.Default;

			ColumnDependencies.FormMain.StatusInfo1 = this.TableName + " definition loaded";
			
			/// 
			/// Fix splitcontaner size for empty datagrids
			/// 

			int empty_space = 15;

			/// Left slit container
			splitContainer_left.SplitterDistance -= FreeSpace(dataGridView_Columns) - empty_space;
			if(m_userControlValues.ValuesDataGrid.Rows.Count == 0)
				splitContainer_left.SplitterDistance = Math.Min(splitContainer_left.Height - 80, splitContainer_left.SplitterDistance);
			else
				splitContainer_left.SplitterDistance = Math.Min(splitContainer_left.Height - 150, splitContainer_left.SplitterDistance);

			/// Right split containeer
			
			int sz_sum = FreeSpace(dataGridView_Child) 
				+ FreeSpace(dataGridView_ColumnConstrains)
				+ FreeSpace(dataGridView_Parent) 
				+ FreeSpace(dataGridView_Sp);

			if (splitContainer_right.Height + sz_sum > 0)
			{
				splitContainer_right.SplitterDistance -= FreeSpace(dataGridView_ColumnConstrains) - empty_space;
				splitContainer_RightBottom.SplitterDistance -= FreeSpace(dataGridView_Parent) - empty_space;
				splitContainer_LeftSpButtom.SplitterDistance -= FreeSpace(dataGridView_Child) - empty_space;
			}
			else 			
			{
				if (FreeSpace(dataGridView_ColumnConstrains) > 0) splitContainer_right.SplitterDistance -= FreeSpace(dataGridView_ColumnConstrains) - empty_space;
				if (FreeSpace(dataGridView_Parent) > 0) splitContainer_RightBottom.SplitterDistance -= FreeSpace(dataGridView_Parent) - empty_space;
				if (FreeSpace(dataGridView_Child) > 0) splitContainer_LeftSpButtom.SplitterDistance -= FreeSpace(dataGridView_Child) - empty_space;			
			}							
		}


		public void UpdateValuesOnly()
		{
			ColumnDependencies.FormMain.StatusInfo1 = "Loading table values ...";
			ColumnDependencies.FormMain.StatusInfo2 = this.TableName;

			SetToolStripLabel();
			Application.DoEvents();
			UpdateValuesOnly(get_all_rows);

			ColumnDependencies.FormMain.StatusInfo1 = this.TableName + " data loaded.";
			

		} 
		
		bool get_all_rows = false;
		private void UpdateValuesOnly(bool get_all_rows)
		{
			Cursor.Current = Cursors.WaitCursor;

			this.panel_DataView.Controls.Clear();

			this.m_userControlValues.Dock = DockStyle.Fill;
			this.panel_DataView.Controls.Add(this.m_userControlValues);

			this.get_all_rows = get_all_rows;

			m_userControlValues.TableCount = this.GetTableCountStr();
			Application.DoEvents();

			this.FillDataGridValues(this.m_userControlValues.ValuesDataGrid);
			this.m_userControlValues.UserDeletingRow -= new DataGridViewRowCancelEventHandler(this.dataGridView_Value_UserDeletingRow);
			this.m_userControlValues.UserDeletingRow += new DataGridViewRowCancelEventHandler(this.dataGridView_Value_UserDeletingRow);
			this.m_userControlValues.TableInfo = this.TableInfo;
			Application.DoEvents();
			Cursor.Current = Cursors.Default;

			TableInfo.LoadTableInfo(TableName);

		}

		private void DataGridViewColumns_SelectionChanged(object sender, EventArgs e)
		{
			RefreshDataGrids();
		}

		private void RefreshDataGrids()
		{
			this.FillDataGridColumnConstrains();
			this.FillDataGridParentTables();
			this.FillDataGridChildTables();
		}

		
		protected virtual void RaiseCloseTabPage()
		{
			if (CloseTabPage != null)
			{
				CloseTabPage(this.TableName);
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
				OpenSpTab(this,spName);
			}
		}


		public string TableName
		{
			get { return m_TableName; }
			set { m_TableName = value; }
		}
		
		public SqlConnection Connection { get; set; }
		public bool ShowAllTableInfo { get; set; }




		void SetCellStyle(DataGridView dg, DataGridViewCellStyle style)
		{
			for (int i = 0; i < dg.Columns.Count; i++)
			{
				dg.Columns[i].DefaultCellStyle = style;
			}
		}

		private void InitDataGridsStyle()
		{
			DataGridViewCellStyle style = new DataGridViewCellStyle();

			style.Font = new Font(FontFamily.GenericMonospace, 10);
			SetCellStyle(dataGridView_Columns, style);

			style = new DataGridViewCellStyle();
			style.Font = new Font(FontFamily.GenericMonospace, 10);
			SetCellStyle(dataGridView_Child, style);
			SetCellStyle(dataGridView_ColumnConstrains, style);
			SetCellStyle(dataGridView_Parent, style);
			SetCellStyle(m_userControlValues.ValuesDataGrid, style);
		}



		void FillColumnDataGrid()
		{

			string sql_cmd = @"SELECT  COLUMN_NAME As Name , DATA_TYPE As [Type],"
				+ "CASE IS_NULLABLE  WHEN 'NO' THEN cast(0 as Bit)  ELSE cast (1 as BIT) END as Nullable,"
				+ " CHARACTER_MAXIMUM_LENGTH As [Max] , COLUMN_DEFAULT AS [Default] "
				+ "FROM   INFORMATION_SCHEMA.COLUMNS WHERE  (TABLE_NAME = @TABSEARCH) ORDER BY ORDINAL_POSITION";
			DataSet ds = FillDataSet(sql_cmd);

			if (ds != null && ds.Tables.Count > 0)
			{
				dataGridView_Columns.DataSource = ds.Tables[0];
				dataGridView_Columns.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dataGridView_Columns.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				for (int i = 1; i < dataGridView_Columns.Columns.Count; i++)
				{
					dataGridView_Columns.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				}
				dataGridView_Columns.SelectAll();
			}
		}

		string GetTableCountStr() {
			string sql_cmd =  @"SELECT  count(*) FROM  " + this.TableName;
			try
			{
				if (this.Connection.State != ConnectionState.Open)
				{
					this.Connection.Open();
				}

				SqlCommand com = new SqlCommand(sql_cmd, this.Connection);
				int count = (int)com.ExecuteScalar();				
				return count + " rows";
			}
			catch {
				return "";
			}
			finally
			{
				this.Connection.Close();
			}
		}
		/// <summary>
		/// TODO: add SqlDependency to this queuery  
		/// <see cref="http://msdn.microsoft.com/en-us/library/a52dhwx7.aspx"/>
		/// </summary>
		/// <param name="dataGrid"></param>
		void FillDataGridValues(DataGridView dataGrid)
		{
			string selected_columns = m_userControlValues.GetColumnSelect() ;
			string rowFilter = m_userControlValues.GetFilter();
			if (selected_columns == null) return;

			string sql_cmd = (this.get_all_rows)
				? "SELECT  "+ selected_columns +" FROM  " + this.TableName
				: "SELECT  TOP 300 " + selected_columns + " FROM  " + this.TableName;			

			if (rowFilter != "") {
				sql_cmd += " WHERE " + rowFilter;
			}

			TableInfo.Values = new DataTable(TableName);
			TableInfo.Values = TableInfo.FillDataTable(TableName,sql_cmd, TableInfo.Values);

			//DataSet ds = FillDataSet(sql_cmd);
			if (TableInfo.Values != null)
			{
				dataGrid.DataSource = TableInfo.Values;
				if (selected_columns == "*") m_userControlValues.AllColumns = new List<string>();
				for (int i = 0; i < dataGrid.Columns.Count; i++)
				{
					dataGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
					if (selected_columns == "*") m_userControlValues.AllColumns.Add(dataGrid.Columns[i].Name);
				}
				if (selected_columns == "*")
				{
					m_userControlValues.ShownColumns = new List<string>();
					m_userControlValues.ShownColumns.AddRange(m_userControlValues.AllColumns);
				}
				m_userControlValues.ApplyFilter();
				m_userControlValues.UpdateShownColumnsContextMenu();
			}		
		}

		void FillDataGridColumnConstrains()
		{			
			DataView dataView = new DataView(TableInfo.ColumnConstrains);
			dataView.RowFilter = GetDataViewFilter(TableInfo.ColumnConstrains.ColumnColumnName.ColumnName);

			if (TableInfo.ColumnConstrains == null || TableInfo.ColumnConstrains.Rows.Count == 0)
			{
				dataGridView_ColumnConstrains.DataSource = null;
			}
			else
			{
				dataGridView_ColumnConstrains.DataSource = dataView;
				dataGridView_ColumnConstrains.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				dataGridView_ColumnConstrains.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dataGridView_ColumnConstrains.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
		}

		void FillDataGridParentTables()
		{
			DataView dataView = new DataView(TableInfo.ParentReferencedTable);
			dataView.RowFilter = GetDataViewFilter(TableInfo.ParentReferencedTable.ColumnParentColumnName.ColumnName);

			if (TableInfo.ParentReferencedTable == null || TableInfo.ParentReferencedTable.Rows.Count == 0)
			{
				dataGridView_Parent.DataSource = null;
			}
			else
			{
				dataGridView_Parent.DataSource = dataView;
				TableInfo.ParentReferencedTable.SetColumns(dataGridView_Parent);
				dataGridView_Parent.Columns[0].ContextMenuStrip = m_contextMenuStrip_ShowTable;
			}
		}

		void FillDataGridChildTables()
		{

			DataView dataView = new DataView(TableInfo.ChildReferencedTable);
			dataView.RowFilter = GetDataViewFilter(TableInfo.ChildReferencedTable.ColumnChildColumnName.ColumnName);

			if (TableInfo.ChildReferencedTable == null || TableInfo.ChildReferencedTable.Rows.Count == 0) 
			{
				dataGridView_Child.DataSource = null;
			}else
			{
				dataGridView_Child.DataSource = dataView;
				TableInfo.ChildReferencedTable.SetColumns(dataGridView_Child);
				dataGridView_Child.Columns[0].ContextMenuStrip = m_contextMenuStrip_ShowTable;
			}
		}

		/// <summary>
		/// Fill datagrid with inforamtion about SP's dependencies
		/// </summary>
		void FillSPDependecies()
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
				com.Parameters[0].Value = this.TableName;

				using (SqlDataAdapter adapter = new SqlDataAdapter(com))
				{
					DataSet ds = new DataSet();
					adapter.Fill(ds);


					if (ds != null && ds.Tables.Count > 0)
					{

						DataTable dt = ds.Tables[0];

						dt.Columns.Add("MyType", typeof(string), "IIF(type = 'stored procedure', 'SP' , 'TAB')");

						dataGridView_Sp.DataSource = dt;
						dataGridView_Sp.Columns["type"].Visible = false;
						dataGridView_Sp.Columns["MyType"].HeaderText = "Type";

						dataGridView_Sp.Columns["name"].HeaderText = "Dependent Object";
						dataGridView_Sp.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
						dataGridView_Sp.Columns["name"].ContextMenuStrip = m_ContextMenuStrip_ShowDefinition;

					}
				}

			}
			finally
			{
				ConnectionFactory.CloseConnection();
			}



		}
		//DataTable FillDataTable(string sql_cmd_str, DataTable dataTable)
		//{
		//    try
		//    {
		//        if (ConnectionFactory.Instance == null) return null;

		//        ConnectionFactory.OpenConnection();

		//        SqlCommand com = new SqlCommand(sql_cmd_str, ConnectionFactory.Instance);
		//        if (sql_cmd_str.IndexOf("@TABSEARCH") > -1)
		//        {
		//            com.Parameters.Add("@TABSEARCH", SqlDbType.NVarChar);
		//            com.Parameters["@TABSEARCH"].Value = this.TableName;
		//        }
		//        using (SqlDataAdapter adapter = new SqlDataAdapter(com))
		//        {

		//            if (dataTable == null)
		//            {
		//                dataTable = new DataTable();
		//            }
		//            adapter.Fill(dataTable);
		//            return dataTable;
		//        }
		//    }
		//    catch
		//    {
		//        return null;

		//    }
		//    finally
		//    {
		//        ConnectionFactory.CloseConnection();
		//    }
		//}

		
		DataSet FillDataSet(string sql_cmd_str, DataSet dataSet)
		{
			try
			{
				ConnectionFactory.OpenConnection();

				SqlCommand com = new SqlCommand(sql_cmd_str, ConnectionFactory.Instance);
				if (sql_cmd_str.IndexOf("@TABSEARCH") > -1)
				{
					com.Parameters.Add("@TABSEARCH", SqlDbType.NVarChar);
					com.Parameters["@TABSEARCH"].Value = this.TableName;
				}
				using (SqlDataAdapter adapter = new SqlDataAdapter(com))
				{					
					if (dataSet == null)
					{
						dataSet = new DataSet();
					}
					adapter.Fill(dataSet);
					return dataSet;
				}
			}catch{
				return null;
			}
			finally
			{
				ConnectionFactory.CloseConnection();
			}
		}


		DataSet FillDataSet(string sql_cmd_str)
		{
			return FillDataSet(sql_cmd_str ,null);
		}


		void ShowTableValues_Click(object sender, EventArgs e) {
			try
			{
				ToolStripItem itm = (System.Windows.Forms.ToolStripItem)sender;
				ContextMenuStrip tool = (ContextMenuStrip)itm.GetCurrentParent();
				Control c = tool.SourceControl;
				DataGridViewRow row = (((System.Windows.Forms.DataGridView)(c))).CurrentRow;
				string table = GetTableNameFromColumnValue(row.Cells[1].Value.ToString());
				m_parentForm.CreateTabPageWithValues(table,null);
			}
			catch { }
		}
		void ShowTableDefinition_Click(object sender, EventArgs e)
		{
			try
			{
				ToolStripItem itm = (System.Windows.Forms.ToolStripItem)sender;
				ContextMenuStrip tool = (ContextMenuStrip)itm.GetCurrentParent();
				Control c = tool.SourceControl;
				DataGridViewRow row = (((System.Windows.Forms.DataGridView)(c))).CurrentRow;
				string table = GetTableNameFromColumnValue(row.Cells[1].Value.ToString());
				m_parentForm.CreateTabPageWithDefinition(table,null);
			}
			catch { }
		}

		private void button_RefreshDef_Click(object sender, EventArgs e)
		{
			this.UpdateAllInfo();
		}
		private void button_RefreshValues_Click(object sender, EventArgs e)
		{
			this.UpdateValuesOnly(true);
		}
		private void button_CloseTab_Click(object sender, EventArgs e)
		{
			this.RaiseCloseTabPage();
		}
		private void toolStripButton_ToolBox_Click(object sender, EventArgs e)
		{
			if (toolbox == null)
			{
				toolbox = new Form();
				toolbox.Text = TableName;
				this.toolStripButton_CloseTab.Visible = false;
				this.toolStripButton_ToolBox.Text = "Show as tab page";
				this.Dock = DockStyle.Fill;
				toolbox.Controls.Add(this);
				toolbox.FormBorderStyle = FormBorderStyle.SizableToolWindow;
				toolbox.Size = new Size(800, 600);
				toolbox.Show();
				this.RaiseCloseTabPage();
				toolbox.Owner = m_parentForm;
			}
			else
			{
				toolbox.Close();
				//this.toolStripButton_ToolBox.Text = "Show as tool box";
				//this.toolStripButton_CloseTab.Visible = true;
				
				TabPage tp = m_parentForm.GetTabPage(this.TableName,null);
				((UserControlAllTableInfo)tp.Controls[0]).InitControl(this.TableName, this.ShowAllTableInfo, m_parentForm);
			}
		}
		private void toolStripSplitButton_LoadMain_Click(object sender, EventArgs e)
		{
			bool load_all = this.toolStripSplitButton_LoadMain.Text == this.loadAllValuesToolStripMenuItem.Text;
			this.UpdateValuesOnly(load_all);
		}
		private void loadTop300ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UpdateValuesOnly(false);
			this.toolStripSplitButton_LoadMain.Text = this.loadTop300ToolStripMenuItem.Text;
		}
		private void loadAllValuesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UpdateValuesOnly(true);
			this.toolStripSplitButton_LoadMain.Text = this.loadAllValuesToolStripMenuItem.Text;
		}
		private void dataGridView_Value_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			
			DeleteRowFromDB(e.Row);
		}

		
		public void DeleteRowFromDB(DataGridViewRow dataGridViewRow)
		{
			if (dataGridViewRow == null) return;

			SqlCommand del_cmd = new SqlCommand();
			del_cmd.Connection = this.Connection;
				
			try
			{
				/// 
				/// Create sql command text
				/// 
				string cmd_str = "DELETE FROM " + this.TableName + " WHERE ";
				

				foreach (DataGridViewCell cell in dataGridViewRow.Cells)
				{
					//cmd_str1 += string.Format(" [{0}]  ,", cell.OwningColumn.Name);
					if (cell.Value == null || cell.Value.ToString() == "")
					{
						cmd_str += string.Format(" [{0}] is null AND", cell.OwningColumn.Name);
					}
					else
					{
						if (cell.ValueType == typeof(string) && cell.Value.ToString().Length > 1000)
						{
							/// probobly nvarchar, do not check
						}
						else if (cell.ValueType == typeof(string) && cell.Value.ToString().Length > 300)
						{
							cmd_str += string.Format(" [{0}] LIKE @PARAM_{0}  AND", cell.OwningColumn.Name);
							del_cmd.Parameters.Add(new SqlParameter("@PARAM_" + cell.OwningColumn.Name, cell.Value));

						}
						else
						{
							cmd_str += string.Format(" [{0}] = @PARAM_{0}  AND", cell.OwningColumn.Name);
							del_cmd.Parameters.Add(new SqlParameter("@PARAM_" + cell.OwningColumn.Name, cell.Value));
						}
					}
				}
				cmd_str = cmd_str.Substring(0, cmd_str.Length - 4); /// remove last AND
				
				del_cmd.CommandText =  cmd_str;

				if (del_cmd.Connection.State != ConnectionState.Open)
				{
					del_cmd.Connection.Open();
				}

				del_cmd.ExecuteNonQuery();
			}
			catch (Exception exc) {
				MessageBox.Show(exc.ToString());
			}
			finally {
				del_cmd.Connection.Close();
			}
		}

		private List<string> GetSelectedColumnNames()
		{
			List<string> result = new List<string>();
			if (dataGridView_Columns.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in dataGridView_Columns.SelectedRows)
				{

					string col_name = row.Cells[0].Value.ToString();
					result.Add(col_name);
				}
			}
			return result;
		}

		private string GetDataViewFilter(string onColumn)
		{
			List<string> sel_columns = this.GetSelectedColumnNames();
			string dv_filter = "";

			foreach (string column in sel_columns)
			{
				if (dv_filter != "") dv_filter += " OR ";
				dv_filter += onColumn + " = '" + column + "' ";
			}
			return dv_filter;
		}

		private string GetTableNameFromColumnValue(string column_value) {
			if (column_value == null || column_value == "") return null;

			int ix = column_value.IndexOf('.');
			if (ix > 0) {
				return column_value.Substring(0, ix).Trim();
			}
			else
			{
				return null;
			}
		}		

		private void ToolStripMenuItem_ShowDefinition_Click(object sender, EventArgs e)
		{
			try
			{
				if (dataGridView_Sp.SelectedCells.Count > 0)
				{
					string val = dataGridView_Sp.SelectedCells[0].Value.ToString();
					bool is_sp = "SP" == dataGridView_Sp.SelectedCells[0].OwningRow.Cells["MyType"].Value.ToString();

					if (is_sp)
					{
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

		private int FreeSpace(DataGridView dg) {
			return (int) ( dg.Height -
				((dg.RowTemplate.Height * dg.RowCount)  + dg.ColumnHeadersHeight));
		}

		private void ToolStripLabelTableName_DoubleClick(object sender, EventArgs e)
		{
			Clipboard.SetText(toolStripLabel_TableName.Text);
		}
		
	}
}
