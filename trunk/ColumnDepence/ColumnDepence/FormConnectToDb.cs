using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ColumnDepence
{
	public partial class FormConnectToDb : Form
	{
		private readonly StackSetting connectionHistorySetting;
		SqlConnection mssql_connection;

		public FormConnectToDb()
		{
			InitializeComponent();
			connectionHistorySetting = new StackSetting { SettingName = "ConnectionHistory" };

			FillConnectionHistoryList();
		}

		public ColumnDependencies FormMain
		{
			get { return ColumnDependencies.FormMain; }
		}

		public string GetConnectionString()
		{
			return GetConnectionString(10000);
		}

		private string GetConnectionString(int timeout)
		{
			SqlConnectionStringBuilder connBulider = new SqlConnectionStringBuilder();

			connBulider.DataSource = m_comboBoxServerName.Text.Trim();
			connBulider.InitialCatalog = m_comboBoxDatabase.Text.Trim();
			connBulider.ConnectTimeout = timeout;

			if (m_checkBoxWindowsAuth.Checked)
			{
				connBulider.IntegratedSecurity = true;								
			}
			else
			{
				connBulider.IntegratedSecurity = false;
				connBulider.UserID = m_comboBoxUserName.Text.Trim();
				connBulider.Password = m_txtPasswordMsSql.Text.Trim();
			}
			return connBulider.ConnectionString;
		}

		private void UpdateConnectionHistory()
		{

			if (ConnectionFactory.ConnectionString == null) return;

			connectionHistorySetting.AddValue(ConnectionFactory.ConnectionString);
			FillConnectionHistoryList();
		}

		private void FillConnectionHistoryList()
		{
			try
			{
				m_comboBoxConnectionHistory.Items.Clear();
				m_comboBoxConnectionHistory.Items.AddRange(connectionHistorySetting.DataSource);
			}
			catch { }

		}

		public bool Connect()
		{
			try
			{
				SqlConnection conn = new SqlConnection { ConnectionString = GetConnectionString(5) };

				conn.Open();

				ConnectionFactory.ConnectionString = GetConnectionString(10000);
				mssql_connection = ConnectionFactory.Instance;
				UpdateConnectionHistory();
				FormMain.FillAutoCompleteCustomSource();
				FormMain.SetTitle();
				return true;
			}
			catch
			{
				return false;
			}
		}

		bool FocusNextTextBox(Control ctrl)
		{
			if (ctrl == null || (ctrl is Button)) return false;

			if (ctrl.Focused)
			{
				Control next = GetNextControl(ctrl, true);
				if (next == null) return false;
				next.Focus();
				if (next is TextBox) return true;

				return FocusNextTextBox(next);
			}
			foreach (Control control in ctrl.Controls)
			{
				if (control.ContainsFocus)
				{
					return FocusNextTextBox(control);
				}
			}
			return false;
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

				string selected = m_comboBoxDatabase.Text;
				m_comboBoxDatabase.DataSource= tab_strs;
				m_comboBoxDatabase.Text = selected;

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

				string selected = m_comboBoxServerName.Text;
				m_comboBoxServerName.DataSource= tab_strs;
				m_comboBoxServerName.Text = selected;

			}

		}



		private void ButtonConnect_Click(object sender, EventArgs e)
		{
			if (Connect()) {
				if (m_comboBoxDatabase.Text.Trim() != "")
				{
					this.DialogResult = DialogResult.OK;
				}
				else
				{
					FillTextBoxSuggestions();
				}
			}
			else
			{
				m_labelInfo.Text = "Faild to connect!";
			}
		}

		private void ComboBoxConnectionHistory_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (m_comboBoxConnectionHistory.SelectedItem != null)
				{
					if (mssql_connection == null)
					{
						mssql_connection = new SqlConnection();
					}
					mssql_connection.ConnectionString = m_comboBoxConnectionHistory.SelectedItem.ToString();

					SqlConnectionStringBuilder b = new SqlConnectionStringBuilder(mssql_connection.ConnectionString);


					m_comboBoxServerName.Text = b.DataSource;
					m_comboBoxUserName.Text = b.UserID;
					m_txtPasswordMsSql.Text = b.Password;
					m_comboBoxDatabase.Text = b.InitialCatalog;
					ButtonConnect_Click(this, EventArgs.Empty);
				}
			}
			catch (Exception)
			{
			}
		}

		private void CheckBoxWindowsAuth_CheckedChanged(object sender, EventArgs e)
		{
			m_comboBoxUserName.Enabled = !m_checkBoxWindowsAuth.Checked;
			m_txtPasswordMsSql.Enabled = !m_checkBoxWindowsAuth.Checked;
		}

		private void Controls_Leave(object sender, EventArgs e)
		{

		}
	}
}
