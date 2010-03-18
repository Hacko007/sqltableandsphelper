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
			this.m_labelTabName = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_ButtonPrev = new System.Windows.Forms.Button();
			this.m_ButtonNext = new System.Windows.Forms.Button();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_panelTop = new System.Windows.Forms.Panel();
			this.m_ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_GroupBoxRowInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewValue)).BeginInit();
			this.panel1.SuspendLayout();
			this.m_panelTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_GroupBoxRowInfo
			// 
			this.m_GroupBoxRowInfo.Controls.Add(this.m_dataGridViewValue);
			this.m_GroupBoxRowInfo.Controls.Add(this.m_panelTop);
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
            this.m_ColumnName,
            this.m_ColumnValue});
			this.m_dataGridViewValue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_dataGridViewValue.Location = new System.Drawing.Point(3, 46);
			this.m_dataGridViewValue.Name = "m_dataGridViewValue";
			this.m_dataGridViewValue.RowHeadersWidth = 15;
			this.m_dataGridViewValue.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_dataGridViewValue.RowTemplate.Height = 25;
			this.m_dataGridViewValue.Size = new System.Drawing.Size(609, 463);
			this.m_dataGridViewValue.TabIndex = 0;
			this.m_dataGridViewValue.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewValue_CellEndEdit);
			// 
			// m_labelTabName
			// 
			this.m_labelTabName.AutoSize = true;
			this.m_labelTabName.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_labelTabName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_labelTabName.Location = new System.Drawing.Point(0, 0);
			this.m_labelTabName.Name = "m_labelTabName";
			this.m_labelTabName.Size = new System.Drawing.Size(121, 24);
			this.m_labelTabName.TabIndex = 1;
			this.m_labelTabName.Text = "Table name";
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.m_ButtonPrev);
			this.panel1.Controls.Add(this.m_ButtonNext);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(441, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(168, 30);
			this.panel1.TabIndex = 2;
			// 
			// m_ButtonPrev
			// 
			this.m_ButtonPrev.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.m_ButtonPrev.Location = new System.Drawing.Point(3, 0);
			this.m_ButtonPrev.Name = "m_ButtonPrev";
			this.m_ButtonPrev.Size = new System.Drawing.Size(81, 26);
			this.m_ButtonPrev.TabIndex = 0;
			this.m_ButtonPrev.Text = "7";
			this.m_ButtonPrev.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.m_ButtonPrev.UseVisualStyleBackColor = true;
			this.m_ButtonPrev.Click += new System.EventHandler(this.ButtonPrev_Click);
			// 
			// m_ButtonNext
			// 
			this.m_ButtonNext.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.m_ButtonNext.Location = new System.Drawing.Point(84, 0);
			this.m_ButtonNext.Name = "m_ButtonNext";
			this.m_ButtonNext.Size = new System.Drawing.Size(81, 26);
			this.m_ButtonNext.TabIndex = 1;
			this.m_ButtonNext.Text = "8";
			this.m_ButtonNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.m_ButtonNext.UseVisualStyleBackColor = true;
			this.m_ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Value";
			this.dataGridViewTextBoxColumn1.FillWeight = 200F;
			this.dataGridViewTextBoxColumn1.HeaderText = "Value";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 200;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ToolTipText = "Column value";
			// 
			// m_panelTop
			// 
			this.m_panelTop.Controls.Add(this.panel1);
			this.m_panelTop.Controls.Add(this.m_labelTabName);
			this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panelTop.Location = new System.Drawing.Point(3, 16);
			this.m_panelTop.Name = "m_panelTop";
			this.m_panelTop.Size = new System.Drawing.Size(609, 30);
			this.m_panelTop.TabIndex = 3;
			// 
			// m_ColumnName
			// 
			this.m_ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.m_ColumnName.HeaderText = "Column";
			this.m_ColumnName.Name = "m_ColumnName";
			this.m_ColumnName.ReadOnly = true;
			this.m_ColumnName.Width = 67;
			// 
			// m_ColumnValue
			// 
			this.m_ColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.m_ColumnValue.FillWeight = 250F;
			this.m_ColumnValue.HeaderText = "Value";
			this.m_ColumnValue.Name = "m_ColumnValue";
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
			this.panel1.ResumeLayout(false);
			this.m_panelTop.ResumeLayout(false);
			this.m_panelTop.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox m_GroupBoxRowInfo;
		private System.Windows.Forms.Button m_ButtonNext;
		private System.Windows.Forms.Button m_ButtonPrev;
		private System.Windows.Forms.DataGridView m_dataGridViewValue;
		private System.Windows.Forms.Label m_labelTabName;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnValueDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.Panel m_panelTop;
		private System.Windows.Forms.DataGridViewTextBoxColumn m_ColumnName;
		private System.Windows.Forms.DataGridViewTextBoxColumn m_ColumnValue;
	}
}