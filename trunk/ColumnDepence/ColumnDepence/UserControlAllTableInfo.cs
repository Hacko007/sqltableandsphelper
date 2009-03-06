using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Permissions;

namespace ColumnDepence
{
	
	public partial class UserControlAllTableInfo : UserControl
	{

		public event TabPageDelegate CloseTabPage;
		public event OpenTableDelegate OpenTableTab;
		public event OpenSPDelegate OpenSpTab;

		private ColumnDependencies m_parentForm;
		string m_TableName = "";
		Form toolbox = null;
		
		
		public UserControlAllTableInfo()
		{
			InitializeComponent();
			m_userControlValues.ShownColumnsChanged += new EventHandler(UserControlValues_ShownColumnsChanged);
		}

		void UserControlValues_ShownColumnsChanged(object sender, EventArgs e)
		{
			FillDataGridValues(m_userControlValues.ValuesDataGrid);
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
			this.FillDataGridColumnConstrains();
			Application.DoEvents();
			this.FillDataGridParentTables();
			Application.DoEvents();
			this.FillDataGridChildTables();
			Application.DoEvents();
			FillSPDependecies();
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
			Cursor.Current = Cursors.Default;
		}

		private void dataGridView_Columns_SelectionChanged(object sender, EventArgs e)
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

			style.Font = new Font(FontFamily.GenericMonospace, 12);
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

			DataSet ds = FillDataSet(sql_cmd);

			if (ds != null && ds.Tables.Count > 0)
			{
				dataGrid.DataSource = ds.Tables[0];
				if (selected_columns == "*") m_userControlValues.AllColumns = new List<string>();
				for (int i = 0; i < dataGrid.Columns.Count; i++)
				{
					dataGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
					if (selected_columns == "*") m_userControlValues.AllColumns.Add(dataGrid.Columns[i].Name);
				}
				if (selected_columns == "*")
				{
					m_userControlValues.ShownColumns = new List<string>();
					m_userControlValues.ShownColumns.AddRange( m_userControlValues.AllColumns);
				}
				m_userControlValues.ApplyFilter();
				m_userControlValues.UpdateShownColumnsContextMenu();
			}
			//try
			//{
				
			//    Application.DoEvents();
			//    /// Get permission to SqlDependency
			//    SqlClientPermission perm = new SqlClientPermission(PermissionState.Unrestricted);
			//    perm.Demand();

			//    SqlDependency.Stop(ConnectionFactory.ConnectionString);
			//    SqlDependency.Start(ConnectionFactory.ConnectionString);

			//    if (enableSqlDependency && !sqlDependencyActive)
			//        AddSqlDependency(sql_cmd);
			//}
			//catch{ 
			//    //(Exception dep){
			//    //MessageBox.Show(dep.ToString());
			//}
		}

