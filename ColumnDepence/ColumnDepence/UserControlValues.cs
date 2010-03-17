using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using ColumnDepence.DbInfo;
using System.Drawing;
using System.Data.SqlClient;

namespace ColumnDepence
{

	public partial class UserControlValues : UserControl
	{

		public event EventHandler ShownColumnsChanged;
		public event OpenTableFilteredDelegate OpenTableFilteredTab;
		public event DataGridViewRowCancelEventHandler UserDeletingRow;

		public UserControlValues()
		{
			InitializeComponent();
			TableInfo = new TableInfo();
			m_TableCount = "";
			m_ShownRows = 0;
			m_ActiveColumn = null;

			CreateFilterPopup();
		}


		public void FillDataGridValues()
		{
			TableInfo.ValuesLoadedWithFilter = false;
			string selectedColumns = GetColumnSelect();
			string rowFilter = GetFilter();
			if (selectedColumns == null) return;
			int maxRows = Math.Max(10, Properties.Settings.Default.MaxRowsLoaded);

			string sqlCmd = "SELECT TOP " + maxRows + "  " + selectedColumns + " FROM  " + TableInfo.TableName;							

			if (rowFilter != "")
			{
				sqlCmd += " WHERE " + rowFilter;
				TableInfo.ValuesLoadedWithFilter = true;
			}

			TableInfo.Values = new DataTable(TableInfo.TableName);
			TableInfo.Values = TableInfo.FillDataTable(TableInfo.TableName, sqlCmd, TableInfo.Values);

			if (TableInfo.Values == null) return;

			SetBindingDataSource(TableInfo.Values);
			//m_BindingSourceValues.DataMember = TableInfo.TableName;

			m_DataGridViewValues .DataSource = m_BindingSourceValues ;

			if (selectedColumns == "*") AllColumns = new List<string>();
			for (int i = 0; i < m_DataGridViewValues.Columns.Count; i++)
			{
				m_DataGridViewValues.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				if (selectedColumns == "*") AllColumns.Add(m_DataGridViewValues.Columns[i].Name);
			}
			if (selectedColumns == "*")
			{
				ShownColumns = new List<string>();
				ShownColumns.AddRange(AllColumns);
			}
			ApplyFilter();
			UpdateShownColumnsContextMenu();
		}

		private void SetBindingDataSource(object dataSource)
		{
			m_BindingSourceValues.AddingNew -= BindingSourceValues_AddingNew;			
			m_DataGridViewValues.CellEndEdit -= this.DataGridViewValues_CellEndEdit;
			
			m_BindingSourceValues.DataSource = dataSource ;

			m_BindingSourceValues.AddingNew += BindingSourceValues_AddingNew;			
			m_DataGridViewValues.CellEndEdit += this.DataGridViewValues_CellEndEdit;
		}



		public BindingSource ValuesDataGrid { get { return m_BindingSourceValues ; } }

		public TableInfo TableInfo { get; set; }


		/// <summary>
		/// Sets Table count label text
		/// </summary>
		public string TableCount {
			get { return m_TableCount; }
			set {
				m_TableCount = value;
				m_labelTableCount.Text = value;
		} }

		/// <summary>
		/// Gets or Sets how meny rows are shown in this datagrid.		
		/// </summary>
		public int ShownRows
		{
			get { return m_ShownRows; }
			set {
				m_ShownRows = value;
				m_labelTableCount.Text = TableCount + " (Shown " + m_ShownRows + ")";
			}
		}

		public void SetFilter(TableFilterData cellInfo)
		{
			m_FilterDictionary = new Dictionary<string, ColumnFilter>();

			if (cellInfo == null) return;

			m_FilterDictionary = cellInfo.GetColumnFilters();
		}

		private void OnShownColumnsChanged()
		{
			if (ShownColumnsChanged != null)
			{
				ShownColumnsChanged(this, EventArgs.Empty);
			}
		}

		protected virtual void RaiseOpenTableTab(string tableName, bool isDefinitionShown, TableFilterData cellInfo)
		{
			if (OpenTableFilteredTab != null)
			{
				OpenTableFilteredTab(this, tableName, isDefinitionShown, cellInfo);
			}
		}

		private void DataGridViewValues_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			if (UserDeletingRow != null)
			{
				UserDeletingRow(sender, e);
			}
		}

