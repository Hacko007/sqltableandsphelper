using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ColumnDepence
{
  public partial class FormConnectToDb : Form
  {
    public FormConnectToDb()
    {
      InitializeComponent();
      m_ConnectionHistorySetting = new StackSetting
                                     {
                                       SettingName =StackSetting.StackConnectionHistory
                                     };
      m_DatabaseHistrory = new StackSetting
                             {
                               SettingName = StackSetting.StackDatabaseHistory
                             };

      FillConnectionHistoryList();
      FillComboBoxDatabaseHistory();
      SetupWindowsAuthorization();
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
      SqlConnectionStringBuilder connBulider =
        new SqlConnectionStringBuilder
          {
            DataSource = m_comboBoxServerName.Text.Trim(),
            InitialCatalog = m_comboBoxDatabase.Text.Trim(),
            ConnectTimeout = timeout
          };

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
      if (ConnectionFactory.ConnectionString == null)
      {
        return;
      }

      m_ConnectionHistorySetting.AddValue(ConnectionFactory.ConnectionString);
      FillConnectionHistoryList();
    }

    private void FillConnectionHistoryList()
    {
      try
      {
        var connectionCollection = m_ConnectionHistorySetting.DataSource
          .Select(item => new ConnectionStringItem {SqlConnectionString = item})
          .ToList();

        // Take only distinct servers-userId values
        Dictionary<string, ConnectionStringItem> conCollDistinct = new Dictionary<string, ConnectionStringItem>();
        foreach (ConnectionStringItem connectionStringItem in connectionCollection)
        {
          if (conCollDistinct.ContainsKey(connectionStringItem.DisplayDbOnly.ToUpper()))
          {
            continue;
          }
          conCollDistinct.Add(connectionStringItem.DisplayDbOnly.ToUpper(), connectionStringItem);
        }
        m_comboBoxConnectionHistory.SelectedValueChanged -= ComboBoxConnectionHistory_SelectedValueChanged;
        m_comboBoxConnectionHistory.DataSource = conCollDistinct.Values.ToList();
        m_comboBoxConnectionHistory.DisplayMember = "DisplayDbOnly";
        m_comboBoxConnectionHistory.SelectedValueChanged += ComboBoxConnectionHistory_SelectedValueChanged;
      }
      catch
      {
      }
    }

    /// <summary>
    ///   Fill saved list with databases.
    /// </summary>
    private void FillComboBoxDatabaseHistory()
    {
      try
      {
        string selected = m_comboBoxDatabase.Text;
        m_comboBoxDatabase.AutoCompleteSource = AutoCompleteSource.ListItems;
        m_comboBoxDatabase.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        if (m_DatabaseHistrory != null && m_DatabaseHistrory.DataSource != null)
        {
          m_comboBoxDatabase.DataSource = m_DatabaseHistrory.DataSource;
        }

        m_comboBoxDatabase.Text = selected;
      }
      catch
      {
      }
    }

    public bool Connect()
    {
      try
      {
        SqlConnection conn = new SqlConnection {ConnectionString = GetConnectionString(5)};

        conn.Open();

        ConnectionFactory.ConnectionString = GetConnectionString(10000);
        UpdateConnectionHistory();
        FormMain.AfterConnect();
        return true;
      }
      catch
      {
        return false;
      }
    }

    private void FillTextBoxSuggestions()
    {
      // Database names
      RefreshDatabaseList();
      DataSet ds;
      string sqlStr;

      // Servers names
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
          catch
          {
          }
        }

        string selected = m_comboBoxServerName.Text;
        m_comboBoxServerName.AutoCompleteSource = AutoCompleteSource.ListItems;
        m_comboBoxServerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        m_comboBoxServerName.DataSource = tabStrs;
        m_comboBoxServerName.Text = selected;
      }
    }

    private void RefreshDatabaseList()
    {
      string sqlStr = "select name from  sys.databases ";
      DataSet ds = FormMain.FillDataSet(sqlStr);

      if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
      {
        DataTable dt = ds.Tables[0];
        m_DatabaseHistrory.Clear();
        foreach (DataRow row in dt.Rows)
        {
          try
          {
            m_DatabaseHistrory.AddValue(row[0].ToString());
          }
          catch
          {
          }
        }

        FillComboBoxDatabaseHistory();
      }
    }

    private void SetupWindowsAuthorization()
    {
      m_comboBoxUserName.Enabled = !m_checkBoxWindowsAuth.Checked;
      m_txtPasswordMsSql.Enabled = !m_checkBoxWindowsAuth.Checked;
      m_LabelUserName.Enabled = !m_checkBoxWindowsAuth.Checked;
      m_LabelPassword.Enabled = !m_checkBoxWindowsAuth.Checked;
    }

    private void ApplySelectedConnection()
    {
      try
      {
        if (m_comboBoxConnectionHistory.SelectedItem == null)
        {
          return;
        }

        SqlConnectionStringBuilder b =
          ((ConnectionStringItem) m_comboBoxConnectionHistory.SelectedItem).SqlConnectionStringBuilder;

        m_comboBoxServerName.Text = b.DataSource;
        m_comboBoxUserName.Text = b.UserID;
        m_txtPasswordMsSql.Text = b.Password;
        m_checkBoxWindowsAuth.Checked = b.IntegratedSecurity;
        m_comboBoxDatabase.Text = b["Initial Catalog"].ToString();
        ButtonConnect_Click(this, EventArgs.Empty);
      }
      catch
      {
      }
    }

    #region Events

    private void ButtonConnect_Click(object sender, EventArgs e)
    {
      if (Connect())
      {
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
        m_labelInfo.Text = @"Faild to connect!";
      }
    }

    private void ComboBoxConnectionHistory_SelectedValueChanged(object sender, EventArgs e)
    {
      ApplySelectedConnection();
    }


    private void CheckBoxWindowsAuth_CheckedChanged(object sender, EventArgs e)
    {
      SetupWindowsAuthorization();
    }

    private void ButtonRefreshDbNames_Click(object sender, EventArgs e)
    {
      Connect();
      RefreshDatabaseList();
    }

    #endregion
  }
}