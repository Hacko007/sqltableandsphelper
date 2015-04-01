using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using hackovic.DbInfo.DbInfo;
using hackovic.DbInfo.Properties;

namespace hackovic.DbInfo
{
    /// <summary>
    ///     Show inforamtion about stored procedures.
    /// </summary>
    public partial class UserControlSpInfo : UserControl
    {
        public UserControlSpInfo()
        {
            InitializeComponent();
            SpName = SpName ?? "";
            SpInfo = new SpInfo(SpName);
            m_tryToLoadCounter = 1;
            RichTextBoxDefinition.AutoWordSelection = true;
            RichTextBoxDefinition.ZoomFactor = 1.2f;
            ShowDependenciesInfo = false;
            m_SplitContainerMain.Panel1Collapsed = true;
        }

        public event TabPageDelegate CloseTabPage;
        public event OpenTableDelegate OpenTableTab;
        public event OpenSpDelegate OpenSpTab;

        /// <summary>
        ///     Fill controls values
        /// </summary>
        internal void InitControl()
        {
            SpName = SpName.Replace("dbo.", "");
            SpInfo = new SpInfo(SpName);

            Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            FillParameters();
            Application.DoEvents();
            FillDependecies();
            Application.DoEvents();
            FillSpDefinition();
            Cursor = Cursors.Default;
            m_toolStripLabelConnection.Text = ConnectionFactory.ShortConnectionName + " . " + SpName;
        }

        internal UserControlSpInfo Clone()
        {
            var sp = new UserControlSpInfo
            {
                SpName = SpName,
                SpInfo = SpInfo,
                SpDefinition = SpDefinition,
                DataViewDependentTablesDataSource = DataViewDependentTablesDataSource,
                DataViewParamsDataSource = DataViewParamsDataSource,
                ShowDependenciesInfo = ShowDependenciesInfo
            };
            sp.SyntaxHighLight();
            sp.InitCoulomnsInDvDepTables();
            return sp;
        }

        public void SyntaxHighLight()
        {
            if (m_RichTextBoxDefinition.InvokeRequired)
            {
                m_RichTextBoxDefinition.Invoke(new MethodInvoker(SyntaxHighLight));
            }
            else
            {
                m_toolStripButtonFindNext.Enabled = false;
                m_ToolStripButtonFindPrevious.Enabled = false;
                FormMain.StatusInfo1 = Resources.UserControlSpInfo_SyntaxHighLight_Syntax_highligting;
                Application.DoEvents();
                RichTextBoxDefinition.ApplySyntaxHighlighting();
                FormMain.StatusInfo1 = "";
            }
        }

        private void RichTextBoxDefinition_FindTextCompleted(object sender, EventArgs e)
        {
            EnableScrollToButtons();
        }

        private void EnableScrollToButtons()
        {
            m_toolStripButtonFindNext.Enabled = !RichTextBoxDefinition.PositionedAtLast && RichTextBoxDefinition.IsTextFounded;
            m_ToolStripButtonFindPrevious.Enabled = !RichTextBoxDefinition.PositionedAtFirst &&
                                                    RichTextBoxDefinition.IsTextFounded;
        }

        private delegate SqlRichTextBox GetSqlRichTextBoxDelegate();

        #region Properties

        public SpInfo SpInfo { get; set; }

        public ColumnDependencies FormMain
        {
            get { return ColumnDependencies.FormMain; }
        }

        private SqlRichTextBox GetSqlRichTextBox()
        {
            return m_RichTextBoxDefinition;
        }

        public SqlRichTextBox RichTextBoxDefinition
        {
            get
            {
                if (m_RichTextBoxDefinition.InvokeRequired)
                {
                    return (SqlRichTextBox)m_RichTextBoxDefinition.Invoke(new GetSqlRichTextBoxDelegate(GetSqlRichTextBox));
                }
                return GetSqlRichTextBox();
            }
        }

        /// <summary>
        ///     Get or Sets Stored Procedures Name
        /// </summary>
        public string SpName { get; set; }

        public string SpDefinition
        {
            get { return RichTextBoxDefinition.Text; }
            set { RichTextBoxDefinition.Text = value; }
        }

        public object DataViewParamsDataSource
        {
            get { return m_DataGridViewParams == null ? null : m_DataGridViewParams.DataSource; }
            set
            {
                if (m_DataGridViewParams == null)
                {
                    return;
                }
                m_DataGridViewParams.DataSource = value;
            }
        }

