using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ColumnDepence
{
	public partial class UserControlConnection : UserControl
	{
		private readonly StackSetting connectionHistorySetting;
		SqlConnection mssql_connection;

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

		public string GetConnectionString() {
			return GetConnectionString(10000);
		}

		private string GetConnectionString(int timeout)
		{			
			return string.Format("server={0};user id={1};password={2};initial catalog={3};Connect Timeout={4}"
				, m_txtServerNameMsSql.Text.Trim()
				, m_txtUsernameMsSql.Text.Trim()
				, m_txtPasswordMsSql.Text.Trim()
				, m_txtDatabaseNameMsSql.Text.Trim()
				, timeout
				);

		}



		private void UpdateConnectionHistory() {

			if (ConnectionFactory.ConnectionString == null) return;

			connectionHistorySetting.AddValue(ConnectionFactory.ConnectionString);
			FillConnectionHistoryList();						
		}	
		
		private void FillConnectionHistoryList()
		{			
			m_toolStripComboBox_ConnectionHistory.Items.Clear();
			m_toolStripComboBox_ConnectionHistory.Items.AddRange(connectionHistorySetting.DataSource);
			
		}

		public bool Connect()
		{
			SqlConnection conn = new SqlConnection {ConnectionString = GetConnectionString(5)};

			try
			{
				conn.Open();

				ConnectionFactory.ConnectionString = GetConnectionString(10000);
				mssql_connection = ConnectionFactory.Instance;
				return true;
			}
			catch
			{
				return false;
			}
		}


		protected override bool ProcessDialogKey(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.F9:
					button_TestConnect_Click(null, EventArgs.Empty);
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
		private void button_TestConnect_Click(object sender, EventArgs e)
		{
			m_label_testconnection.Text = "Connecting...";
			if (Connect())
			{
				m_label_testconnection.Text = "Connection OK";
				UpdateConnectionHistory();
				FormMain.FillAutoCompleteCustomSource();
				FillTextBoxSuggestions();
				mssql_connection.Close();
			}
			else
			{
				m_label_testconnection.Text = "Faild to connect!";
			}
		}

		private void FillTextBoxSuggestions()
		{

			/// Database names
			string sql_str = "select name from  sys.databases ";
			DataSet ds = FormMain.FillDataSet(sql_str);

			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				DataTable dt = ds.Tables[0];
				AutoCompleteStringCollection tab_strs = new AutoCompleteStringCollection();
				foreach (DataRow row in dt.Rows)
				{
					try
					{
						tab_strs.Add(row[0].ToString());
					}
					catch { }
				}
				m_txtDatabaseNameMsSql.AutoCompleteCustomSource = tab_strs;
			}

			/// Servers names
			sql_str = "select name from  sys.servers ";
			ds = FormMain.FillDataSet(sql_str);

			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				DataTable dt = ds.Tables[0];
				AutoCompleteStringCollection tab_strs = new AutoCompleteStringCollection();
				foreach (DataRow row in dt.Rows)
				{
					try
					{
						tab_strs.Add(row[0].ToString());
					}
					catch { }
				}
				m_txtServerNameMsSql.AutoCompleteCustomSource = tab_strs;
			}

		}

		/// <summary>
		/// Apply values from connection history on textbox
		/// </summary>		
		private void toolStripMenuItem_Apply_Click(object sender, EventArgs e)
		{
			try
			{
				if (m_toolStripComboBox_ConnectionHistory.SelectedItem != null)
				{
					if (mssql_connection == null)
					{
						mssql_connection = new SqlConnection();
					}
					mssql_connection.ConnectionString = m_toolStripComboBox_ConnectionHistory.SelectedItem.ToString();

					SqlConnectionStringBuilder b = new SqlConnectionStringBuilder(mssql_connection.ConnectionString);
					

					m_txtServerNameMsSql.Text = b.DataSource;
					m_txtUsernameMsSql.Text = b.UserID;
					//txtPasswordMsSql.Text = b.Password;
					m_txtDatabaseNameMsSql.Text = b.InitialCatalog;
					button_TestConnect_Click(this, EventArgs.Empty);
				}
			}
			catch (Exception)
			{
			}
		}
		/// <summary>
		/// Clear connection history
		/// </summary>		
		private void toolStripMenuItem_Clear_Click(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.ConnectionHistory != null)
			{
				m_toolStripComboBox_ConnectionHistory.Items.Clear();
			}
		}
		#endregion 
	}
}
