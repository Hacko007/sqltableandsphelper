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
			TableInfo = new TableInfo();			
			m_getAllRows = false;
			m_userControlValues.ShownColumnsChanged += UserControlValuesShownColumnsChanged;
			m_userControlValues.OpenTableFilteredTab += UserControlValuesOpenTableFilteredTab;
			TableName = "";
		}


		public TableInfo TableInfo { 
			get { return m_userControlValues.TableInfo; }
			set { m_userControlValues.TableInfo = value; }
		}

		public string TableName
		{
			get
			{
				return TableInfo.TableName;
			}
			set
			{
				TableInfo.TableName = value;
			}
		}

		public SqlConnection Connection { get; set; }
		public bool ShowAllTableInfo { get; set; }


		public void SetFilter(TableFilterData cellInfo)
		{
			m_userControlValues.SetFilter(cellInfo);
		}


		private void UserControlValuesShownColumnsChanged(object sender, EventArgs e)
		{
			FillDataGridValues();
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
			FillDataGridValues();
			m_SplitContainerLeft.Panel2.Controls.Clear();
			m_userControlValues.Dock = DockStyle.Fill;
			m_SplitContainerLeft.Panel2.Controls.Add(m_userControlValues);
			m_userControlValues.TableCount = GetTableCountStr();
			Application.DoEvents();
			TableInfo.LoadTableInfo();
			FillColumnDataGrid();
			Application.DoEvents();
						
			RefreshDataGrids();
			Application.DoEvents();
			FillSpDependecies();
			Application.DoEvents();
			Cursor.Current = Cursors.Default;

			ColumnDependencies.FormMain.StatusInfo1 = TableName + " definition loaded";
			ArrangeDataGridViews();
		}

		private void ArrangeDataGridViews()
		{
			try
			{
				/// 
				/// Fix splitcontaner size for empty datagrids
				/// 

				const int emptySpace = 15;

				/// Left slit container
				m_SplitContainerLeft.SplitterDistance -= FreeSpace(m_DataGridViewColumns) - emptySpace;
				if (m_userControlValues.ValuesDataGrid.Count == 0)
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
			try
			{
				m_PanelDataView.Controls.Clear();
			}
			catch { }

			m_userControlValues.Dock = DockStyle.Fill;
			m_PanelDataView.Controls.Add(m_userControlValues);

			m_getAllRows = getAllRows;

			m_userControlValues.TableCount = GetTableCountStr();
			Application.DoEvents();

			FillDataGridValues();
			m_userControlValues.UserDeletingRow -= DataGridViewValueUserDeletingRow;
			m_userControlValues.UserDeletingRow += DataGridViewValueUserDeletingRow;
			Application.DoEvents();
			Cursor.Current = Cursors.Default;

			TableInfo.LoadTableInfo();
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

			if (TableInfo.ColumnInfo == null || TableInfo.ColumnInfo.Rows.Count == 0)
			{
				m_DataGridViewColumns.DataSource = null;
			}
			else
			{
				m_DataGridViewColumns.DataSource = TableInfo.ColumnInfo;
				for (int i = 0; i < m_DataGridViewColumns.Columns.Count; i++)
				{
					m_DataGridViewColumns.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				}
				m_DataGridViewColumns.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				
				m_DataGridViewColumns.SelectAll();
				foreach (DataGridViewRow row in m_DataGridViewColumns.Rows)
				{
					ColumnRefType refType = TableInfo.ColumnConstrains.GetColumnRefType(row.Cells[TableInfo.ColumnInfo.ColumnColumnName.ColumnName].Value.ToString());
					row.HeaderCell = new RowHeaderCellColumnInfo() { ColumnRefType = refType };
				}				
				m_DataGridViewColumns.AutoResizeRowHeadersWidth(  DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

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
		
		private void FillDataGridValues()
		{
			m_userControlValues.FillDataGridValues();			
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

				foreach (DataGridViewRow row in m_DataGridViewColumnConstrains.Rows)
				{
					ColumnRefType refType = TableInfo.ColumnConstrains.GetColumnRefType(row.Cells[TableInfo.ColumnConstrains.ColumnColumnName.ColumnName].Value.ToString());
					row.HeaderCell = new RowHeaderCellColumnInfo() { ColumnRefType = refType };
				}
				m_DataGridViewColumns.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

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

				var com = new SqlCommand("sp_depends", ConnectionFactory.Instance)
				          	{
				          		CommandType = CommandType.StoredProcedure
				          	};
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
						// ReSharper disable PossibleNullReferenceException
						m_DataGridViewSp.Columns["type"].Visible = false;
						m_DataGridViewSp.Columns["MyType"].HeaderText = "Type";
						m_DataGridViewSp.Columns["name"].HeaderText = "Dependent Object";
						m_DataGridViewSp.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
						m_DataGridViewSp.Columns["name"].ContextMenuStrip = m_ContextMenuStripShowDefinition;
						// ReSharper restore PossibleNullReferenceException
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