        public object DataViewDependentTablesDataSource
        {
            get { return m_DataGridViewDepTables == null ? null : m_DataGridViewDepTables.DataSource; }
            set
            {
                if (m_DataGridViewDepTables == null)
                {
                    return;
                }
                m_DataGridViewDepTables.DataSource = value;
            }
        }

        public bool ShowDependenciesInfo
        {
            get { return m_toolStripButtonShowParamInfo.Checked; }
            set { m_toolStripButtonShowParamInfo.Checked = value; }
        }

        #endregion Properties

        #region Raise on event

        protected virtual void RaiseCloseTabPage()
        {
            if (CloseTabPage != null)
            {
                CloseTabPage(SpName);
            }
        }

        protected virtual void RaiseOpenTableTab(string tableName, bool isDefinitionShown)
        {
            if (OpenTableTab != null)
            {
                OpenTableTab(this, tableName, isDefinitionShown);
            }
        }

        protected virtual void RaiseOpenSpTab(string spName)
        {
            if (OpenSpTab != null)
            {
                OpenSpTab(this, spName);
            }
        }

        #endregion Raise on event

        #region Get data from DB

        /// <summary>
        ///     Refreshes textbox with SPs definition.
        /// </summary>
        private void FillSpDefinition()
        {
            if (SpName == "")
            {
                return;
            }
            if (ConnectionFactory.OpenConnection() == false)
            {
                return;
            }

            var sqlStrBuilder = new StringBuilder();
            sqlStrBuilder.AppendLine("Declare @id int");
            sqlStrBuilder.AppendLine("Declare @name nvarchar(255)");

            sqlStrBuilder.AppendLine("if exists(select id from sys.sysobjects where name like @SPSEARCH 	AND xtype in ('F','P') )");
            sqlStrBuilder.AppendLine(
                "Begin select top 1 @id =id, @name = name  from sys.sysobjects where name like 	@SPSEARCH 	AND xtype in ('F','P')	END	");
            sqlStrBuilder.AppendLine(
                "ELSE BEGIN select top 1 id, name from sys.sysobjects where name like 	'%' + @SPSEARCH + '%' 	AND xtype in ('F','P')	END");

            sqlStrBuilder.AppendLine("SELECT @name as name,[text] FROM syscomments WHERE id= @id order by colid");
            var sqlStr = sqlStrBuilder.ToString();

            var com = new SqlCommand(sqlStr, ConnectionFactory.Instance);
            com.Parameters.Add("@SPSEARCH", SqlDbType.NVarChar);
            com.Parameters["@SPSEARCH"].Value = SpName;

            RichTextBoxDefinition.Text = "";

            FormMain.StatusInfo1 = Resources.UserControlSpInfo_FillSpDefinition_Loading_SP_definition____;
            FormMain.StatusInfo2 = m_tryToLoadCounter + Resources.UserControlSpInfo_FillSpDefinition__try;
            Application.DoEvents();

            try
            {
                var reader = com.ExecuteReader();
                if (reader == null)
                {
                    return;
                }
                try
                {
                    while (reader.Read())
                    {
                        SpName = reader["name"].ToString();
                        RichTextBoxDefinition.Text += reader["text"];
                        Application.DoEvents();
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                    m_tryToLoadCounter = 1;
                }
            }
            catch
            {
                if (m_tryToLoadCounter < 4)
                {
                    Application.DoEvents();
                    m_tryToLoadCounter++;
                    FillSpDefinition();
                    return;
                }
            }
            ConnectionFactory.CloseConnection();
            FormMain.StatusInfo1 = "";
            FormMain.StatusInfo2 = "";
        }

        /// <summary>
        ///     Fill datagrid with inforamtion about SP's parameters
        /// </summary>
        private void FillParameters()
        {
            m_DataGridViewParams.DataSource = SpInfo.ParameterInfo;
        }

        /// <summary>
        ///     Fill datagrid with inforamtion about SP's dependencies
        /// </summary>
        private void FillDependecies()
        {
            m_DataGridViewDepTables.DataSource = SpInfo.Dependencies;
            InitCoulomnsInDvDepTables();
        }

        private void InitCoulomnsInDvDepTables()
        {
            try
            {
                // ReSharper disable PossibleNullReferenceException
                m_DataGridViewDepTables.Columns["type"].Visible = false;
                m_DataGridViewDepTables.Columns["updated"].Visible = false;
                m_DataGridViewDepTables.Columns["selected"].Visible = false;
                m_DataGridViewDepTables.Columns["MyUpd"].HeaderText = Resources.UserControlSpInfo_InitCoulomnsInDvDepTables_Updated;
                m_DataGridViewDepTables.Columns["MySel"].HeaderText =
                    Resources.UserControlSpInfo_InitCoulomnsInDvDepTables_Selected;
                m_DataGridViewDepTables.Columns["MyType"].HeaderText = Resources.UserControlSpInfo_InitCoulomnsInDvDepTables_Type;
                m_DataGridViewDepTables.Columns["name"].HeaderText =
                    Resources.UserControlSpInfo_InitCoulomnsInDvDepTables_Dependent_Object;
                m_DataGridViewDepTables.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                m_DataGridViewDepTables.Columns["name"].ContextMenuStrip = m_ContextMenuStripShowDefinition;
                m_DataGridViewDepTables.Columns["column"].HeaderText = Resources.UserControlSpInfo_InitCoulomnsInDvDepTables_Column;
                m_DataGridViewDepTables.Columns["column"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                // ReSharper restore PossibleNullReferenceException
            }
            catch
            {
            }
        }

        #endregion Get data from DB

        #region ToolStripMenuItem events

        private void ShowDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_DataGridViewDepTables.SelectedCells.Count > 0)
                {
                    var val = m_DataGridViewDepTables.SelectedCells[0].Value.ToString();
                    var isSp = "SP" == m_DataGridViewDepTables.SelectedCells[0].OwningRow.Cells["MyType"].Value.ToString();

                    if (isSp)
                    {
                        RaiseOpenSpTab(val);
                    }
                    else
                    {
                        RaiseOpenTableTab(val, true);
                    }
                }
            }
            catch
            {
            }
        }

