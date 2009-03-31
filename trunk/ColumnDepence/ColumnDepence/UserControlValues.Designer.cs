namespace ColumnDepence
{
	partial class UserControlValues
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel_menu = new System.Windows.Forms.Panel();
			this.m_labelTableCount = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.m_labelFilter = new System.Windows.Forms.Label();
			this.m_buttonRemoveFilter = new System.Windows.Forms.Button();
			this.m_labelInfo = new System.Windows.Forms.Label();
			this.dataGridView_Values = new System.Windows.Forms.DataGridView();
			this.m_contextMenuStripShownColumns = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_showallClumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_ChooseColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.m_ShowRowInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_contextMenuStripFilter = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_filterByValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_LikeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_LikeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.m_equalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_EqualToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.m_greToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_GraterThenToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.m_lessThenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_LessThenToolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.m_isNotNullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_isNullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_isTrueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_isFalseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_removeFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_panelDataGrid = new System.Windows.Forms.Panel();
			this.panel_menu.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Values)).BeginInit();
			this.m_contextMenuStripShownColumns.SuspendLayout();
			this.m_contextMenuStripFilter.SuspendLayout();
			this.m_panelDataGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_menu
			// 
			this.panel_menu.Controls.Add(this.m_labelTableCount);
			this.panel_menu.Controls.Add(this.flowLayoutPanel1);
			this.panel_menu.Controls.Add(this.m_labelInfo);
			this.panel_menu.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_menu.Location = new System.Drawing.Point(0, 0);
			this.panel_menu.Name = "panel_menu";
			this.panel_menu.Size = new System.Drawing.Size(227, 22);
			this.panel_menu.TabIndex = 0;
			// 
			// m_labelTableCount
			// 
			this.m_labelTableCount.AutoSize = true;
			this.m_labelTableCount.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_labelTableCount.Location = new System.Drawing.Point(227, 0);
			this.m_labelTableCount.Name = "m_labelTableCount";
			this.m_labelTableCount.Size = new System.Drawing.Size(0, 13);
			this.m_labelTableCount.TabIndex = 2;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.m_labelFilter);
			this.flowLayoutPanel1.Controls.Add(this.m_buttonRemoveFilter);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(58, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(169, 22);
			this.flowLayoutPanel1.TabIndex = 4;
			// 
			// m_labelFilter
			// 
			this.m_labelFilter.AutoSize = true;
			this.m_labelFilter.BackColor = System.Drawing.SystemColors.Control;
			this.m_labelFilter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.m_labelFilter.Location = new System.Drawing.Point(3, 0);
			this.m_labelFilter.Name = "m_labelFilter";
			this.m_labelFilter.Size = new System.Drawing.Size(0, 13);
			this.m_labelFilter.TabIndex = 1;
			this.m_labelFilter.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// m_buttonRemoveFilter
			// 
			this.m_buttonRemoveFilter.BackColor = System.Drawing.Color.Transparent;
			this.m_buttonRemoveFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_buttonRemoveFilter.ForeColor = System.Drawing.Color.Brown;
			this.m_buttonRemoveFilter.Location = new System.Drawing.Point(9, 3);
			this.m_buttonRemoveFilter.Name = "m_buttonRemoveFilter";
			this.m_buttonRemoveFilter.Size = new System.Drawing.Size(18, 21);
			this.m_buttonRemoveFilter.TabIndex = 3;
			this.m_buttonRemoveFilter.Text = "X";
			this.m_buttonRemoveFilter.UseVisualStyleBackColor = false;
			this.m_buttonRemoveFilter.Visible = false;
			this.m_buttonRemoveFilter.Click += new System.EventHandler(this.ButtonRemoveFilter_Click);
			// 
			// m_labelInfo
			// 
			this.m_labelInfo.AutoSize = true;
			this.m_labelInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_labelInfo.Location = new System.Drawing.Point(0, 0);
			this.m_labelInfo.Name = "m_labelInfo";
			this.m_labelInfo.Size = new System.Drawing.Size(58, 20);
			this.m_labelInfo.TabIndex = 0;
			this.m_labelInfo.Text = "Values";
			// 
			// dataGridView_Values
			// 
			this.dataGridView_Values.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
			this.dataGridView_Values.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView_Values.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView_Values.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView_Values.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Values.ContextMenuStrip = this.m_contextMenuStripShownColumns;
			this.dataGridView_Values.Location = new System.Drawing.Point(3, 3);
			this.dataGridView_Values.MinimumSize = new System.Drawing.Size(50, 50);
			this.dataGridView_Values.Name = "dataGridView_Values";
			this.dataGridView_Values.Size = new System.Drawing.Size(221, 86);
			this.dataGridView_Values.TabIndex = 1;
			this.dataGridView_Values.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_Values_UserDeletingRow);
			this.dataGridView_Values.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Values_MouseUp);
			// 
			// m_contextMenuStripShownColumns
			// 
			this.m_contextMenuStripShownColumns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_showallClumnsToolStripMenuItem,
            this.m_ChooseColumnsToolStripMenuItem,
            this.toolStripSeparator1,
            this.m_ShowRowInfoToolStripMenuItem});
			this.m_contextMenuStripShownColumns.Name = "m_contextMenuStripShownColumns";
			this.m_contextMenuStripShownColumns.Size = new System.Drawing.Size(165, 76);
			this.m_contextMenuStripShownColumns.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripShownColumns_Opening);
			// 
			// m_showallClumnsToolStripMenuItem
			// 
			this.m_showallClumnsToolStripMenuItem.Name = "m_showallClumnsToolStripMenuItem";
			this.m_showallClumnsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.m_showallClumnsToolStripMenuItem.Text = "Show &all clumns";
			this.m_showallClumnsToolStripMenuItem.Click += new System.EventHandler(this.ShowAllClumnsToolStripMenuItem_Click);
			// 
			// m_ChooseColumnsToolStripMenuItem
			// 
			this.m_ChooseColumnsToolStripMenuItem.Name = "m_ChooseColumnsToolStripMenuItem";
			this.m_ChooseColumnsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.m_ChooseColumnsToolStripMenuItem.Text = "&Choose Columns";
			this.m_ChooseColumnsToolStripMenuItem.Click += new System.EventHandler(this.ChooseColumnsToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
			// 
			// m_ShowRowInfoToolStripMenuItem
			// 
			this.m_ShowRowInfoToolStripMenuItem.Name = "m_ShowRowInfoToolStripMenuItem";
			this.m_ShowRowInfoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.m_ShowRowInfoToolStripMenuItem.Text = "Show row info";
			this.m_ShowRowInfoToolStripMenuItem.Click += new System.EventHandler(this.ShowRowInfoToolStripMenuItem_Click);
			// 
			// m_contextMenuStripFilter
			// 
			this.m_contextMenuStripFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_filterByValueToolStripMenuItem,
            this.m_removeFiltersToolStripMenuItem});
			this.m_contextMenuStripFilter.Name = "m_contextMenuStrip";
			this.m_contextMenuStripFilter.Size = new System.Drawing.Size(155, 48);
			// 
			// m_filterByValueToolStripMenuItem
			// 
			this.m_filterByValueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_LikeToolStripMenuItem,
            this.m_equalToolStripMenuItem,
            this.m_greToolStripMenuItem,
            this.m_lessThenToolStripMenuItem,
            this.m_isNotNullToolStripMenuItem,
            this.m_isNullToolStripMenuItem,
            this.m_isTrueToolStripMenuItem,
            this.m_isFalseToolStripMenuItem});
			this.m_filterByValueToolStripMenuItem.Image = global::ColumnDepence.Properties.Resources.FilterByColumn;
			this.m_filterByValueToolStripMenuItem.Name = "m_filterByValueToolStripMenuItem";
			this.m_filterByValueToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.m_filterByValueToolStripMenuItem.Text = "Filter by value";
			this.m_filterByValueToolStripMenuItem.Click += new System.EventHandler(this.FilterByValueToolStripMenuItem_Click);
			// 
			// m_LikeToolStripMenuItem
			// 
			this.m_LikeToolStripMenuItem.CheckOnClick = true;
			this.m_LikeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_LikeToolStripTextBox});
			this.m_LikeToolStripMenuItem.Name = "m_LikeToolStripMenuItem";
			this.m_LikeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.m_LikeToolStripMenuItem.Text = "Like";
			this.m_LikeToolStripMenuItem.Click += new System.EventHandler(this.LikeToolStripMenuItem_Click);
			// 
			// m_LikeToolStripTextBox
			// 
			this.m_LikeToolStripTextBox.Name = "m_LikeToolStripTextBox";
			this.m_LikeToolStripTextBox.Size = new System.Drawing.Size(100, 21);
			this.m_LikeToolStripTextBox.TextChanged += new System.EventHandler(this.LikeToolStripTextBox_TextChanged);
			// 
			// m_equalToolStripMenuItem
			// 
			this.m_equalToolStripMenuItem.CheckOnClick = true;
			this.m_equalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_EqualToolStripTextBox});
			this.m_equalToolStripMenuItem.Name = "m_equalToolStripMenuItem";
			this.m_equalToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.m_equalToolStripMenuItem.Text = "Equal To";
			this.m_equalToolStripMenuItem.Click += new System.EventHandler(this.EqualToolStripMenuItem_Click);
			// 
			// m_EqualToolStripTextBox
			// 
			this.m_EqualToolStripTextBox.Name = "m_EqualToolStripTextBox";
			this.m_EqualToolStripTextBox.Size = new System.Drawing.Size(100, 21);
			this.m_EqualToolStripTextBox.TextChanged += new System.EventHandler(this.EqualToolStripTextBox_TextChanged);
			// 
			// m_greToolStripMenuItem
			// 
			this.m_greToolStripMenuItem.CheckOnClick = true;
			this.m_greToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_GraterThenToolStripTextBox});
			this.m_greToolStripMenuItem.Name = "m_greToolStripMenuItem";
			this.m_greToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.m_greToolStripMenuItem.Text = "Greater Then";
			this.m_greToolStripMenuItem.Click += new System.EventHandler(this.GreToolStripMenuItem_Click);
			// 
			// m_GraterThenToolStripTextBox
			// 
			this.m_GraterThenToolStripTextBox.Name = "m_GraterThenToolStripTextBox";
			this.m_GraterThenToolStripTextBox.Size = new System.Drawing.Size(100, 21);
			this.m_GraterThenToolStripTextBox.TextChanged += new System.EventHandler(this.GraterThenToolStripTextBox_TextChanged);
			// 
			// m_lessThenToolStripMenuItem
			// 
			this.m_lessThenToolStripMenuItem.CheckOnClick = true;
			this.m_lessThenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_LessThenToolStripTextBox2});
			this.m_lessThenToolStripMenuItem.Name = "m_lessThenToolStripMenuItem";
			this.m_lessThenToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.m_lessThenToolStripMenuItem.Text = "Less Then";
			this.m_lessThenToolStripMenuItem.Click += new System.EventHandler(this.LessThenToolStripMenuItem_Click);
			// 
			// m_LessThenToolStripTextBox2
			// 
			this.m_LessThenToolStripTextBox2.Name = "m_LessThenToolStripTextBox2";
			this.m_LessThenToolStripTextBox2.Size = new System.Drawing.Size(100, 21);
			this.m_LessThenToolStripTextBox2.TextChanged += new System.EventHandler(this.LessThenToolStripTextBox2_TextChanged);
			// 
			// m_isNotNullToolStripMenuItem
			// 
			this.m_isNotNullToolStripMenuItem.CheckOnClick = true;
			this.m_isNotNullToolStripMenuItem.Name = "m_isNotNullToolStripMenuItem";
			this.m_isNotNullToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.m_isNotNullToolStripMenuItem.Text = "Is NOT null";
			this.m_isNotNullToolStripMenuItem.Click += new System.EventHandler(this.IsNotNullToolStripMenuItem_Click);
			// 
			// m_isNullToolStripMenuItem
			// 
			this.m_isNullToolStripMenuItem.CheckOnClick = true;
			this.m_isNullToolStripMenuItem.Name = "m_isNullToolStripMenuItem";
			this.m_isNullToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.m_isNullToolStripMenuItem.Text = "Is null";
			this.m_isNullToolStripMenuItem.Click += new System.EventHandler(this.IsNullToolStripMenuItem_Click);
			// 
			// m_isTrueToolStripMenuItem
			// 
			this.m_isTrueToolStripMenuItem.CheckOnClick = true;
			this.m_isTrueToolStripMenuItem.Name = "m_isTrueToolStripMenuItem";
			this.m_isTrueToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.m_isTrueToolStripMenuItem.Text = "Is True";
			this.m_isTrueToolStripMenuItem.Click += new System.EventHandler(this.IsTrueToolStripMenuItem_Click);
			// 
			// m_isFalseToolStripMenuItem
			// 
			this.m_isFalseToolStripMenuItem.CheckOnClick = true;
			this.m_isFalseToolStripMenuItem.Name = "m_isFalseToolStripMenuItem";
			this.m_isFalseToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.m_isFalseToolStripMenuItem.Text = "Is False";
			this.m_isFalseToolStripMenuItem.Click += new System.EventHandler(this.IsFalseToolStripMenuItem_Click);
			// 
			// m_removeFiltersToolStripMenuItem
			// 
			this.m_removeFiltersToolStripMenuItem.Enabled = false;
			this.m_removeFiltersToolStripMenuItem.Image = global::ColumnDepence.Properties.Resources.CloseImage;
			this.m_removeFiltersToolStripMenuItem.Name = "m_removeFiltersToolStripMenuItem";
			this.m_removeFiltersToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.m_removeFiltersToolStripMenuItem.Text = "Remove filters";
			this.m_removeFiltersToolStripMenuItem.Click += new System.EventHandler(this.RemoveFiltersToolStripMenuItem_Click);
			// 
			// m_panelDataGrid
			// 
			this.m_panelDataGrid.AutoScroll = true;
			this.m_panelDataGrid.Controls.Add(this.dataGridView_Values);
			this.m_panelDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panelDataGrid.Location = new System.Drawing.Point(0, 22);
			this.m_panelDataGrid.Name = "m_panelDataGrid";
			this.m_panelDataGrid.Size = new System.Drawing.Size(227, 106);
			this.m_panelDataGrid.TabIndex = 2;
			// 
			// UserControlValues
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.m_panelDataGrid);
			this.Controls.Add(this.panel_menu);
			this.Name = "UserControlValues";
			this.Size = new System.Drawing.Size(227, 128);
			this.panel_menu.ResumeLayout(false);
			this.panel_menu.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Values)).EndInit();
			this.m_contextMenuStripShownColumns.ResumeLayout(false);
			this.m_contextMenuStripFilter.ResumeLayout(false);
			this.m_panelDataGrid.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel_menu;
		private System.Windows.Forms.Label m_labelInfo;
		private System.Windows.Forms.DataGridView dataGridView_Values;
		private System.Windows.Forms.ContextMenuStrip m_contextMenuStripFilter;
		private System.Windows.Forms.ToolStripMenuItem m_filterByValueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_greToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox m_GraterThenToolStripTextBox;
		private System.Windows.Forms.ToolStripMenuItem m_lessThenToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox m_LessThenToolStripTextBox2;
		private System.Windows.Forms.ToolStripMenuItem m_equalToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox m_EqualToolStripTextBox;
		private System.Windows.Forms.ToolStripMenuItem m_isNullToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_isNotNullToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_removeFiltersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_LikeToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox m_LikeToolStripTextBox;
		private System.Windows.Forms.ToolStripMenuItem m_isTrueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_isFalseToolStripMenuItem;
		private System.Windows.Forms.Label m_labelFilter;
		private System.Windows.Forms.Label m_labelTableCount;
		private System.Windows.Forms.Panel m_panelDataGrid;
		private System.Windows.Forms.ContextMenuStrip m_contextMenuStripShownColumns;
		private System.Windows.Forms.ToolStripMenuItem m_showallClumnsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_ChooseColumnsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem m_ShowRowInfoToolStripMenuItem;
		private System.Windows.Forms.Button m_buttonRemoveFilter;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}
