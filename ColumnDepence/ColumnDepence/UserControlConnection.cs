using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ColumnDepence
{
	public partial class UserControlConnection : UserControl
	{
		private readonly StackSetting connectionHistorySetting;

		public UserControlConnection()
		{
			InitializeComponent();
			connectionHistorySetting = new StackSetting {SettingName = "ConnectionHistory"};

			FillConnectionHistoryList();
		}

		public ColumnDependencies FormMain
		{
			get{ return ColumnDependencies.FormMain; }
		}


		private void UpdateConnectionHistory() {

			if (ConnectionFactory.ConnectionString == null) return;

			connectionHistorySetting.AddValue(ConnectionFactory.ConnectionString);
			FillConnectionHistoryList();						
		}	
		
		private void FillConnectionHistoryList()
		{
			try
			{
				var ConnectionCollection = connectionHistorySetting.DataSource.Select(item => new ConnectionStringItem { SqlConnectionString = item }).ToList();
				m_comboBoxConnectionHistory.DataSource = ConnectionCollection;
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


		#region Events
		private void ButtonConnect_Click(object sender, EventArgs e)
		{
			if (m_comboBoxConnectionHistory.SelectedItem == null) return;
			try
			{
				ConnectionFactory.ConnectionString = ((ConnectionStringItem)m_comboBoxConnectionHistory.SelectedItem).SqlConnectionString;
				if (ConnectionFactory.OpenConnection())
				{
					FormMain.SetTitle();
				}
				else
				{
					if (ConnectionFactory.ConnectionString != null)
					{
						connectionHistorySetting.RemoveValue(ConnectionFactory.ConnectionString);
						FillConnectionHistoryList();
					}

					MessageBox.Show("Connection faild", "Connecting to " + ConnectionFactory.ShortConnectionName, MessageBoxButtons.OK);
				}
			}
			catch { }
		}
		private void ButtonNewConnection_Click(object sender, EventArgs e)
		{
			FormConnectToDb form = new FormConnectToDb();
			if (form.ShowDialog(this) == DialogResult.OK) {
				UpdateConnectionHistory();			
			}
		}
		
		/// <summary>
		/// Clear connection history
		/// </summary>		
		private void ButtonClear_Click(object sender, EventArgs e)
		{

			if (connectionHistorySetting != null)
			{
				connectionHistorySetting.Clear();
				FillConnectionHistoryList();
			}			
		}
		#endregion 

		
	}
}
