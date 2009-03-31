using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ColumnDepence.DbInfo
{
	public class  DataTableColumnConstrains  : DataTable
	{
		public const string TABLE_NAME = "ColumnConstrains";

		public bool IsDataLoaded { get; set; }

		public DataColumn ColumnColumnName { get; set; }
		public DataColumn ColumnConstraint { get; set; }
		public DataColumn ColumnType { get; set; }

		public DataTableColumnConstrains()
			: base(TABLE_NAME)
		{
			InitColumns();
			IsDataLoaded = false;
		}

		
		public bool IsPrimaryKey(string ColumnName)
		{
			return IsColumnType(ColumnName, "PRIMARY KEY");			
		}
		
		public bool IsUnique(string ColumnName)
		{
			return IsColumnType(ColumnName ,"UNIQUE");
		}

		public bool IsForeignKey(string ColumnName)
		{
			return IsColumnType(ColumnName, "FOREIGN KEY");
		}

		public bool IsColumnType(string ColumnName , string columnType)
		{

			if (Rows.Count == 0) return false;

			foreach (DataRow row in Rows)
			{
				if (row[ColumnColumnName].ToString() == ColumnName
					&& row[ColumnType].ToString().Trim() == columnType)
				{
					return true;
				}
			}
			return false;
		}
		private void InitColumns() {
			ColumnColumnName = new DataColumn("Column", typeof(string));
			ColumnConstraint = new DataColumn("Constraint", typeof(string));
			ColumnType = new DataColumn("Type", typeof(string));
			this.Columns.Clear();
			this.Columns.AddRange(new DataColumn[] { ColumnColumnName, ColumnConstraint, ColumnType });
		}
	}
}
