namespace ColumnDepence
{
	partial class UserControlSPInfo
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
			this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
			this.splitContainer_Top = new System.Windows.Forms.SplitContainer();
			this.m_dataGridView_Params = new System.Windows.Forms.DataGridView();
			this.m_labelParam = new System.Windows.Forms.Label();
			this.m_dataGridView_DepTables = new System.Windows.Forms.DataGridView();
			this.m_labelDepTab = new System.Windows.Forms.Label();
			this.m_richTextBox_Definition = new System.Windows.Forms.RichTextBox();
			this.m_ContextMenuStrip_ShowDefinition = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_showDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer_Main.Panel1.SuspendLayout();
			this.splitContainer_Main.Panel2.SuspendLayout();
			this.splitContainer_Main.SuspendLayout();
			this.splitContainer_Top.Panel1.SuspendLayout();
			this.splitContainer_Top.Panel2.SuspendLayout();
			this.splitContainer_Top.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dataGridView_Params)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dataGridView_DepTables)).BeginInit();
			this.m_ContextMenuStrip_ShowDefinition.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer_Main
			// 
			this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_Main.Name = "splitContainer_Main";
			this.splitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer_Main.Panel1
			// 
			this.splitContainer_Main.Panel1.Controls.Add(this.splitContainer_Top);
			// 
			// splitContainer_Main.Panel2
			// 
			this.splitContainer_Main.Panel2.Controls.Add(this.m_richTextBox_Definition);
			this.splitContainer_Main.Size = new System.Drawing.Size(1021, 772);
			this.splitContainer_Main.SplitterDistance = 207;
			this.splitContainer_Main.TabIndex = 0;
			// 
			// splitContainer_Top
			// 
			this.splitContainer_Top.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer_Top.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_Top.Name = "splitContainer_Top";
			// 
			// splitContainer_Top.Panel1
			// 
			this.splitContainer_Top.Panel1.Controls.Add(this.m_dataGridView_Params);
			this.splitContainer_Top.Panel1.Controls.Add(this.m_labelParam);
			// 
			// splitContainer_Top.Panel2
			// 
			this.splitContainer_Top.Panel2.Controls.Add(this.m_dataGridView_DepTables);
			this.splitContainer_Top.Panel2.Controls.Add(this.m_labelDepTab);
			this.splitContainer_Top.Size = new System.Drawing.Size(1021, 207);
			this.splitContainer_Top.SplitterDistance = 398;
			this.splitContainer_Top.TabIndex = 0;
			// 
			// m_dataGridView_Params
			// 
			this.m_dataGridView_Params.AllowUserToAddRows = false;
			this.m_dataGridView_Params.AllowUserToDeleteRows = false;
			this.m_dataGridView_Params.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_dataGridView_Params.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_dataGridView_Params.Location = new System.Drawing.Point(0, 13);
			this.m_dataGridView_Params.Name = "m_dataGridView_Params";
			this.m_dataGridView_Params.ReadOnly = true;
			this.m_dataGridView_Params.Size = new System.Drawing.Size(398, 194);
			this.m_dataGridView_Params.TabIndex = 0;
			// 
			// m_labelParam
			// 
			this.m_labelParam.AutoSize = true;
			this.m_labelParam.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_labelParam.Location = new System.Drawing.Point(0, 0);
			this.m_labelParam.Name = "m_labelParam";
			this.m_labelParam.Size = new System.Drawing.Size(60, 13);
			this.m_labelParam.TabIndex = 1;
			this.m_labelParam.Text = "Parameters";
			// 
			// m_dataGridView_DepTables
			// 
			this.m_dataGridView_DepTables.AllowUserToAddRows = false;
			this.m_dataGridView_DepTables.AllowUserToDeleteRows = false;
			this.m_dataGridView_DepTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_dataGridView_DepTables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_dataGridView_DepTables.Location = new System.Drawing.Point(0, 13);
			this.m_dataGridView_DepTables.MultiSelect = false;
			this.m_dataGridView_DepTables.Name = "m_dataGridView_DepTables";
			this.m_dataGridView_DepTables.ReadOnly = true;
			this.m_dataGridView_DepTables.Size = new System.Drawing.Size(619, 194);
			this.m_dataGridView_DepTables.TabIndex = 1;
			// 
			// m_labelDepTab
			// 
			this.m_labelDepTab.AutoSize = true;
			this.m_labelDepTab.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_labelDepTab.Location = new System.Drawing.Point(0, 0);
			this.m_labelDepTab.Name = "m_labelDepTab";
			this.m_labelDepTab.Size = new System.Drawing.Size(91, 13);
			this.m_labelDepTab.TabIndex = 0;
			this.m_labelDepTab.Text = "Dependent tables";
			// 
			// m_richTextBox_Definition
			// 
			this.m_richTextBox_Definition.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_richTextBox_Definition.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_richTextBox_Definition.Location = new System.Drawing.Point(0, 0);
			this.m_richTextBox_Definition.Name = "m_richTextBox_Definition";
			this.m_richTextBox_Definition.Size = new System.Drawing.Size(1021, 561);
			this.m_richTextBox_Definition.TabIndex = 0;
			this.m_richTextBox_Definition.Text = "";
			// 
			// m_ContextMenuStrip_ShowDefinition
			// 
			this.m_ContextMenuStrip_ShowDefinition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_showDefinitionToolStripMenuItem});
			this.m_ContextMenuStrip_ShowDefinition.Name = "m_ContextMenuStrip_ShowDefinition";
			this.m_ContextMenuStrip_ShowDefinition.Size = new System.Drawing.Size(160, 26);
			// 
			// m_showDefinitionToolStripMenuItem
			// 
			this.m_showDefinitionToolStripMenuItem.Image = global::ColumnDepence.Properties.Resources.LoadDefinitionImage;
			this.m_showDefinitionToolStripMenuItem.Name = "m_showDefinitionToolStripMenuItem";
			this.m_showDefinitionToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.m_showDefinitionToolStripMenuItem.Text = "Show Definition";
			this.m_showDefinitionToolStripMenuItem.Click += new System.EventHandler(this.ShowDefinitionToolStripMenuItem_Click);
			// 
			// UserControlSPInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer_Main);
			this.Name = "UserControlSPInfo";
			this.Size = new System.Drawing.Size(1021, 772);
			this.splitContainer_Main.Panel1.ResumeLayout(false);
			this.splitContainer_Main.Panel2.ResumeLayout(false);
			this.splitContainer_Main.ResumeLayout(false);
			this.splitContainer_Top.Panel1.ResumeLayout(false);
			this.splitContainer_Top.Panel1.PerformLayout();
			this.splitContainer_Top.Panel2.ResumeLayout(false);
			this.splitContainer_Top.Panel2.PerformLayout();
			this.splitContainer_Top.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dataGridView_Params)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dataGridView_DepTables)).EndInit();
			this.m_ContextMenuStrip_ShowDefinition.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer_Main;
		private System.Windows.Forms.SplitContainer splitContainer_Top;
		private System.Windows.Forms.DataGridView m_dataGridView_Params;
		private System.Windows.Forms.Label m_labelParam;
		private System.Windows.Forms.Label m_labelDepTab;
		private System.Windows.Forms.RichTextBox m_richTextBox_Definition;
		private System.Windows.Forms.DataGridView m_dataGridView_DepTables;
		private System.Windows.Forms.ContextMenuStrip m_ContextMenuStrip_ShowDefinition;
		private System.Windows.Forms.ToolStripMenuItem m_showDefinitionToolStripMenuItem;
	}
}
