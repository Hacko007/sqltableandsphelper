using System;
using System.Windows.Forms;

namespace ColumnDepence
{
	public partial class UserControlHistoryList : UserControl
	{
		public delegate void SelectedIndexChangedHandler(object sender, string value);

		private string m_SettingName ;

		public UserControlHistoryList()
		{
			InitializeComponent();
			m_SettingName = null;
			m_DataSource = new StackSetting {MaxSize = 30};
		}

		public string SettingName
		{
			get { return m_SettingName; }

			set
			{
				m_SettingName = value;
				m_DataSource.SettingName = value;
				m_ComboBoxLatestUsed.DataSource = m_DataSource.DataSource;
			}
		}

		public event SelectedIndexChangedHandler SelectedIndexChanged;

		public void AddValue(string value)
		{
			m_DataSource.AddValue(value);
			m_ComboBoxLatestUsed.DataSource = m_DataSource.DataSource;
		}

		private void RaiseSelectedIndexChanged()
		{
			if (SelectedIndexChanged != null)
			{
				SelectedIndexChanged(this, m_ComboBoxLatestUsed.SelectedValue.ToString());
			}
		}

		private void m_comboBox_LatestUsed_SelectedIndexChanged(object sender, EventArgs e)
		{
			RaiseSelectedIndexChanged();
		}
	}
}