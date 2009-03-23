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
			this.groupBox_Search = new System.Windows.Forms.GroupBox();
			this.m_UserControlConnection = new ColumnDepence.UserControlConnection();
			this.m_tabControl_Search = new System.Windows.Forms.TabControl();
			this.m_tabPage_TabSearch = new System.Windows.Forms.TabPage();
			this.m_userControlHistoryList_Tables = new ColumnDepence.UserControlHistoryList();
			this.button_TabDef = new System.Windows.Forms.Button();
			this.button_GetAllRows = new System.Windows.Forms.Button();
			this.txtTableName = new System.Windows.Forms.TextBox();
			this.m_tabPage_SpSearch = new System.Windows.Forms.TabPage();
			this.m_userControlHistoryList_Sp = new ColumnDepence.UserControlHistoryList();
			this.m_button_SpDef = new System.Windows.Forms.Button();
			this.m_textBox_SpSearch = new System.Windows.Forms.TextBox();
			this.tabControl_TableInfo = new System.Windows.Forms.TabControl();
			this.contextMenuStrip_TabPage = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllTabsButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_statusStrip_Main = new System.Windows.Forms.StatusStrip();
			this.m_toolStripStatusLabel_First = new System.Windows.Forms.ToolStripStatusLabel();
			this.m_toolStripStatusLabel_Second = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBox_Search.SuspendLayout();
			this.m_tabControl_Search.SuspendLayout();
			this.m_tabPage_TabSearch.SuspendLayout();
			this.m_tabPage_SpSearch.SuspendLayout();
			this.contextMenuStrip_TabPage.SuspendLayout();
			this.m_statusStrip_Main.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_Search
			// 
			this.groupBox_Search.Controls.Add(this.m_UserControlConnection);
			this.groupBox_Search.Controls.Add(this.m_tabControl_Search);
			this.groupBox_Search.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_Search.Location = new System.Drawing.Point(0, 0);
			this.groupBox_Search.Name = "groupBox_Search";
			this.groupBox_Search.Size = new System.Drawing.Size(1214, 131);
			this.groupBox_Search.TabIndex = 0;
			this.groupBox_Search.TabStop = false;
			// 
			// m_UserControlConnection
			// 
			this.m_UserControlConnection.Location = new System.Drawing.Point(471, 14);
			this.m_UserControlConnection.Name = "m_UserControlConnection";
			this.m_UserControlConnection.Size = new System.Drawing.Size(530, 111);
			this.m_UserControlConnection.TabIndex = 1;
			// 
			// m_tabControl_Search
			// 
			this.m_tabControl_Search.Controls.Add(this.m_tabPage_TabSearch);
			this.m_tabControl_Search.Controls.Add(this.m_tabPage_SpSearch);
			this.m_tabControl_Search.Location = new System.Drawing.Point(6, 8);
			this.m_tabControl_Search.Name = "m_tabControl_Search";
			this.m_tabControl_Search.SelectedIndex = 0;
			this.m_tabControl_Search.Size = new System.Drawing.Size(459, 117);
			this.m_tabControl_Search.TabIndex = 0;
			// 
			// m_tabPage_TabSearch
			// 
			this.m_tabPage_TabSearch.Controls.Add(this.m_userControlHistoryList_Tables);
			this.m_tabPage_TabSearch.Controls.Add(this.button_TabDef);
			this.m_tabPage_TabSearch.Controls.Add(this.button_GetAllRows);
			this.m_tabPage_TabSearch.Controls.Add(this.txtTableName);
			this.m_tabPage_TabSearch.Location = new System.Drawing.Point(4, 22);
			this.m_tabPage_TabSearch.Name = "m_tabPage_TabSearch";
			this.m_tabPage_TabSearch.Padding = new System.Windows.Forms.Padding(3);
			this.m_tabPage_TabSearch.Size = new System.Drawing.Size(451, 91);
			this.m_tabPage_TabSearch.TabIndex = 0;
			this.m_tabPage_TabSearch.Text = "Tables";
			this.m_tabPage_TabSearch.UseVisualStyleBackColor = true;
			// 
			// m_userControlHistoryList_Tables
			// 
			this.m_userControlHistoryList_Tables.Location = new System.Drawing.Point(429, 13);
			this.m_userControlHistoryList_Tables.Name = "m_userControlHistoryList_Tables";
			this.m_userControlHistoryList_Tables.SettingName = null;
			this.m_userControlHistoryList_Tables.Size = new System.Drawing.Size(22, 25);
			this.m_userControlHistoryList_Tables.TabIndex = 3;
			this.m_userControlHistoryList_Tables.SelectedIndexChanged += new ColumnDepence.UserControlHistoryList.SelectedIndexChangedHandler(this.m_userControlHistoryList_Tables_SelectedIndexChanged);
			// 
			// button_TabDef
			// 
			this.button_TabDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_TabDef.Image = global::ColumnDepence.Properties.Resources.LoadDefinitionImage;
			this.button_TabDef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button_TabDef.Location = new System.Drawing.Point(9, 44);
			this.button_TabDef.Name = "button_TabDef";
			this.button_TabDef.Size = new System.Drawing.Size(197, 29);
			this.button_TabDef.TabIndex = 1;
			this.button_TabDef.Text = "Table &Definition";
			this.button_TabDef.UseVisualStyleBackColor = true;
			this.button_TabDef.Click += new System.EventHandler(this.button_TabDef_Click);
			// 
			// button_GetAllRows
			// 
			this.button_GetAllRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_GetAllRows.Image = global::ColumnDepence.Properties.Resources.LoadAllValues;
			this.button_GetAllRows.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button_GetAllRows.Location = new System.Drawing.Point(212, 44);
			this.button_GetAllRows.Name = "button_GetAllRows";
			this.button_GetAllRows.Size = new System.Drawing.Size(146, 29);
			this.button_GetAllRows.TabIndex = 2;
			this.button_GetAllRows.Text = "&All rows";
			this.button_GetAllRows.UseVisualStyleBackColor = true;
			this.button_GetAllRows.Click += new System.EventHandler(this.button_GetAllRows_Click_1);
			// 
			// txtTableName
			// 
			this.txtTableName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtTableName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtTableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedTable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.txtTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTableName.Location = new System.Drawing.Point(9, 7);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Size = new System.Drawing.Size(414, 31);
			this.txtTableName.TabIndex = 0;
			this.txtTableName.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedTable;
			this.txtTableName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxTableName_KeyUp);
			// 
			// m_tabPage_SpSearch
			// 
			this.m_tabPage_SpSearch.Controls.Add(this.m_userControlHistoryList_Sp);
			this.m_tabPage_SpSearch.Controls.Add(this.m_button_SpDef);
			this.m_tabPage_SpSearch.Controls.Add(this.m_textBox_SpSearch);
			this.m_tabPage_SpSearch.Location = new System.Drawing.Point(4, 22);
			this.m_tabPage_SpSearch.Name = "m_tabPage_SpSearch";
			this.m_tabPage_SpSearch.Padding = new System.Windows.Forms.Padding(3);
			this.m_tabPage_SpSearch.Size = new System.Drawing.Size(451, 91);
			this.m_tabPage_SpSearch.TabIndex = 1;
			this.m_tabPage_SpSearch.Text = "Stored Procedures";
			this.m_tabPage_SpSearch.UseVisualStyleBackColor = true;
			// 
			// m_userControlHistoryList_Sp
			// 
			this.m_userControlHistoryList_Sp.Location = new System.Drawing.Point(429, 13);
			this.m_userControlHistoryList_Sp.Name = "m_userControlHistoryList_Sp";
			this.m_userControlHistoryList_Sp.SettingName = null;
			this.m_userControlHistoryList_Sp.Size = new System.Drawing.Size(22, 27);
			this.m_userControlHistoryList_Sp.TabIndex = 2;
			this.m_userControlHistoryList_Sp.SelectedIndexChanged += new ColumnDepence.UserControlHistoryList.SelectedIndexChangedHandler(this.m_userControlHistoryList_Sp_SelectedIndexChanged);
			// 
			// m_button_SpDef
			// 
			this.m_button_SpDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_button_SpDef.Image = global::ColumnDepence.Properties.Resources.LoadDefinitionImage;
			this.m_button_SpDef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_button_SpDef.Location = new System.Drawing.Point(7, 44);
			this.m_button_SpDef.Name = "m_button_SpDef";
			this.m_button_SpDef.Size = new System.Drawing.Size(197, 29);
			this.m_button_SpDef.TabIndex = 1;
			this.m_button_SpDef.Text = "S&P Definition";
			this.m_button_SpDef.UseVisualStyleBackColor = true;
			this.m_button_SpDef.Click += new System.EventHandler(this.Button_SPDef_Click);
			// 
			// m_textBox_SpSearch
			// 
			this.m_textBox_SpSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.m_textBox_SpSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.m_textBox_SpSearch.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedSP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.m_textBox_SpSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_textBox_SpSearch.Location = new System.Drawing.Point(7, 7);
			this.m_textBox_SpSearch.Name = "m_textBox_SpSearch";
			this.m_textBox_SpSearch.Size = new System.Drawing.Size(418, 31);
			this.m_textBox_SpSearch.TabIndex = 0;
			this.m_textBox_SpSearch.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedSP;
			this.m_textBox_SpSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxSpSearch_KeyUp);
			// 
			// tabControl_TableInfo
			// 
			this.tabControl_TableInfo.ContextMenuStrip = this.contextMenuStrip_TabPage;
			this.tabControl_TableInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl_TableInfo.HotTrack = true;
			this.tabControl_TableInfo.Location = new System.Drawing.Point(0, 131);
			this.tabControl_TableInfo.Multiline = true;
			this.tabControl_TableInfo.Name = "tabControl_TableInfo";
			this.tabControl_TableInfo.SelectedIndex = 0;
			this.tabControl_TableInfo.Size = new System.Drawing.Size(1214, 782);
			this.tabControl_TableInfo.TabIndex = 0;
			// 
			// contextMenuStrip_TabPage
			// 
			this.contextMenuStrip_TabPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTabToolStripMenuItem,
            this.closeAllTabsButThisToolStripMenuItem,
            this.closeAllTabsToolStripMenuItem});
			this.contextMenuStrip_TabPage.Name = "contextMenuStrip_TabPage";
			this.contextMenuStrip_TabPage.Size = new System.Drawing.Size(193, 70);
			// 
			// closeTabToolStripMenuItem
			// 
			this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
			this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.closeTabToolStripMenuItem.Text = "Close Active Tab";
			this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.closeActiveTabToolStripMenuItem_Click);
			// 
			// closeAllTabsButThisToolStripMenuItem
			// 
			this.closeAllTabsButThisToolStripMenuItem.Name = "closeAllTabsButThisToolStripMenuItem";
			this.closeAllTabsButThisToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.closeAllTabsButThisToolStripMenuItem.Text = "Close All Tabs But This";
			this.closeAllTabsButThisToolStripMenuItem.Click += new System.EventHandler(this.closeAllTabsButThisToolStripMenuItem_Click);
			// 
			// closeAllTabsToolStripMenuItem
			// 
			this.closeAllTabsToolStripMenuItem.Name = "closeAllTabsToolStripMenuItem";
			this.closeAllTabsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.closeAllTabsToolStripMenuItem.Text = "Close All Tabs";
			this.closeAllTabsToolStripMenuItem.Click += new System.EventHandler(this.closeAllTabsToolStripMenuItem_Click);
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
			// ColumnDependencies
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1214, 913);
			this.Controls.Add(this.m_statusStrip_Main);
			this.Controls.Add(this.tabControl_TableInfo);
			this.Controls.Add(this.groupBox_Search);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ColumnDependencies";
			this.Text = "DB Info";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ColumnDependencies_FormClosed);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ColumnDependencies_KeyPress);
			this.groupBox_Search.ResumeLayout(false);
			this.m_tabControl_Search.ResumeLayout(false);
			this.m_tabPage_TabSearch.ResumeLayout(false);
			this.m_tabPage_TabSearch.PerformLayout();
			this.m_tabPage_SpSearch.ResumeLayout(false);
			this.m_tabPage_SpSearch.PerformLayout();
			this.contextMenuStrip_TabPage.ResumeLayout(false);
			this.m_statusStrip_Main.ResumeLayout(false);
			this.m_statusStrip_Main.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox_Search;
		private System.Windows.Forms.TextBox txtTableName;
		private System.Windows.Forms.Button button_TabDef;
		private System.Windows.Forms.Button button_GetAllRows;
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

	}
}

