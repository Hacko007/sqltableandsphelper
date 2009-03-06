namespace ColumnDepence
{
	partial class FormShowOneRow
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
			this.m_GroupBoxRowInfo = new System.Windows.Forms.GroupBox();
			this.m_PropertyGridRowData = new System.Windows.Forms.PropertyGrid();
			this.m_GroupBoxButtons = new System.Windows.Forms.GroupBox();
			this.m_ButtonCancel = new System.Windows.Forms.Button();
			this.m_ButtonUpdate = new System.Windows.Forms.Button();
			this.m_ButtonNext = new System.Windows.Forms.Button();
			this.m_ButtonPrev = new System.Windows.Forms.Button();
			this.m_GroupBoxRowInfo.SuspendLayout();
			this.m_GroupBoxButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_GroupBoxRowInfo
			// 
			this.m_GroupBoxRowInfo.Controls.Add(this.m_PropertyGridRowData);
			this.m_GroupBoxRowInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_GroupBoxRowInfo.Location = new System.Drawing.Point(0, 0);
			this.m_GroupBoxRowInfo.Name = "m_GroupBoxRowInfo";
			this.m_GroupBoxRowInfo.Size = new System.Drawing.Size(353, 278);
			this.m_GroupBoxRowInfo.TabIndex = 0;
			this.m_GroupBoxRowInfo.TabStop = false;
			// 
			// m_PropertyGridRowData
			// 
			this.m_PropertyGridRowData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_PropertyGridRowData.HelpVisible = false;
			this.m_PropertyGridRowData.Location = new System.Drawing.Point(3, 16);
			this.m_PropertyGridRowData.Name = "m_PropertyGridRowData";
			this.m_PropertyGridRowData.Size = new System.Drawing.Size(347, 259);
			this.m_PropertyGridRowData.TabIndex = 0;
			this.m_PropertyGridRowData.SelectedObjectsChanged += new System.EventHandler(this.PropertyGridRowData_SelectedObjectsChanged);
			// 
			// m_GroupBoxButtons
			// 
			this.m_GroupBoxButtons.Controls.Add(this.m_ButtonCancel);
			this.m_GroupBoxButtons.Controls.Add(this.m_ButtonUpdate);
			this.m_GroupBoxButtons.Controls.Add(this.m_ButtonNext);
			this.m_GroupBoxButtons.Controls.Add(this.m_ButtonPrev);
			this.m_GroupBoxButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_GroupBoxButtons.Location = new System.Drawing.Point(0, 278);
			this.m_GroupBoxButtons.Name = "m_GroupBoxButtons";
			this.m_GroupBoxButtons.Size = new System.Drawing.Size(353, 45);
			this.m_GroupBoxButtons.TabIndex = 1;
			this.m_GroupBoxButtons.TabStop = false;
			// 
			// m_ButtonCancel
			// 
			this.m_ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ButtonCancel.Enabled = false;
			this.m_ButtonCancel.Location = new System.Drawing.Point(272, 16);
			this.m_ButtonCancel.Name = "m_ButtonCancel";
			this.m_ButtonCancel.Size = new System.Drawing.Size(75, 23);
			this.m_ButtonCancel.TabIndex = 3;
			this.m_ButtonCancel.Text = "Cancel";
			this.m_ButtonCancel.UseVisualStyleBackColor = true;
			this.m_ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// m_ButtonUpdate
			// 
			this.m_ButtonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ButtonUpdate.Enabled = false;
			this.m_ButtonUpdate.Location = new System.Drawing.Point(191, 16);
			this.m_ButtonUpdate.Name = "m_ButtonUpdate";
			this.m_ButtonUpdate.Size = new System.Drawing.Size(75, 23);
			this.m_ButtonUpdate.TabIndex = 2;
			this.m_ButtonUpdate.Text = "Update";
			this.m_ButtonUpdate.UseVisualStyleBackColor = true;
			this.m_ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
			// 
			// m_ButtonNext
			// 
			this.m_ButtonNext.Location = new System.Drawing.Point(69, 16);
			this.m_ButtonNext.Name = "m_ButtonNext";
			this.m_ButtonNext.Size = new System.Drawing.Size(55, 23);
			this.m_ButtonNext.TabIndex = 1;
			this.m_ButtonNext.Text = ">>";
			this.m_ButtonNext.UseVisualStyleBackColor = true;
			this.m_ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
			// 
			// m_ButtonPrev
			// 
			this.m_ButtonPrev.Location = new System.Drawing.Point(6, 16);
			this.m_ButtonPrev.Name = "m_ButtonPrev";
			this.m_ButtonPrev.Size = new System.Drawing.Size(57, 23);
			this.m_ButtonPrev.TabIndex = 0;
			this.m_ButtonPrev.Text = "<<";
			this.m_ButtonPrev.UseVisualStyleBackColor = true;
			this.m_ButtonPrev.Click += new System.EventHandler(this.ButtonPrev_Click);
			// 
			// FormShowOneRow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(353, 323);
			this.Controls.Add(this.m_GroupBoxRowInfo);
			this.Controls.Add(this.m_GroupBoxButtons);
			this.Name = "FormShowOneRow";
			this.Text = "Show one row";
			this.m_GroupBoxRowInfo.ResumeLayout(false);
			this.m_GroupBoxButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox m_GroupBoxRowInfo;
		private System.Windows.Forms.GroupBox m_GroupBoxButtons;
		private System.Windows.Forms.Button m_ButtonCancel;
		private System.Windows.Forms.Button m_ButtonUpdate;
		private System.Windows.Forms.Button m_ButtonNext;
		private System.Windows.Forms.Button m_ButtonPrev;
		private System.Windows.Forms.PropertyGrid m_PropertyGridRowData;
	}
}