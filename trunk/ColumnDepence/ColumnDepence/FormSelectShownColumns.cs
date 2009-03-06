using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

		private void m_radioButtonAll_CheckedChanged(object sender, EventArgs e)
		{
			if (m_checkedListBoxSelectedColumns.Items.Count > 0) {
				for (int i = 0; i < m_checkedListBoxSelectedColumns.Items.Count; i++)
				{
					m_checkedListBoxSelectedColumns.SetItemChecked(i, true);
				}
			}
		}

		private void m_radioButtonNone_CheckedChanged(object sender, EventArgs e)
		{
			if (m_checkedListBoxSelectedColumns.Items.Count > 0)
			{
				for (int i = 0; i < m_checkedListBoxSelectedColumns.Items.Count; i++)
				{
					m_checkedListBoxSelectedColumns.SetItemChecked(i, false);
				}
			}
		}

		private void m_buttonOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;

			ShownColumns = new List<string>();
			foreach (var item in m_checkedListBoxSelectedColumns.CheckedItems)
			{
				ShownColumns.Add(item.ToString());
			}
			Close();
		}
	}
}
