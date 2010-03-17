using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ColumnDepence.DbInfo
{
	public class DataTableColumnInfo : DataTable
	{
		public const string TABLE_NAME = "ColumnInfo";

		public bool IsDataLoaded { get; set; }

		public DataColumn ColumnColumnName { get; set; }
		public DataColumn ColumnType { get; set; }
		public DataColumn ColumnNullable { get; set; }
		public DataColumn ColumnMax { get; set; }
		public DataColumn ColumnDefault { get; set; }
		public DataColumn ColumnIdentity { get; set; }

		public DataTableColumnInfo()
			: base(TABLE_NAME)
		{
			InitColumns();
			IsDataLoaded = false;
		}


		private void InitColumns()
		{
			ColumnColumnName = new DataColumn("Name", typeof(string));
			ColumnType = new DataColumn("Type", typeof(string));
			ColumnNullable = new DataColumn("Nullable", typeof(bool));
			ColumnMax = new DataColumn("Max", typeof(int));
			ColumnDefault = new DataColumn("Default", typeof(string));
			ColumnIdentity = new DataColumn("Identity", typeof(Boolean));
			this.Columns.Clear();
			this.Columns.AddRange(
				new DataColumn[] 
				{	ColumnColumnName, 
					ColumnType, 
					ColumnNullable,
					ColumnMax, 
					ColumnDefault,
					ColumnIdentity 
				});
		}

		internal void SetIdentityColumns(DataTable dataTable)
		{
			if (dataTable == null || dataTable.Rows.Count == 0) return;
			foreach (DataRow row in this.Rows)
			{
				row[ColumnIdentity] = false;
				foreach (DataRow columnIdentityRow in dataTable.Rows)
				{
					if (row[ColumnColumnName].ToString() == columnIdentityRow[0].ToString())
					{
						row[ColumnIdentity] = true;
					}
				}
			}
		}


		internal bool IsIdentityColumn(string ColumnName)
		{
			foreach (DataRow row in this.Rows)
			{
				if (row[ColumnColumnName].ToString() == ColumnName && (bool)row[ColumnIdentity])
					return true;
			}
			return false;
		}
	}
}
