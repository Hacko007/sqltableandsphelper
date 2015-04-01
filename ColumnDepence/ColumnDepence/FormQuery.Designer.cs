namespace hackovic.DbInfo
{
  partial class FormQuery
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuery));
      this.m_StatusStrip = new System.Windows.Forms.StatusStrip();
      this.m_StatusConnection = new System.Windows.Forms.ToolStripStatusLabel();
      this.m_StatusTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.m_StatuNrRows = new System.Windows.Forms.ToolStripStatusLabel();
      this.m_ToolStrip = new System.Windows.Forms.ToolStrip();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.m_ToolStripComboBoxConnection = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.m_ToolStripButtonExecute = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.m_ToolStripButtonOutputDataGrid = new System.Windows.Forms.ToolStripButton();
      this.m_ToolStripButtonOutputText = new System.Windows.Forms.ToolStripButton();
      this.m_SplitContainerMain = new System.Windows.Forms.SplitContainer();
      this.m_sqlRichTextBox = new SqlRichTextBox();
      this.m_TableLayoutPanelResult = new System.Windows.Forms.TableLayoutPanel();
      this.m_StatusStrip.SuspendLayout();
      this.m_ToolStrip.SuspendLayout();
      this.m_SplitContainerMain.Panel1.SuspendLayout();
      this.m_SplitContainerMain.Panel2.SuspendLayout();
      this.m_SplitContainerMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_StatusStrip
      // 
      this.m_StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_StatusConnection,
            this.m_StatusTime,
            this.m_StatuNrRows});
      this.m_StatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.m_StatusStrip.Location = new System.Drawing.Point(0, 496);
      this.m_StatusStrip.Name = "m_StatusStrip";
      this.m_StatusStrip.Size = new System.Drawing.Size(995, 22);
      this.m_StatusStrip.TabIndex = 0;
      // 
      // m_StatusConnection
      // 
      this.m_StatusConnection.Image = global::hackovic.DbInfo.Properties.Resources.Connect;
      this.m_StatusConnection.Name = "m_StatusConnection";
      this.m_StatusConnection.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
      this.m_StatusConnection.Size = new System.Drawing.Size(36, 17);
      // 
      // m_StatusTime
      // 
      this.m_StatusTime.Image = global::hackovic.DbInfo.Properties.Resources.Time;
      this.m_StatusTime.Name = "m_StatusTime";
      this.m_StatusTime.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
      this.m_StatusTime.Size = new System.Drawing.Size(36, 17);
      // 
      // m_StatuNrRows
      // 
      this.m_StatuNrRows.Image = global::hackovic.DbInfo.Properties.Resources.Number;
      this.m_StatuNrRows.Name = "m_StatuNrRows";
      this.m_StatuNrRows.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
      this.m_StatuNrRows.Size = new System.Drawing.Size(36, 17);
      // 
      // m_ToolStrip
      // 
      this.m_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.m_ToolStripComboBoxConnection,
            this.toolStripSeparator1,
            this.m_ToolStripButtonExecute,
            this.toolStripSeparator2,
            this.m_ToolStripButtonOutputDataGrid,
            this.m_ToolStripButtonOutputText});
      this.m_ToolStrip.Location = new System.Drawing.Point(0, 0);
      this.m_ToolStrip.Name = "m_ToolStrip";
      this.m_ToolStrip.Size = new System.Drawing.Size(995, 25);
      this.m_ToolStrip.TabIndex = 1;
      this.m_ToolStrip.Text = "toolStrip1";
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Image = global::hackovic.DbInfo.Properties.Resources.Connect;
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(77, 22);
      this.toolStripLabel1.Text = "Connection";
      this.toolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
      // 
      // m_ToolStripComboBoxConnection
      // 
      this.m_ToolStripComboBoxConnection.DropDownWidth = 200;
      this.m_ToolStripComboBoxConnection.Name = "m_ToolStripComboBoxConnection";
      this.m_ToolStripComboBoxConnection.Size = new System.Drawing.Size(200, 25);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // m_ToolStripButtonExecute
      // 
      this.m_ToolStripButtonExecute.Image = global::hackovic.DbInfo.Properties.Resources.m_ToolStripButtonExecSp_Image;
      this.m_ToolStripButtonExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_ToolStripButtonExecute.Name = "m_ToolStripButtonExecute";
      this.m_ToolStripButtonExecute.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
      this.m_ToolStripButtonExecute.Size = new System.Drawing.Size(106, 22);
      this.m_ToolStripButtonExecute.Text = "&Execute";
      this.m_ToolStripButtonExecute.Click += new System.EventHandler(this.OnExecuteClick);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // m_ToolStripButtonOutputDataGrid
      // 
      this.m_ToolStripButtonOutputDataGrid.Checked = true;
      this.m_ToolStripButtonOutputDataGrid.CheckOnClick = true;
      this.m_ToolStripButtonOutputDataGrid.CheckState = System.Windows.Forms.CheckState.Checked;
      this.m_ToolStripButtonOutputDataGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_ToolStripButtonOutputDataGrid.Image = global::hackovic.DbInfo.Properties.Resources._1322752321_grid;
      this.m_ToolStripButtonOutputDataGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_ToolStripButtonOutputDataGrid.Name = "m_ToolStripButtonOutputDataGrid";
      this.m_ToolStripButtonOutputDataGrid.Size = new System.Drawing.Size(23, 22);
      this.m_ToolStripButtonOutputDataGrid.Text = "Data grid";
      // 
      // m_ToolStripButtonOutputText
      // 
      this.m_ToolStripButtonOutputText.CheckOnClick = true;
      this.m_ToolStripButtonOutputText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_ToolStripButtonOutputText.Image = global::hackovic.DbInfo.Properties.Resources.text_align_justify;
      this.m_ToolStripButtonOutputText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_ToolStripButtonOutputText.Name = "m_ToolStripButtonOutputText";
      this.m_ToolStripButtonOutputText.Size = new System.Drawing.Size(23, 22);
      this.m_ToolStripButtonOutputText.Text = "Text";
      // 
      // m_SplitContainerMain
      // 
      this.m_SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_SplitContainerMain.Location = new System.Drawing.Point(0, 25);
      this.m_SplitContainerMain.Name = "m_SplitContainerMain";
      // 
      // m_SplitContainerMain.Panel1
      // 
      this.m_SplitContainerMain.Panel1.Controls.Add(this.m_sqlRichTextBox);
      // 
      // m_SplitContainerMain.Panel2
      // 
      this.m_SplitContainerMain.Panel2.Controls.Add(this.m_TableLayoutPanelResult);
      this.m_SplitContainerMain.Panel2MinSize = 0;
      this.m_SplitContainerMain.Size = new System.Drawing.Size(995, 471);
      this.m_SplitContainerMain.SplitterDistance = 607;
      this.m_SplitContainerMain.SplitterWidth = 8;
      this.m_SplitContainerMain.TabIndex = 2;
      this.m_SplitContainerMain.DoubleClick += new System.EventHandler(this.OnSplitContainerMainDoubleClick);
      // 
      // m_sqlRichTextBox
      // 
      this.m_sqlRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_sqlRichTextBox.Location = new System.Drawing.Point(0, 0);
      this.m_sqlRichTextBox.Name = "m_sqlRichTextBox";
      this.m_sqlRichTextBox.Size = new System.Drawing.Size(607, 471);
      this.m_sqlRichTextBox.TabIndex = 0;
      this.m_sqlRichTextBox.Text = "";
      // 
      // m_TableLayoutPanelResult
      // 
      this.m_TableLayoutPanelResult.AutoScroll = true;
      this.m_TableLayoutPanelResult.ColumnCount = 1;
      this.m_TableLayoutPanelResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.m_TableLayoutPanelResult.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_TableLayoutPanelResult.Location = new System.Drawing.Point(0, 0);
      this.m_TableLayoutPanelResult.Name = "m_TableLayoutPanelResult";
      this.m_TableLayoutPanelResult.RowCount = 1;
      this.m_TableLayoutPanelResult.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.m_TableLayoutPanelResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 471F));
      this.m_TableLayoutPanelResult.Size = new System.Drawing.Size(380, 471);
      this.m_TableLayoutPanelResult.TabIndex = 0;
      // 
      // FormQuery
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(995, 518);
      this.Controls.Add(this.m_SplitContainerMain);
      this.Controls.Add(this.m_ToolStrip);
      this.Controls.Add(this.m_StatusStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormQuery";
      this.Text = "Sql query";
      this.Load += new System.EventHandler(this.FormQuery_Load);
      this.m_StatusStrip.ResumeLayout(false);
      this.m_StatusStrip.PerformLayout();
      this.m_ToolStrip.ResumeLayout(false);
      this.m_ToolStrip.PerformLayout();
      this.m_SplitContainerMain.Panel1.ResumeLayout(false);
      this.m_SplitContainerMain.Panel2.ResumeLayout(false);
      this.m_SplitContainerMain.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip m_StatusStrip;
    private System.Windows.Forms.ToolStrip m_ToolStrip;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripComboBox m_ToolStripComboBoxConnection;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton m_ToolStripButtonExecute;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton m_ToolStripButtonOutputDataGrid;
    private System.Windows.Forms.ToolStripButton m_ToolStripButtonOutputText;
    private System.Windows.Forms.SplitContainer m_SplitContainerMain;
    private SqlRichTextBox m_sqlRichTextBox;
    private System.Windows.Forms.TableLayoutPanel m_TableLayoutPanelResult;
    private System.Windows.Forms.ToolStripStatusLabel m_StatuNrRows;
    private System.Windows.Forms.ToolStripStatusLabel m_StatusTime;
    private System.Windows.Forms.ToolStripStatusLabel m_StatusConnection;
  }
}