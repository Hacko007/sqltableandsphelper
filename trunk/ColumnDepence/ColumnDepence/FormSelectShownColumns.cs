using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ColumnDepence
{
	public partial class FormSelectShownColumns : Form
	{

		public List<string> AllColumns { get; set; }
		public List<string> ShownColumns { get; set; }	

		public FormSelectShownColumns()
		{
			InitializeComponent();
			AllColumns = new List<string>();
			ShownColumns = new List<string>();
		}

		public void InitColumns() {
			m_checkedListBoxSelectedColumns.Items.Clear();

			foreach (string item in AllColumns)
			{
				bool selected = (ShownColumns != null && ShownColumns.Contains(item));
				m_checkedListBoxSelectedColumns.Items.Add(item, selected);
			}
		}

		private void RadioButtonAll_CheckedChanged(object sender, EventArgs e)
		{
			if (m_checkedListBoxSelectedColumns.Items.Count <= 0) return;

			for (int i = 0; i < m_checkedListBoxSelectedColumns.Items.Count; i++)
			{
				m_checkedListBoxSelectedColumns.SetItemChecked(i, true);
			}
		}

		private void RadioButtonNone_CheckedChanged(object sender, EventArgs e)
		{
			if (m_checkedListBoxSelectedColumns.Items.Count <= 0) return;

			for (int i = 0; i < m_checkedListBoxSelectedColumns.Items.Count; i++)
			{
				m_checkedListBoxSelectedColumns.SetItemChecked(i, false);
			}
		}

		private void ButtonOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			ShownColumns = new List<string>();
			foreach (var item in m_checkedListBoxSelectedColumns.CheckedItems)
			{
				ShownColumns.Add(item.ToString());
			}
			Close();
		}
	}
}
