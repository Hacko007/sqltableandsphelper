using System.Windows.Forms;

namespace hackovic.DbInfo
{
	partial class CustomControlLabelTextBox
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
			this.m_Label = new System.Windows.Forms.Label();
			this.m_TextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// m_Label
			// 
			this.m_Label.AutoSize = true;
			this.m_Label.BackColor = System.Drawing.Color.Transparent;
			this.m_Label.Location = new System.Drawing.Point(0, 3);
			this.m_Label.Name = "m_Label";
			this.m_Label.Size = new System.Drawing.Size(33, 13);
			this.m_Label.TabIndex = 0;
			this.m_Label.Text = "Label";
			// 
			// m_TextBox
			// 
			this.m_TextBox.Location = new System.Drawing.Point(39, 0);
			this.m_TextBox.Name = "m_TextBox";
			this.m_TextBox.Size = new System.Drawing.Size(219, 20);
			this.m_TextBox.TabIndex = 0;			
			// 
			// CustomControlLabelTextBox
			// 
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.m_TextBox);
			this.Controls.Add(this.m_Label);
			this.Name = "CustomControlLabelTextBox";
			this.Size = new System.Drawing.Size(258, 22);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label m_Label;
		private TextBox m_TextBox;
	}
}
