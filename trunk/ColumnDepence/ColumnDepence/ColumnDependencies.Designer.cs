using System.Collections.Generic;
using System.Windows.Forms;

namespace ColumnDepence
{
	partial class ColumnDependencies
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnDependencies));
      this.m_GroupBoxSearch = new System.Windows.Forms.GroupBox();
      this.m_tabControl_Search = new System.Windows.Forms.TabControl();
      this.m_tabPage_TabSearch = new System.Windows.Forms.TabPage();
      this.m_ButtonTabDef = new System.Windows.Forms.Button();
      this.m_ButtonGetAllRows = new System.Windows.Forms.Button();
      this.m_TextBoxTableName = new System.Windows.Forms.TextBox();
      this.m_tabPage_SpSearch = new System.Windows.Forms.TabPage();
      this.m_button_SpDef = new System.Windows.Forms.Button();
      this.m_textBox_SpSearch = new System.Windows.Forms.TextBox();
      this.m_tabPage_DbConnection = new System.Windows.Forms.TabPage();
      this.m_tabPageQuery = new System.Windows.Forms.TabPage();
      this.tabControl_TableInfo = new System.Windows.Forms.TabControl();
      this.contextMenuStrip_TabPage = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeAllTabsButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeAllTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.m_statusStrip_Main = new System.Windows.Forms.StatusStrip();
      this.m_toolStripStatusLabel_First = new System.Windows.Forms.ToolStripStatusLabel();
      this.m_toolStripStatusLabel_Second = new System.Windows.Forms.ToolStripStatusLabel();
      this.m_UserControlFullNameListTableNames = new ColumnDepence.UserControlFullNameList();
      this.m_userControlHistoryList_Tables = new ColumnDepence.UserControlHistoryList();
      this.m_UserControlFullNameListSPNames = new ColumnDepence.UserControlFullNameList();
      this.m_userControlHistoryList_Sp = new ColumnDepence.UserControlHistoryList();
      this.m_UserControlConnection = new ColumnDepence.UserControlConnection();
      this.m_GroupBoxSearch.SuspendLayout();
      this.m_tabControl_Search.SuspendLayout();
      this.m_tabPage_TabSearch.SuspendLayout();
      this.m_tabPage_SpSearch.SuspendLayout();
      this.m_tabPage_DbConnection.SuspendLayout();
      this.contextMenuStrip_TabPage.SuspendLayout();
      this.m_statusStrip_Main.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_GroupBoxSearch
      // 
      this.m_GroupBoxSearch.Controls.Add(this.m_tabControl_Search);
      this.m_GroupBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
      this.m_GroupBoxSearch.Location = new System.Drawing.Point(0, 0);
      this.m_GroupBoxSearch.Name = "m_GroupBoxSearch";
      this.m_GroupBoxSearch.Size = new System.Drawing.Size(1214, 74);
      this.m_GroupBoxSearch.TabIndex = 0;
      this.m_GroupBoxSearch.TabStop = false;
      // 
      // m_tabControl_Search
      // 
      this.m_tabControl_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.m_tabControl_Search.Controls.Add(this.m_tabPage_TabSearch);
      this.m_tabControl_Search.Controls.Add(this.m_tabPage_SpSearch);
      this.m_tabControl_Search.Controls.Add(this.m_tabPage_DbConnection);
      this.m_tabControl_Search.Controls.Add(this.m_tabPageQuery);
      this.m_tabControl_Search.HotTrack = true;
      this.m_tabControl_Search.Location = new System.Drawing.Point(6, 8);
      this.m_tabControl_Search.Name = "m_tabControl_Search";
      this.m_tabControl_Search.SelectedIndex = 0;
      this.m_tabControl_Search.Size = new System.Drawing.Size(1202, 66);
      this.m_tabControl_Search.TabIndex = 0;
      this.m_tabControl_Search.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.OnTabControlSearchSelecting);
      this.m_tabControl_Search.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnTabControlSearchMouseUp);
      // 
      // m_tabPage_TabSearch
      // 
      this.m_tabPage_TabSearch.Controls.Add(this.m_UserControlFullNameListTableNames);
      this.m_tabPage_TabSearch.Controls.Add(this.m_userControlHistoryList_Tables);
      this.m_tabPage_TabSearch.Controls.Add(this.m_ButtonTabDef);
      this.m_tabPage_TabSearch.Controls.Add(this.m_ButtonGetAllRows);
      this.m_tabPage_TabSearch.Controls.Add(this.m_TextBoxTableName);
      this.m_tabPage_TabSearch.Location = new System.Drawing.Point(4, 22);
      this.m_tabPage_TabSearch.Name = "m_tabPage_TabSearch";
      this.m_tabPage_TabSearch.Padding = new System.Windows.Forms.Padding(3);
      this.m_tabPage_TabSearch.Size = new System.Drawing.Size(1194, 40);
      this.m_tabPage_TabSearch.TabIndex = 0;
      this.m_tabPage_TabSearch.Text = "Tables";
      this.m_tabPage_TabSearch.UseVisualStyleBackColor = true;
      // 
      // m_ButtonTabDef
      // 
      this.m_ButtonTabDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_ButtonTabDef.Image = global::ColumnDepence.Properties.Resources.LoadDefinitionImage;
      this.m_ButtonTabDef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.m_ButtonTabDef.Location = new System.Drawing.Point(481, 6);
      this.m_ButtonTabDef.Name = "m_ButtonTabDef";
      this.m_ButtonTabDef.Size = new System.Drawing.Size(197, 28);
      this.m_ButtonTabDef.TabIndex = 1;
      this.m_ButtonTabDef.Text = "&Definition";
      this.m_ButtonTabDef.UseVisualStyleBackColor = true;
      this.m_ButtonTabDef.Click += new System.EventHandler(this.ButtonTableDefinition_Click);
      // 
      // m_ButtonGetAllRows
      // 
      this.m_ButtonGetAllRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_ButtonGetAllRows.Image = global::ColumnDepence.Properties.Resources.LoadAllValues;
      this.m_ButtonGetAllRows.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.m_ButtonGetAllRows.Location = new System.Drawing.Point(684, 6);
      this.m_ButtonGetAllRows.Name = "m_ButtonGetAllRows";
      this.m_ButtonGetAllRows.Size = new System.Drawing.Size(173, 28);
      this.m_ButtonGetAllRows.TabIndex = 2;
      this.m_ButtonGetAllRows.Text = "&Data";
      this.m_ButtonGetAllRows.UseVisualStyleBackColor = true;
      this.m_ButtonGetAllRows.Click += new System.EventHandler(this.ButtonGetAllRows_Click);
      // 
      // m_TextBoxTableName
      // 
      this.m_TextBoxTableName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.m_TextBoxTableName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
      this.m_TextBoxTableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedTable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.m_TextBoxTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_TextBoxTableName.Location = new System.Drawing.Point(0, 4);
      this.m_TextBoxTableName.Name = "m_TextBoxTableName";
      this.m_TextBoxTableName.Size = new System.Drawing.Size(414, 31);
      this.m_TextBoxTableName.TabIndex = 0;
      this.m_TextBoxTableName.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedTable;
      this.m_TextBoxTableName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxTableName_KeyUp);
      // 
      // m_tabPage_SpSearch
      // 
      this.m_tabPage_SpSearch.Controls.Add(this.m_UserControlFullNameListSPNames);
      this.m_tabPage_SpSearch.Controls.Add(this.m_userControlHistoryList_Sp);
      this.m_tabPage_SpSearch.Controls.Add(this.m_button_SpDef);
      this.m_tabPage_SpSearch.Controls.Add(this.m_textBox_SpSearch);
      this.m_tabPage_SpSearch.Location = new System.Drawing.Point(4, 22);
      this.m_tabPage_SpSearch.Name = "m_tabPage_SpSearch";
      this.m_tabPage_SpSearch.Padding = new System.Windows.Forms.Padding(3);
      this.m_tabPage_SpSearch.Size = new System.Drawing.Size(1194, 40);
      this.m_tabPage_SpSearch.TabIndex = 1;
      this.m_tabPage_SpSearch.Text = "Stored Procedures";
      this.m_tabPage_SpSearch.UseVisualStyleBackColor = true;
      // 
      // m_button_SpDef
      // 
      this.m_button_SpDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_button_SpDef.Image = global::ColumnDepence.Properties.Resources.LoadDefinitionImage;
      this.m_button_SpDef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.m_button_SpDef.Location = new System.Drawing.Point(490, 5);
      this.m_button_SpDef.Name = "m_button_SpDef";
      this.m_button_SpDef.Size = new System.Drawing.Size(197, 27);
      this.m_button_SpDef.TabIndex = 1;
      this.m_button_SpDef.Text = "S&P Definition";
      this.m_button_SpDef.UseVisualStyleBackColor = true;
      this.m_button_SpDef.Click += new System.EventHandler(this.ButtonSpDefClick);
      // 
      // m_textBox_SpSearch
      // 
      this.m_textBox_SpSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.m_textBox_SpSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
      this.m_textBox_SpSearch.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedSP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.m_textBox_SpSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_textBox_SpSearch.Location = new System.Drawing.Point(0, 5);
      this.m_textBox_SpSearch.Name = "m_textBox_SpSearch";
      this.m_textBox_SpSearch.Size = new System.Drawing.Size(418, 31);
      this.m_textBox_SpSearch.TabIndex = 0;
      this.m_textBox_SpSearch.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedSP;
      this.m_textBox_SpSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxSpSearch_KeyUp);
      // 
      // m_tabPage_DbConnection
      // 
      this.m_tabPage_DbConnection.Controls.Add(this.m_UserControlConnection);
      this.m_tabPage_DbConnection.Location = new System.Drawing.Point(4, 22);
      this.m_tabPage_DbConnection.Name = "m_tabPage_DbConnection";
      this.m_tabPage_DbConnection.Padding = new System.Windows.Forms.Padding(3);
      this.m_tabPage_DbConnection.Size = new System.Drawing.Size(1194, 40);
      this.m_tabPage_DbConnection.TabIndex = 2;
      this.m_tabPage_DbConnection.Text = "Db Connection";
      this.m_tabPage_DbConnection.UseVisualStyleBackColor = true;
      // 
      // m_tabPageQuery
      // 
      this.m_tabPageQuery.Location = new System.Drawing.Point(4, 22);
      this.m_tabPageQuery.Name = "m_tabPageQuery";
      this.m_tabPageQuery.Padding = new System.Windows.Forms.Padding(3);
      this.m_tabPageQuery.Size = new System.Drawing.Size(1194, 40);
      this.m_tabPageQuery.TabIndex = 3;
      this.m_tabPageQuery.Text = "Query";
      this.m_tabPageQuery.UseVisualStyleBackColor = true;
      // 
      // tabControl_TableInfo
      // 
      this.tabControl_TableInfo.ContextMenuStrip = this.contextMenuStrip_TabPage;
      this.tabControl_TableInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl_TableInfo.HotTrack = true;
      this.tabControl_TableInfo.Location = new System.Drawing.Point(0, 74);
      this.tabControl_TableInfo.Multiline = true;
      this.tabControl_TableInfo.Name = "tabControl_TableInfo";
      this.tabControl_TableInfo.SelectedIndex = 0;
      this.tabControl_TableInfo.Size = new System.Drawing.Size(1214, 839);
      this.tabControl_TableInfo.TabIndex = 0;
      this.tabControl_TableInfo.SelectedIndexChanged += new System.EventHandler(this.TabControlTableInfoSelectedIndexChanged);
      this.tabControl_TableInfo.TabIndexChanged += new System.EventHandler(this.TabControlTableInfoTabIndexChanged);
      this.tabControl_TableInfo.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.TabControlTableInfoControlAdded);
      this.tabControl_TableInfo.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.TabControlTableInfoControlRemoved);
      // 
      // contextMenuStrip_TabPage
      // 
      this.contextMenuStrip_TabPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTabToolStripMenuItem,
            this.closeAllTabsButThisToolStripMenuItem,
            this.closeAllTabsToolStripMenuItem});
      this.contextMenuStrip_TabPage.Name = "contextMenuStrip_TabPage";
      this.contextMenuStrip_TabPage.Size = new System.Drawing.Size(182, 70);
      // 
      // closeTabToolStripMenuItem
      // 
      this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
      this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
      this.closeTabToolStripMenuItem.Text = "Close Active Tab";
      this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.CloseActiveTabToolStripMenuItemClick);
      // 
      // closeAllTabsButThisToolStripMenuItem
      // 
      this.closeAllTabsButThisToolStripMenuItem.Name = "closeAllTabsButThisToolStripMenuItem";
      this.closeAllTabsButThisToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
      this.closeAllTabsButThisToolStripMenuItem.Text = "Close All Tabs But This";
      this.closeAllTabsButThisToolStripMenuItem.Click += new System.EventHandler(this.CloseAllTabsButThisToolStripMenuItemClick);
      // 
      // closeAllTabsToolStripMenuItem
      // 
      this.closeAllTabsToolStripMenuItem.Name = "closeAllTabsToolStripMenuItem";
      this.closeAllTabsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
      this.closeAllTabsToolStripMenuItem.Text = "Close All Tabs";
      this.closeAllTabsToolStripMenuItem.Click += new System.EventHandler(this.CloseAllTabsToolStripMenuItemClick);
      // 
      // m_statusStrip_Main
      // 
      this.m_statusStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolStripStatusLabel_First,
            this.m_toolStripStatusLabel_Second});
      this.m_statusStrip_Main.Location = new System.Drawing.Point(0, 891);
      this.m_statusStrip_Main.Name = "m_statusStrip_Main";
      this.m_statusStrip_Main.Size = new System.Drawing.Size(1214, 22);
      this.m_statusStrip_Main.TabIndex = 1;
      // 
      // m_toolStripStatusLabel_First
      // 
      this.m_toolStripStatusLabel_First.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.m_toolStripStatusLabel_First.Name = "m_toolStripStatusLabel_First";
      this.m_toolStripStatusLabel_First.Size = new System.Drawing.Size(4, 17);
      // 
      // m_toolStripStatusLabel_Second
      // 
      this.m_toolStripStatusLabel_Second.Name = "m_toolStripStatusLabel_Second";
      this.m_toolStripStatusLabel_Second.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
      this.m_toolStripStatusLabel_Second.Size = new System.Drawing.Size(10, 17);
      // 
      // m_UserControlFullNameListTableNames
      // 
      this.m_UserControlFullNameListTableNames.FullNameListType = ColumnDepence.FullNameListType.TableNames;
      this.m_UserControlFullNameListTableNames.Location = new System.Drawing.Point(420, 6);
      this.m_UserControlFullNameListTableNames.Name = "m_UserControlFullNameListTableNames";
      this.m_UserControlFullNameListTableNames.SelectedName = null;
      this.m_UserControlFullNameListTableNames.Size = new System.Drawing.Size(27, 28);
      this.m_UserControlFullNameListTableNames.StringList = null;
      this.m_UserControlFullNameListTableNames.TabIndex = 4;
      // 
      // m_userControlHistoryList_Tables
      // 
      this.m_userControlHistoryList_Tables.Location = new System.Drawing.Point(453, 9);
      this.m_userControlHistoryList_Tables.Name = "m_userControlHistoryList_Tables";
      this.m_userControlHistoryList_Tables.SettingName = null;
      this.m_userControlHistoryList_Tables.Size = new System.Drawing.Size(22, 29);
      this.m_userControlHistoryList_Tables.TabIndex = 3;
      this.m_userControlHistoryList_Tables.SelectedIndexChanged += new ColumnDepence.UserControlHistoryList.SelectedIndexChangedHandler(this.UserControlHistoryListTablesSelectedIndexChanged);
      // 
      // m_UserControlFullNameListSPNames
      // 
      this.m_UserControlFullNameListSPNames.FullNameListType = ColumnDepence.FullNameListType.SpNames;
      this.m_UserControlFullNameListSPNames.Location = new System.Drawing.Point(424, 5);
      this.m_UserControlFullNameListSPNames.Name = "m_UserControlFullNameListSPNames";
      this.m_UserControlFullNameListSPNames.SelectedName = null;
      this.m_UserControlFullNameListSPNames.Size = new System.Drawing.Size(32, 29);
      this.m_UserControlFullNameListSPNames.StringList = null;
      this.m_UserControlFullNameListSPNames.TabIndex = 3;
      // 
      // m_userControlHistoryList_Sp
      // 
      this.m_userControlHistoryList_Sp.Location = new System.Drawing.Point(462, 7);
      this.m_userControlHistoryList_Sp.Name = "m_userControlHistoryList_Sp";
      this.m_userControlHistoryList_Sp.SettingName = null;
      this.m_userControlHistoryList_Sp.Size = new System.Drawing.Size(22, 27);
      this.m_userControlHistoryList_Sp.TabIndex = 2;
      this.m_userControlHistoryList_Sp.SelectedIndexChanged += new ColumnDepence.UserControlHistoryList.SelectedIndexChangedHandler(this.UserControlHistoryListSpSelectedIndexChanged);
      // 
      // m_UserControlConnection
      // 
      this.m_UserControlConnection.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_UserControlConnection.Location = new System.Drawing.Point(3, 3);
      this.m_UserControlConnection.Name = "m_UserControlConnection";
      this.m_UserControlConnection.Size = new System.Drawing.Size(1188, 34);
      this.m_UserControlConnection.TabIndex = 1;
      // 
      // ColumnDependencies
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1214, 913);
      this.Controls.Add(this.m_statusStrip_Main);
      this.Controls.Add(this.tabControl_TableInfo);
      this.Controls.Add(this.m_GroupBoxSearch);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ColumnDependencies";
      this.Text = "DB Info";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ColumnDependencies_FormClosed);
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ColumnDependencies_KeyPress);
      this.m_GroupBoxSearch.ResumeLayout(false);
      this.m_tabControl_Search.ResumeLayout(false);
      this.m_tabPage_TabSearch.ResumeLayout(false);
      this.m_tabPage_TabSearch.PerformLayout();
      this.m_tabPage_SpSearch.ResumeLayout(false);
      this.m_tabPage_SpSearch.PerformLayout();
      this.m_tabPage_DbConnection.ResumeLayout(false);
      this.contextMenuStrip_TabPage.ResumeLayout(false);
      this.m_statusStrip_Main.ResumeLayout(false);
      this.m_statusStrip_Main.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox m_GroupBoxSearch;
		private System.Windows.Forms.TextBox m_TextBoxTableName;
		private System.Windows.Forms.Button m_ButtonTabDef;
		private System.Windows.Forms.Button m_ButtonGetAllRows;
		private System.Windows.Forms.TabControl tabControl_TableInfo;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip_TabPage;
		private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeAllTabsButThisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeAllTabsToolStripMenuItem;
		private System.Windows.Forms.TabControl m_tabControl_Search;
		private System.Windows.Forms.TabPage m_tabPage_TabSearch;
		private System.Windows.Forms.TabPage m_tabPage_SpSearch;
		private System.Windows.Forms.Button m_button_SpDef;
		private System.Windows.Forms.TextBox m_textBox_SpSearch;
		private UserControlHistoryList m_userControlHistoryList_Tables;
		private UserControlHistoryList m_userControlHistoryList_Sp;
		private System.Windows.Forms.StatusStrip m_statusStrip_Main;
		private System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabel_First;
		private System.Windows.Forms.ToolStripStatusLabel m_toolStripStatusLabel_Second;
		private UserControlConnection m_UserControlConnection;
		private System.Windows.Forms.TabPage m_tabPage_DbConnection;
		private UserControlFullNameList m_UserControlFullNameListTableNames;
		private UserControlFullNameList m_UserControlFullNameListSPNames;
		private readonly LinkedList<TabPage> ClosingTabOrder = new LinkedList<TabPage>();
    private TabPage m_tabPageQuery;
	}
}

