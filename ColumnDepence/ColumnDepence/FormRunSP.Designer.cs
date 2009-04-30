namespace ColumnDepence
{
	partial class FormRunSp
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRunSp));
			this.m_DataGridViewInputParameters = new System.Windows.Forms.DataGridView();
			this.m_ColumnParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_ColumnTypeAndLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_ColumnSetNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.m_ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_ToolStrip = new System.Windows.Forms.ToolStrip();
			this.m_toolStripButtonExec = new System.Windows.Forms.ToolStripButton();
			this.m_ToolStripButtonClearInputValues = new System.Windows.Forms.ToolStripButton();
			this.m_ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.m_ToolStripButtonClose = new System.Windows.Forms.ToolStripButton();
			this.m_SplitContainer = new System.Windows.Forms.SplitContainer();
			this.m_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewInputParameters)).BeginInit();
			this.m_ToolStrip.SuspendLayout();
			this.m_SplitContainer.Panel1.SuspendLayout();
			this.m_SplitContainer.Panel2.SuspendLayout();
			this.m_SplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_DataGridViewInputParameters
			// 
			this.m_DataGridViewInputParameters.AllowUserToAddRows = false;
			this.m_DataGridViewInputParameters.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_DataGridViewInputParameters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.m_DataGridViewInputParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_DataGridViewInputParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_ColumnParameterName,
            this.m_ColumnTypeAndLength,
            this.m_ColumnSetNull,
            this.m_ColumnValue});
			this.m_DataGridViewInputParameters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_DataGridViewInputParameters.Location = new System.Drawing.Point(0, 0);
			this.m_DataGridViewInputParameters.Name = "m_DataGridViewInputParameters";
			this.m_DataGridViewInputParameters.RowHeadersWidth = 20;
			this.m_DataGridViewInputParameters.Size = new System.Drawing.Size(800, 319);
			this.m_DataGridViewInputParameters.TabIndex = 0;
			this.m_DataGridViewInputParameters.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewInputParameters_CellClick);
			// 
			// m_ColumnParameterName
			// 
			this.m_ColumnParameterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.m_ColumnParameterName.HeaderText = "Parameter Name";
			this.m_ColumnParameterName.Name = "m_ColumnParameterName";
			this.m_ColumnParameterName.ReadOnly = true;
			this.m_ColumnParameterName.Width = 136;
			// 
			// m_ColumnTypeAndLength
			// 
			this.m_ColumnTypeAndLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.m_ColumnTypeAndLength.HeaderText = "Type and Length";
			this.m_ColumnTypeAndLength.Name = "m_ColumnTypeAndLength";
			this.m_ColumnTypeAndLength.ReadOnly = true;
			this.m_ColumnTypeAndLength.Width = 134;
			// 
			// m_ColumnSetNull
			// 
			this.m_ColumnSetNull.HeaderText = "Set null";
			this.m_ColumnSetNull.Name = "m_ColumnSetNull";
			this.m_ColumnSetNull.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.m_ColumnSetNull.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// m_ColumnValue
			// 
			this.m_ColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.m_ColumnValue.HeaderText = "Value";
			this.m_ColumnValue.Name = "m_ColumnValue";
			// 
			// m_ToolStrip
			// 
			this.m_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolStripButtonExec,
            this.m_ToolStripButtonClearInputValues,
            this.m_ToolStripSeparator1,
            this.m_ToolStripButtonClose});
			this.m_ToolStrip.Location = new System.Drawing.Point(0, 0);
			this.m_ToolStrip.Name = "m_ToolStrip";
			this.m_ToolStrip.Size = new System.Drawing.Size(800, 25);
			this.m_ToolStrip.TabIndex = 1;
			this.m_ToolStrip.Text = "toolStrip1";
			// 
			// m_toolStripButtonExec
			// 
			this.m_toolStripButtonExec.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonExec.Image")));
			this.m_toolStripButtonExec.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_toolStripButtonExec.Name = "m_toolStripButtonExec";
			this.m_toolStripButtonExec.Size = new System.Drawing.Size(81, 22);
			this.m_toolStripButtonExec.Text = "Execute SP";
			this.m_toolStripButtonExec.ToolTipText = "Execute stored procedure";
			this.m_toolStripButtonExec.Click += new System.EventHandler(this.ToolStripButtonExec_Click);
			// 
			// m_ToolStripButtonClearInputValues
			// 
			this.m_ToolStripButtonClearInputValues.Image = ((System.Drawing.Image)(resources.GetObject("m_ToolStripButtonClearInputValues.Image")));
			this.m_ToolStripButtonClearInputValues.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_ToolStripButtonClearInputValues.Name = "m_ToolStripButtonClearInputValues";
			this.m_ToolStripButtonClearInputValues.Size = new System.Drawing.Size(79, 22);
			this.m_ToolStripButtonClearInputValues.Text = "Clear input";
			this.m_ToolStripButtonClearInputValues.ToolTipText = "Clear input parameters";
			this.m_ToolStripButtonClearInputValues.Click += new System.EventHandler(this.ToolStripButtonClearInputValues_Click);
			// 
			// m_ToolStripSeparator1
			// 
			this.m_ToolStripSeparator1.Name = "m_ToolStripSeparator1";
			this.m_ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// m_ToolStripButtonClose
			// 
			this.m_ToolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_ToolStripButtonClose.Image = global::ColumnDepence.Properties.Resources.CloseImage;
			this.m_ToolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_ToolStripButtonClose.Name = "m_ToolStripButtonClose";
			this.m_ToolStripButtonClose.Size = new System.Drawing.Size(53, 22);
			this.m_ToolStripButtonClose.Text = "Close";
			this.m_ToolStripButtonClose.Click += new System.EventHandler(this.ToolStripButtonClose_Click);
			// 
			// m_SplitContainer
			// 
			this.m_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.m_SplitContainer.Location = new System.Drawing.Point(0, 25);
			this.m_SplitContainer.Name = "m_SplitContainer";
			this.m_SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// m_SplitContainer.Panel1
			// 
			this.m_SplitContainer.Panel1.Controls.Add(this.m_DataGridViewInputParameters);
			// 
			// m_SplitContainer.Panel2
			// 
			this.m_SplitContainer.Panel2.Controls.Add(this.m_TableLayoutPanel);
			this.m_SplitContainer.Panel2Collapsed = true;
			this.m_SplitContainer.Size = new System.Drawing.Size(800, 319);
			this.m_SplitContainer.SplitterDistance = 167;
			this.m_SplitContainer.TabIndex = 2;
			// 
			// m_TableLayoutPanel
			// 
			this.m_TableLayoutPanel.ColumnCount = 1;
			this.m_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.m_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.m_TableLayoutPanel.Name = "m_TableLayoutPanel";
			this.m_TableLayoutPanel.RowCount = 1;
			this.m_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.m_TableLayoutPanel.Size = new System.Drawing.Size(800, 148);
			this.m_TableLayoutPanel.TabIndex = 1;
			// 
			// FormRunSp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 344);
			this.Controls.Add(this.m_SplitContainer);
			this.Controls.Add(this.m_ToolStrip);
			this.Name = "FormRunSp";
			this.Text = "FormRunSp";
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewInputParameters)).EndInit();
			this.m_ToolStrip.ResumeLayout(false);
			this.m_ToolStrip.PerformLayout();
			this.m_SplitContainer.Panel1.ResumeLayout(false);
			this.m_SplitContainer.Panel2.ResumeLayout(false);
			this.m_SplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView m_DataGridViewInputParameters;
		private System.Windows.Forms.ToolStrip m_ToolStrip;
		private System.Windows.Forms.SplitContainer m_SplitContainer;
		private System.Windows.Forms.ToolStripButton m_toolStripButtonExec;
		private System.Windows.Forms.ToolStripButton m_ToolStripButtonClearInputValues;
		private System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator1;
		private System.Windows.Forms.ToolStripButton m_ToolStripButtonClose;
		private System.Windows.Forms.DataGridViewTextBoxColumn m_ColumnParameterName;
		private System.Windows.Forms.DataGridViewTextBoxColumn m_ColumnTypeAndLength;
		private System.Windows.Forms.DataGridViewCheckBoxColumn m_ColumnSetNull;
		private System.Windows.Forms.DataGridViewTextBoxColumn m_ColumnValue;
		private System.Windows.Forms.TableLayoutPanel m_TableLayoutPanel;
	}
}