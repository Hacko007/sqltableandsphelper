using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text;

namespace ColumnDepence
{

	public partial class UserControlValues : UserControl
	{

		public event EventHandler ShownColumnsChanged;

		private Dictionary<string, Filters.ColumnFilter> filter_dict = new Dictionary<string, ColumnDepence.Filters.ColumnFilter>();

		/// <summary>
		/// Last pressed column header
		/// </summary>
		private DataGridViewColumn m_ActiveColumn = null;

		public event DataGridViewRowCancelEventHandler UserDeletingRow;
		public UserControlValues()
		{
			InitializeComponent();
		}

		public DataGridView ValuesDataGrid { get { return dataGridView_Values; } }
		
		string tableCount = "";
		/// <summary>
		/// Sets Table count label text
		/// </summary>
		public string TableCount {
			get { return tableCount; }
			set {
				tableCount = value;
				m_labelTableCount.Text = value;
		} }
		
		int shownRows = 0;
		/// <summary>
		/// Gets or Sets how meny rows are shown in this datagrid.		
		/// </summary>
		public int ShownRows
		{
			get { return shownRows; }
			set {
				shownRows = value;
				m_labelTableCount.Text = TableCount + " (Shown " + shownRows + ")";
			}
		}

		private void OnShownColumnsChanged() {
			if (ShownColumnsChanged != null) {
				ShownColumnsChanged(this, EventArgs.Empty);
			}
		}

		private void dataGridView_Values_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			if (UserDeletingRow != null)
			{
				UserDeletingRow(sender, e);
			}
		}

		private void dataGridView_Values_MouseUp(object sender, MouseEventArgs e)
		{
			DataGridView.HitTestInfo hti = dataGridView_Values.HitTest(e.Location.X, e.Location.Y);
			if (hti.Type == DataGridViewHitTestType.ColumnHeader && e.Button == MouseButtons.Right)
			{				
				try
				{
					m_ActiveColumn = dataGridView_Values.Columns[hti.ColumnIndex];

					if (!filter_dict.ContainsKey(m_ActiveColumn.Name))
					{
						Filters.ColumnFilter col_filters = new ColumnDepence.Filters.ColumnFilter();
						col_filters.ColumnName = m_ActiveColumn.Name;
						col_filters.Rules = new Dictionary<ColumnDepence.Filters.FilterRule, ColumnDepence.Filters.RuleBase>();
						filter_dict.Add(col_filters.ColumnName, col_filters);
					}
					ResetContextMenu(m_contextMenuStripFilter, filter_dict[m_ActiveColumn.Name]);

					/// Which filters are visible 
					/// depends on column type

					m_LikeToolStripMenuItem.Visible = (m_ActiveColumn.ValueType != typeof(int) 
													&& (m_ActiveColumn.ValueType != typeof(bool)));

					m_equalToolStripMenuItem.Visible = (m_ActiveColumn.ValueType != typeof(bool));					
					m_greToolStripMenuItem.Visible = (m_ActiveColumn.ValueType != typeof(bool));
					m_lessThenToolStripMenuItem.Visible = (m_ActiveColumn.ValueType != typeof(bool));

					m_isTrueToolStripMenuItem.Visible = (m_ActiveColumn.ValueType == typeof(bool));
					m_isFalseToolStripMenuItem.Visible = (m_ActiveColumn.ValueType == typeof(bool));
					

					m_ActiveColumn.ContextMenuStrip = m_contextMenuStripFilter;
					m_contextMenuStripFilter.Show(Cursor.Position);
					m_contextMenuStripFilter.BringToFront();
				}
				catch { }
			}
		}