		private void DataGridViewValues_MouseUp(object sender, MouseEventArgs e)
		{
			DataGridView.HitTestInfo hti = m_DataGridViewValues.HitTest(e.Location.X, e.Location.Y);
			if (hti.Type != DataGridViewHitTestType.ColumnHeader || e.Button != MouseButtons.Right)
			{
				return;
			}
			try
			{
				m_ActiveColumn = m_DataGridViewValues.Columns[hti.ColumnIndex];

				if (!m_FilterDictionary.ContainsKey(m_ActiveColumn.Name))
				{
					ColumnFilter colFilters = new ColumnFilter
					                          	{
					                          		ColumnName = m_ActiveColumn.Name,
					                          		Rules = new Dictionary<FilterRule, RuleBase>()
					                          	};
					m_FilterDictionary.Add(colFilters.ColumnName, colFilters);
				}
				ResetContextMenu(m_FilterDictionary[m_ActiveColumn.Name]);

				m_ToolStripLabelFilteredColumn.Text = "Filter column:" + m_ActiveColumn.Name;

				m_ToolStripMenuItemEqual.ValueType = m_ActiveColumn.ValueType;
				m_ToolStripMenuItemNotEqual.ValueType = m_ActiveColumn.ValueType;
				m_ToolStripMenuItemGreaterThen.ValueType = m_ActiveColumn.ValueType;
				m_ToolStripMenuItemLessThen.ValueType = m_ActiveColumn.ValueType;

				/// Which filters are visible 
				/// depends on column type
				bool notInt = m_ActiveColumn.ValueType != typeof (int);
				bool notBool = (m_ActiveColumn.ValueType != typeof (bool));

				m_ToolStripMenuItemLike.Visible = notInt && notBool;

				m_ToolStripMenuItemEqual.Visible = notBool;
				m_ToolStripMenuItemNotEqual.Visible = notBool;
				m_ToolStripMenuItemGreaterThen.Visible = notBool;
				m_ToolStripMenuItemLessThen.Visible = notBool;

				m_ToolStripMenuItemIsTrue.Visible = !notBool;
				m_ToolStripMenuItemIsFalse.Visible = !notBool;


				m_ActiveColumn.ContextMenuStrip = m_contextMenuStripFilter;

				m_contextMenuStripFilter.Show(new Point(Cursor.Position.X, Cursor.Position.Y + 15));
				m_contextMenuStripFilter.BringToFront();
			}
			catch
			{
			}
		}

		private void CreateFilterPopup()
		{
			m_ToolStripSeparator2 = new ToolStripSeparator();
			m_ToolStripLabelFilteredColumn = new ToolStripLabel("Filter column:");
			m_ToolStripMenuItemLike = new UserControlToolStripLabelTextBox {LabelText = "Like"};
			m_ToolStripMenuItemEqual = new UserControlToolStripLabelTextBox {LabelText = "="};
			m_ToolStripMenuItemNotEqual = new UserControlToolStripLabelTextBox {LabelText = "<>"};
			m_ToolStripMenuItemGreaterThen = new UserControlToolStripLabelTextBox {LabelText = ">"};
			m_ToolStripMenuItemLessThen = new UserControlToolStripLabelTextBox {LabelText = "<"};

			m_ToolStripMenuItemLike.TextBox.TextChanged += ToolStripTextBoxTextChanged;
			m_ToolStripMenuItemEqual.TextBox.TextChanged += ToolStripTextBoxTextChanged;
			m_ToolStripMenuItemNotEqual.TextBox.TextChanged += ToolStripTextBoxTextChanged;
			m_ToolStripMenuItemGreaterThen.TextBox.TextChanged += ToolStripTextBoxTextChanged;
			m_ToolStripMenuItemLessThen.TextBox.TextChanged += ToolStripTextBoxTextChanged;

			m_ToolStripMenuItemLike.Visible = false;
			m_ToolStripMenuItemEqual.Visible = false;
			m_ToolStripMenuItemNotEqual.Visible = false;
			m_ToolStripMenuItemGreaterThen.Visible = false;
			m_ToolStripMenuItemLessThen.Visible = false;
			m_ToolStripMenuItemIsTrue.Visible = false;
			m_ToolStripMenuItemIsFalse.Visible = false;


			m_contextMenuStripFilter.Items.Clear();
			m_contextMenuStripFilter.Items.AddRange(new ToolStripItem[]
			                                        	{
			                                        		m_ToolStripLabelFilteredColumn,
			                                        		new ToolStripSeparator(),

			                                        		m_removeFiltersToolStripMenuItem,
			                                        		m_ToolStripSeparator2,

			                                        		m_ToolStripMenuItemLike, m_ToolStripMenuItemEqual,
			                                        		m_ToolStripMenuItemNotEqual
			                                        		, m_ToolStripMenuItemGreaterThen, m_ToolStripMenuItemLessThen
			                                        		, m_ToolStripMenuItemIsTrue, m_ToolStripMenuItemIsFalse
			                                        		, m_isNotNullToolStripMenuItem, m_isNullToolStripMenuItem
			                                        	});


		}

