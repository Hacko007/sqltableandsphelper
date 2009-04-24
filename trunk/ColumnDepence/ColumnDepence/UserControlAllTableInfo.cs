using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ColumnDepence.DbInfo;

namespace ColumnDepence
{
	public partial class UserControlAllTableInfo : UserControl
	{
		public event TabPageDelegate CloseTabPage;
		public event OpenTableDelegate OpenTableTab;
		public event OpenTableFilteredDelegate OpenTableFilteredTab;
		public event OpenSpDelegate OpenSpTab;

		public UserControlAllTableInfo()
		{
			InitializeComponent();
			TableName = "";
			m_getAllRows = false;
			m_userControlValues.ShownColumnsChanged += UserControlValuesShownColumnsChanged;
			m_userControlValues.OpenTableFilteredTab += UserControlValuesOpenTableFilteredTab;
			TableInfo = new TableInfo();
		}


		public TableInfo TableInfo { get; set; }
		public string TableName { get; set; }
		public SqlConnection Connection { get; set; }
		public bool ShowAllTableInfo { get; set; }


		public void SetFilter(TableFilterData cellInfo)
		{
			m_userControlValues.SetFilter(cellInfo);
		}


		private void UserControlValuesShownColumnsChanged(object sender, EventArgs e)
		{
			FillDataGridValues(m_userControlValues.ValuesDataGrid);
		}

		private void UserControlValuesOpenTableFilteredTab(object sender, string tableName, bool isDefinitionShown,
		                                                   TableFilterData cellInfo)
		{
			if (OpenTableFilteredTab != null)
			{
				OpenTableFilteredTab(sender, tableName, isDefinitionShown, cellInfo);
			}
		}

		public void InitControl(string tableName, bool showAllData, ColumnDependencies parentForm)
		{
			ShowAllTableInfo = showAllData;
			Connection = ConnectionFactory.Instance;
			TableName = tableName;
			m_ParentForm = parentForm;

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
			m_ToolStripLabelDb.Text = ConnectionFactory.Instance.DataSource + " ." + ConnectionFactory.Instance.Database + " . ";
			m_ToolStripLabelTableName.Text = TableName;
		}


		public void UpdateAllInfo()
		{
			SetToolStripLabel();
			Cursor.Current = Cursors.WaitCursor;
			ColumnDependencies.FormMain.StatusInfo1 = "Loading table definition ...";
			ColumnDependencies.FormMain.StatusInfo2 = TableName;

			m_PanelDataView.Controls.Clear();
			m_PanelDataView.Controls.Add(m_SplitContainerMain);
			Application.DoEvents();
			FillColumnDataGrid();
			Application.DoEvents();
			m_SplitContainerLeft.Panel2.Controls.Clear();
			m_userControlValues.Dock = DockStyle.Fill;
			m_SplitContainerLeft.Panel2.Controls.Add(m_userControlValues);
			m_userControlValues.TableCount = GetTableCountStr();
			Application.DoEvents();
			FillDataGridValues(m_userControlValues.ValuesDataGrid);
			Application.DoEvents();

			TableInfo.LoadTableInfo(TableName);
			RefreshDataGrids();
			Application.DoEvents();
			FillSpDependecies();
			m_userControlValues.TableInfo = TableInfo;
			Application.DoEvents();
			Cursor.Current = Cursors.Default;

			ColumnDependencies.FormMain.StatusInfo1 = TableName + " definition loaded";
			try
			{
				/// 
				/// Fix splitcontaner size for empty datagrids
				/// 

				const int emptySpace = 15;

				/// Left slit container
				m_SplitContainerLeft.SplitterDistance -= FreeSpace(m_DataGridViewColumns) - emptySpace;
				if (m_userControlValues.ValuesDataGrid.Rows.Count == 0)
					m_SplitContainerLeft.SplitterDistance = Math.Min(m_SplitContainerLeft.Height - 80,
					                                                m_SplitContainerLeft.SplitterDistance);
				else
					m_SplitContainerLeft.SplitterDistance = Math.Min(m_SplitContainerLeft.Height - 250,
					                                                m_SplitContainerLeft.SplitterDistance);

				/// Right split containeer

				int szSum = FreeSpace(m_DataGridViewChild)
				            + FreeSpace(m_DataGridViewColumnConstrains)
				            + FreeSpace(m_DataGridViewParent)
				            + FreeSpace(m_DataGridViewSp);

				if (m_SplitContainerRight.Height + szSum > 0)
				{
					m_SplitContainerRight.SplitterDistance -= FreeSpace(m_DataGridViewColumnConstrains) - emptySpace;
					m_SplitContainerRightBottom.SplitterDistance -= FreeSpace(m_DataGridViewParent) - emptySpace;
					m_SplitContainerLeftSpButtom.SplitterDistance -= FreeSpace(m_DataGridViewChild) - emptySpace;
				}
				else
				{
					if (FreeSpace(m_DataGridViewColumnConstrains) > 0)
						m_SplitContainerRight.SplitterDistance -= FreeSpace(m_DataGridViewColumnConstrains) - emptySpace;
					if (FreeSpace(m_DataGridViewParent) > 0)
						m_SplitContainerRightBottom.SplitterDistance -= FreeSpace(m_DataGridViewParent) - emptySpace;
					if (FreeSpace(m_DataGridViewChild) > 0)
						m_SplitContainerLeftSpButtom.SplitterDistance -= FreeSpace(m_DataGridViewChild) - emptySpace;
				}
			}
			catch
			{
			}
		}


