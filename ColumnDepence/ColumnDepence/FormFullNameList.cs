using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ColumnDepence
{
	public partial class FormFullNameList : Form
	{
		public event EventHandler NameSelected;
		private List<string> m_StringList;

		public FormFullNameList()
		{
			InitializeComponent();
			this.DialogResult = DialogResult.None; 
			m_StringList = new List<string>();
		}



		public string SelectedName { get; set; }
		public List<string> StringList { 
			get { return m_StringList; }
			set
			{
				m_StringList = value;
				m_ListBox.DataSource = m_StringList;
				SetSize();
			}
		}



		private void RaiseNameSelected()
		{
			if (NameSelected != null)
			{
				NameSelected(this, EventArgs.Empty);
			}
		}

		private void SetSize() {
			Screen screen = Screen.FromControl(this);
			int optimalSizeHight = (StringList.Count * m_ListBox.ItemHeight) + 100;
			optimalSizeHight = Math.Min(screen.WorkingArea.Height - 50, optimalSizeHight);
			this.Height = optimalSizeHight;
			this.CenterToScreen();
		}


		private void ApplyFilter()
		{
			m_ListBox.SelectedIndexChanged -= ListBox_SelectedIndexChanged;
			string searchStr = m_TextBoxFilter.Text.Trim().ToLowerInvariant();
			if (searchStr == String.Empty)
			{
				m_ListBox.DataSource = m_StringList;
				m_ListBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;

				return;
			}

			List<string> list = (from name in StringList
								 where name.ToLowerInvariant().Contains(searchStr)
								 select name).ToList();
			m_ListBox.DataSource = list;

			m_ListBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;

		}

		private void TextBoxFilter_TextChanged(object sender, EventArgs e)
		{
			ApplyFilter();
		}

		private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedName = m_ListBox.SelectedItem.ToString ();
			DialogResult = DialogResult.OK;
			RaiseNameSelected();
		}

		
	}
}