		private void ResetContextMenu(ColumnFilter columnFilter)
		{
			
			m_isNotNullToolStripMenuItem.Checked = columnFilter.HasFilter(FilterRule.IsNotNull);
			m_isNullToolStripMenuItem.Checked = columnFilter.HasFilter(FilterRule.IsNull);			
			m_ToolStripMenuItemIsTrue.Checked = columnFilter.HasFilter(FilterRule.IsTrue);
			m_ToolStripMenuItemIsFalse.Checked = columnFilter.HasFilter(FilterRule.IsFalse);
			
			m_ToolStripMenuItemLike.Text = columnFilter.GetRuleValue(FilterRule.Like);
			m_ToolStripMenuItemLessThen.Text = columnFilter.GetRuleValue(FilterRule.Less);
			m_ToolStripMenuItemEqual.Text = columnFilter.GetRuleValue(FilterRule.Eq);
			m_ToolStripMenuItemNotEqual.Text = columnFilter.GetRuleValue(FilterRule.NotEq);
			m_ToolStripMenuItemGreaterThen.Text = columnFilter.GetRuleValue(FilterRule.Greater);

			UpdateContexMenuStatus();
		}

		private void UpdateContexMenuStatus()
		{

			bool hasFilter = m_ToolStripMenuItemEqual.HasValue
			                 || m_ToolStripMenuItemGreaterThen.HasValue
			                 || m_ToolStripMenuItemLessThen.HasValue
			                 || m_ToolStripMenuItemLike.HasValue
			                 || m_isNotNullToolStripMenuItem.Checked
			                 || m_isNullToolStripMenuItem.Checked
			                 || m_ToolStripMenuItemIsTrue.Checked
			                 || m_ToolStripMenuItemIsFalse.Checked;

			string col = m_ActiveColumn.Name;

			if (!m_FilterDictionary.ContainsKey(col))
			{
				ColumnFilter cf = new ColumnFilter {ColumnName = col, Rules = new Dictionary<FilterRule, RuleBase>()};
				m_FilterDictionary.Add(col, cf);
			}

			if (m_ToolStripMenuItemLike.HasValue)
				m_FilterDictionary[col].Add(new Like(col, m_ToolStripMenuItemLike.Text));
			else
				m_FilterDictionary[col].Remove(FilterRule.Like);

			if (m_ToolStripMenuItemEqual.HasValue)
				m_FilterDictionary[col].Add(new Eq(col, m_ToolStripMenuItemEqual.Text));
			else
				m_FilterDictionary[col].Remove(FilterRule.Eq);

			if (m_ToolStripMenuItemNotEqual.HasValue)
				m_FilterDictionary[col].Add(new NotEq(col, m_ToolStripMenuItemNotEqual.Text));
			else
				m_FilterDictionary[col].Remove(FilterRule.NotEq);


			if (m_ToolStripMenuItemLessThen.HasValue)
				m_FilterDictionary[col].Add(new Less(col, m_ToolStripMenuItemLessThen.Text));
			else
				m_FilterDictionary[col].Remove(FilterRule.Less);

			if (m_ToolStripMenuItemGreaterThen.HasValue)
				m_FilterDictionary[col].Add(new Greater(col, m_ToolStripMenuItemGreaterThen.Text));
			else
				m_FilterDictionary[col].Remove(FilterRule.Greater);

			if (m_isNotNullToolStripMenuItem.Checked)
				m_FilterDictionary[col].Add(new IsNotNull(col));
			else
				m_FilterDictionary[col].Remove(FilterRule.IsNotNull);

			if (m_isNullToolStripMenuItem.Checked)
				m_FilterDictionary[col].Add(new IsNull(col));
			else
				m_FilterDictionary[col].Remove(FilterRule.IsNull);


			if (m_ToolStripMenuItemIsTrue.Checked)
				m_FilterDictionary[col].Add(new IsTrue(col));
			else
				m_FilterDictionary[col].Remove(FilterRule.IsTrue);

			if (m_ToolStripMenuItemIsFalse.Checked)
				m_FilterDictionary[col].Add(new IsFalse(col));
			else
				m_FilterDictionary[col].Remove(FilterRule.IsFalse);

			m_removeFiltersToolStripMenuItem.Enabled = hasFilter;
			m_ToolStripSeparator2.Visible = hasFilter;

			m_ActiveColumn.HeaderText = (hasFilter) ? "["+ m_ActiveColumn.Name + "]" : m_ActiveColumn.Name;
			
			ApplyFilter();
		}

