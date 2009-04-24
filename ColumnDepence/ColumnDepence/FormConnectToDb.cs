using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ColumnDepence
{
	public partial class FormConnectToDb : Form
	{

		public FormConnectToDb()
		{
			InitializeComponent();
			connectionHistorySetting = new StackSetting
			                           	{
			                           		SettingName = "ConnectionHistory"
			                           	};

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
				var connectionCollection = connectionHistorySetting.DataSource
					.Select(item => new ConnectionStringItem {SqlConnectionString = item})					
					.ToList();
				
				/// Take only distinct servers-userId values
				Dictionary<string,ConnectionStringItem> conCollDistinct =new Dictionary<string, ConnectionStringItem>();				
				foreach (ConnectionStringItem connectionStringItem in connectionCollection)
				{
					if(conCollDistinct.ContainsKey(connectionStringItem.DisplayDbOnly.ToUpper() ))	continue;					
					conCollDistinct.Add(connectionStringItem.DisplayDbOnly.ToUpper(), connectionStringItem);
				}
				m_comboBoxConnectionHistory.SelectedValueChanged -= ComboBoxConnectionHistory_SelectedValueChanged;
				m_comboBoxConnectionHistory.DataSource = conCollDistinct.Values.ToList();
				m_comboBoxConnectionHistory.DisplayMember = "DisplayDbOnly";
				m_comboBoxConnectionHistory.SelectedValueChanged += ComboBoxConnectionHistory_SelectedValueChanged;

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

		private void FillTextBoxSuggestions()
		{

			/// Database names
			string sqlStr = "select name from  sys.databases ";
			DataSet ds = FormMain.FillDataSet(sqlStr);

			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				DataTable dt = ds.Tables[0];
				AutoCompleteStringCollection tabStrs = new AutoCompleteStringCollection();
				foreach (DataRow row in dt.Rows)
				{
					try
					{
						tabStrs.Add(row[0].ToString());
					}
					catch { }
				}

				string selected = m_comboBoxDatabase.Text;
				m_comboBoxDatabase.AutoCompleteSource = AutoCompleteSource.ListItems;
				m_comboBoxDatabase.AutoCompleteMode= AutoCompleteMode.SuggestAppend;
				m_comboBoxDatabase.DataSource = tabStrs;
				m_comboBoxDatabase.Text = selected;

			}

			/// Servers names
			sqlStr = "select name from  sys.servers ";
			ds = FormMain.FillDataSet(sqlStr);

			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				DataTable dt = ds.Tables[0];
				AutoCompleteStringCollection tabStrs = new AutoCompleteStringCollection();
				foreach (DataRow row in dt.Rows)
				{
					try
					{
						tabStrs.Add(row[0].ToString());
					}
					catch { }
				}

				string selected = m_comboBoxServerName.Text;
				m_comboBoxServerName.AutoCompleteSource = AutoCompleteSource.ListItems;
				m_comboBoxServerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				m_comboBoxServerName.DataSource = tabStrs;
				m_comboBoxServerName.Text = selected;

			}

		}



		private void ButtonConnect_Click(object sender, EventArgs e)
		{
			if (Connect()) {
				if (m_comboBoxDatabase.Text.Trim() != "")
				{
					DialogResult = DialogResult.OK;
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
				if (m_comboBoxConnectionHistory.SelectedItem == null) return;

				SqlConnectionStringBuilder b =
					((ConnectionStringItem) m_comboBoxConnectionHistory.SelectedItem).SqlConnectionStringBuilder;

				m_comboBoxServerName.Text = b.DataSource;
				m_comboBoxUserName.Text = b.UserID;
				m_txtPasswordMsSql.Text = b.Password;
				m_comboBoxDatabase.Text = ""; // b.InitialCatalog;
				ButtonConnect_Click(this, EventArgs.Empty);
			}
			catch
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
