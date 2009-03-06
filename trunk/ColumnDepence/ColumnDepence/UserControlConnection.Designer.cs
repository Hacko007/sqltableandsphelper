namespace ColumnDepence
{
	partial class UserControlConnection
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_tabControl = new System.Windows.Forms.TabControl();
			this.m_tabPage_MSSQL = new System.Windows.Forms.TabPage();
			this.m_txtDatabaseNameMsSql = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_button_Connect = new System.Windows.Forms.Button();
			this.m_label_testconnection = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtServerNameMsSql = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_txtUsernameMsSql = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.m_txtPasswordMsSql = new System.Windows.Forms.TextBox();
			this.m_menuStrip_ConnectionHistory = new System.Windows.Forms.MenuStrip();
			this.m_toolStripComboBox_ConnectionHistory = new System.Windows.Forms.ToolStripComboBox();
			this.m_toolStripMenuItem_Apply = new System.Windows.Forms.ToolStripMenuItem();
			this.m_toolStripMenuItem_Clear = new System.Windows.Forms.ToolStripMenuItem();
			this.m_tabControl.SuspendLayout();
			this.m_tabPage_MSSQL.SuspendLayout();
			this.m_menuStrip_ConnectionHistory.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_tabControl
			// 
			this.m_tabControl.Controls.Add(this.m_tabPage_MSSQL);
			this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tabControl.Location = new System.Drawing.Point(0, 0);
			this.m_tabControl.Name = "m_tabControl";
			this.m_tabControl.SelectedIndex = 0;
			this.m_tabControl.Size = new System.Drawing.Size(530, 111);
			this.m_tabControl.TabIndex = 0;
			// 
			// m_tabPage_MSSQL
			// 
			this.m_tabPage_MSSQL.Controls.Add(this.m_txtDatabaseNameMsSql);
			this.m_tabPage_MSSQL.Controls.Add(this.label2);
			this.m_tabPage_MSSQL.Controls.Add(this.m_button_Connect);
			this.m_tabPage_MSSQL.Controls.Add(this.m_label_testconnection);
			this.m_tabPage_MSSQL.Controls.Add(this.label4);
			this.m_tabPage_MSSQL.Controls.Add(this.m_txtServerNameMsSql);
			this.m_tabPage_MSSQL.Controls.Add(this.label5);
			this.m_tabPage_MSSQL.Controls.Add(this.m_txtUsernameMsSql);
			this.m_tabPage_MSSQL.Controls.Add(this.label6);
			this.m_tabPage_MSSQL.Controls.Add(this.m_txtPasswordMsSql);
			this.m_tabPage_MSSQL.Controls.Add(this.m_menuStrip_ConnectionHistory);
			this.m_tabPage_MSSQL.Location = new System.Drawing.Point(4, 22);
			this.m_tabPage_MSSQL.Name = "m_tabPage_MSSQL";
			this.m_tabPage_MSSQL.Padding = new System.Windows.Forms.Padding(3);
			this.m_tabPage_MSSQL.Size = new System.Drawing.Size(522, 85);
			this.m_tabPage_MSSQL.TabIndex = 0;
			this.m_tabPage_MSSQL.Text = "MS SQL Server Connection";
			this.m_tabPage_MSSQL.UseVisualStyleBackColor = true;
			// 
			// m_txtDatabaseNameMsSql
			// 
			this.m_txtDatabaseNameMsSql.AutoCompleteCustomSource.AddRange(new string[] {
            "OmniData_EADS_NS_2",
            "OmniData_ERM4",
            "Unittest_EADS_NS_2",
            "Unittest_ERM4"});
			this.m_txtDatabaseNameMsSql.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_txtDatabaseNameMsSql.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.m_txtDatabaseNameMsSql.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedDatabase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.m_txtDatabaseNameMsSql.Location = new System.Drawing.Point(252, 58);
			this.m_txtDatabaseNameMsSql.Name = "m_txtDatabaseNameMsSql";
			this.m_txtDatabaseNameMsSql.Size = new System.Drawing.Size(141, 20);
			this.m_txtDatabaseNameMsSql.TabIndex = 8;
			this.m_txtDatabaseNameMsSql.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedDatabase;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(193, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Database";
			// 
			// m_button_Connect
			// 
			this.m_button_Connect.Location = new System.Drawing.Point(399, 36);
			this.m_button_Connect.Name = "m_button_Connect";
			this.m_button_Connect.Size = new System.Drawing.Size(107, 23);
			this.m_button_Connect.TabIndex = 9;
			this.m_button_Connect.Text = "Connect";
			this.m_button_Connect.UseVisualStyleBackColor = true;
			this.m_button_Connect.Click += new System.EventHandler(this.button_TestConnect_Click);
			// 
			// m_label_testconnection
			// 
			this.m_label_testconnection.AutoSize = true;
			this.m_label_testconnection.Location = new System.Drawing.Point(408, 62);
			this.m_label_testconnection.Name = "m_label_testconnection";
			this.m_label_testconnection.Size = new System.Drawing.Size(0, 13);
			this.m_label_testconnection.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(6, 61);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Server";
			// 
			// m_txtServerNameMsSql
			// 
			this.m_txtServerNameMsSql.AutoCompleteCustomSource.AddRange(new string[] {
            "KMSRV10",
            "KMSRV22\\int_2005"});
			this.m_txtServerNameMsSql.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_txtServerNameMsSql.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.m_txtServerNameMsSql.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedServer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.m_txtServerNameMsSql.Location = new System.Drawing.Point(69, 58);
			this.m_txtServerNameMsSql.Name = "m_txtServerNameMsSql";
			this.m_txtServerNameMsSql.Size = new System.Drawing.Size(118, 20);
			this.m_txtServerNameMsSql.TabIndex = 6;
			this.m_txtServerNameMsSql.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedServer;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label5.Location = new System.Drawing.Point(6, 39);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Username";
			// 
			// m_txtUsernameMsSql
			// 
			this.m_txtUsernameMsSql.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.m_txtUsernameMsSql.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedUsername", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.m_txtUsernameMsSql.Location = new System.Drawing.Point(69, 36);
			this.m_txtUsernameMsSql.Name = "m_txtUsernameMsSql";
			this.m_txtUsernameMsSql.Size = new System.Drawing.Size(118, 20);
			this.m_txtUsernameMsSql.TabIndex = 2;
			this.m_txtUsernameMsSql.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedUsername;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label6.Location = new System.Drawing.Point(193, 39);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Password";
			// 
			// m_txtPasswordMsSql
			// 
			this.m_txtPasswordMsSql.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.m_txtPasswordMsSql.Location = new System.Drawing.Point(252, 36);
			this.m_txtPasswordMsSql.Name = "m_txtPasswordMsSql";
			this.m_txtPasswordMsSql.PasswordChar = '*';
			this.m_txtPasswordMsSql.Size = new System.Drawing.Size(141, 20);
			this.m_txtPasswordMsSql.TabIndex = 4;
			this.m_txtPasswordMsSql.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedPassword;
			// 
			// m_menuStrip_ConnectionHistory
			// 
			this.m_menuStrip_ConnectionHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolStripComboBox_ConnectionHistory,
            this.m_toolStripMenuItem_Apply,
            this.m_toolStripMenuItem_Clear});
			this.m_menuStrip_ConnectionHistory.Location = new System.Drawing.Point(3, 3);
			this.m_menuStrip_ConnectionHistory.Name = "m_menuStrip_ConnectionHistory";
			this.m_menuStrip_ConnectionHistory.Size = new System.Drawing.Size(516, 25);
			this.m_menuStrip_ConnectionHistory.TabIndex = 0;
			this.m_menuStrip_ConnectionHistory.Text = "menuStrip1";
			// 
			// m_toolStripComboBox_ConnectionHistory
			// 
			this.m_toolStripComboBox_ConnectionHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_toolStripComboBox_ConnectionHistory.DropDownWidth = 521;
			this.m_toolStripComboBox_ConnectionHistory.Name = "m_toolStripComboBox_ConnectionHistory";
			this.m_toolStripComboBox_ConnectionHistory.Size = new System.Drawing.Size(401, 21);
			this.m_toolStripComboBox_ConnectionHistory.ToolTipText = "Connection History";
			// 
			// m_toolStripMenuItem_Apply
			// 
			this.m_toolStripMenuItem_Apply.Name = "m_toolStripMenuItem_Apply";
			this.m_toolStripMenuItem_Apply.Size = new System.Drawing.Size(46, 21);
			this.m_toolStripMenuItem_Apply.Text = "Apply";
			this.m_toolStripMenuItem_Apply.Click += new System.EventHandler(this.toolStripMenuItem_Apply_Click);
			// 
			// m_toolStripMenuItem_Clear
			// 
			this.m_toolStripMenuItem_Clear.Name = "m_toolStripMenuItem_Clear";
			this.m_toolStripMenuItem_Clear.Size = new System.Drawing.Size(44, 21);
			this.m_toolStripMenuItem_Clear.Text = "Clear";
			this.m_toolStripMenuItem_Clear.ToolTipText = "Clear history";
			this.m_toolStripMenuItem_Clear.Click += new System.EventHandler(this.toolStripMenuItem_Clear_Click);
			// 
			// UserControlConnection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_tabControl);
			this.Name = "UserControlConnection";
			this.Size = new System.Drawing.Size(530, 111);
			this.m_tabControl.ResumeLayout(false);
			this.m_tabPage_MSSQL.ResumeLayout(false);
			this.m_tabPage_MSSQL.PerformLayout();
			this.m_menuStrip_ConnectionHistory.ResumeLayout(false);
			this.m_menuStrip_ConnectionHistory.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl m_tabControl;
		private System.Windows.Forms.TabPage m_tabPage_MSSQL;
		private System.Windows.Forms.TextBox m_txtDatabaseNameMsSql;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button m_button_Connect;
		private System.Windows.Forms.Label m_label_testconnection;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox m_txtServerNameMsSql;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox m_txtUsernameMsSql;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox m_txtPasswordMsSql;
		private System.Windows.Forms.MenuStrip m_menuStrip_ConnectionHistory;
		private System.Windows.Forms.ToolStripComboBox m_toolStripComboBox_ConnectionHistory;
		private System.Windows.Forms.ToolStripMenuItem m_toolStripMenuItem_Apply;
		private System.Windows.Forms.ToolStripMenuItem m_toolStripMenuItem_Clear;
	}
}
