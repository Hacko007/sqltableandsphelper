using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColumnDepence.Filters;

namespace ColumnDepence.DbInfo
{
	public enum TableRelation { 
		None,
		Parent,
		Child
	}
	public class TableFilterData
	{		
		public string TableName { get; set; }
		public TableRelation  TableRelation  { get; set; }
		/// <summary>
		/// Key - Column Name
		/// Value - List of column values
		/// </summary>
		public Dictionary<string, List<object>> ColumnValues { get; set; }

		public TableFilterData()
		{
			ColumnValues = new Dictionary<string, List<object>>();
		}				

		public void Add(string columnName, object value)
		{
			if (!ColumnValues.ContainsKey(columnName))
			{
				ColumnValues.Add(columnName, new List<object>());
			}
			if (ColumnValues[columnName] == null)
			{
				ColumnValues[columnName] = new List<object>();
				ColumnValues[columnName].Add(value);
			}
			if (false == ColumnValues[columnName].Contains(value)) {
				ColumnValues[columnName].Add(value);
			}
		}

		public Dictionary<string, ColumnFilter> GetColumnFilters()
		{
			Dictionary<string, ColumnFilter>  filter_dict = new Dictionary<string, ColumnFilter>();
			
			if (ColumnValues == null || ColumnValues.Count == 0) return filter_dict;

			foreach (var column in ColumnValues)
			{
				ColumnFilter cf = new ColumnFilter() { ColumnName = column.Key };
				cf.Rules = new Dictionary<ColumnDepence.Filters.FilterRule, ColumnDepence.Filters.RuleBase>();

				if (column.Value.Count == 1) {
					cf.Rules.Add(FilterRule.Eq, new Eq()
					{
						ColumnName = column.Key,
						Value = column.Value[0].ToString()
					});
				}
				else
				{
					cf.Rules.Add(FilterRule.InValues, new InValues()
					{
						ColumnName = column.Key,
						Values = column.Value
					});				
				}
				
				filter_dict.Add(column.Key, cf);
			}

			return filter_dict;
		}
	}
}