		void FillDataGridColumnConstrains()
		{
			string sql_str = "select CN.COLUMN_NAME As [Column] ,TB.CONSTRAINT_NAME as [Constraint] , TB.CONSTRAINT_TYPE as [Type]"
	+ "from  INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE CN inner join "
	+ " INFORMATION_SCHEMA.TABLE_CONSTRAINTS TB on (CN.TABLE_NAME = TB.TABLE_NAME AND CN.CONSTRAINT_NAME = TB.CONSTRAINT_NAME) "
	+ "WHERE  CN.TABLE_NAME = '" + this.TableName + "'  ";

			if (dataGridView_Columns.SelectedRows.Count > 0)
			{
				string cols = "";
				foreach (DataGridViewRow row in dataGridView_Columns.SelectedRows)
				{
					if (cols != "") cols += " OR ";

					string col_name = row.Cells[0].Value.ToString();
					cols += " CN.COLUMN_NAME = '" + col_name + "' ";
				}
				sql_str += " AND ( " + cols + " ) ";

			}

			DataSet ds = FillDataSet(sql_str);

			if (ds != null && ds.Tables.Count > 0)
			{
				dataGridView_ColumnConstrains.DataSource = ds.Tables[0];
				dataGridView_ColumnConstrains.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				dataGridView_ColumnConstrains.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dataGridView_ColumnConstrains.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
		}

		void FillDataGridParentTables()
		{
			string sql_str = " SELECT COL2.name AS Parent ,    tb.name + ' . ' + COL1.name AS Referenced_Column " //tb2.name AS RefTab, 
				+ @"FROM         sys.columns AS COL1 INNER JOIN
                      sys.columns AS COL2 INNER JOIN
                      sys.tables AS tb2 INNER JOIN
                      sys.foreign_key_columns AS FK INNER JOIN
                      sys.tables AS tb ON FK.parent_object_id = tb.object_id ON tb2.object_id = FK.referenced_object_id ON COL2.column_id = FK.referenced_column_id AND
                       COL2.object_id = FK.referenced_object_id ON COL1.column_id = FK.parent_column_id AND COL1.object_id = FK.parent_object_id "
				+ " WHERE tb2.name = @TABSEARCH ";

			List<string> sel_columns = this.GetSelectedColumnNames();
			string cols_sql = "";
			foreach (string column in sel_columns)
			{
				if (cols_sql != "") cols_sql += " OR ";
				cols_sql += " COL2.name = '" + column + "' ";
			}
			if (cols_sql != "")
			{
				sql_str += " AND (" + cols_sql + ") ";
			}
			DataSet ds = this.FillDataSet(sql_str);
			if (ds != null && ds.Tables.Count > 0)
			{
				dataGridView_Parent.DataSource = ds.Tables[0];
				dataGridView_Parent.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				dataGridView_Parent.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dataGridView_Parent.Columns[1].ContextMenuStrip = m_contextMenuStrip_ShowTable;
			}
		}

		void FillDataGridChildTables()
		{
			string sql_str = " SELECT    COL1.name AS Parent_Column, tb2.name +' . '+ COL2.name AS Referenced_Colomn " // 
				+ @"FROM         sys.columns AS COL1 INNER JOIN
                      sys.columns AS COL2 INNER JOIN
                      sys.tables AS tb2 INNER JOIN
                      sys.foreign_key_columns AS FK INNER JOIN
                      sys.tables AS tb ON FK.parent_object_id = tb.object_id ON tb2.object_id = FK.referenced_object_id ON COL2.column_id = FK.referenced_column_id AND
                       COL2.object_id = FK.referenced_object_id ON COL1.column_id = FK.parent_column_id AND COL1.object_id = FK.parent_object_id "
				+ " WHERE tb.name = @TABSEARCH ";

			List<string> sel_columns = this.GetSelectedColumnNames();
			string cols_sql = "";
			foreach (string column in sel_columns)
			{
				if (cols_sql != "") cols_sql += " OR ";
				cols_sql += " COL1.name = '" + column + "' ";
			}
			if (cols_sql != "")
			{
				sql_str += " AND (" + cols_sql + ") ";
			}
			DataSet ds = this.FillDataSet(sql_str);

			if (ds != null && ds.Tables.Count > 0)
			{
				dataGridView_Child.DataSource = ds.Tables[0];
				dataGridView_Child.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				dataGridView_Child.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

				dataGridView_Child.Columns[1].ContextMenuStrip = m_contextMenuStrip_ShowTable;
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
				ConnectionFactory.Instance.Close();
			}



		}


		DataSet FillDataSet(string sql_cmd_str)
		{
			try
			{
				if (this.Connection.State != ConnectionState.Open)
				{
					this.Connection.Open();
				}

				SqlCommand com = new SqlCommand(sql_cmd_str, this.Connection);
				if (sql_cmd_str.IndexOf("@TABSEARCH") > -1)
				{
					com.Parameters.Add("@TABSEARCH", SqlDbType.NVarChar);
					com.Parameters["@TABSEARCH"].Value = this.TableName;
				}
				using (SqlDataAdapter adapter = new SqlDataAdapter(com))
				{
					DataSet ds = new DataSet();
					adapter.Fill(ds);
					return ds;
				}

			}
			finally
			{
				this.Connection.Close();
			}
		}

		void ShowTableValues_Click(object sender, EventArgs e) {
			try
			{
				ToolStripItem itm = (System.Windows.Forms.ToolStripItem)sender;
				ContextMenuStrip tool = (ContextMenuStrip)itm.GetCurrentParent();
				Control c = tool.SourceControl;
				DataGridViewRow row = (((System.Windows.Forms.DataGridView)(c))).CurrentRow;
				string table = GetTableNameFromColumnValue(row.Cells[1].Value.ToString());
				m_parentForm.CreateTabPageWithValues(table);
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
				m_parentForm.CreateTabPageWithDefinition(table);
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
				this.toolStripButton_CloseTab.Visible = false;
				this.toolStripButton_ToolBox.Text = "Show as tab page";
				this.Dock = DockStyle.Fill;
				toolbox.Controls.Add(this);
				toolbox.FormBorderStyle = FormBorderStyle.SizableToolWindow;
				toolbox.Size = new Size(800, 600);
				toolbox.Show();
				this.RaiseCloseTabPage();
				
			}
			else
			{
				toolbox.Close();
				this.toolStripButton_ToolBox.Text = "Show as tool box";
				this.toolStripButton_CloseTab.Visible = true;
				
				TabPage tp = m_parentForm.GetTabPage(this.TableName);
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


		
		#region TODO: SqlDependency 
		bool enableSqlDependency = true;
		bool sqlDependencyActive = false;
		SqlCommand dependency_command = null;

		private void AddSqlDependency(string sql_cmd)
		{
			try
			{
				
				if (dependency_command == null)
				{
					dependency_command = new SqlCommand(sql_cmd, ConnectionFactory.Instance);
				}
				else
				{
					dependency_command.CommandText = sql_cmd ;
				}

				// Make sure the command object does not already have
				// a notification object associated with it.
				dependency_command.Notification = null;

				// Create and bind the SqlDependency object
				// to the command object.
				SqlDependency dependency = new SqlDependency(dependency_command);
				dependency.OnChange += new OnChangeEventHandler(SqlDependency_OnChange);				
			}
			catch (Exception exc)
			{
				sqlDependencyActive = false;
				MessageBox.Show(exc.ToString());
			}
			sqlDependencyActive = true;
		}

		private void SqlDependency_OnChange(object sender, SqlNotificationEventArgs e)
		{
			// This event will occur on a thread pool thread.
			// Updating the UI from a worker thread is not permitted.
			// The following code checks to see if it is safe to
			// update the UI.
			ISynchronizeInvoke i = (ISynchronizeInvoke)this;

			// If InvokeRequired returns True, the code
			// is executing on a worker thread.
			if (i.InvokeRequired)
			{
				// Create a delegate to perform the thread switch.
				OnChangeEventHandler tempDelegate = new OnChangeEventHandler(SqlDependency_OnChange);

				object[] args = { sender, e };

				// Marshal the data from the worker thread
				// to the UI thread.
				i.BeginInvoke(tempDelegate, args);

				return;
			}
			// Remove the handler, since it is only good
			// for a single notification.
			SqlDependency dependency =	(SqlDependency)sender;

			dependency.OnChange -= SqlDependency_OnChange;
			
			// Reload the dataset that is bound to the grid.
			FillDataGridValues(m_userControlValues.ValuesDataGrid);
		}
		#endregion SqlDependency

		private void m_toolStripMenuItem_ShowDefinition_Click(object sender, EventArgs e)
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
	}
}
