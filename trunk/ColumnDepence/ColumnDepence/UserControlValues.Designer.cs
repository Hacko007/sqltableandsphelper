using System.Collections.Generic;
using System.Windows.Forms;

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
			this.m_PanelMenu = new System.Windows.Forms.Panel();
			this.m_labelTableCount = new System.Windows.Forms.Label();
			this.m_FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.m_labelFilter = new System.Windows.Forms.Label();
			this.m_buttonRemoveFilter = new System.Windows.Forms.Button();
			this.m_labelInfo = new System.Windows.Forms.Label();
			this.m_DataGridViewValues = new System.Windows.Forms.DataGridView();
			this.m_contextMenuStripShownColumns = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_showallClumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_ChooseColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.m_ShowRowInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_contextMenuStripFilter = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_LikeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_equalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_greToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_lessThenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_isNotNullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_isNullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_ToolStripMenuItemIsTrue = new System.Windows.Forms.ToolStripMenuItem();
			this.m_ToolStripMenuItemIsFalse = new System.Windows.Forms.ToolStripMenuItem();
			this.m_removeFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_panelDataGrid = new System.Windows.Forms.Panel();
			this.m_PanelMenu.SuspendLayout();
			this.m_FlowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewValues)).BeginInit();
			this.m_contextMenuStripShownColumns.SuspendLayout();
			this.m_panelDataGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_PanelMenu
			// 
			this.m_PanelMenu.Controls.Add(this.m_labelTableCount);
			this.m_PanelMenu.Controls.Add(this.m_FlowLayoutPanel1);
			this.m_PanelMenu.Controls.Add(this.m_labelInfo);
			this.m_PanelMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_PanelMenu.Location = new System.Drawing.Point(0, 0);
			this.m_PanelMenu.Name = "m_PanelMenu";
			this.m_PanelMenu.Size = new System.Drawing.Size(227, 22);
			this.m_PanelMenu.TabIndex = 0;
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
			// m_FlowLayoutPanel1
			// 
			this.m_FlowLayoutPanel1.Controls.Add(this.m_labelFilter);
			this.m_FlowLayoutPanel1.Controls.Add(this.m_buttonRemoveFilter);
			this.m_FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_FlowLayoutPanel1.Location = new System.Drawing.Point(58, 0);
			this.m_FlowLayoutPanel1.Name = "m_FlowLayoutPanel1";
			this.m_FlowLayoutPanel1.Size = new System.Drawing.Size(169, 22);
			this.m_FlowLayoutPanel1.TabIndex = 4;
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
			this.m_labelFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_buttonRemoveFilter
			// 
			this.m_buttonRemoveFilter.BackColor = System.Drawing.Color.Transparent;
			this.m_buttonRemoveFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_buttonRemoveFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_buttonRemoveFilter.ForeColor = System.Drawing.Color.Brown;
			this.m_buttonRemoveFilter.Location = new System.Drawing.Point(9, 3);
			this.m_buttonRemoveFilter.Name = "m_buttonRemoveFilter";
			this.m_buttonRemoveFilter.Size = new System.Drawing.Size(19, 17);
			this.m_buttonRemoveFilter.TabIndex = 3;
			this.m_buttonRemoveFilter.Text = "X";
			this.m_buttonRemoveFilter.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
			// m_DataGridViewValues
			// 
			this.m_DataGridViewValues.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
			this.m_DataGridViewValues.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.m_DataGridViewValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_DataGridViewValues.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_DataGridViewValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_DataGridViewValues.ContextMenuStrip = this.m_contextMenuStripShownColumns;
			this.m_DataGridViewValues.Location = new System.Drawing.Point(3, 3);
			this.m_DataGridViewValues.MinimumSize = new System.Drawing.Size(50, 50);
			this.m_DataGridViewValues.Name = "m_DataGridViewValues";
			this.m_DataGridViewValues.Size = new System.Drawing.Size(221, 86);
			this.m_DataGridViewValues.TabIndex = 1;
			this.m_DataGridViewValues.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridViewValues_UserDeletingRow);
			this.m_DataGridViewValues.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGridViewValues_MouseUp);
			// 
			// m_contextMenuStripShownColumns
			// 
			this.m_contextMenuStripShownColumns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_showallClumnsToolStripMenuItem,
            this.m_ChooseColumnsToolStripMenuItem,
            this.m_ToolStripSeparator1,
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
			// m_ToolStripSeparator1
			// 
			this.m_ToolStripSeparator1.Name = "m_ToolStripSeparator1";
			this.m_ToolStripSeparator1.Size = new System.Drawing.Size(161, 6);
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
			this.m_contextMenuStripFilter.Name = "m_contextMenuStrip";
			this.m_contextMenuStripFilter.Size = new System.Drawing.Size(61, 4);
			// 
			// m_LikeToolStripMenuItem
			// 
			this.m_LikeToolStripMenuItem.Name = "m_LikeToolStripMenuItem";
			this.m_LikeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// m_equalToolStripMenuItem
			// 
			this.m_equalToolStripMenuItem.Name = "m_equalToolStripMenuItem";
			this.m_equalToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// m_greToolStripMenuItem
			// 
			this.m_greToolStripMenuItem.Name = "m_greToolStripMenuItem";
			this.m_greToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// m_lessThenToolStripMenuItem
			// 
			this.m_lessThenToolStripMenuItem.Name = "m_lessThenToolStripMenuItem";
			this.m_lessThenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
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
			// m_ToolStripMenuItemIsTrue
			// 
			this.m_ToolStripMenuItemIsTrue.CheckOnClick = true;
			this.m_ToolStripMenuItemIsTrue.Name = "m_ToolStripMenuItemIsTrue";
			this.m_ToolStripMenuItemIsTrue.Size = new System.Drawing.Size(149, 22);
			this.m_ToolStripMenuItemIsTrue.Text = "Is True";
			this.m_ToolStripMenuItemIsTrue.Click += new System.EventHandler(this.IsTrueToolStripMenuItem_Click);
			// 
			// m_ToolStripMenuItemIsFalse
			// 
			this.m_ToolStripMenuItemIsFalse.CheckOnClick = true;
			this.m_ToolStripMenuItemIsFalse.Name = "m_ToolStripMenuItemIsFalse";
			this.m_ToolStripMenuItemIsFalse.Size = new System.Drawing.Size(149, 22);
			this.m_ToolStripMenuItemIsFalse.Text = "Is False";
			this.m_ToolStripMenuItemIsFalse.Click += new System.EventHandler(this.IsFalseToolStripMenuItem_Click);
			// 
			// m_removeFiltersToolStripMenuItem
			// 
			this.m_removeFiltersToolStripMenuItem.Image = global::ColumnDepence.Properties.Resources.CloseImage;
			this.m_removeFiltersToolStripMenuItem.Name = "m_removeFiltersToolStripMenuItem";
			this.m_removeFiltersToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.m_removeFiltersToolStripMenuItem.Text = "Remove filters";
			this.m_removeFiltersToolStripMenuItem.Click += new System.EventHandler(this.RemoveFiltersToolStripMenuItem_Click);
			// 
			// m_panelDataGrid
			// 
			this.m_panelDataGrid.AutoScroll = true;
			this.m_panelDataGrid.Controls.Add(this.m_DataGridViewValues);
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
			this.Controls.Add(this.m_PanelMenu);
			this.Name = "UserControlValues";
			this.Size = new System.Drawing.Size(227, 128);
			this.m_PanelMenu.ResumeLayout(false);
			this.m_PanelMenu.PerformLayout();
			this.m_FlowLayoutPanel1.ResumeLayout(false);
			this.m_FlowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewValues)).EndInit();
			this.m_contextMenuStripShownColumns.ResumeLayout(false);
			this.m_panelDataGrid.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Panel m_PanelMenu;
		private Label m_labelInfo;
		private DataGridView m_DataGridViewValues;
		private ContextMenuStrip m_contextMenuStripFilter;		
		private ToolStripMenuItem m_greToolStripMenuItem;
		private ToolStripMenuItem m_lessThenToolStripMenuItem;
		private ToolStripMenuItem m_equalToolStripMenuItem;
		private ToolStripMenuItem m_isNullToolStripMenuItem;
		private ToolStripMenuItem m_isNotNullToolStripMenuItem;
		private ToolStripMenuItem m_removeFiltersToolStripMenuItem;
		private ToolStripMenuItem m_LikeToolStripMenuItem;
		private ToolStripMenuItem m_ToolStripMenuItemIsTrue;
		private ToolStripMenuItem m_ToolStripMenuItemIsFalse;
		private Label m_labelFilter;
		private Label m_labelTableCount;
		private Panel m_panelDataGrid;
		private ContextMenuStrip m_contextMenuStripShownColumns;
		private ToolStripMenuItem m_showallClumnsToolStripMenuItem;
		private ToolStripMenuItem m_ChooseColumnsToolStripMenuItem;
		private ToolStripSeparator m_ToolStripSeparator1;
		private ToolStripMenuItem m_ShowRowInfoToolStripMenuItem;
		private Button m_buttonRemoveFilter;
		private FlowLayoutPanel m_FlowLayoutPanel1;
		private string m_TableCount;
		private int m_ShownRows ;

		/// <summary>
		/// Last pressed column header
		/// </summary>
		private DataGridViewColumn m_ActiveColumn ;

		private Dictionary<string, ColumnFilter> m_FilterDictionary = new Dictionary<string, ColumnFilter>();
		private ToolStripLabel m_ToolStripLabelFilteredColumn;
		private ToolStripSeparator m_ToolStripSeparator2 ;
		private UserControlToolStripLabelTextBox m_ToolStripMenuItemLike;
		private UserControlToolStripLabelTextBox m_ToolStripMenuItemEqual;
		private UserControlToolStripLabelTextBox m_ToolStripMenuItemNotEqual;
		private UserControlToolStripLabelTextBox m_ToolStripMenuItemGreaterThen;
		private UserControlToolStripLabelTextBox m_ToolStripMenuItemLessThen;
	}
}
