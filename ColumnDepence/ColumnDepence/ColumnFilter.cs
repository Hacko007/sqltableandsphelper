using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColumnDepence.Filters
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
			else {
				return Rules.ContainsKey(fr);
			}
		}

		public string GetRuleValue(FilterRule fr) {
			if (Rules == null || Rules.Count == 0 || !Rules.ContainsKey(fr))
			{
				return "";
			}
			else
			{
				return Rules[fr].Value;
			}
		}
	}

	public enum FilterRule
	{
		Like,
		Eq,
		Less,
		Greater,
		IsNull,
		IsNotNull,
		IsTrue,
		IsFalse
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
			this.FilterRule = FilterRule.Like;
		}
		public Like(string column_name, string value)
		{
			this.FilterRule = FilterRule.Like;
			this.Value = value;
			this.ColumnName = column_name;
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
		public Eq(string column_name, string value)
		{
			this.FilterRule = FilterRule.Eq;
			this.Value = value;
			this.ColumnName = column_name;
		}
		public override string Filter
		{
			get { return string.Format(" ({0} = '{1}') ", this.ColumnName, this.Value); }
		}
	}

	public class Greater : RuleBase
	{
		public Greater()
		{
			this.FilterRule = FilterRule.Greater;
		}
		public Greater(string column_name, string value)
		{
			this.FilterRule = FilterRule.Greater;
			this.Value = value;
			this.ColumnName = column_name;
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
		public Less(string column_name, string value)
		{
			this.FilterRule = FilterRule.Less;
			this.Value = value;
			this.ColumnName = column_name;
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
		public IsNull(string column_name)
		{
			this.FilterRule = FilterRule.IsNull;
			this.ColumnName = column_name;
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
		public IsNotNull(string column_name)
		{
			this.FilterRule = FilterRule.IsNotNull;
			this.ColumnName = column_name;
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
		public IsFalse(string column_name)
		{
			this.FilterRule = FilterRule.IsFalse;
			this.ColumnName = column_name;
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
		public IsTrue(string column_name)
		{
			this.FilterRule = FilterRule.IsTrue;
			this.ColumnName = column_name;
		}
		public override string Filter
		{
			get { return string.Format(" ({0} = 1 ) ", this.ColumnName); }
		}
	}


	/*
	 	if (m_equalToolStripMenuItem.Checked)
			{
				filter = string.Format(" {0} = '{1}' ", col, m_EqualToolStripTextBox.TextBox.Text);
			}
			if (m_LikeToolStripMenuItem.Checked)
			{
				filter += (filter == "") ? "" : " AND ";
				filter += string.Format(" ({0} LIKE '%{1}%') ", col, m_LikeToolStripTextBox.TextBox.Text);
			} 
			
			if (m_greToolStripMenuItem.Checked)
			{
				filter += (filter == "") ? "" : " AND ";
				filter += string.Format(" ({0} > '{1}') ", col, m_GraterThenToolStripTextBox.TextBox.Text);
			}
			if (m_isNotNullToolStripMenuItem.Checked)
			{
				filter += (filter == "") ? "" : " AND ";
				filter += string.Format(" ({0} is NOT NULL) ", col);
			}
			if (m_isNullToolStripMenuItem.Checked)
			{
				filter += (filter == "") ? "" : " AND ";
				filter += string.Format(" ({0} is NULL) ", col);
			}
			if (m_lessThenToolStripMenuItem.Checked)
			{
				filter += (filter == "") ? "" : " AND ";
				filter += string.Format(" ({0} < '{1}') ", col, m_LessThenToolStripTextBox2.TextBox.Text);
			}


	 */
}