		private void ResetContextMenu(ContextMenuStrip m_contextMenuStrip, ColumnDepence.Filters.ColumnFilter columnFilter)
		{
			
			m_equalToolStripMenuItem.Checked = columnFilter.HasFilter(Filters.FilterRule.Eq) ;
			m_greToolStripMenuItem.Checked = columnFilter.HasFilter(Filters.FilterRule.Greater);
			m_isNotNullToolStripMenuItem.Checked = columnFilter.HasFilter(Filters.FilterRule.IsNotNull);
			m_isNullToolStripMenuItem.Checked = columnFilter.HasFilter(Filters.FilterRule.IsNull);
			m_lessThenToolStripMenuItem.Checked = columnFilter.HasFilter(Filters.FilterRule.Less);
			m_LikeToolStripMenuItem.Checked = columnFilter.HasFilter(Filters.FilterRule.Like);
			m_isTrueToolStripMenuItem.Checked = columnFilter.HasFilter(Filters.FilterRule.IsTrue);
			m_isFalseToolStripMenuItem.Checked = columnFilter.HasFilter(Filters.FilterRule.IsFalse);
			
			m_LikeToolStripTextBox.TextBox.Text = columnFilter.GetRuleValue(Filters.FilterRule.Like);
			m_LessThenToolStripTextBox2.TextBox.Text = columnFilter.GetRuleValue(Filters.FilterRule.Less);
			m_EqualToolStripTextBox.TextBox.Text = columnFilter.GetRuleValue(Filters.FilterRule.Eq);
			m_GraterThenToolStripTextBox.TextBox.Text = columnFilter.GetRuleValue(Filters.FilterRule.Greater);

			this.UpdateContexMenuStatus();
		}

		private void UpdateContexMenuStatus()
		{

			bool has_filter = m_equalToolStripMenuItem.Checked
			 || m_greToolStripMenuItem.Checked
			 || m_isNotNullToolStripMenuItem.Checked
			 || m_isNullToolStripMenuItem.Checked
			 || m_lessThenToolStripMenuItem.Checked
			 || m_LikeToolStripMenuItem.Checked
			 || m_isTrueToolStripMenuItem.Checked
			 || m_isFalseToolStripMenuItem.Checked;

			string col = m_ActiveColumn.Name;

			if (!filter_dict.ContainsKey(col))
			{
				Filters.ColumnFilter cf = new ColumnDepence.Filters.ColumnFilter();
				cf.ColumnName = col;
				cf.Rules = new Dictionary<ColumnDepence.Filters.FilterRule, ColumnDepence.Filters.RuleBase>();
				filter_dict.Add(col, cf);
			}

			if (m_LikeToolStripMenuItem.Checked)
				filter_dict[col].Add(new Filters.Like(col, m_LikeToolStripTextBox.Text));
			else
				filter_dict[col].Remove(Filters.FilterRule.Like);

			if (m_equalToolStripMenuItem.Checked)
				filter_dict[col].Add(new Filters.Eq(col, m_EqualToolStripTextBox.Text));
			else
				filter_dict[col].Remove(Filters.FilterRule.Eq);


			if (m_lessThenToolStripMenuItem.Checked)
				filter_dict[col].Add(new Filters.Less(col, m_LessThenToolStripTextBox2.Text));
			else
				filter_dict[col].Remove(Filters.FilterRule.Less);

			if (m_greToolStripMenuItem.Checked)
				filter_dict[col].Add(new Filters.Greater(col, m_GraterThenToolStripTextBox.Text));
			else
				filter_dict[col].Remove(Filters.FilterRule.Greater);

			if (m_isNotNullToolStripMenuItem.Checked)
				filter_dict[col].Add(new Filters.IsNotNull(col));
			else
				filter_dict[col].Remove(Filters.FilterRule.IsNotNull);

			if (m_isNullToolStripMenuItem.Checked)
				filter_dict[col].Add(new Filters.IsNull(col));
			else
				filter_dict[col].Remove(Filters.FilterRule.IsNull);


			if (m_isTrueToolStripMenuItem.Checked)
				filter_dict[col].Add(new Filters.IsTrue(col));
			else
				filter_dict[col].Remove(Filters.FilterRule.IsTrue);

			if (m_isFalseToolStripMenuItem.Checked)
				filter_dict[col].Add(new Filters.IsFalse(col));
			else
				filter_dict[col].Remove(Filters.FilterRule.IsFalse);


			m_filterByValueToolStripMenuItem.Checked = has_filter;
			m_removeFiltersToolStripMenuItem.Enabled = has_filter;

			m_ActiveColumn.HeaderText = (has_filter) ? "["+ m_ActiveColumn.Name + "]" : m_ActiveColumn.Name;
			
			ApplyFilter();
		}

