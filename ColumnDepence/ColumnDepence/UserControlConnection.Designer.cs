namespace hackovic.DbInfo
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
			this.m_button_Connect = new System.Windows.Forms.Button();
			this.m_label_testconnection = new System.Windows.Forms.Label();
			this.m_comboBoxConnectionHistory = new System.Windows.Forms.ComboBox();
			this.m_buttonNewConnection = new System.Windows.Forms.Button();
			this.m_buttonRemove = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_button_Connect
			// 
			this.m_button_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_button_Connect.Location = new System.Drawing.Point(538, 6);
			this.m_button_Connect.Name = "m_button_Connect";
			this.m_button_Connect.Size = new System.Drawing.Size(120, 27);
			this.m_button_Connect.TabIndex = 9;
			this.m_button_Connect.Text = "Connect";
			this.m_button_Connect.UseVisualStyleBackColor = true;
			this.m_button_Connect.Click += new System.EventHandler(this.ButtonConnect_Click);
			// 
			// m_label_testconnection
			// 
			this.m_label_testconnection.AutoSize = true;
			this.m_label_testconnection.Location = new System.Drawing.Point(876, 30);
			this.m_label_testconnection.Name = "m_label_testconnection";
			this.m_label_testconnection.Size = new System.Drawing.Size(0, 13);
			this.m_label_testconnection.TabIndex = 10;
			// 
			// m_comboBoxConnectionHistory
			// 
			this.m_comboBoxConnectionHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_comboBoxConnectionHistory.DropDownWidth = 730;
			this.m_comboBoxConnectionHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_comboBoxConnectionHistory.FormattingEnabled = true;
			this.m_comboBoxConnectionHistory.IntegralHeight = false;
			this.m_comboBoxConnectionHistory.Location = new System.Drawing.Point(0, 3);
			this.m_comboBoxConnectionHistory.MaxDropDownItems = 15;
			this.m_comboBoxConnectionHistory.Name = "m_comboBoxConnectionHistory";
			this.m_comboBoxConnectionHistory.Size = new System.Drawing.Size(529, 33);
			this.m_comboBoxConnectionHistory.TabIndex = 11;
			// 
			// m_buttonNewConnection
			// 
			this.m_buttonNewConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_buttonNewConnection.Location = new System.Drawing.Point(828, 6);
			this.m_buttonNewConnection.Name = "m_buttonNewConnection";
			this.m_buttonNewConnection.Size = new System.Drawing.Size(148, 27);
			this.m_buttonNewConnection.TabIndex = 12;
			this.m_buttonNewConnection.Text = "New connection";
			this.m_buttonNewConnection.UseVisualStyleBackColor = true;
			this.m_buttonNewConnection.Click += new System.EventHandler(this.ButtonNewConnection_Click);
			// 
			// m_buttonRemove
			// 
			this.m_buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_buttonRemove.Location = new System.Drawing.Point(664, 6);
			this.m_buttonRemove.Name = "m_buttonRemove";
			this.m_buttonRemove.Size = new System.Drawing.Size(86, 27);
			this.m_buttonRemove.TabIndex = 13;
			this.m_buttonRemove.Text = "Remove";
			this.m_buttonRemove.UseVisualStyleBackColor = true;
			this.m_buttonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
			// 
			// UserControlConnection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_buttonRemove);
			this.Controls.Add(this.m_buttonNewConnection);
			this.Controls.Add(this.m_comboBoxConnectionHistory);
			this.Controls.Add(this.m_button_Connect);
			this.Controls.Add(this.m_label_testconnection);
			this.Name = "UserControlConnection";
			this.Size = new System.Drawing.Size(979, 38);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button m_button_Connect;
		private System.Windows.Forms.Label m_label_testconnection;
		private System.Windows.Forms.ComboBox m_comboBoxConnectionHistory;
		private System.Windows.Forms.Button m_buttonNewConnection;
		private System.Windows.Forms.Button m_buttonRemove;
	}
}
