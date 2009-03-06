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
			this.m_comboBox_LatestUsed = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// m_comboBox_LatestUsed
			// 
			this.m_comboBox_LatestUsed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_comboBox_LatestUsed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_comboBox_LatestUsed.DropDownWidth = 300;
			this.m_comboBox_LatestUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_comboBox_LatestUsed.FormattingEnabled = true;
			this.m_comboBox_LatestUsed.ItemHeight = 16;
			this.m_comboBox_LatestUsed.Location = new System.Drawing.Point(0, 0);
			this.m_comboBox_LatestUsed.Name = "m_comboBox_LatestUsed";
			this.m_comboBox_LatestUsed.Size = new System.Drawing.Size(22, 24);
			this.m_comboBox_LatestUsed.TabIndex = 5;
			this.m_comboBox_LatestUsed.SelectedIndexChanged += new System.EventHandler(this.m_comboBox_LatestUsed_SelectedIndexChanged);
			// 
			// UserControlHistoryList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_comboBox_LatestUsed);
			this.Name = "UserControlHistoryList";
			this.Size = new System.Drawing.Size(22, 27);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox m_comboBox_LatestUsed;
	}
}
