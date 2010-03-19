namespace ColumnDepence
{
	partial class UserControlFullNameList
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
			this.m_ButtonOpen = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_ButtonOpen
			// 
			this.m_ButtonOpen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_ButtonOpen.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.m_ButtonOpen.Location = new System.Drawing.Point(0, 0);
			this.m_ButtonOpen.Name = "m_ButtonOpen";
			this.m_ButtonOpen.Size = new System.Drawing.Size(32, 29);
			this.m_ButtonOpen.TabIndex = 0;
			this.m_ButtonOpen.Text = "L";
			this.m_ButtonOpen.UseVisualStyleBackColor = true;
			this.m_ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
			// 
			// UserControlFullNameList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_ButtonOpen);
			this.Name = "UserControlFullNameList";
			this.Size = new System.Drawing.Size(32, 29);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button m_ButtonOpen;
	}
}
