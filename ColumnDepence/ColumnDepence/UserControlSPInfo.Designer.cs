using System.Windows.Forms;

namespace hackovic.DbInfo
{
	partial class UserControlSpInfo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSpInfo));
			this.m_SplitContainerMain = new System.Windows.Forms.SplitContainer();
			this.m_SplitContainerTop = new System.Windows.Forms.SplitContainer();
			this.m_DataGridViewParams = new System.Windows.Forms.DataGridView();
			this.m_labelParam = new System.Windows.Forms.Label();
			this.m_DataGridViewDepTables = new System.Windows.Forms.DataGridView();
			this.m_labelDepTab = new System.Windows.Forms.Label();
			this.m_ContextMenuStripShowDefinition = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_showDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_ToolStrip = new System.Windows.Forms.ToolStrip();
			this.m_toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
			this.m_toolStripButtonShowAsToolBox = new System.Windows.Forms.ToolStripButton();
			this.m_toolStripButtonShowParamInfo = new System.Windows.Forms.ToolStripButton();
			this.m_ToolStripButtonExecSp = new System.Windows.Forms.ToolStripButton();
			this.m_toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.m_toolStripLabelFind = new System.Windows.Forms.ToolStripLabel();
			this.m_toolStripTextBoxFind = new System.Windows.Forms.ToolStripTextBox();
			this.m_ToolStripButtonFindPrevious = new System.Windows.Forms.ToolStripButton();
			this.m_toolStripButtonFindNext = new System.Windows.Forms.ToolStripButton();
			this.m_toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.m_toolStripLabelConnection = new System.Windows.Forms.ToolStripLabel();
			this.m_RichTextBoxDefinition = new SqlRichTextBox();
			this.m_SplitContainerMain.Panel1.SuspendLayout();
			this.m_SplitContainerMain.Panel2.SuspendLayout();
			this.m_SplitContainerMain.SuspendLayout();
			this.m_SplitContainerTop.Panel1.SuspendLayout();
			this.m_SplitContainerTop.Panel2.SuspendLayout();
			this.m_SplitContainerTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewParams)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewDepTables)).BeginInit();
			this.m_ContextMenuStripShowDefinition.SuspendLayout();
			this.m_ToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_SplitContainerMain
			// 
			this.m_SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_SplitContainerMain.Location = new System.Drawing.Point(0, 25);
			this.m_SplitContainerMain.Name = "m_SplitContainerMain";
			this.m_SplitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// m_SplitContainerMain.Panel1
			// 
			this.m_SplitContainerMain.Panel1.Controls.Add(this.m_SplitContainerTop);
			this.m_SplitContainerMain.Panel1MinSize = 0;
			// 
			// m_SplitContainerMain.Panel2
			// 
			this.m_SplitContainerMain.Panel2.Controls.Add(this.m_RichTextBoxDefinition);
			this.m_SplitContainerMain.Panel2MinSize = 20;
			this.m_SplitContainerMain.Size = new System.Drawing.Size(1021, 747);
			this.m_SplitContainerMain.SplitterDistance = 200;
			this.m_SplitContainerMain.TabIndex = 0;
			// 
			// m_SplitContainerTop
			// 
			this.m_SplitContainerTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_SplitContainerTop.Location = new System.Drawing.Point(0, 0);
			this.m_SplitContainerTop.Name = "m_SplitContainerTop";
			// 
			// m_SplitContainerTop.Panel1
			// 
			this.m_SplitContainerTop.Panel1.Controls.Add(this.m_DataGridViewParams);
			this.m_SplitContainerTop.Panel1.Controls.Add(this.m_labelParam);
			// 
			// m_SplitContainerTop.Panel2
			// 
			this.m_SplitContainerTop.Panel2.Controls.Add(this.m_DataGridViewDepTables);
			this.m_SplitContainerTop.Panel2.Controls.Add(this.m_labelDepTab);
			this.m_SplitContainerTop.Size = new System.Drawing.Size(1021, 200);
			this.m_SplitContainerTop.SplitterDistance = 398;
			this.m_SplitContainerTop.TabIndex = 0;
			// 
			// m_DataGridViewParams
			// 
			this.m_DataGridViewParams.AllowUserToAddRows = false;
			this.m_DataGridViewParams.AllowUserToDeleteRows = false;
			this.m_DataGridViewParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_DataGridViewParams.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_DataGridViewParams.Location = new System.Drawing.Point(0, 20);
			this.m_DataGridViewParams.Name = "m_DataGridViewParams";
			this.m_DataGridViewParams.ReadOnly = true;
			this.m_DataGridViewParams.Size = new System.Drawing.Size(398, 180);
			this.m_DataGridViewParams.TabIndex = 1;
			// 
			// m_labelParam
			// 
			this.m_labelParam.AutoSize = true;
			this.m_labelParam.BackColor = System.Drawing.Color.Transparent;
			this.m_labelParam.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_labelParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_labelParam.Location = new System.Drawing.Point(0, 0);
			this.m_labelParam.Name = "m_labelParam";
			this.m_labelParam.Size = new System.Drawing.Size(91, 20);
			this.m_labelParam.TabIndex = 0;
			this.m_labelParam.Text = "Parameters";
			// 
			// m_DataGridViewDepTables
			// 
			this.m_DataGridViewDepTables.AllowUserToAddRows = false;
			this.m_DataGridViewDepTables.AllowUserToDeleteRows = false;
			this.m_DataGridViewDepTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_DataGridViewDepTables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_DataGridViewDepTables.Location = new System.Drawing.Point(0, 20);
			this.m_DataGridViewDepTables.MultiSelect = false;
			this.m_DataGridViewDepTables.Name = "m_DataGridViewDepTables";
			this.m_DataGridViewDepTables.ReadOnly = true;
			this.m_DataGridViewDepTables.Size = new System.Drawing.Size(619, 180);
			this.m_DataGridViewDepTables.TabIndex = 1;
			// 
			// m_labelDepTab
			// 
			this.m_labelDepTab.AutoSize = true;
			this.m_labelDepTab.BackColor = System.Drawing.Color.Transparent;
			this.m_labelDepTab.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_labelDepTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_labelDepTab.Location = new System.Drawing.Point(0, 0);
			this.m_labelDepTab.Name = "m_labelDepTab";
			this.m_labelDepTab.Size = new System.Drawing.Size(136, 20);
			this.m_labelDepTab.TabIndex = 0;
			this.m_labelDepTab.Text = "Dependent tables";
			// 
			// m_ContextMenuStripShowDefinition
			// 
			this.m_ContextMenuStripShowDefinition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_showDefinitionToolStripMenuItem});
			this.m_ContextMenuStripShowDefinition.Name = "m_ContextMenuStripShowDefinition";
			this.m_ContextMenuStripShowDefinition.Size = new System.Drawing.Size(160, 26);
			// 
			// m_showDefinitionToolStripMenuItem
			// 
            this.m_showDefinitionToolStripMenuItem.Image = global::hackovic.DbInfo.Properties.Resources.LoadDefinitionImage;
			this.m_showDefinitionToolStripMenuItem.Name = "m_showDefinitionToolStripMenuItem";
			this.m_showDefinitionToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.m_showDefinitionToolStripMenuItem.Text = "Show Definition";
			this.m_showDefinitionToolStripMenuItem.Click += new System.EventHandler(this.ShowDefinitionToolStripMenuItem_Click);
			// 
			// m_ToolStrip
			// 
			this.m_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolStripButtonClose,
            this.m_toolStripButtonShowAsToolBox,
            this.m_toolStripButtonShowParamInfo,
            this.m_ToolStripButtonExecSp,
            this.m_toolStripSeparator1,
            this.m_toolStripLabelFind,
            this.m_toolStripTextBoxFind,
            this.m_ToolStripButtonFindPrevious,
            this.m_toolStripButtonFindNext,
            this.m_toolStripSeparator2,
            this.m_toolStripLabelConnection});
			this.m_ToolStrip.Location = new System.Drawing.Point(0, 0);
			this.m_ToolStrip.Name = "m_ToolStrip";
			this.m_ToolStrip.Size = new System.Drawing.Size(1021, 25);
			this.m_ToolStrip.TabIndex = 0;
			this.m_ToolStrip.Text = "Tool Strip";
			// 
			// m_toolStripButtonClose
			// 
			this.m_toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.m_toolStripButtonClose.Image = global::hackovic.DbInfo.Properties.Resources.CloseImage;
			this.m_toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_toolStripButtonClose.Name = "m_toolStripButtonClose";
			this.m_toolStripButtonClose.Size = new System.Drawing.Size(72, 22);
			this.m_toolStripButtonClose.Text = "Close tab";
			this.m_toolStripButtonClose.Click += new System.EventHandler(this.ToolStripButtonClose_Click);
			// 
			// m_toolStripButtonShowAsToolBox
			// 
			this.m_toolStripButtonShowAsToolBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.m_toolStripButtonShowAsToolBox.Image = global::hackovic.DbInfo.Properties.Resources.ToolBoxImage;
			this.m_toolStripButtonShowAsToolBox.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_toolStripButtonShowAsToolBox.Name = "m_toolStripButtonShowAsToolBox";
			this.m_toolStripButtonShowAsToolBox.Size = new System.Drawing.Size(109, 22);
			this.m_toolStripButtonShowAsToolBox.Text = "Show as tool box";
			this.m_toolStripButtonShowAsToolBox.Click += new System.EventHandler(this.ToolStripButtonShowAsToolBox_Click);
			// 
			// m_toolStripButtonShowParamInfo
			// 
			this.m_toolStripButtonShowParamInfo.CheckOnClick = true;
            this.m_toolStripButtonShowParamInfo.Image = global::hackovic.DbInfo.Properties.Resources.LoadDefinitionImage;
			this.m_toolStripButtonShowParamInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_toolStripButtonShowParamInfo.Name = "m_toolStripButtonShowParamInfo";
			this.m_toolStripButtonShowParamInfo.Size = new System.Drawing.Size(116, 22);
			this.m_toolStripButtonShowParamInfo.Text = "Show ralationships";
			this.m_toolStripButtonShowParamInfo.CheckedChanged += new System.EventHandler(this.ToolStripButtonShowParamInfo_CheckedChanged);
			// 
			// m_ToolStripButtonExecSp
			// 
            this.m_ToolStripButtonExecSp.Image = global::hackovic.DbInfo.Properties.Resources.m_ToolStripButtonExecSp_Image;
			this.m_ToolStripButtonExecSp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_ToolStripButtonExecSp.Name = "m_ToolStripButtonExecSp";
			this.m_ToolStripButtonExecSp.Size = new System.Drawing.Size(81, 22);
			this.m_ToolStripButtonExecSp.Text = "Execute SP";
			this.m_ToolStripButtonExecSp.ToolTipText = "Execute Stored Procedure";
			this.m_ToolStripButtonExecSp.Click += new System.EventHandler(this.ToolStripButtonExecSp_Click);
			// 
			// m_toolStripSeparator1
			// 
			this.m_toolStripSeparator1.Name = "m_toolStripSeparator1";
			this.m_toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// m_toolStripLabelFind
			// 
			this.m_toolStripLabelFind.Name = "m_toolStripLabelFind";
			this.m_toolStripLabelFind.Size = new System.Drawing.Size(31, 22);
			this.m_toolStripLabelFind.Text = "Find:";
			// 
			// m_toolStripTextBoxFind
			// 
			this.m_toolStripTextBoxFind.Name = "m_toolStripTextBoxFind";
			this.m_toolStripTextBoxFind.Size = new System.Drawing.Size(150, 25);
			this.m_toolStripTextBoxFind.TextChanged += new System.EventHandler(this.ToolStripTextBoxFind_TextChanged);
			// 
			// m_ToolStripButtonFindPrevious
			// 
			this.m_ToolStripButtonFindPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_ToolStripButtonFindPrevious.Image = ((System.Drawing.Image)(resources.GetObject("m_ToolStripButtonFindPrevious.Image")));
			this.m_ToolStripButtonFindPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_ToolStripButtonFindPrevious.Name = "m_ToolStripButtonFindPrevious";
			this.m_ToolStripButtonFindPrevious.Size = new System.Drawing.Size(27, 22);
			this.m_ToolStripButtonFindPrevious.Text = "<<";
			this.m_ToolStripButtonFindPrevious.ToolTipText = "Scroll to previous";
			this.m_ToolStripButtonFindPrevious.Click += new System.EventHandler(this.ToolStripButtonFindPrevious_Click);
			// 
			// m_toolStripButtonFindNext
			// 
			this.m_toolStripButtonFindNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_toolStripButtonFindNext.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonFindNext.Image")));
			this.m_toolStripButtonFindNext.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_toolStripButtonFindNext.Name = "m_toolStripButtonFindNext";
			this.m_toolStripButtonFindNext.Size = new System.Drawing.Size(27, 22);
			this.m_toolStripButtonFindNext.Text = ">>";
			this.m_toolStripButtonFindNext.ToolTipText = "Scroll to next";
			this.m_toolStripButtonFindNext.Click += new System.EventHandler(this.ToolStripButtonFindNext_Click);
			// 
			// m_toolStripSeparator2
			// 
			this.m_toolStripSeparator2.Name = "m_toolStripSeparator2";
			this.m_toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// m_toolStripLabelConnection
			// 
			this.m_toolStripLabelConnection.Name = "m_toolStripLabelConnection";
			this.m_toolStripLabelConnection.Size = new System.Drawing.Size(0, 22);
			// 
			// m_RichTextBoxDefinition
			// 
			this.m_RichTextBoxDefinition.AcceptsTab = true;
			this.m_RichTextBoxDefinition.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_RichTextBoxDefinition.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_RichTextBoxDefinition.Location = new System.Drawing.Point(0, 0);
			this.m_RichTextBoxDefinition.Name = "m_RichTextBoxDefinition";
			this.m_RichTextBoxDefinition.Size = new System.Drawing.Size(1021, 543);
			this.m_RichTextBoxDefinition.TabIndex = 0;
			this.m_RichTextBoxDefinition.Text = "";
			this.m_RichTextBoxDefinition.FindTextCompleted += new System.EventHandler(RichTextBoxDefinition_FindTextCompleted);			
			// 
			// UserControlSpInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_SplitContainerMain);
			this.Controls.Add(this.m_ToolStrip);
			this.Name = "UserControlSpInfo";
			this.Size = new System.Drawing.Size(1021, 772);
			this.m_SplitContainerMain.Panel1.ResumeLayout(false);
			this.m_SplitContainerMain.Panel2.ResumeLayout(false);
			this.m_SplitContainerMain.ResumeLayout(false);
			this.m_SplitContainerTop.Panel1.ResumeLayout(false);
			this.m_SplitContainerTop.Panel1.PerformLayout();
			this.m_SplitContainerTop.Panel2.ResumeLayout(false);
			this.m_SplitContainerTop.Panel2.PerformLayout();
			this.m_SplitContainerTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewParams)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewDepTables)).EndInit();
			this.m_ContextMenuStripShowDefinition.ResumeLayout(false);
			this.m_ToolStrip.ResumeLayout(false);
			this.m_ToolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer m_SplitContainerMain;
		private System.Windows.Forms.SplitContainer m_SplitContainerTop;
		private System.Windows.Forms.DataGridView m_DataGridViewParams;
		private System.Windows.Forms.Label m_labelParam;
		private System.Windows.Forms.Label m_labelDepTab;
		private SqlRichTextBox m_RichTextBoxDefinition;
		private System.Windows.Forms.DataGridView m_DataGridViewDepTables;
		private System.Windows.Forms.ContextMenuStrip m_ContextMenuStripShowDefinition;
		private System.Windows.Forms.ToolStripMenuItem m_showDefinitionToolStripMenuItem;
		private System.Windows.Forms.ToolStrip m_ToolStrip;
		private System.Windows.Forms.ToolStripButton m_toolStripButtonShowAsToolBox;
		private System.Windows.Forms.ToolStripButton m_toolStripButtonClose;
		private System.Windows.Forms.ToolStripButton m_toolStripButtonShowParamInfo;
		private System.Windows.Forms.ToolStripSeparator m_toolStripSeparator1;
		private System.Windows.Forms.ToolStripTextBox m_toolStripTextBoxFind;
		private System.Windows.Forms.ToolStripSeparator m_toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel m_toolStripLabelConnection;
		private System.Windows.Forms.ToolStripLabel m_toolStripLabelFind;
		private int m_tryToLoadCounter ;
		private Form m_Toolbox ;
		private ToolStripButton m_ToolStripButtonExecSp;
		private ToolStripButton m_toolStripButtonFindNext;
		private ToolStripButton m_ToolStripButtonFindPrevious;
	}
}
