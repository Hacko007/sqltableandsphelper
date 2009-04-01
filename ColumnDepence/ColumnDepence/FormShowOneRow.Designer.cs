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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.m_GroupBoxRowInfo = new System.Windows.Forms.GroupBox();
			this.m_dataGridViewValue = new System.Windows.Forms.DataGridView();
			this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_labelTabName = new System.Windows.Forms.Label();
			this.m_ButtonCancel = new System.Windows.Forms.Button();
			this.m_ButtonUpdate = new System.Windows.Forms.Button();
			this.m_ButtonNext = new System.Windows.Forms.Button();
			this.m_ButtonPrev = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_GroupBoxRowInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewValue)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_GroupBoxRowInfo
			// 
			this.m_GroupBoxRowInfo.Controls.Add(this.m_dataGridViewValue);
			this.m_GroupBoxRowInfo.Controls.Add(this.flowLayoutPanel1);
			this.m_GroupBoxRowInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_GroupBoxRowInfo.Location = new System.Drawing.Point(0, 0);
			this.m_GroupBoxRowInfo.Name = "m_GroupBoxRowInfo";
			this.m_GroupBoxRowInfo.Size = new System.Drawing.Size(615, 512);
			this.m_GroupBoxRowInfo.TabIndex = 0;
			this.m_GroupBoxRowInfo.TabStop = false;
			// 
			// m_dataGridViewValue
			// 
			this.m_dataGridViewValue.AllowUserToAddRows = false;
			this.m_dataGridViewValue.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.m_dataGridViewValue.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.m_dataGridViewValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_dataGridViewValue.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.m_dataGridViewValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_dataGridViewValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnValue});
			this.m_dataGridViewValue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_dataGridViewValue.Location = new System.Drawing.Point(3, 43);
			this.m_dataGridViewValue.Name = "m_dataGridViewValue";
			this.m_dataGridViewValue.RowHeadersWidth = 15;
			this.m_dataGridViewValue.Size = new System.Drawing.Size(609, 466);
			this.m_dataGridViewValue.TabIndex = 0;
			this.m_dataGridViewValue.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridViewValue_CellBeginEdit);
			// 
			// ColumnName
			// 
			this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColumnName.HeaderText = "Column";
			this.ColumnName.MinimumWidth = 100;
			this.ColumnName.Name = "ColumnName";
			this.ColumnName.ReadOnly = true;
			// 
			// ColumnValue
			// 
			this.ColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColumnValue.FillWeight = 200F;
			this.ColumnValue.HeaderText = "Value";
			this.ColumnValue.MinimumWidth = 200;
			this.ColumnValue.Name = "ColumnValue";
			this.ColumnValue.Width = 200;
			// 
			// m_labelTabName
			// 
			this.m_labelTabName.AutoSize = true;
			this.m_labelTabName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_labelTabName.Location = new System.Drawing.Point(3, 0);
			this.m_labelTabName.Name = "m_labelTabName";
			this.m_labelTabName.Size = new System.Drawing.Size(121, 24);
			this.m_labelTabName.TabIndex = 1;
			this.m_labelTabName.Text = "Table name";
			// 
			// m_ButtonCancel
			// 
			this.m_ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ButtonCancel.Enabled = false;
			this.m_ButtonCancel.Location = new System.Drawing.Point(262, 0);
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
			this.m_ButtonUpdate.Location = new System.Drawing.Point(183, 0);
			this.m_ButtonUpdate.Name = "m_ButtonUpdate";
			this.m_ButtonUpdate.Size = new System.Drawing.Size(75, 23);
			this.m_ButtonUpdate.TabIndex = 2;
			this.m_ButtonUpdate.Text = "Update";
			this.m_ButtonUpdate.UseVisualStyleBackColor = true;
			this.m_ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
			// 
			// m_ButtonNext
			// 
			this.m_ButtonNext.Location = new System.Drawing.Point(66, 0);
			this.m_ButtonNext.Name = "m_ButtonNext";
			this.m_ButtonNext.Size = new System.Drawing.Size(55, 23);
			this.m_ButtonNext.TabIndex = 1;
			this.m_ButtonNext.Text = ">>";
			this.m_ButtonNext.UseVisualStyleBackColor = true;
			this.m_ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
			// 
			// m_ButtonPrev
			// 
			this.m_ButtonPrev.Location = new System.Drawing.Point(3, 0);
			this.m_ButtonPrev.Name = "m_ButtonPrev";
			this.m_ButtonPrev.Size = new System.Drawing.Size(57, 23);
			this.m_ButtonPrev.TabIndex = 0;
			this.m_ButtonPrev.Text = "<<";
			this.m_ButtonPrev.UseVisualStyleBackColor = true;
			this.m_ButtonPrev.Click += new System.EventHandler(this.ButtonPrev_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.m_labelTabName);
			this.flowLayoutPanel1.Controls.Add(this.panel1);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(609, 27);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.m_ButtonCancel);
			this.panel1.Controls.Add(this.m_ButtonPrev);
			this.panel1.Controls.Add(this.m_ButtonUpdate);
			this.panel1.Controls.Add(this.m_ButtonNext);
			this.panel1.Location = new System.Drawing.Point(130, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(340, 26);
			this.panel1.TabIndex = 2;
			// 
			// FormShowOneRow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(615, 512);
			this.Controls.Add(this.m_GroupBoxRowInfo);
			this.Name = "FormShowOneRow";
			this.Text = "Show one row";
			this.m_GroupBoxRowInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewValue)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox m_GroupBoxRowInfo;
		private System.Windows.Forms.Button m_ButtonCancel;
		private System.Windows.Forms.Button m_ButtonUpdate;
		private System.Windows.Forms.Button m_ButtonNext;
		private System.Windows.Forms.Button m_ButtonPrev;
		private System.Windows.Forms.DataGridView m_dataGridViewValue;
		private System.Windows.Forms.Label m_labelTabName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
	}
}