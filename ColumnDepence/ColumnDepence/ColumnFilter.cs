using System.Collections.Generic;

namespace hackovic.DbInfo
{
	public class ColumnFilter
	{
		public string ColumnName { get; set; }
		public Dictionary<FilterRule, RuleBase> Rules { get; set; }

		public TRule Add<TRule>(TRule rule) where TRule : RuleBase
		{
			if (Rules.ContainsKey(rule.FilterRule))
			{
				Rules[rule.FilterRule] = rule;
			}
			else
			{
				Rules.Add(rule.FilterRule, rule);
			}

			return rule;
		}

		public void Remove(FilterRule fr)
		{
			if (Rules != null && Rules.ContainsKey(fr))
			{
				Rules.Remove(fr);
			}
		}

		public bool HasFilter(FilterRule fr)
		{
			if (Rules == null || Rules.Count == 0)
			{
				return false;
			}

			return Rules.ContainsKey(fr);
		}

		public string GetRuleValue(FilterRule fr)
		{
			if (Rules == null || Rules.Count == 0 || !Rules.ContainsKey(fr))
			{
				return "";
			}

			return Rules[fr].Value;
		}
	}

	public enum FilterRule
	{
		Like,
		Eq,
		NotEq,
		Less,
		Greater,
		IsNull,
		IsNotNull,
		IsTrue,
		IsFalse,
		InValues
	}

	public abstract class RuleBase
	{
		public abstract string Filter { get; }
		public FilterRule FilterRule { get; set; }
		public string ColumnName { get; set; }
		public string Value { get; set; }
	}

	public class Like : RuleBase
	{
		public Like()
		{
			FilterRule = FilterRule.Like;
		}

		public Like(string columnName, string value)
		{
			FilterRule = FilterRule.Like;
			Value = value;
			ColumnName = columnName;
		}

		public override string Filter
		{
			get { return string.Format(" ({0} LIKE '%{1}%') ", ColumnName, Value); }
		}
	}

	public class Eq : RuleBase
	{
		public Eq()
		{
			FilterRule = FilterRule.Eq;
		}

		public Eq(string columnName, string value)
		{
			FilterRule = FilterRule.Eq;
			Value = value;
			ColumnName = columnName;
		}

		public override string Filter
		{
			get { return string.Format(" ({0} = '{1}') ", ColumnName, Value); }
		}
	}

	public class NotEq : RuleBase
	{
		public NotEq()
		{
			FilterRule = FilterRule.NotEq;
		}

		public NotEq(string columnName, string value)
		{
			FilterRule = FilterRule.NotEq;
			Value = value;
			ColumnName = columnName;
		}

		public override string Filter
		{
			get { return string.Format(" ({0} <> '{1}') ", ColumnName, Value); }
		}
	}

	public class Greater : RuleBase
	{
		public Greater()
		{
			FilterRule = FilterRule.Greater;
		}

		public Greater(string columnName, string value)
		{
			FilterRule = FilterRule.Greater;
			Value = value;
			ColumnName = columnName;
		}

		public override string Filter
		{
			get { return string.Format(" ({0} > '{1}') ", ColumnName, Value); }
		}
	}

	public class Less : RuleBase
	{
		public Less()
		{
			FilterRule = FilterRule.Less;
		}

		public Less(string columnName, string value)
		{
			FilterRule = FilterRule.Less;
			Value = value;
			ColumnName = columnName;
		}

		public override string Filter
		{
			get { return string.Format(" ({0} < '{1}') ", ColumnName, Value); }
		}
	}

	public class IsNull : RuleBase
	{
		public IsNull()
		{
			FilterRule = FilterRule.IsNull;
		}

		public IsNull(string columnName)
		{
			FilterRule = FilterRule.IsNull;
			ColumnName = columnName;
		}

		public override string Filter
		{
			get { return string.Format(" ({0} IS NULL ) ", ColumnName); }
		}
	}

	public class IsNotNull : RuleBase
	{
		public IsNotNull()
		{
			FilterRule = FilterRule.IsNotNull;
		}

		public IsNotNull(string columnName)
		{
			FilterRule = FilterRule.IsNotNull;
			ColumnName = columnName;
		}

		public override string Filter
		{
			get { return string.Format(" ({0} IS NOT NULL ) ", ColumnName); }
		}
	}

	public class IsFalse : RuleBase
	{
		public IsFalse()
		{
			FilterRule = FilterRule.IsFalse;
		}

		public IsFalse(string columnName)
		{
			FilterRule = FilterRule.IsFalse;
			ColumnName = columnName;
		}

		public override string Filter
		{
			get { return string.Format(" ({0} = 0 ) ", ColumnName); }
		}
	}

	public class IsTrue : RuleBase
	{
		public IsTrue()
		{
			FilterRule = FilterRule.IsTrue;
		}

		public IsTrue(string columnName)
		{
			FilterRule = FilterRule.IsTrue;
			ColumnName = columnName;
		}

		public override string Filter
		{
			get { return string.Format(" ({0} = 1 ) ", ColumnName); }
		}
	}

	public class InValues : RuleBase
	{
		public InValues()
		{
			FilterRule = FilterRule.InValues;
			Values = new List<object>();
		}

		public List<object> Values { get; set; }

		public override string Filter
		{
			get
			{
				string filter = "";
				foreach (object item in Values)
				{
					filter += string.Format(" ({0} = '{1}') OR", ColumnName, item);
				}

				if (filter.Length > 3)
				{
					filter = filter.Substring(0, filter.Length - 3); //remove last OR
					filter = "( " + filter + " )";
				}
				return filter;
			}
		}
	}
}