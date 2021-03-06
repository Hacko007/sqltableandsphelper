﻿using System.Data;

namespace hackovic.DbInfo.DbInfo
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

		public ColumnRefType GetColumnRefType(string ColumnName) {
			ColumnRefType refType = ColumnRefType.None;
			if (IsPrimaryKey(ColumnName))
				refType |= ColumnRefType.PrimaryKey;

			if (IsForeignKey(ColumnName))
				refType |= ColumnRefType.ForegnKey;

			if (IsUnique(ColumnName))
				refType |= ColumnRefType.Unique;

			return refType;
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
			Columns.Clear();
			Columns.AddRange(new[] { ColumnColumnName, ColumnConstraint, ColumnType });
		}
	}
}
