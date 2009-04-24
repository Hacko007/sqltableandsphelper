using System.Collections.Generic;

namespace ColumnDepence
{
	public	class ColumnFilter
	{
		public string ColumnName { get; set; }
		public Dictionary<FilterRule, RuleBase> Rules { get; set; }

		public TRule Add<TRule>(TRule rule) where TRule : RuleBase {
			if (Rules.ContainsKey(rule.FilterRule))
			{
				Rules[rule.FilterRule] = rule;
			}
			else {
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

		public bool HasFilter(FilterRule fr) {
			if (Rules == null || Rules.Count == 0)
			{
				return false;
			}
			
			return Rules.ContainsKey(fr);			
		}

		public string GetRuleValue(FilterRule fr) {
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
		public Like() {
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
			get { return string.Format(" ({0} LIKE '%{1}%') ", this.ColumnName, this.Value); }
		}
	}

	public class Eq : RuleBase
	{
		public Eq()
		{
			this.FilterRule = FilterRule.Eq;
		}
		public Eq(string columnName, string value)
		{
			this.FilterRule = FilterRule.Eq;
			this.Value = value;
			this.ColumnName = columnName;
		}
		public override string Filter
		{
			get { return string.Format(" ({0} = '{1}') ", this.ColumnName, this.Value); }
		}
	}

	public class NotEq : RuleBase
	{
		public NotEq()
		{
			this.FilterRule = FilterRule.NotEq;
		}
		public NotEq(string columnName, string value)
		{
			this.FilterRule = FilterRule.NotEq;
			this.Value = value;
			this.ColumnName = columnName;
		}
		public override string Filter
		{
			get { return string.Format(" ({0} <> '{1}') ", this.ColumnName, this.Value); }
		}
	}

	public class Greater : RuleBase
	{
		public Greater()
		{
			this.FilterRule = FilterRule.Greater;
		}
		public Greater(string columnName, string value)
		{
			this.FilterRule = FilterRule.Greater;
			this.Value = value;
			this.ColumnName = columnName;
		}
		public override string Filter
		{
			get { return string.Format(" ({0} > '{1}') ", this.ColumnName, this.Value); }
		}
	}

	public class Less : RuleBase
	{
		public Less()
		{
			this.FilterRule = FilterRule.Less;
		}
		public Less(string columnName, string value)
		{
			this.FilterRule = FilterRule.Less;
			this.Value = value;
			this.ColumnName = columnName;
		}
		public override string Filter
		{
			get { return string.Format(" ({0} < '{1}') ", this.ColumnName, this.Value); }
		}
	}

	public class IsNull : RuleBase
	{
		public IsNull()
		{
			this.FilterRule = FilterRule.IsNull;
		}
		public IsNull(string columnName)
		{
			this.FilterRule = FilterRule.IsNull;
			this.ColumnName = columnName;
		}
		public override string Filter
		{
			get { return string.Format(" ({0} IS NULL ) ", this.ColumnName); }
		}
	}

	public class IsNotNull : RuleBase
	{
		public IsNotNull()
		{
			this.FilterRule = FilterRule.IsNotNull;
		}
		public IsNotNull(string columnName)
		{
			this.FilterRule = FilterRule.IsNotNull;
			this.ColumnName = columnName;
		}
		public override string Filter
		{
			get { return string.Format(" ({0} IS NOT NULL ) ", this.ColumnName); }
		}
	}

	public class IsFalse : RuleBase
	{
		public IsFalse()
		{
			this.FilterRule = FilterRule.IsFalse;
		}
		public IsFalse(string columnName)
		{
			this.FilterRule = FilterRule.IsFalse;
			this.ColumnName = columnName;
		}
		public override string Filter
		{
			get { return string.Format(" ({0} = 0 ) ", this.ColumnName); }
		}
	}

	public class IsTrue : RuleBase
	{
		public IsTrue()
		{
			this.FilterRule = FilterRule.IsTrue;
		}
		public IsTrue(string columnName)
		{
			this.FilterRule = FilterRule.IsTrue;
			this.ColumnName = columnName;
		}
		public override string Filter
		{
			get { return string.Format(" ({0} = 1 ) ", this.ColumnName); }
		}
	}

	public class InValues : RuleBase
	{
		public List<object> Values { get; set; }
		
		public InValues()
		{
			this.FilterRule = FilterRule.InValues;
			Values = new List<object>();
		}		
		public override string Filter
		{
			get {
				string filter = "";
				foreach (object item in Values)
				{
					filter += string.Format(" ({0} = '{1}') OR", this.ColumnName, item); 
				}
				if (filter.Length > 3) {
					filter = filter.Substring(0, filter.Length - 3); //remove last OR
					filter = "( " + filter + " )";
				}
				return filter; 										
			}
		}
	}
}