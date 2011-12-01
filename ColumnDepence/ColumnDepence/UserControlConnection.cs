using System;
using System.Linq;
using System.Windows.Forms;

namespace ColumnDepence
{
	public partial class UserControlConnection : UserControl
	{
		private readonly StackSetting m_connectionHistorySetting;

		public UserControlConnection()
		{
			InitializeComponent();
			m_connectionHistorySetting = new StackSetting {SettingName = StackSetting.StackConnectionHistory };

			FillConnectionHistoryList();
		}

		public ColumnDependencies FormMain
		{
			get{ return ColumnDependencies.FormMain; }
		}


		private void UpdateConnectionHistory() {

			if (ConnectionFactory.ConnectionString == null) return;

			m_connectionHistorySetting.AddValue(ConnectionFactory.ConnectionString);
			FillConnectionHistoryList();						
		}	
		
		private void FillConnectionHistoryList()
		{
			try
			{
				var connectionCollection = m_connectionHistorySetting.DataSource.Select(item => new ConnectionStringItem { SqlConnectionString = item }).ToList();
				m_comboBoxConnectionHistory.DataSource = connectionCollection;
				m_comboBoxConnectionHistory.DisplayMember = "Display";
			}
			catch { }
			
		}


		protected override bool ProcessDialogKey(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.F9:
					ButtonConnect_Click(null, EventArgs.Empty);
					break;
				default:
					if (keyData == Keys.Return && ContainsFocus)
					{
						foreach (Control control in Controls)
						{
							if (control.ContainsFocus)
							{
							 return	FocusNextTextBox(control);
							}
						}

					}
					break;
			}

			return base.ProcessDialogKey(keyData);
		}

		bool FocusNextTextBox(Control ctrl)
		{
			if(ctrl == null || (ctrl is Button)) return false;
			
			if(ctrl.Focused)
			{
				Control next = GetNextControl(ctrl, true);
				if(next ==null) return false;
				next.Focus();
				if (next is TextBox) return true; 

				return FocusNextTextBox(next);
			}
			foreach (Control control in  ctrl.Controls)
			{				
				if (control.ContainsFocus)
				{
					return FocusNextTextBox(control);
				}
			}
			return false;
		}

		private void CreeateNewConnection()
		{
			FormConnectToDb form = new FormConnectToDb();
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				UpdateConnectionHistory();
			}
		}

		private void Connect()
		{
			if (m_comboBoxConnectionHistory.SelectedItem == null) return;
			try
			{
				ConnectionFactory.ConnectionString = ((ConnectionStringItem)m_comboBoxConnectionHistory.SelectedItem).SqlConnectionString;
				if (ConnectionFactory.OpenConnection())
				{
					FormMain.SetTitle();
					FormMain.AfterConnect();
				}
				else
				{
					if (ConnectionFactory.ConnectionString != null)
					{
						m_connectionHistorySetting.Remove(ConnectionFactory.ConnectionString);
						FillConnectionHistoryList();
					}

					MessageBox.Show("Connection faild", "Connecting to " + ConnectionFactory.ShortConnectionName, MessageBoxButtons.OK);
				}
			}
			catch { }
		}

		private void RemoveSelectedConnection()
		{
			if (m_connectionHistorySetting == null || m_comboBoxConnectionHistory.SelectedIndex < 0) return;

			try
			{
				m_connectionHistorySetting.Remove(m_comboBoxConnectionHistory.SelectedIndex);
				FillConnectionHistoryList();
			}
			catch
			{
			}
		}



		#region Events
		private void ButtonConnect_Click(object sender, EventArgs e)
		{
			Connect();
		}

		
		private void ButtonNewConnection_Click(object sender, EventArgs e)
		{
			CreeateNewConnection();
		}

		
		/// <summary>
		/// Remove selected connection history
		/// </summary>		
		private void ButtonRemove_Click(object sender, EventArgs e)
		{
			RemoveSelectedConnection();
		}


		#endregion 

		
	}
}