		internal string GetFilter() {

			StringBuilder filterBuild = new StringBuilder();

			foreach (KeyValuePair<string, Filters.ColumnFilter> col_rules in filter_dict)
			{
				foreach (KeyValuePair<Filters.FilterRule, Filters.RuleBase> rules in col_rules.Value.Rules)
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
			if (this.dataGridView_Values.DataSource is DataTable)
			{
				DataTable tab = (DataTable)this.dataGridView_Values.DataSource;
				DataView dv = new DataView();
				dv.Table = tab;
				try
				{
					dv.RowFilter = filter;
				}
				catch { }
				dataGridView_Values.DataSource = dv;
				ShownRows = dv.Count;
			}
			else
			{
				DataView dv = (DataView)this.dataGridView_Values.DataSource;
				try
				{
					dv.RowFilter = filter;
				}
				catch { }
				dataGridView_Values.DataSource = dv;
				ShownRows = dv.Count;
			}

			m_labelFilter.Text = (filter == "") ? "" : "Filter: " + filter;

		}

		#region Filter Menu Events

		private void m_EqualToolStripTextBox_TextChanged(object sender, EventArgs e)
		{
			m_equalToolStripMenuItem.Checked = m_EqualToolStripTextBox.TextBox.Text.Trim() != "";
			UpdateContexMenuStatus();
		}

		private void m_GraterThenToolStripTextBox_TextChanged(object sender, EventArgs e)
		{
			m_greToolStripMenuItem.Checked = m_GraterThenToolStripTextBox.TextBox.Text.Trim() != "";
			UpdateContexMenuStatus();
		}

		private void m_LessThenToolStripTextBox2_TextChanged(object sender, EventArgs e)
		{
			m_lessThenToolStripMenuItem.Checked = m_LessThenToolStripTextBox2.TextBox.Text.Trim() != "";
			UpdateContexMenuStatus();
		}

		private void m_LikeToolStripTextBox_TextChanged(object sender, EventArgs e)
		{
			m_LikeToolStripMenuItem.Checked = m_LikeToolStripTextBox.TextBox.Text.Trim() != "";
			UpdateContexMenuStatus();
		}
		
		private void m_equalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_EqualToolStripTextBox.TextBox.Text.Trim() == "")
			{
				m_equalToolStripMenuItem.Checked = false;
			}
			UpdateContexMenuStatus();

		}

		private void m_filterByValueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UpdateContexMenuStatus();
		}

		private void m_greToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_GraterThenToolStripTextBox.TextBox.Text.Trim() == "")
			{
				m_greToolStripMenuItem.Checked = false;
			}
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

		private void LessThenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_LessThenToolStripTextBox2.TextBox.Text.Trim() == "")
			{
				m_lessThenToolStripMenuItem.Checked = false;
			}
			UpdateContexMenuStatus();
		}

		private void LikeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_LikeToolStripTextBox.TextBox.Text.Trim() == "") {
				m_LikeToolStripMenuItem.Checked = false;
			}
			UpdateContexMenuStatus();
		}

		private void IsTrueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_isTrueToolStripMenuItem.Checked)
			{
				m_isFalseToolStripMenuItem.Checked = false;
			}
			UpdateContexMenuStatus();
		}

		private void IsFalseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_isFalseToolStripMenuItem.Checked)
			{
				m_isTrueToolStripMenuItem.Checked = false;
			}
			UpdateContexMenuStatus();
		}

		private void RemoveFiltersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			filter_dict.Remove(m_ActiveColumn.Name);

			m_filterByValueToolStripMenuItem.Checked = false;

			m_equalToolStripMenuItem.Checked = false;
			m_greToolStripMenuItem.Checked = false;
			m_lessThenToolStripMenuItem.Checked = false;
			m_LikeToolStripMenuItem.Checked = false;
			m_isNotNullToolStripMenuItem.Checked = false;
			m_isNullToolStripMenuItem.Checked = false;
			m_isTrueToolStripMenuItem.Checked = false;
			m_isFalseToolStripMenuItem.Checked = false;
			
			m_LikeToolStripTextBox.TextBox.Text = "";
			m_LessThenToolStripTextBox2.TextBox.Text = "";
			m_EqualToolStripTextBox.TextBox.Text = "";
			m_GraterThenToolStripTextBox.TextBox.Text = "";
			
			m_removeFiltersToolStripMenuItem.Enabled = false;
			UpdateContexMenuStatus();
		}

		#endregion

		#region Show Column ContextMenu
		public List<string> AllColumns { get; set; }
		public List<string> ShownColumns { get; set; }

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

			FormSelectShownColumns form = new FormSelectShownColumns();
			form.AllColumns = AllColumns;
			form.ShownColumns = ShownColumns;
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
			
			return;

			foreach (string item in AllColumns)
			{
				bool selected = (ShownColumns != null && ShownColumns.Contains(item));
				ToolStripMenuItem mi = new ToolStripMenuItem(item);
				mi.CheckOnClick = true;
				mi.Checked = selected;
				mi.CheckedChanged += new EventHandler(ShowColumnToolStripMenuItem_CheckedChanged);
				m_contextMenuStripShownColumns.Items.Add(mi);
			}
		}

		void ShowColumnToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem item = (ToolStripMenuItem)sender;
				string col_name = item.Text;
				if (item.Checked )
				{ 
					if(ShownColumns == null) ShownColumns = new List<string>();

					if (!ShownColumns.Contains(col_name)) {
						ShownColumns.Add(col_name);
					}
				}
				else
				{
					if (ShownColumns != null && ShownColumns.Contains(col_name)) {
						ShownColumns.Remove(col_name);
					}
				}
			}
			OnShownColumnsChanged();
			UpdateShownColumnsContextMenu();
		}
		#endregion Show Column ContextMenu

		private void m_ShowRowInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dataGridView_Values.SelectedRows.Count == 0) return;

			FormShowOneRow showOneRow = new FormShowOneRow();
			showOneRow.DataGridValues = dataGridView_Values;
			showOneRow.LoadRowItnoView();
			showOneRow.Show();			
		}

		//private List<ChangedCell> changedCells = null;
		//private void dataGridView_Values_RowLeave(object sender, DataGridViewCellEventArgs e)
		//{
			
		//}

		//private void dataGridView_Values_RowEnter(object sender, DataGridViewCellEventArgs e)
		//{
			
		//}

		//private void dataGridView_Values_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		//{
			//if (changedCells == null) changedCells = new List<ChangedCell>();
			//ChangedCell cc = new ChangedCell();
			//cc.RowIndex = e.RowIndex;
			//cc.ColumnIndex = e.ColumnIndex;
			//if (changedCells.Contains(cc) == false)
			//{
			//    changedCells.Add(cc);
			//}

			//DataView dv = null;
			//DataView dv_orig = null;

			//if (this.dataGridView_Values.DataSource is DataView)
			//{

			//    DataTable dt = ((DataView)this.dataGridView_Values.DataSource).Table;
			//    var b = dt.Rows[0].RowState;
			//    dv = new DataView(dt, "", "", DataViewRowState.CurrentRows);
			//    dv_orig = new DataView(dt, "", "", DataViewRowState.OriginalRows);

			//}
			//else
			//    return;

			//if (changedCells != null)
			//{
			//    foreach (ChangedCell item in changedCells)
			//    {

			//        Console.Write("[" + item.RowIndex + "," + item.ColumnIndex + "]= " + dv_orig[item.RowIndex][item.ColumnIndex] + "->" + dv[item.RowIndex][item.ColumnIndex] + "   , ");
			//    }
			//    Console.WriteLine();
			//}
		//}

		//struct ChangedCell {
		//    public int RowIndex { get; set; }
		//    public int ColumnIndex { get; set; }
		//}
	}
}
