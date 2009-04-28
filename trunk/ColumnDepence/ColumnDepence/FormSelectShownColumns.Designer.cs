namespace ColumnDepence
{
	partial class FormSelectShownColumns
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
			this.m_radioButtonAll = new System.Windows.Forms.RadioButton();
			this.m_radioButtonNone = new System.Windows.Forms.RadioButton();
			this.m_checkedListBoxSelectedColumns = new System.Windows.Forms.CheckedListBox();
			this.m_buttonOK = new System.Windows.Forms.Button();
			this.m_buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_radioButtonAll
			// 
			this.m_radioButtonAll.AutoSize = true;
			this.m_radioButtonAll.Location = new System.Drawing.Point(13, 13);
			this.m_radioButtonAll.Name = "m_radioButtonAll";
			this.m_radioButtonAll.Size = new System.Drawing.Size(36, 17);
			this.m_radioButtonAll.TabIndex = 0;
			this.m_radioButtonAll.TabStop = true;
			this.m_radioButtonAll.Text = "All";
			this.m_radioButtonAll.UseVisualStyleBackColor = true;
			this.m_radioButtonAll.CheckedChanged += new System.EventHandler(this.RadioButtonAll_CheckedChanged);
			// 
			// m_radioButtonNone
			// 
			this.m_radioButtonNone.AutoSize = true;
			this.m_radioButtonNone.Location = new System.Drawing.Point(66, 13);
			this.m_radioButtonNone.Name = "m_radioButtonNone";
			this.m_radioButtonNone.Size = new System.Drawing.Size(51, 17);
			this.m_radioButtonNone.TabIndex = 1;
			this.m_radioButtonNone.TabStop = true;
			this.m_radioButtonNone.Text = "None";
			this.m_radioButtonNone.UseVisualStyleBackColor = true;
			this.m_radioButtonNone.CheckedChanged += new System.EventHandler(this.RadioButtonNone_CheckedChanged);
			// 
			// m_checkedListBoxSelectedColumns
			// 
			this.m_checkedListBoxSelectedColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_checkedListBoxSelectedColumns.CheckOnClick = true;
			this.m_checkedListBoxSelectedColumns.FormattingEnabled = true;
			this.m_checkedListBoxSelectedColumns.Location = new System.Drawing.Point(12, 36);
			this.m_checkedListBoxSelectedColumns.Name = "m_checkedListBoxSelectedColumns";
			this.m_checkedListBoxSelectedColumns.Size = new System.Drawing.Size(321, 379);
			this.m_checkedListBoxSelectedColumns.TabIndex = 2;
			// 
			// m_buttonOK
			// 
			this.m_buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_buttonOK.Location = new System.Drawing.Point(177, 434);
			this.m_buttonOK.Name = "m_buttonOK";
			this.m_buttonOK.Size = new System.Drawing.Size(75, 23);
			this.m_buttonOK.TabIndex = 3;
			this.m_buttonOK.Text = "OK";
			this.m_buttonOK.UseVisualStyleBackColor = true;
			this.m_buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
			// 
			// m_buttonCancel
			// 
			this.m_buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_buttonCancel.Location = new System.Drawing.Point(258, 434);
			this.m_buttonCancel.Name = "m_buttonCancel";
			this.m_buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.m_buttonCancel.TabIndex = 4;
			this.m_buttonCancel.Text = "Cancel";
			this.m_buttonCancel.UseVisualStyleBackColor = true;
			// 
			// FormSelectShownColumns
			// 
			this.AcceptButton = this.m_buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.m_buttonCancel;
			this.ClientSize = new System.Drawing.Size(345, 469);
			this.Controls.Add(this.m_buttonCancel);
			this.Controls.Add(this.m_buttonOK);
			this.Controls.Add(this.m_checkedListBoxSelectedColumns);
			this.Controls.Add(this.m_radioButtonNone);
			this.Controls.Add(this.m_radioButtonAll);
			this.Name = "FormSelectShownColumns";
			this.Text = "FormSelectShownColumns";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton m_radioButtonAll;
		private System.Windows.Forms.RadioButton m_radioButtonNone;
		private System.Windows.Forms.CheckedListBox m_checkedListBoxSelectedColumns;
		private System.Windows.Forms.Button m_buttonOK;
		private System.Windows.Forms.Button m_buttonCancel;
	}
}