		internal string GetFilter() {

			StringBuilder filterBuild = new StringBuilder();

			foreach (KeyValuePair<string, ColumnFilter> colRules in m_FilterDictionary)
			{
				foreach (KeyValuePair<FilterRule, RuleBase> rules in colRules.Value.Rules)
				{
					filterBuild.Append(rules.Value.Filter + " AND ");
				}
			}
			string filter = filterBuild.ToString();

			if (filter.Length > 5)
				filter = filter.Substring(0, filter.Length - 5); /// remove last AND

			return filter;
		}

		internal void ApplyFilter()
		{			
			string filter = GetFilter();

			if (filter == "")
			{
				m_labelFilter.Text = "";
				m_buttonRemoveFilter.Visible = false;
			}
			else
			{
				m_labelFilter.Text = "Filter: " + filter;
				m_buttonRemoveFilter.Visible = true;
			}

			try
			{
				if(TableInfo.Values.TableName == "") return;

				DataView dv = new DataView {Table = TableInfo.Values, RowFilter = filter};
				SetBindingDataSource (dv);

				m_DataGridViewValues.DataSource = m_BindingSourceValues;
				ShownRows = dv.Count;			
			}
			catch { }									
		}

		#region Filter Menu Events

		private void ToolStripTextBoxTextChanged(object sender, EventArgs e)
		{			
			UpdateContexMenuStatus();
		}			
		

