using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ColumnDepence.DbInfo
{
	public class DataTableReferencedColumnTable : DataTable
	{
		public const string TABLE_NAME = "ReferencedColumnTable";
		public bool IsDataLoaded { get; set; }

		public DataColumn ColumnParentColumnName { get; set; }
		public DataColumn ColumnChildColumnName { get; set; }
		public DataColumn ColumnTableName { get; set; }

		public DataTableReferencedColumnTable()
			: base(TABLE_NAME)
		{
			InitColumns();
			IsDataLoaded = false;
		}

		public DataRow[] FindChilds(string ParentColumnName)
		{
			return Select(this.ColumnParentColumnName.ColumnName + "='" + ParentColumnName + "'");			
		}
		public DataRow[] FindParents(string ChildColumnName)
		{
			return Select(this.ColumnChildColumnName.ColumnName + "='" + ChildColumnName + "'");			
		}

		private void InitColumns()
		{
			ColumnParentColumnName = new DataColumn("Parent_Column", typeof(string));
			ColumnParentColumnName.Caption = "Parent";

			ColumnChildColumnName = new DataColumn("Referenced_Column", typeof(string));
			ColumnChildColumnName.Caption = "Child";			

			ColumnTableName = new DataColumn("TableName", typeof(string));
			ColumnTableName.Caption = "Table";

			this.Columns.Clear();
			this.Columns.AddRange(new DataColumn[] { ColumnTableName, ColumnParentColumnName, ColumnChildColumnName });
		}

		public void SetColumns(DataGridView dataGridView) {

			if (dataGridView == null) return;
			try
			{
				dataGridView.Columns[0].HeaderText = ColumnTableName.Caption ;
				dataGridView.Columns[1].HeaderText = ColumnParentColumnName.Caption;
				dataGridView.Columns[2].HeaderText = ColumnChildColumnName.Caption;

				dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
				dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;

				dataGridView.Columns[1].ContextMenuStrip = null;
				dataGridView.Columns[2].ContextMenuStrip = null;
			}
			catch { }
		}
	}
}
