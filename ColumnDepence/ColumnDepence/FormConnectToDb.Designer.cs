namespace ColumnDepence
{
	partial class FormConnectToDb
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
      this.m_Label2 = new System.Windows.Forms.Label();
      this.m_LabelUserName = new System.Windows.Forms.Label();
      this.m_ButtonConnect = new System.Windows.Forms.Button();
      this.m_txtPasswordMsSql = new System.Windows.Forms.TextBox();
      this.m_LabelPassword = new System.Windows.Forms.Label();
      this.m_Label4 = new System.Windows.Forms.Label();
      this.m_comboBoxServerName = new System.Windows.Forms.ComboBox();
      this.m_comboBoxUserName = new System.Windows.Forms.ComboBox();
      this.m_comboBoxDatabase = new System.Windows.Forms.ComboBox();
      this.m_checkBoxWindowsAuth = new System.Windows.Forms.CheckBox();
      this.m_groupBoxButtons = new System.Windows.Forms.GroupBox();
      this.m_buttonCancel = new System.Windows.Forms.Button();
      this.m_GroupBox1 = new System.Windows.Forms.GroupBox();
      this.m_comboBoxConnectionHistory = new System.Windows.Forms.ComboBox();
      this.m_labelInfo = new System.Windows.Forms.Label();
      this.m_ButtonRefreshDbNames = new System.Windows.Forms.Button();
      this.m_groupBoxButtons.SuspendLayout();
      this.m_GroupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_Label2
      // 
      this.m_Label2.AutoSize = true;
      this.m_Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.m_Label2.Location = new System.Drawing.Point(12, 189);
      this.m_Label2.Name = "m_Label2";
      this.m_Label2.Size = new System.Drawing.Size(53, 13);
      this.m_Label2.TabIndex = 8;
      this.m_Label2.Text = "Database";
      // 
      // m_LabelUserName
      // 
      this.m_LabelUserName.AutoSize = true;
      this.m_LabelUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.m_LabelUserName.Location = new System.Drawing.Point(32, 119);
      this.m_LabelUserName.Name = "m_LabelUserName";
      this.m_LabelUserName.Size = new System.Drawing.Size(55, 13);
      this.m_LabelUserName.TabIndex = 4;
      this.m_LabelUserName.Text = "Username";
      // 
      // m_ButtonConnect
      // 
      this.m_ButtonConnect.Location = new System.Drawing.Point(74, 17);
      this.m_ButtonConnect.Name = "m_ButtonConnect";
      this.m_ButtonConnect.Size = new System.Drawing.Size(107, 23);
      this.m_ButtonConnect.TabIndex = 0;
      this.m_ButtonConnect.Text = "Connect";
      this.m_ButtonConnect.UseVisualStyleBackColor = true;
      this.m_ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
      // 
      // m_txtPasswordMsSql
      // 
      this.m_txtPasswordMsSql.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.m_txtPasswordMsSql.Location = new System.Drawing.Point(94, 143);
      this.m_txtPasswordMsSql.Name = "m_txtPasswordMsSql";
      this.m_txtPasswordMsSql.PasswordChar = '*';
      this.m_txtPasswordMsSql.Size = new System.Drawing.Size(214, 20);
      this.m_txtPasswordMsSql.TabIndex = 7;
      this.m_txtPasswordMsSql.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedPassword;
      // 
      // m_LabelPassword
      // 
      this.m_LabelPassword.AutoSize = true;
      this.m_LabelPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.m_LabelPassword.Location = new System.Drawing.Point(32, 146);
      this.m_LabelPassword.Name = "m_LabelPassword";
      this.m_LabelPassword.Size = new System.Drawing.Size(53, 13);
      this.m_LabelPassword.TabIndex = 6;
      this.m_LabelPassword.Text = "Password";
      // 
      // m_Label4
      // 
      this.m_Label4.AutoSize = true;
      this.m_Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.m_Label4.Location = new System.Drawing.Point(12, 57);
      this.m_Label4.Name = "m_Label4";
      this.m_Label4.Size = new System.Drawing.Size(38, 13);
      this.m_Label4.TabIndex = 1;
      this.m_Label4.Text = "Server";
      // 
      // m_comboBoxServerName
      // 
      this.m_comboBoxServerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedServer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.m_comboBoxServerName.FormattingEnabled = true;
      this.m_comboBoxServerName.Location = new System.Drawing.Point(74, 54);
      this.m_comboBoxServerName.Name = "m_comboBoxServerName";
      this.m_comboBoxServerName.Size = new System.Drawing.Size(234, 21);
      this.m_comboBoxServerName.TabIndex = 2;
      this.m_comboBoxServerName.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedServer;
      // 
      // m_comboBoxUserName
      // 
      this.m_comboBoxUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedUsername", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.m_comboBoxUserName.FormattingEnabled = true;
      this.m_comboBoxUserName.Location = new System.Drawing.Point(94, 116);
      this.m_comboBoxUserName.Name = "m_comboBoxUserName";
      this.m_comboBoxUserName.Size = new System.Drawing.Size(214, 21);
      this.m_comboBoxUserName.TabIndex = 5;
      this.m_comboBoxUserName.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedUsername;
      // 
      // m_comboBoxDatabase
      // 
      this.m_comboBoxDatabase.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ColumnDepence.Properties.Settings.Default, "LastUsedDatabase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.m_comboBoxDatabase.FormattingEnabled = true;
      this.m_comboBoxDatabase.Location = new System.Drawing.Point(74, 186);
      this.m_comboBoxDatabase.Name = "m_comboBoxDatabase";
      this.m_comboBoxDatabase.Size = new System.Drawing.Size(234, 21);
      this.m_comboBoxDatabase.TabIndex = 9;
      this.m_comboBoxDatabase.Text = global::ColumnDepence.Properties.Settings.Default.LastUsedDatabase;
      // 
      // m_checkBoxWindowsAuth
      // 
      this.m_checkBoxWindowsAuth.AutoSize = true;
      this.m_checkBoxWindowsAuth.Checked = global::ColumnDepence.Properties.Settings.Default.LastUsedIntegratedSecurity;
      this.m_checkBoxWindowsAuth.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ColumnDepence.Properties.Settings.Default, "LastUsedIntegratedSecurity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.m_checkBoxWindowsAuth.Location = new System.Drawing.Point(15, 93);
      this.m_checkBoxWindowsAuth.Name = "m_checkBoxWindowsAuth";
      this.m_checkBoxWindowsAuth.Size = new System.Drawing.Size(163, 17);
      this.m_checkBoxWindowsAuth.TabIndex = 3;
      this.m_checkBoxWindowsAuth.Text = "Use Windows Authentication";
      this.m_checkBoxWindowsAuth.UseVisualStyleBackColor = true;
      this.m_checkBoxWindowsAuth.CheckedChanged += new System.EventHandler(this.CheckBoxWindowsAuth_CheckedChanged);
      // 
      // m_groupBoxButtons
      // 
      this.m_groupBoxButtons.Controls.Add(this.m_buttonCancel);
      this.m_groupBoxButtons.Controls.Add(this.m_ButtonConnect);
      this.m_groupBoxButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.m_groupBoxButtons.Location = new System.Drawing.Point(0, 237);
      this.m_groupBoxButtons.Name = "m_groupBoxButtons";
      this.m_groupBoxButtons.Size = new System.Drawing.Size(356, 46);
      this.m_groupBoxButtons.TabIndex = 12;
      this.m_groupBoxButtons.TabStop = false;
      // 
      // m_buttonCancel
      // 
      this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.m_buttonCancel.Location = new System.Drawing.Point(189, 17);
      this.m_buttonCancel.Name = "m_buttonCancel";
      this.m_buttonCancel.Size = new System.Drawing.Size(107, 23);
      this.m_buttonCancel.TabIndex = 1;
      this.m_buttonCancel.Text = "Cancel";
      this.m_buttonCancel.UseVisualStyleBackColor = true;
      // 
      // m_GroupBox1
      // 
      this.m_GroupBox1.Controls.Add(this.m_comboBoxConnectionHistory);
      this.m_GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.m_GroupBox1.Location = new System.Drawing.Point(0, 0);
      this.m_GroupBox1.Name = "m_GroupBox1";
      this.m_GroupBox1.Size = new System.Drawing.Size(356, 42);
      this.m_GroupBox1.TabIndex = 0;
      this.m_GroupBox1.TabStop = false;
      this.m_GroupBox1.Text = "Server history";
      // 
      // m_comboBoxConnectionHistory
      // 
      this.m_comboBoxConnectionHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.m_comboBoxConnectionHistory.FormattingEnabled = true;
      this.m_comboBoxConnectionHistory.Location = new System.Drawing.Point(15, 15);
      this.m_comboBoxConnectionHistory.Name = "m_comboBoxConnectionHistory";
      this.m_comboBoxConnectionHistory.Size = new System.Drawing.Size(329, 21);
      this.m_comboBoxConnectionHistory.TabIndex = 0;
      this.m_comboBoxConnectionHistory.SelectedValueChanged += new System.EventHandler(this.ComboBoxConnectionHistory_SelectedValueChanged);
      // 
      // m_labelInfo
      // 
      this.m_labelInfo.AutoSize = true;
      this.m_labelInfo.ForeColor = System.Drawing.Color.Red;
      this.m_labelInfo.Location = new System.Drawing.Point(15, 218);
      this.m_labelInfo.Name = "m_labelInfo";
      this.m_labelInfo.Size = new System.Drawing.Size(0, 13);
      this.m_labelInfo.TabIndex = 11;
      // 
      // m_ButtonRefreshDbNames
      // 
      this.m_ButtonRefreshDbNames.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
      this.m_ButtonRefreshDbNames.Location = new System.Drawing.Point(315, 186);
      this.m_ButtonRefreshDbNames.Margin = new System.Windows.Forms.Padding(0);
      this.m_ButtonRefreshDbNames.Name = "m_ButtonRefreshDbNames";
      this.m_ButtonRefreshDbNames.Size = new System.Drawing.Size(29, 21);
      this.m_ButtonRefreshDbNames.TabIndex = 10;
      this.m_ButtonRefreshDbNames.Text = "q";
      this.m_ButtonRefreshDbNames.UseVisualStyleBackColor = true;
      this.m_ButtonRefreshDbNames.Click += new System.EventHandler(this.ButtonRefreshDbNames_Click);
      // 
      // FormConnectToDb
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.m_buttonCancel;
      this.ClientSize = new System.Drawing.Size(356, 283);
      this.Controls.Add(this.m_ButtonRefreshDbNames);
      this.Controls.Add(this.m_labelInfo);
      this.Controls.Add(this.m_GroupBox1);
      this.Controls.Add(this.m_groupBoxButtons);
      this.Controls.Add(this.m_checkBoxWindowsAuth);
      this.Controls.Add(this.m_comboBoxDatabase);
      this.Controls.Add(this.m_comboBoxUserName);
      this.Controls.Add(this.m_comboBoxServerName);
      this.Controls.Add(this.m_Label2);
      this.Controls.Add(this.m_LabelUserName);
      this.Controls.Add(this.m_txtPasswordMsSql);
      this.Controls.Add(this.m_LabelPassword);
      this.Controls.Add(this.m_Label4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormConnectToDb";
      this.Text = "Connect to Db";
      this.m_groupBoxButtons.ResumeLayout(false);
      this.m_GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label m_Label2;
		private System.Windows.Forms.Label m_LabelUserName;
		private System.Windows.Forms.Button m_ButtonConnect;
		private System.Windows.Forms.TextBox m_txtPasswordMsSql;
		private System.Windows.Forms.Label m_LabelPassword;
		private System.Windows.Forms.Label m_Label4;
		private System.Windows.Forms.ComboBox m_comboBoxServerName;
		private System.Windows.Forms.ComboBox m_comboBoxUserName;
		private System.Windows.Forms.ComboBox m_comboBoxDatabase;
		private System.Windows.Forms.CheckBox m_checkBoxWindowsAuth;
		private System.Windows.Forms.GroupBox m_groupBoxButtons;
		private System.Windows.Forms.Button m_buttonCancel;
		private System.Windows.Forms.GroupBox m_GroupBox1;
		private System.Windows.Forms.ComboBox m_comboBoxConnectionHistory;
		private System.Windows.Forms.Label m_labelInfo;
		private readonly StackSetting m_ConnectionHistorySetting;
		private StackSetting m_DatabaseHistrory;
    private System.Windows.Forms.Button m_ButtonRefreshDbNames;
	}
}