		private void IsNotNullToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_isNotNullToolStripMenuItem.Checked)
			{
				m_isNullToolStripMenuItem.Checked = false;
			}
			UpdateContexMenuStatus();
		}

		private void IsNullToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_isNullToolStripMenuItem.Checked)
			{
				m_isNotNullToolStripMenuItem.Checked = false;
			}
			UpdateContexMenuStatus();
		}

		private void IsTrueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_ToolStripMenuItemIsTrue.Checked)
			{
				m_ToolStripMenuItemIsFalse.Checked = false;
			}
			UpdateContexMenuStatus();
		}

		private void IsFalseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_ToolStripMenuItemIsFalse.Checked)
			{
				m_ToolStripMenuItemIsTrue.Checked = false;
			}
			UpdateContexMenuStatus();
		}

		private void RemoveFiltersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_FilterDictionary.Remove(m_ActiveColumn.Name);

			ResetFilterContextMenuItems();
			UpdateContexMenuStatus();
			if (TableInfo.ValuesLoadedWithFilter)
			{
				FillDataGridValues();
			}
		}

		private void ResetFilterContextMenuItems()
		{
			m_isNotNullToolStripMenuItem.Checked = false;
			m_isNullToolStripMenuItem.Checked = false;
			m_ToolStripMenuItemIsTrue.Checked = false;
			m_ToolStripMenuItemIsFalse.Checked = false;

			m_ToolStripMenuItemLike.Text = "";
			m_ToolStripMenuItemEqual.Text = "";
			m_ToolStripMenuItemNotEqual.Text = "";
			m_ToolStripMenuItemGreaterThen.Text = "";
			m_ToolStripMenuItemLessThen.Text = "";

			m_removeFiltersToolStripMenuItem.Enabled = false;
		}

		#endregion

		#region Show Column ContextMenu
		public List<string> AllColumns { get; set; }
		public List<string> ShownColumns { get; set; }

		private void ContextMenuStripShownColumns_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Point cliecked = PointToClient(Cursor.Position);
			DataGridView.HitTestInfo hti = m_DataGridViewValues.HitTest(cliecked.X-2, cliecked.Y-15);
			if (hti.Type != DataGridViewHitTestType.Cell)
			{
			    e.Cancel = true;
			    return;
			}

			m_contextMenuStripShownColumns.Items.Clear();
			m_contextMenuStripShownColumns.Items.AddRange(new ToolStripItem[]{
				m_showallClumnsToolStripMenuItem,
				m_ChooseColumnsToolStripMenuItem,
				new ToolStripSeparator(),
				m_ShowRowInfoToolStripMenuItem
				});

			if (TableInfo.Values == null )
				return;

			/// if foregn key column(s) are selected 
			/// add contxt menu that should open parent table 
			/// with this rows filtered.
			/// 

			TableFilterDataCollection cellValues = new TableFilterDataCollection();

			/// 
			/// Find all referensed tables for selected cells
			/// 
			foreach (DataGridViewCell cell in m_DataGridViewValues.SelectedCells)
			{
				// cell.ColumnIndex
				if (TableInfo.Values.Columns.Count > cell.ColumnIndex)
				{					
					string colName = TableInfo.Values.Columns[cell.ColumnIndex].ColumnName;
					/// 
					/// find parents and add to CellInfoCollection
					/// 
					if (TableInfo.ChildTables != null && TableInfo.ChildTables.Rows.Count > 0)
					{
						DataRow[] parentColRefs = TableInfo.ChildTables.FindChilds(colName);
						if (parentColRefs != null && parentColRefs.Length > 0)
						{
							foreach (DataRow row in parentColRefs)
							{
								cellValues.Add(
									row[TableInfo.ChildTables.ColumnTableName].ToString(),
									row[TableInfo.ChildTables.ColumnChildColumnName].ToString(),
									cell.Value,
									TableRelation.Child);
							}							
						}
					}
					/// 
					/// find children and add to CellInfoCollection
					/// 
					if (TableInfo.ParentTables != null && TableInfo.ParentTables.Rows.Count > 0)
					{
						DataRow[] childColRefs = TableInfo.ParentTables.FindParents(colName);
						if (childColRefs != null && childColRefs.Length > 0)
						{
							foreach (DataRow row in childColRefs)
							{
								cellValues.Add(
									row[TableInfo.ParentTables.ColumnTableName].ToString(),
									row[TableInfo.ParentTables.ColumnParentColumnName].ToString(),
									cell.Value, 
									TableRelation.Parent);
							}

						}
					}									
				}
			}

			if (cellValues.Tables.Count == 0) return;

			TableRelation tabRelation = TableRelation.None;
			
			/// 
			/// Create context menus for found 
			/// refernece tables
			/// 
			foreach (KeyValuePair<string, TableFilterData> table in cellValues.Tables.OrderBy(tab=> tab.Value.TableRelation).ThenBy(tab=> tab.Value.TableName) )
			{
				if (tabRelation != table.Value.TableRelation)
				{
					m_contextMenuStripShownColumns.Items.Add(new ToolStripSeparator());
					ToolStripLabel toolStripLabel = new ToolStripLabel {ForeColor = Color.DarkGray};
					toolStripLabel.Font = new Font(toolStripLabel.Font, FontStyle.Bold | FontStyle.Underline);
					switch (table.Value.TableRelation)
					{
						case TableRelation.Parent:
							toolStripLabel.Text = "   Parent tables   ";
							m_contextMenuStripShownColumns.Items.Add(toolStripLabel);
							break;
						case TableRelation.Child:
							toolStripLabel.Text = "   Child tables   ";
							m_contextMenuStripShownColumns.Items.Add(toolStripLabel);
							break;					
					}
					
				}

				ToolStripMenuItem tabMenuItem = new ToolStripMenuItem(table.Key) {Tag = table.Value};
				tabMenuItem.Click += ShowTableRowsFilterd;
				m_contextMenuStripShownColumns.Items.Add(tabMenuItem);

				tabRelation = table.Value.TableRelation;

			}
		}

		void ShowTableRowsFilterd(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem &&
				((ToolStripMenuItem)sender).Tag is TableFilterData)
			{
				TableFilterData ci = ((ToolStripMenuItem)sender).Tag as TableFilterData;
				RaiseOpenTableTab(ci.TableName, false, ci);
			}
		}
		
			

		/// <summary>
		/// Get string representing selected columns
		/// that should be used in SQL queuery. 
		/// </summary>
		/// <returns> * if all columns selected or list of comma separeted columns names, 
		/// eg [col1],[col2],[col3]</returns>
		public string GetColumnSelect() {
			if (AllColumns == null)
				return "*";
			
			if(ShownColumns == null || ShownColumns.Count == 0)
				return null;

			if (AllColumns.Count == ShownColumns.Count)
				return "*";

			StringBuilder sel = new StringBuilder();
			foreach (string item in ShownColumns)
			{
				sel.AppendFormat("[{0}] , ", item);
			}
			string result = sel.ToString();
			result = result.Substring(0, result.Length - 3); /// remove last , 
			return result;
		}

		private void ChooseColumnsToolStripMenuItem_Click(object sender, EventArgs e)
		{

			FormSelectShownColumns form = new FormSelectShownColumns {AllColumns = AllColumns, ShownColumns = ShownColumns};
			form.InitColumns();
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				ShownColumns = form.ShownColumns;
				OnShownColumnsChanged();
				UpdateShownColumnsContextMenu();
			}
		}

		private void ShowAllClumnsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShownColumns = AllColumns;
			OnShownColumnsChanged();
			UpdateShownColumnsContextMenu();
		}
		
		public void UpdateShownColumnsContextMenu() {

			if (AllColumns== null)
			{
				return;
			}
			
			m_contextMenuStripShownColumns.Items.Clear();
			m_contextMenuStripShownColumns.Items.AddRange(
				new ToolStripItem[]{ 
					m_showallClumnsToolStripMenuItem,
					m_ChooseColumnsToolStripMenuItem,
					new ToolStripSeparator(),
					m_ShowRowInfoToolStripMenuItem
				});
		}


		#endregion Show Column ContextMenu

		private void ShowRowInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_DataGridViewValues.Rows.Count == 0) return;

			FormShowOneRow showOneRow = new FormShowOneRow {DataGridValues = m_DataGridViewValues};
			showOneRow.LoadRowItnoView();
			showOneRow.ResizeWindow();
			showOneRow.Show();			
		}

		private void ButtonRemoveFilter_Click(object sender, EventArgs e)
		{
			ClearFilter();
		}

		private void ClearFilter()
		{
			m_FilterDictionary = new Dictionary<string, ColumnFilter>();
			ResetFilterContextMenuItems();
			ApplyFilter();
			if (TableInfo.ValuesLoadedWithFilter) {
				FillDataGridValues();
			}
		}

		private void DataGridViewValues_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
			
			//if( false == m_NewRowAddedButNotSaved )
				Save();
		}

		private void Save()
		{
			Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

			DataRowView rowView = m_BindingSourceValues.Current as DataRowView ;
			if (rowView == null) return;
			SqlCommand sqlCmd ;
				if( m_NewRowAddedButNotSaved ){
					sqlCmd = CreateInsertSqlCommand(rowView);
				}
				else
				{
					sqlCmd = CreateUpdateRowSqlCommand(rowView);
				}
			if (sqlCmd == null) return;
			try
			{
				if (ConnectionFactory.OpenConnection())
				{
					sqlCmd.Connection = ConnectionFactory.Instance;
					sqlCmd.ExecuteNonQuery();
					m_BindingSourceValues.EndEdit();
					m_NewRowAddedButNotSaved = false;
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally {
				ConnectionFactory.CloseConnection();
			}
		}

		private SqlCommand CreateInsertSqlCommand(DataRowView rowView)
		{
			Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

			SqlCommand sqlCmd = new SqlCommand();
			StringBuilder sqlColumns = new StringBuilder();
			StringBuilder sqlValues = new StringBuilder();

			foreach (DataColumn col in rowView.Row.Table.Columns)
			{
				if (TableInfo.ColumnInfo.IsIdentityColumn(col.ColumnName)) continue ;

				sqlColumns.Append(string.Format("[{0}] ,", col.ColumnName));
				sqlValues .Append(string.Format("@{0} ,", col.ColumnName));
				if (rowView.Row.HasVersion(DataRowVersion.Proposed ))
				{
					sqlCmd.Parameters.Add(new SqlParameter("@" + col.ColumnName, rowView.Row[col, DataRowVersion.Proposed]));
				}
				else
				{
					sqlCmd.Parameters.Add(new SqlParameter("@" + col.ColumnName, DBNull.Value  ));
				}
			}
			if (sqlColumns .Length > 0)
			{
				sqlColumns.Remove(sqlColumns.Length - 1, 1);
			}
			else
			{
				return null;
			}

			if (sqlValues.Length > 0)
			{
				sqlValues.Remove(sqlValues.Length - 1, 1);
			}
			else
			{
				return null;
			}

			sqlCmd.CommandText = "INSERT INTO " + TableInfo.TableName + " (" + sqlColumns .ToString() + ") Values( " + sqlValues.ToString() +")";
			Console.WriteLine(sqlCmd.CommandText);
			return sqlCmd;
		}
	
		private SqlCommand CreateUpdateRowSqlCommand(DataRowView rowView)
		{
			Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

			SqlCommand sqlCmd = new SqlCommand();

			StringBuilder sql = new StringBuilder();
			StringBuilder sqlWhere = new StringBuilder();

			SqlParameter[] sqlParams = new SqlParameter[rowView.Row.Table.Columns.Count * 2];

			foreach (DataColumn col in rowView.Row.Table.Columns)
			{
				if (rowView.Row.HasVersion(DataRowVersion.Original) &&
					rowView.Row.HasVersion(DataRowVersion.Proposed) &&
					!rowView.Row[col, DataRowVersion.Proposed].Equals(rowView.Row[col, DataRowVersion.Original]))
				{
					sql.Append(string.Format("[{0}] = @{0} ,", col.ColumnName));
					sqlCmd.Parameters.Add(new SqlParameter("@" + col.ColumnName, rowView.Row[col, DataRowVersion.Proposed]));
				}

				if (rowView.Row[col, DataRowVersion.Original] is DBNull)
				{
					sqlWhere.Append(string.Format(" ([{0}] IS NULL) AND", col.ColumnName));					
				}
				else
				{
					sqlWhere.Append(string.Format(" ([{0}] = @Original_{0}) AND", col.ColumnName));
					sqlCmd.Parameters.Add(new SqlParameter("@Original_" + col.ColumnName, rowView.Row[col, DataRowVersion.Original]));
				}
			}
			if (sql.Length > 0)
			{
				sql.Remove(sql.Length - 1, 1);
			}
			else
			{
				return null;
			}

			if (sqlWhere.Length > 0)
			{
				sqlWhere.Remove(sqlWhere.Length - 3, 3);
			}
			else
			{
				return null;
			}

			sqlCmd.CommandText = "UPDATE " + TableInfo.TableName + " SET " + sql.ToString() + " WHERE " + sqlWhere.ToString();
			Console.WriteLine(sqlCmd.CommandText);
			return sqlCmd;
		}

		bool m_NewRowAddedButNotSaved = false;
		private void BindingSourceValues_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
		{
			Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

			Console.WriteLine(e.ToString());
			m_NewRowAddedButNotSaved = true;
			m_DataGridViewValues.RowLeave += DataGridViewValues_RowLeave;
			m_DataGridViewValues.CellEndEdit  -= DataGridViewValues_CellEndEdit ;

		}

		private void DataGridViewValues_RowLeave(object sender, DataGridViewCellEventArgs e)
		{
			Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
			if (IsRowEmpty(CurrentRow)) {
				m_NewRowAddedButNotSaved = false;
				m_BindingSourceValues.CancelEdit();
			}
			if (m_NewRowAddedButNotSaved)
			{
				//Save();								
				m_DataGridViewValues.CellEndEdit += DataGridViewValues_CellEndEdit;
			}
			m_DataGridViewValues.RowLeave -= DataGridViewValues_RowLeave;
		}

		private bool IsRowEmpty(DataRow row) {
			
			if (row == null) return true;

			foreach (var item in row.ItemArray )
			{
				if (item.ToString() != String.Empty)
					return false;
			}
			return true;
		}

		private DataRow CurrentRow
		{
			get
			{
				DataRowView rowView = m_BindingSourceValues.Current as DataRowView;
				if (rowView == null) return null;
				return rowView.Row;
			}
		}

	}
}
