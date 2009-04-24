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
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.m_button_Connect = new System.Windows.Forms.Button();
			this.m_txtPasswordMsSql = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_comboBoxServerName = new System.Windows.Forms.ComboBox();
			this.m_comboBoxUserName = new System.Windows.Forms.ComboBox();
			this.m_comboBoxDatabase = new System.Windows.Forms.ComboBox();
			this.m_checkBoxWindowsAuth = new System.Windows.Forms.CheckBox();
			this.m_groupBoxButtons = new System.Windows.Forms.GroupBox();
			this.m_buttonCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_comboBoxConnectionHistory = new System.Windows.Forms.ComboBox();
			this.m_labelInfo = new System.Windows.Forms.Label();
			this.m_groupBoxButtons.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(12, 189);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Database";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label5.Location = new System.Drawing.Point(32, 119);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Username";
			// 
			// m_button_Connect
			// 
			this.m_button_Connect.Location = new System.Drawing.Point(74, 17);
			this.m_button_Connect.Name = "m_button_Connect";
			this.m_button_Connect.Size = new System.Drawing.Size(107, 23);
			this.m_button_Connect.TabIndex = 0;
			this.m_button_Connect.Text = "Connect";
			this.m_button_Connect.UseVisualStyleBackColor = true;
			this.m_button_Connect.Click += new System.EventHandler(this.ButtonConnect_Click);
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
			this.m_txtPasswordMsSql.Leave += new System.EventHandler(this.Controls_Leave);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label6.Location = new System.Drawing.Point(32, 146);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Password";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(12, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Server";
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
			this.m_comboBoxServerName.Leave += new System.EventHandler(this.Controls_Leave);
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
			this.m_comboBoxUserName.Leave += new System.EventHandler(this.Controls_Leave);
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
			this.m_groupBoxButtons.Controls.Add(this.m_button_Connect);
			this.m_groupBoxButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_groupBoxButtons.Location = new System.Drawing.Point(0, 237);
			this.m_groupBoxButtons.Name = "m_groupBoxButtons";
			this.m_groupBoxButtons.Size = new System.Drawing.Size(356, 46);
			this.m_groupBoxButtons.TabIndex = 11;
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_comboBoxConnectionHistory);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(356, 42);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Connection history";
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
			this.m_labelInfo.TabIndex = 10;
			// 
			// FormConnectToDb
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.m_buttonCancel;
			this.ClientSize = new System.Drawing.Size(356, 283);
			this.Controls.Add(this.m_labelInfo);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_groupBoxButtons);
			this.Controls.Add(this.m_checkBoxWindowsAuth);
			this.Controls.Add(this.m_comboBoxDatabase);
			this.Controls.Add(this.m_comboBoxUserName);
			this.Controls.Add(this.m_comboBoxServerName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.m_txtPasswordMsSql);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormConnectToDb";
			this.Text = "Connect to Db";
			this.m_groupBoxButtons.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button m_button_Connect;
		private System.Windows.Forms.TextBox m_txtPasswordMsSql;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox m_comboBoxServerName;
		private System.Windows.Forms.ComboBox m_comboBoxUserName;
		private System.Windows.Forms.ComboBox m_comboBoxDatabase;
		private System.Windows.Forms.CheckBox m_checkBoxWindowsAuth;
		private System.Windows.Forms.GroupBox m_groupBoxButtons;
		private System.Windows.Forms.Button m_buttonCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox m_comboBoxConnectionHistory;
		private System.Windows.Forms.Label m_labelInfo;
		private readonly StackSetting connectionHistorySetting;
	}
}