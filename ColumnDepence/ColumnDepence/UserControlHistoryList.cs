using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace ColumnDepence
{
	

	public partial class UserControlHistoryList : UserControl
	{
		public delegate void SelectedIndexChangedHandler(object sender , string value);	
		public event SelectedIndexChangedHandler SelectedIndexChanged;

		private StackSetting dataSource;

		public UserControlHistoryList()
		{
			InitializeComponent();
			this.dataSource = new StackSetting();
			this.dataSource.MaxSize = 30;
		}

		public void AddValue(string value) {
			dataSource.AddValue(value);
			m_comboBox_LatestUsed.DataSource = dataSource.DataSource;
		}

		private void RaiseSelectedIndexChanged() {
			if (SelectedIndexChanged != null) {
				SelectedIndexChanged(this, m_comboBox_LatestUsed.SelectedValue.ToString());
			}
		}

		private string m_SettingName = null;

		public string SettingName
		{
			get { return m_SettingName; }

			set
			{
				this.m_SettingName = value;
				this.dataSource.SettingName = value;
				this.dataSource.FillTableHistoryList();
				this.m_comboBox_LatestUsed.DataSource = this.dataSource.DataSource;

			}
		}

		private void m_comboBox_LatestUsed_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.RaiseSelectedIndexChanged();
		}
	}
}