		public void UpdateValuesOnly()
		{
			ColumnDependencies.FormMain.StatusInfo1 = "Loading table values ...";
			ColumnDependencies.FormMain.StatusInfo2 = TableName;

			SetToolStripLabel();
			Application.DoEvents();
			UpdateValuesOnly(m_getAllRows);

			ColumnDependencies.FormMain.StatusInfo1 = TableName + " data loaded.";
		}

		private void UpdateValuesOnly(bool getAllRows)
		{
			Cursor.Current = Cursors.WaitCursor;

			m_PanelDataView.Controls.Clear();

			m_userControlValues.Dock = DockStyle.Fill;
			m_PanelDataView.Controls.Add(m_userControlValues);

			m_getAllRows = getAllRows;

			m_userControlValues.TableCount = GetTableCountStr();
			Application.DoEvents();

			FillDataGridValues(m_userControlValues.ValuesDataGrid);
			m_userControlValues.UserDeletingRow -= DataGridViewValueUserDeletingRow;
			m_userControlValues.UserDeletingRow += DataGridViewValueUserDeletingRow;
			m_userControlValues.TableInfo = TableInfo;
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
			FillDataGridColumnConstrains();
			FillDataGridParentTables();
			FillDataGridChildTables();
		}


		protected virtual void RaiseCloseTabPage()
		{
			if (CloseTabPage != null)
			{
				CloseTabPage(TableName);
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


		private void FillColumnDataGrid()
		{
			const string sqlCmd = @"SELECT  COLUMN_NAME As Name , DATA_TYPE As [Type],"
			                      + "CASE IS_NULLABLE  WHEN 'NO' THEN cast(0 as Bit)  ELSE cast (1 as BIT) END as Nullable,"
			                      + " CHARACTER_MAXIMUM_LENGTH As [Max] , COLUMN_DEFAULT AS [Default] "
			                      +
			                      "FROM   INFORMATION_SCHEMA.COLUMNS WHERE  (TABLE_NAME = @TABSEARCH) ORDER BY ORDINAL_POSITION";
			DataSet ds = FillDataSet(sqlCmd);

			if (ds != null && ds.Tables.Count > 0)
			{
				m_DataGridViewColumns.DataSource = ds.Tables[0];
				m_DataGridViewColumns.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				m_DataGridViewColumns.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				for (int i = 1; i < m_DataGridViewColumns.Columns.Count; i++)
				{
					m_DataGridViewColumns.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				}
				m_DataGridViewColumns.SelectAll();
			}
		}

		private string GetTableCountStr()
		{
			string sqlCmd = @"SELECT  count(*) FROM  " + TableName;
			try
			{
				if (Connection.State != ConnectionState.Open)
				{
					Connection.Open();
				}

				var com = new SqlCommand(sqlCmd, Connection);
				var count = (int) com.ExecuteScalar();
				return count + " rows";
			}
			catch
			{
				return "";
			}
			finally
			{
				Connection.Close();
			}
		}

		/// <summary>
		/// TODO: add SqlDependency to this queuery  
		/// <see cref="http://msdn.microsoft.com/en-us/library/a52dhwx7.aspx"/>
		/// </summary>
		/// <param name="dataGrid"></param>
		private void FillDataGridValues(DataGridView dataGrid)
		{
			string selectedColumns = m_userControlValues.GetColumnSelect();
			string rowFilter = m_userControlValues.GetFilter();
			if (selectedColumns == null) return;

			string sqlCmd = (m_getAllRows)
			                	? "SELECT  TOP 5000 " + selectedColumns + " FROM  " + TableName
			                	: "SELECT  TOP 300 " + selectedColumns + " FROM  " + TableName;

			if (rowFilter != "")
			{
				sqlCmd += " WHERE " + rowFilter;
			}

			TableInfo.Values = new DataTable(TableName);
			TableInfo.Values = TableInfo.FillDataTable(TableName, sqlCmd, TableInfo.Values);

			if (TableInfo.Values == null) return;

			dataGrid.DataSource = TableInfo.Values;
			if (selectedColumns == "*") m_userControlValues.AllColumns = new List<string>();
			for (int i = 0; i < dataGrid.Columns.Count; i++)
			{
				dataGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				if (selectedColumns == "*") m_userControlValues.AllColumns.Add(dataGrid.Columns[i].Name);
			}
			if (selectedColumns == "*")
			{
				m_userControlValues.ShownColumns = new List<string>();
				m_userControlValues.ShownColumns.AddRange(m_userControlValues.AllColumns);
			}
			m_userControlValues.ApplyFilter();
			m_userControlValues.UpdateShownColumnsContextMenu();
		}

		private void FillDataGridColumnConstrains()
		{
			var dataView = new DataView(TableInfo.ColumnConstrains)
			               	{
			               		RowFilter = GetDataViewFilter(TableInfo.ColumnConstrains.ColumnColumnName.ColumnName)
			               	};

			if (TableInfo.ColumnConstrains == null || TableInfo.ColumnConstrains.Rows.Count == 0)
			{
				m_DataGridViewColumnConstrains.DataSource = null;
			}
			else
			{
				m_DataGridViewColumnConstrains.DataSource = dataView;
				m_DataGridViewColumnConstrains.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				m_DataGridViewColumnConstrains.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				m_DataGridViewColumnConstrains.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
		}

		private void FillDataGridParentTables()
		{
			var dataView = new DataView(TableInfo.ChildTables)
			               	{
			               		RowFilter = GetDataViewFilter(TableInfo.ChildTables.ColumnParentColumnName.ColumnName)
			               	};

			if (TableInfo.ChildTables == null || TableInfo.ChildTables.Rows.Count == 0)
			{
				m_DataGridViewParent.DataSource = null;
			}
			else
			{
				m_DataGridViewParent.DataSource = dataView;
				TableInfo.ChildTables.SetColumns(m_DataGridViewParent);
				m_DataGridViewParent.Columns[0].ContextMenuStrip = m_ContextMenuStripShowTable;
			}
		}

		private void FillDataGridChildTables()
		{
			var dataView = new DataView(TableInfo.ParentTables)
			               	{
			               		RowFilter = GetDataViewFilter(TableInfo.ParentTables.ColumnChildColumnName.ColumnName)
			               	};

			if (TableInfo.ParentTables == null || TableInfo.ParentTables.Rows.Count == 0)
			{
				m_DataGridViewChild.DataSource = null;
			}
			else
			{
				m_DataGridViewChild.DataSource = dataView;
				TableInfo.ParentTables.SetColumns(m_DataGridViewChild);
				m_DataGridViewChild.Columns[0].ContextMenuStrip = m_ContextMenuStripShowTable;
			}
		}

		/// <summary>
		/// Fill datagrid with inforamtion about SP's dependencies
		/// </summary>
		private void FillSpDependecies()
		{
			try
			{
				if (ConnectionFactory.Instance.State != ConnectionState.Open)
				{
					ConnectionFactory.Instance.Open();
				}

				var com = new SqlCommand("sp_depends", ConnectionFactory.Instance);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.Add("@objname", SqlDbType.NVarChar, 517);
				com.Parameters[0].Value = TableName;

				using (var adapter = new SqlDataAdapter(com))
				{
					var ds = new DataSet();
					adapter.Fill(ds);


					if (ds.Tables.Count > 0)
					{
						DataTable dt = ds.Tables[0];

						dt.Columns.Add("MyType", typeof (string), "IIF(type = 'stored procedure', 'SP' , 'TAB')");

						m_DataGridViewSp.DataSource = dt;
						m_DataGridViewSp.Columns["type"].Visible = false;
						m_DataGridViewSp.Columns["MyType"].HeaderText = "Type";

						m_DataGridViewSp.Columns["name"].HeaderText = "Dependent Object";
						m_DataGridViewSp.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
						m_DataGridViewSp.Columns["name"].ContextMenuStrip = m_ContextMenuStripShowDefinition;
					}
				}
			}
			finally
			{
				ConnectionFactory.CloseConnection();
			}
		}

		private DataSet FillDataSet(string sqlCmdStr, DataSet dataSet)
		{
			try
			{
				ConnectionFactory.OpenConnection();

				var com = new SqlCommand(sqlCmdStr, ConnectionFactory.Instance);
				if (sqlCmdStr.IndexOf("@TABSEARCH") > -1)
				{
					com.Parameters.Add("@TABSEARCH", SqlDbType.NVarChar);
					com.Parameters["@TABSEARCH"].Value = TableName;
				}
				using (var adapter = new SqlDataAdapter(com))
				{
					if (dataSet == null)
					{
						dataSet = new DataSet();
					}
					adapter.Fill(dataSet);
					return dataSet;
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


		private DataSet FillDataSet(string sqlCmdStr)
		{
			return FillDataSet(sqlCmdStr, null);
		}


		private void ShowTableValues_Click(object sender, EventArgs e)
		{
			try
			{
				var itm = (ToolStripItem) sender;
				var tool = (ContextMenuStrip) itm.GetCurrentParent();
				Control c = tool.SourceControl;
				DataGridViewRow row = (((DataGridView) (c))).CurrentRow;
				if (row != null)
				{
					string table = row.Cells[0].Value.ToString();
					m_ParentForm.CreateTabPageWithValues(table, null);
				}
			}
			catch
			{
			}
		}

		private void ShowTableDefinition_Click(object sender, EventArgs e)
		{
			try
			{
				var itm = (ToolStripItem) sender;
				var tool = (ContextMenuStrip) itm.GetCurrentParent();
				Control c = tool.SourceControl;
				DataGridViewRow row = (((DataGridView) (c))).CurrentRow;
				if (row != null)
				{
					string table = row.Cells[0].Value.ToString();
					m_ParentForm.CreateTabPageWithDefinition(table, null);
				}
			}
			catch
			{
			}
		}

		private void button_RefreshDef_Click(object sender, EventArgs e)
		{
			UpdateAllInfo();
		}

		private void button_CloseTab_Click(object sender, EventArgs e)
		{
			RaiseCloseTabPage();
		}

		private void ToolStripButtonToolBox_Click(object sender, EventArgs e)
		{
			if (m_toolbox == null)
			{
				m_toolbox = new Form {Text = TableName};
				m_ToolStripButtonCloseTab.Visible = false;
				m_ToolStripButtonToolBox.Text = "Show as tab page";
				Dock = DockStyle.Fill;
				m_toolbox.Controls.Add(this);
				m_toolbox.FormBorderStyle = FormBorderStyle.SizableToolWindow;
				m_toolbox.Size = new Size(800, 600);
				m_toolbox.Show();
				RaiseCloseTabPage();
				m_toolbox.Owner = m_ParentForm;
			}
			else
			{
				m_toolbox.Close();

				TabPage tp = m_ParentForm.GetTabPage(TableName, null);
				((UserControlAllTableInfo) tp.Controls[0]).InitControl(TableName, ShowAllTableInfo, m_ParentForm);
			}
		}

		private void toolStripSplitButton_LoadMain_Click(object sender, EventArgs e)
		{
			bool loadAll = m_ToolStripSplitButtonLoadMain.Text == m_LoadAllValuesToolStripMenuItem.Text;
			UpdateValuesOnly(loadAll);
		}

		private void loadTop300ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UpdateValuesOnly(false);
			m_ToolStripSplitButtonLoadMain.Text = m_LoadTop300ToolStripMenuItem.Text;
		}

		private void loadAllValuesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UpdateValuesOnly(true);
			m_ToolStripSplitButtonLoadMain.Text = m_LoadAllValuesToolStripMenuItem.Text;
		}

		private void DataGridViewValueUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			DeleteRowFromDb(e.Row);
		}


		public void DeleteRowFromDb(DataGridViewRow dataGridViewRow)
		{
			if (dataGridViewRow == null) return;

			var delCmd = new SqlCommand {Connection = Connection};

			try
			{
				/// 
				/// Create sql command text
				/// 
				string cmdStr = "DELETE FROM " + TableName + " WHERE ";


				foreach (DataGridViewCell cell in dataGridViewRow.Cells)
				{
					//cmd_str1 += string.Format(" [{0}]  ,", cell.OwningColumn.Name);
					if (cell.Value == null || cell.Value.ToString() == "")
					{
						cmdStr += string.Format(" [{0}] is null AND", cell.OwningColumn.Name);
					}
					else
					{
						if (cell.ValueType == typeof (string) && cell.Value.ToString().Length > 1000)
						{
							/// probobly nvarchar, do not check
						}
						else if (cell.ValueType == typeof (string) && cell.Value.ToString().Length > 300)
						{
							cmdStr += string.Format(" [{0}] LIKE @PARAM_{0}  AND", cell.OwningColumn.Name);
							delCmd.Parameters.Add(new SqlParameter("@PARAM_" + cell.OwningColumn.Name, cell.Value));
						}
						else
						{
							cmdStr += string.Format(" [{0}] = @PARAM_{0}  AND", cell.OwningColumn.Name);
							delCmd.Parameters.Add(new SqlParameter("@PARAM_" + cell.OwningColumn.Name, cell.Value));
						}
					}
				}
				cmdStr = cmdStr.Substring(0, cmdStr.Length - 4); /// remove last AND

				delCmd.CommandText = cmdStr;

				if (delCmd.Connection.State != ConnectionState.Open)
				{
					delCmd.Connection.Open();
				}

				delCmd.ExecuteNonQuery();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.ToString());
			}
			finally
			{
				delCmd.Connection.Close();
			}
		}

		private List<string> GetSelectedColumnNames()
		{
			var result = new List<string>();
			if (m_DataGridViewColumns.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in m_DataGridViewColumns.SelectedRows)
				{
					string colName = row.Cells[0].Value.ToString();
					result.Add(colName);
				}
			}
			return result;
		}

		private string GetDataViewFilter(string onColumn)
		{
			List<string> selColumns = GetSelectedColumnNames();
			string dvFilter = "";

			foreach (string column in selColumns)
			{
				if (dvFilter != "") dvFilter += " OR ";
				dvFilter += onColumn + " = '" + column + "' ";
			}
			return dvFilter;
		}

		private void ToolStripMenuItem_ShowDefinition_Click(object sender, EventArgs e)
		{
			try
			{
				if (m_DataGridViewSp.SelectedCells.Count > 0)
				{
					string val = m_DataGridViewSp.SelectedCells[0].Value.ToString();
					bool isSp = "SP" == m_DataGridViewSp.SelectedCells[0].OwningRow.Cells["MyType"].Value.ToString();

					if (isSp)
					{
						RaiseOpenSpTab(val);
					}
					else
					{
						RaiseOpenTableTab(val, true);
					}
				}
			}
			catch
			{
			}
		}

		private static int FreeSpace(DataGridView dg)
		{
			return dg.Height -
			       ((dg.RowTemplate.Height*dg.RowCount) + dg.ColumnHeadersHeight);
		}

		private void ToolStripLabelTableName_DoubleClick(object sender, EventArgs e)
		{
			Clipboard.SetText(m_ToolStripLabelTableName.Text);
		}
	}
}