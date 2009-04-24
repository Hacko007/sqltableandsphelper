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

		public DataRow[] FindChilds(string parentColumnName)
		{
			return Select(ColumnParentColumnName.ColumnName + "='" + parentColumnName + "'");			
		}
		public DataRow[] FindParents(string childColumnName)
		{
			return Select(ColumnChildColumnName.ColumnName + "='" + childColumnName + "'");			
		}

		private void InitColumns()
		{
			ColumnParentColumnName = new DataColumn("Parent_Column", typeof(string))
			                         	{
			                         		Caption = "Parent column"
			                         	};

			ColumnChildColumnName = new DataColumn("Referenced_Column", typeof(string))
			                        	{
			                        		Caption = "Child column"
			                        	};

			ColumnTableName = new DataColumn("TableName", typeof(string))
			                  	{
			                  		Caption = "Table"
			                  	};

			Columns.Clear();
			Columns.AddRange(new[] { ColumnTableName, ColumnParentColumnName, ColumnChildColumnName });
		}

		public void SetColumns(DataGridView dataGridView) {

			if (dataGridView == null) return;
			try
			{
				dataGridView.Columns[0].HeaderText = ColumnTableName.Caption ;
				dataGridView.Columns[1].HeaderText = ColumnParentColumnName.Caption;
				dataGridView.Columns[2].HeaderText = ColumnChildColumnName.Caption;

				dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
				dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

				dataGridView.Columns[1].ContextMenuStrip = null;
				dataGridView.Columns[2].ContextMenuStrip = null;
			}
			catch
			{ }
		}
	}
}
