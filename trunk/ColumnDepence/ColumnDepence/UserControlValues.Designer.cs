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
			this.m_PanelFilter = new System.Windows.Forms.Panel();
			this.m_TextBoxFilter = new System.Windows.Forms.TextBox();
			this.m_buttonRemoveFilter = new System.Windows.Forms.Button();
			this.m_labelTableCount = new System.Windows.Forms.Label();
			this.m_labelInfo = new System.Windows.Forms.Label();
			this.m_DataGridViewValues = new System.Windows.Forms.DataGridView();
			this.m_contextMenuStripShownColumns = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_showallClumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_ChooseColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.m_ShowRowInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_ToolStripMenuItemFilterOnSelectedCells = new System.Windows.Forms.ToolStripMenuItem();
			this.m_BindingSourceValues = new System.Windows.Forms.BindingSource(this.components);
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
			this.m_PanelFilter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewValues)).BeginInit();
			this.m_contextMenuStripShownColumns.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_BindingSourceValues)).BeginInit();
			this.m_panelDataGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_PanelMenu
			// 
			this.m_PanelMenu.Controls.Add(this.m_PanelFilter);
			this.m_PanelMenu.Controls.Add(this.m_labelTableCount);
			this.m_PanelMenu.Controls.Add(this.m_labelInfo);
			this.m_PanelMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_PanelMenu.Location = new System.Drawing.Point(0, 0);
			this.m_PanelMenu.Name = "m_PanelMenu";
			this.m_PanelMenu.Size = new System.Drawing.Size(399, 31);
			this.m_PanelMenu.TabIndex = 0;
			// 
			// m_PanelFilter
			// 
			this.m_PanelFilter.Controls.Add(this.m_TextBoxFilter);
			this.m_PanelFilter.Controls.Add(this.m_buttonRemoveFilter);
			this.m_PanelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_PanelFilter.Location = new System.Drawing.Point(58, 0);
			this.m_PanelFilter.Name = "m_PanelFilter";
			this.m_PanelFilter.Size = new System.Drawing.Size(341, 31);
			this.m_PanelFilter.TabIndex = 4;
			// 
			// m_TextBoxFilter
			// 
			this.m_TextBoxFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_TextBoxFilter.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_TextBoxFilter.Location = new System.Drawing.Point(25, 0);
			this.m_TextBoxFilter.Multiline = true;
			this.m_TextBoxFilter.Name = "m_TextBoxFilter";
			this.m_TextBoxFilter.ReadOnly = true;
			this.m_TextBoxFilter.Size = new System.Drawing.Size(316, 31);
			this.m_TextBoxFilter.TabIndex = 4;
			// 
			// m_buttonRemoveFilter
			// 
			this.m_buttonRemoveFilter.BackColor = System.Drawing.Color.Transparent;
			this.m_buttonRemoveFilter.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_buttonRemoveFilter.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.m_buttonRemoveFilter.ForeColor = System.Drawing.Color.Brown;
			this.m_buttonRemoveFilter.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.m_buttonRemoveFilter.Location = new System.Drawing.Point(0, 0);
			this.m_buttonRemoveFilter.Name = "m_buttonRemoveFilter";
			this.m_buttonRemoveFilter.Size = new System.Drawing.Size(25, 31);
			this.m_buttonRemoveFilter.TabIndex = 3;
			this.m_buttonRemoveFilter.Text = "r";
			this.m_buttonRemoveFilter.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.m_buttonRemoveFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.m_buttonRemoveFilter.UseVisualStyleBackColor = true;
			this.m_buttonRemoveFilter.Visible = false;
			this.m_buttonRemoveFilter.Click += new System.EventHandler(this.ButtonRemoveFilter_Click);
			// 
			// m_labelTableCount
			// 
			this.m_labelTableCount.AutoSize = true;
			this.m_labelTableCount.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_labelTableCount.Location = new System.Drawing.Point(399, 0);
			this.m_labelTableCount.Name = "m_labelTableCount";
			this.m_labelTableCount.Size = new System.Drawing.Size(0, 13);
			this.m_labelTableCount.TabIndex = 2;
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
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
			this.m_DataGridViewValues.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.m_DataGridViewValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_DataGridViewValues.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_DataGridViewValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_DataGridViewValues.ContextMenuStrip = this.m_contextMenuStripShownColumns;
			this.m_DataGridViewValues.Location = new System.Drawing.Point(3, 6);
			this.m_DataGridViewValues.MinimumSize = new System.Drawing.Size(50, 50);
			this.m_DataGridViewValues.Name = "m_DataGridViewValues";
			this.m_DataGridViewValues.Size = new System.Drawing.Size(393, 196);
			this.m_DataGridViewValues.TabIndex = 1;
			this.m_DataGridViewValues.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridViewValues_UserDeletingRow);
			this.m_DataGridViewValues.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGridViewValues_MouseUp);
			this.m_DataGridViewValues.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewValues_CellEndEdit);
			// 
			// m_contextMenuStripShownColumns
			// 
			this.m_contextMenuStripShownColumns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_showallClumnsToolStripMenuItem,
            this.m_ChooseColumnsToolStripMenuItem,
            this.m_ToolStripSeparator1,
            this.m_ShowRowInfoToolStripMenuItem,
            this.m_ToolStripMenuItemFilterOnSelectedCells});
			this.m_contextMenuStripShownColumns.Name = "m_contextMenuStripShownColumns";
			this.m_contextMenuStripShownColumns.Size = new System.Drawing.Size(190, 120);
			this.m_contextMenuStripShownColumns.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripShownColumns_Opening);
			// 
			// m_showallClumnsToolStripMenuItem
			// 
			this.m_showallClumnsToolStripMenuItem.Name = "m_showallClumnsToolStripMenuItem";
			this.m_showallClumnsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.m_showallClumnsToolStripMenuItem.Text = "Show &all clumns";
			this.m_showallClumnsToolStripMenuItem.Click += new System.EventHandler(this.ShowAllClumnsToolStripMenuItem_Click);
			// 
			// m_ChooseColumnsToolStripMenuItem
			// 
			this.m_ChooseColumnsToolStripMenuItem.Name = "m_ChooseColumnsToolStripMenuItem";
			this.m_ChooseColumnsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.m_ChooseColumnsToolStripMenuItem.Text = "&Choose Columns";
			this.m_ChooseColumnsToolStripMenuItem.Click += new System.EventHandler(this.ChooseColumnsToolStripMenuItem_Click);
			// 
			// m_ToolStripSeparator1
			// 
			this.m_ToolStripSeparator1.Name = "m_ToolStripSeparator1";
			this.m_ToolStripSeparator1.Size = new System.Drawing.Size(186, 6);
			// 
			// m_ShowRowInfoToolStripMenuItem
			// 
			this.m_ShowRowInfoToolStripMenuItem.Name = "m_ShowRowInfoToolStripMenuItem";
			this.m_ShowRowInfoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.m_ShowRowInfoToolStripMenuItem.Text = "Show row info";
			this.m_ShowRowInfoToolStripMenuItem.Click += new System.EventHandler(this.ShowRowInfoToolStripMenuItem_Click);
			// 
			// m_ToolStripMenuItemFilterOnSelectedCells
			// 
			this.m_ToolStripMenuItemFilterOnSelectedCells.Image = global::ColumnDepence.Properties.Resources.FilterByWholeRow;
			this.m_ToolStripMenuItemFilterOnSelectedCells.ImageTransparentColor = System.Drawing.Color.Black;
			this.m_ToolStripMenuItemFilterOnSelectedCells.Name = "m_ToolStripMenuItemFilterOnSelectedCells";
			this.m_ToolStripMenuItemFilterOnSelectedCells.Size = new System.Drawing.Size(189, 22);
			this.m_ToolStripMenuItemFilterOnSelectedCells.Text = "Filter on selected cells";
			this.m_ToolStripMenuItemFilterOnSelectedCells.Click += new System.EventHandler(this.ToolStripMenuItemFilterOnSelectedCells_Click);
			// 
			// m_BindingSourceValues
			// 
			this.m_BindingSourceValues.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.BindingSourceValues_AddingNew);
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
			this.m_panelDataGrid.Location = new System.Drawing.Point(0, 31);
			this.m_panelDataGrid.Name = "m_panelDataGrid";
			this.m_panelDataGrid.Size = new System.Drawing.Size(399, 219);
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
			this.Size = new System.Drawing.Size(399, 250);
			this.m_PanelMenu.ResumeLayout(false);
			this.m_PanelMenu.PerformLayout();
			this.m_PanelFilter.ResumeLayout(false);
			this.m_PanelFilter.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewValues)).EndInit();
			this.m_contextMenuStripShownColumns.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_BindingSourceValues)).EndInit();
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
		private Label m_labelTableCount;
		private Panel m_panelDataGrid;
		private ContextMenuStrip m_contextMenuStripShownColumns;
		private ToolStripMenuItem m_showallClumnsToolStripMenuItem;
		private ToolStripMenuItem m_ChooseColumnsToolStripMenuItem;
		private ToolStripSeparator m_ToolStripSeparator1;
		private ToolStripMenuItem m_ShowRowInfoToolStripMenuItem;
		private Button m_buttonRemoveFilter;
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
		private BindingSource m_BindingSourceValues;
		private ToolStripMenuItem m_ToolStripMenuItemFilterOnSelectedCells;
		private Panel m_PanelFilter;
		private TextBox m_TextBoxFilter;
	}
}
