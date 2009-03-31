﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColumnDepence.DbInfo
{
	public class TableFilterDataCollection
	{
		public TableFilterDataCollection()
		{
			Tables = new Dictionary<string, TableFilterData>();
		}

		public Dictionary<string, TableFilterData> Tables { get; set; }

	
		public void Add(string tableName, string columnName, object cellValue, TableRelation tableRelation)
		{
			if (!Tables.ContainsKey(tableName))
			{
				Tables.Add(tableName, new TableFilterData { TableName = tableName});
			}
			Tables[tableName].Add(columnName, cellValue);
			Tables[tableName].TableRelation = tableRelation;
		}
	}
}
