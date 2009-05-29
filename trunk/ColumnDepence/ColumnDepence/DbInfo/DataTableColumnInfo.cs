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
		public DataColumn ColumnType{ get; set; }
		public DataColumn ColumnNullable { get; set; }
		public DataColumn ColumnMax { get; set; }
		public DataColumn ColumnDefault { get; set; }

		public DataTableColumnInfo()
			: base(TABLE_NAME)
		{
			InitColumns();
			IsDataLoaded = false;
		}


	private void InitColumns() {
			ColumnColumnName = new DataColumn("Name", typeof(string));
			ColumnType= new DataColumn("Type", typeof(string));
			ColumnNullable = new DataColumn("Nullable", typeof(bool));
			ColumnMax= new DataColumn("Max", typeof(int));
			ColumnDefault= new DataColumn("Default", typeof(string));
			this.Columns.Clear();
			this.Columns.AddRange(
				new DataColumn[] 
				{	ColumnColumnName, 
					ColumnType, 
					ColumnNullable,
					ColumnMax, 
					ColumnDefault
				});
		}
	}
}
