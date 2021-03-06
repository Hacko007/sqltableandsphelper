﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace hackovic.DbInfo
{
	public partial class FormFullNameList : Form
	{
		public event EventHandler NameSelected;
		private List<string> m_StringList;

		public FormFullNameList()
		{
			InitializeComponent();
			DialogResult = DialogResult.None; 
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
			Height = optimalSizeHight;
			CenterToScreen();
		}


		internal void ApplyFilter()
		{
			string searchStr = m_TextBoxFilter.Text.Trim().ToLowerInvariant();
			if (searchStr == String.Empty)
			{
				m_ListBox.DataSource = m_StringList;
				return;
			}

			List<string> list = (from name in StringList
								 where name.ToLowerInvariant().Contains(searchStr)
								 select name).ToList();
			m_ListBox.DataSource = list;
		}

		private void TextBoxFilter_TextChanged(object sender, EventArgs e)
		{
			ApplyFilter();
		}

		private void SelectName()
		{
			if (m_ListBox.SelectedItem != null)
			{
				DialogResult = DialogResult.OK;
				SelectedName = m_ListBox.SelectedItem.ToString();				
				RaiseNameSelected();
				
			}
		}

		
		/// <summary>
		///  Select selected item when user doubleclicks on it.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			SelectName();
		}


		/// <summary>
		/// Select selected item when user press Enter or Return.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ListBox_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{				
				case Keys.Return:
					SelectName();
					e.Handled = true;
					break;
				default:
					e.Handled = false;
					break;
			}
		}

		private void ButtonClearClick(object sender, EventArgs e)
		{
			m_TextBoxFilter.Text = String.Empty;
			m_TextBoxFilter.Focus();
		}

		
	}
}
