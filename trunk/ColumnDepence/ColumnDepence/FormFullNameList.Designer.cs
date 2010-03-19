namespace ColumnDepence
{
	partial class FormFullNameList
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
			this.m_Panel = new System.Windows.Forms.Panel();
			this.m_ListBox = new System.Windows.Forms.ListBox();
			this.m_GroupBoxSearch = new System.Windows.Forms.GroupBox();
			this.m_TextBoxFilter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_Panel.SuspendLayout();
			this.m_GroupBoxSearch.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_Panel
			// 
			this.m_Panel.Controls.Add(this.m_ListBox);
			this.m_Panel.Controls.Add(this.m_GroupBoxSearch);
			this.m_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_Panel.Location = new System.Drawing.Point(0, 0);
			this.m_Panel.Name = "m_Panel";
			this.m_Panel.Size = new System.Drawing.Size(522, 803);
			this.m_Panel.TabIndex = 0;
			// 
			// m_ListBox
			// 
			this.m_ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_ListBox.FormattingEnabled = true;
			this.m_ListBox.ItemHeight = 20;
			this.m_ListBox.Location = new System.Drawing.Point(0, 47);
			this.m_ListBox.Name = "m_ListBox";
			this.m_ListBox.Size = new System.Drawing.Size(522, 744);
			this.m_ListBox.TabIndex = 1;
			this.m_ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
			// 
			// m_GroupBoxSearch
			// 
			this.m_GroupBoxSearch.Controls.Add(this.m_TextBoxFilter);
			this.m_GroupBoxSearch.Controls.Add(this.label1);
			this.m_GroupBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_GroupBoxSearch.Location = new System.Drawing.Point(0, 0);
			this.m_GroupBoxSearch.Name = "m_GroupBoxSearch";
			this.m_GroupBoxSearch.Size = new System.Drawing.Size(522, 47);
			this.m_GroupBoxSearch.TabIndex = 0;
			this.m_GroupBoxSearch.TabStop = false;
			// 
			// m_TextBoxFilter
			// 
			this.m_TextBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_TextBoxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_TextBoxFilter.Location = new System.Drawing.Point(47, 13);
			this.m_TextBoxFilter.Name = "m_TextBoxFilter";
			this.m_TextBoxFilter.Size = new System.Drawing.Size(463, 26);
			this.m_TextBoxFilter.TabIndex = 1;
			this.m_TextBoxFilter.TextChanged += new System.EventHandler(this.TextBoxFilter_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Filter";
			// 
			// FormFullNameList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(522, 803);
			this.Controls.Add(this.m_Panel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimizeBox = false;
			this.Name = "FormFullNameList";
			this.Text = "FormFullNameList";
			this.m_Panel.ResumeLayout(false);
			this.m_GroupBoxSearch.ResumeLayout(false);
			this.m_GroupBoxSearch.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel m_Panel;
		private System.Windows.Forms.GroupBox m_GroupBoxSearch;
		private System.Windows.Forms.TextBox m_TextBoxFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox m_ListBox;
	}
}