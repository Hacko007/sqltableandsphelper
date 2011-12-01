using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ColumnDepence
{
  public partial class FormQuery : Form
  {
    private StackSetting m_connectionHistorySetting;

    public FormQuery()
    {
      InitializeComponent();
      ResetStatus();

      m_SplitContainerMain.Panel2Collapsed = true;
      FillConnectionComboBox();
    }

   

    protected SqlConnection Connection { get; set; }


    private void FormQuery_Load( object sender, EventArgs e )
    {
      TopMost = true;
      BringToFront();
      TopMost = false;
    }

    private void ResetStatus()
    {
      m_StatusTime.Text = "";
      m_StatusConnection.Text = @"Not connected";
      m_StatuNrRows.Text = "";

      m_StatusTime.DisplayStyle = ToolStripItemDisplayStyle.Text;
      m_StatusConnection.DisplayStyle = ToolStripItemDisplayStyle.Text;
      m_StatuNrRows.DisplayStyle = ToolStripItemDisplayStyle.Text;
    }


    private void FillConnectionComboBox()
    {
      m_connectionHistorySetting = new StackSetting
                                     {
                                       SettingName = StackSetting.StackConnectionHistory
                                     };
      try
      {
        var connectionCollection = m_connectionHistorySetting.DataSource.Select(item => new ConnectionStringItem
                                                                                          {
                                                                                            SqlConnectionString = item
                                                                                          }).ToList();
        m_ToolStripComboBoxConnection.ComboBox.DataSource = connectionCollection;
        m_ToolStripComboBoxConnection.ComboBox.DisplayMember = "Display";
      }
      catch
      {
      }
    }


    private bool Connect()
    {
      ResetStatus();
      Text = "Sql Query";
      if (m_ToolStripComboBoxConnection.ComboBox.SelectedItem == null)
      {
        return false;
      }

      string sqlConnectionString = "";
      try
      {
        sqlConnectionString =
          ((ConnectionStringItem) m_ToolStripComboBoxConnection.ComboBox.SelectedItem).SqlConnectionString;

        if (Connection == null || Connection.ConnectionString != sqlConnectionString)
        {
          Connection = new SqlConnection(sqlConnectionString);
        }

        if (Connection.State == ConnectionState.Closed)
        {
          Connection.Open();

          Text = "Sql Query - " + Connection.Database;
          m_StatusConnection.Text = @"Connected to "  +Connection.Database;
          m_StatusConnection.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
          return true;
        }
      }
      catch
      {
        MessageBox.Show(@"Connection faild for:" + Environment.NewLine + sqlConnectionString, @"Connection faild ",
                        MessageBoxButtons.OK);
        return false;
      }
      return false;
    }

    private void CloseConnection()
    {
      if (Connection != null && Connection.State != ConnectionState.Closed)
      {
        Connection.Close();
      }
    }


    private void OnSplitContainerMainDoubleClick(object sender, EventArgs e)
    {
    }

    private void OnExecuteClick(object sender, EventArgs e)
    {
      try
      {
        bool connected = Connect();
        if (!connected)
        {
          return;
        }
        Stopwatch watch = Stopwatch.StartNew();
        SqlCommand cmd = new SqlCommand(m_sqlRichTextBox.Text, Connection);


        // 
        // Execute command
        // 
        var dataSetResult = new DataSet();
        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        {
          try
          {
            adapter.Fill(dataSetResult);
            watch.Stop();
            m_StatusTime.Text = watch.Elapsed.ToString();
            m_StatusTime.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
          }
          catch (SqlException exception)
          {
            MessageBox.Show(exception.Message);
            return;
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
            return;
          }
        }

        if (dataSetResult.Tables.Count == 0)
        {
          const string columnName = "No Value";
          dataSetResult.Tables.Add(columnName).Columns.Add(columnName);
          dataSetResult.Tables[columnName].Rows.Add("No value returned");
        }

        // 
        // Place result on window
        //         
        DisplayResultInSplitPanels(dataSetResult);
        m_SplitContainerMain.Panel2Collapsed = false;

        // Count Rows
        int i = dataSetResult.Tables.Cast<DataTable>().Sum(table => table.Rows.Count);
        m_StatuNrRows.Text = string.Format("Total: {0} rows", i);
        m_StatuNrRows.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

      }
      finally
      {
        CloseConnection();
      }
    }

    private void DisplayResultInSplitPanels(DataSet dataSetResult)
    {
      m_SplitContainerMain.Panel2.Controls.Clear();

      var splitPanel = new SplitContainer
                         {
                           Dock = DockStyle.Fill,
                           Orientation = Orientation.Horizontal
                         };
      m_SplitContainerMain.Panel2.Controls.Add(splitPanel);

      FillSplitPanel(dataSetResult, splitPanel, 0);
    }

    private static void FillSplitPanel(DataSet dataSet, SplitContainer splitPanel, int fromTableIndex)
    {
      if (dataSet.Tables.Count < fromTableIndex)
      {
        return;
      }
      DataGridView dataGrid = GetDataGridView(dataSet.Tables[fromTableIndex]);

      // Last table
      if (dataSet.Tables.Count == fromTableIndex + 1)
      {
        splitPanel.Panel1.Controls.Add(dataGrid);
        splitPanel.Panel2Collapsed = true;
        return;
      }

      var splitPanelRec = new SplitContainer
                            {
                              Dock = DockStyle.Fill,
                              Orientation = Orientation.Horizontal
                            };
      splitPanel.Panel1.Controls.Add(dataGrid);
      splitPanel.Panel2.Controls.Add(splitPanelRec);

      // recursive call
      FillSplitPanel(dataSet, splitPanelRec, fromTableIndex + 1);
    }

    private static DataGridView GetDataGridView(DataTable table)
    {
      var dataGrid = new DataGridView
                       {
                         DataSource = table,
                         Dock = DockStyle.Fill,
                         AutoSize = true,
                         AllowUserToAddRows = false,
                         AllowUserToDeleteRows = false,
                         AllowUserToResizeRows = true,
                       };
      dataGrid.DataError += delegate { };
      return dataGrid;
    }

   
  }
}