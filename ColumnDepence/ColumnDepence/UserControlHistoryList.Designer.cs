namespace ColumnDepence
{
	partial class UserControlHistoryList
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
			this.m_ComboBoxLatestUsed = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// m_ComboBoxLatestUsed
			// 
			this.m_ComboBoxLatestUsed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_ComboBoxLatestUsed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_ComboBoxLatestUsed.DropDownWidth = 300;
			this.m_ComboBoxLatestUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_ComboBoxLatestUsed.FormattingEnabled = true;
			this.m_ComboBoxLatestUsed.ItemHeight = 16;
			this.m_ComboBoxLatestUsed.Location = new System.Drawing.Point(0, 0);
			this.m_ComboBoxLatestUsed.Name = "m_ComboBoxLatestUsed";
			this.m_ComboBoxLatestUsed.Size = new System.Drawing.Size(20, 24);
			this.m_ComboBoxLatestUsed.TabIndex = 5;
			this.m_ComboBoxLatestUsed.SelectedIndexChanged += new System.EventHandler(this.m_comboBox_LatestUsed_SelectedIndexChanged);
			// 
			// UserControlHistoryList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_ComboBoxLatestUsed);
			this.Name = "UserControlHistoryList";
			this.Size = new System.Drawing.Size(20, 25);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox m_ComboBoxLatestUsed;
		private StackSetting m_DataSource;
	}
}