        private void ToolStripButtonShowAsToolBox_Click(object sender, EventArgs e)
        {
            if (m_Toolbox == null)
            {
                m_Toolbox = new Form
                {
                    Text = SpName
                };
                m_toolStripButtonClose.Visible = false;
                m_toolStripButtonShowAsToolBox.Text =
                    Resources.UserControlSpInfo_ToolStripButtonShowAsToolBox_Click_Show_as_tab_page;
                Dock = DockStyle.Fill;
                m_Toolbox.Controls.Add(this);
                m_Toolbox.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                m_Toolbox.Size = new Size(800, 600);
                m_Toolbox.Show();
                RaiseCloseTabPage();
                m_Toolbox.Owner = FormMain;
            }
            else
            {
                try
                {
                    if (m_Toolbox.Controls.Count > 0 && m_Toolbox.Controls[0] is UserControlSpInfo)
                    {
                        var spClone = ((UserControlSpInfo)m_Toolbox.Controls[0]).Clone();
                        m_Toolbox.Close();
                        FormMain.CreateSpTabPage(SpName, spClone);
                    }
                }
                catch
                {
                    FormMain.CreateSpTabPage(SpName);
                }
            }
        }

        private void ToolStripButtonClose_Click(object sender, EventArgs e)
        {
            RaiseCloseTabPage();
        }

        private void ToolStripButtonShowParamInfo_CheckedChanged(object sender, EventArgs e)
        {
            m_SplitContainerMain.Panel1Collapsed = !m_toolStripButtonShowParamInfo.Checked;
        }

        private void ToolStripTextBoxFind_TextChanged(object sender, EventArgs e)
        {
            RichTextBoxDefinition.FindText(m_toolStripTextBoxFind.Text);
        }

        private void ToolStripButtonExecSp_Click(object sender, EventArgs e)
        {
            var formRunSp = new FormRunSp { SpInfo = SpInfo };
            formRunSp.InitDataGridView();
            formRunSp.Show();
        }

        private void ToolStripButtonFindNext_Click(object sender, EventArgs e)
        {
            RichTextBoxDefinition.ScrollToNext();
            EnableScrollToButtons();
        }

        private void ToolStripButtonFindPrevious_Click(object sender, EventArgs e)
        {
            RichTextBoxDefinition.ScrollToPrevious();
            EnableScrollToButtons();
        }

        #endregion ToolStripMenuItem events
    }
}