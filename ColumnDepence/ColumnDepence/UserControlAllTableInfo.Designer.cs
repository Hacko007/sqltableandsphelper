using System.Windows.Forms;

using hackovic.DbInfo.DbInfo;

namespace hackovic.DbInfo
{
	partial class UserControlAllTableInfo
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			TableInfo tableInfo1 = new TableInfo();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlAllTableInfo));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			this.m_DataGridViewColumns = new System.Windows.Forms.DataGridView();
			this.m_Label7 = new System.Windows.Forms.Label();
			this.m_SplitContainerLeft = new System.Windows.Forms.SplitContainer();
			this.m_userControlValues = new UserControlValues();
			this.m_DataGridViewColumnConstrains = new System.Windows.Forms.DataGridView();
			this.m_Label9 = new System.Windows.Forms.Label();
			this.m_Label10 = new System.Windows.Forms.Label();
			this.m_DataGridViewParent = new System.Windows.Forms.DataGridView();
			this.m_DataGridViewChild = new System.Windows.Forms.DataGridView();
			this.m_Label11 = new System.Windows.Forms.Label();
			this.m_SplitContainerRightBottom = new System.Windows.Forms.SplitContainer();
			this.m_SplitContainerLeftSpButtom = new System.Windows.Forms.SplitContainer();
			this.m_DataGridViewSp = new System.Windows.Forms.DataGridView();
			this.m_LabelSp = new System.Windows.Forms.Label();
			this.m_SplitContainerRight = new System.Windows.Forms.SplitContainer();
			this.m_SplitContainerMain = new System.Windows.Forms.SplitContainer();
			this.m_ToolStripMenu = new System.Windows.Forms.ToolStrip();
			this.m_ToolStripButtonLoadDef = new System.Windows.Forms.ToolStripButton();
			this.m_ToolStripSplitButtonLoadMain = new System.Windows.Forms.ToolStripSplitButton();
			this.m_LoadAllValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_LoadTop300ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.m_ToolStripLabelDb = new System.Windows.Forms.ToolStripLabel();
			this.m_ToolStripLabelTableName = new System.Windows.Forms.ToolStripLabel();
			this.m_ToolStripButtonCloseTab = new System.Windows.Forms.ToolStripButton();
			this.m_ToolStripButtonToolBox = new System.Windows.Forms.ToolStripButton();
			this.m_PanelDataView = new System.Windows.Forms.Panel();
			this.m_ContextMenuStripShowTable = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_showDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_showTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_ContextMenuStripShowDefinition = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_ToolStripMenuItemShowDefinition = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewColumns)).BeginInit();
			this.m_SplitContainerLeft.Panel1.SuspendLayout();
			this.m_SplitContainerLeft.Panel2.SuspendLayout();
			this.m_SplitContainerLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewColumnConstrains)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewParent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewChild)).BeginInit();
			this.m_SplitContainerRightBottom.Panel1.SuspendLayout();
			this.m_SplitContainerRightBottom.Panel2.SuspendLayout();
			this.m_SplitContainerRightBottom.SuspendLayout();
			this.m_SplitContainerLeftSpButtom.Panel1.SuspendLayout();
			this.m_SplitContainerLeftSpButtom.Panel2.SuspendLayout();
			this.m_SplitContainerLeftSpButtom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewSp)).BeginInit();
			this.m_SplitContainerRight.Panel1.SuspendLayout();
			this.m_SplitContainerRight.Panel2.SuspendLayout();
			this.m_SplitContainerRight.SuspendLayout();
			this.m_SplitContainerMain.Panel1.SuspendLayout();
			this.m_SplitContainerMain.Panel2.SuspendLayout();
			this.m_SplitContainerMain.SuspendLayout();
			this.m_ToolStripMenu.SuspendLayout();
			this.m_PanelDataView.SuspendLayout();
			this.m_ContextMenuStripShowTable.SuspendLayout();
			this.m_ContextMenuStripShowDefinition.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_DataGridViewColumns
			// 
			this.m_DataGridViewColumns.AllowUserToAddRows = false;
			this.m_DataGridViewColumns.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.m_DataGridViewColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.m_DataGridViewColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_DataGridViewColumns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.m_DataGridViewColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_DataGridViewColumns.DefaultCellStyle = dataGridViewCellStyle3;
			this.m_DataGridViewColumns.Location = new System.Drawing.Point(3, 16);
			this.m_DataGridViewColumns.Name = "m_DataGridViewColumns";
			this.m_DataGridViewColumns.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_DataGridViewColumns.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.m_DataGridViewColumns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.m_DataGridViewColumns.Size = new System.Drawing.Size(695, 362);
			this.m_DataGridViewColumns.TabIndex = 0;
			this.m_DataGridViewColumns.SelectionChanged += new System.EventHandler(this.DataGridViewColumns_SelectionChanged);
			// 
			// m_Label7
			// 
			this.m_Label7.AutoSize = true;
			this.m_Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_Label7.Location = new System.Drawing.Point(3, 0);
			this.m_Label7.Name = "m_Label7";
			this.m_Label7.Size = new System.Drawing.Size(60, 16);
			this.m_Label7.TabIndex = 2;
			this.m_Label7.Text = "Columns";
			// 
			// m_SplitContainerLeft
			// 
			this.m_SplitContainerLeft.BackColor = System.Drawing.SystemColors.ControlDark;
			this.m_SplitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_SplitContainerLeft.Location = new System.Drawing.Point(0, 0);
			this.m_SplitContainerLeft.Name = "m_SplitContainerLeft";
			this.m_SplitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// m_SplitContainerLeft.Panel1
			// 
			this.m_SplitContainerLeft.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.m_SplitContainerLeft.Panel1.Controls.Add(this.m_DataGridViewColumns);
			this.m_SplitContainerLeft.Panel1.Controls.Add(this.m_Label7);
			// 
			// m_SplitContainerLeft.Panel2
			// 
			this.m_SplitContainerLeft.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.m_SplitContainerLeft.Panel2.Controls.Add(this.m_userControlValues);
			this.m_SplitContainerLeft.Size = new System.Drawing.Size(700, 860);
			this.m_SplitContainerLeft.SplitterDistance = 379;
			this.m_SplitContainerLeft.SplitterWidth = 8;
			this.m_SplitContainerLeft.TabIndex = 0;
			// 
			// m_userControlValues
			// 
			this.m_userControlValues.AllColumns = null;
			this.m_userControlValues.AutoScroll = true;
			this.m_userControlValues.Location = new System.Drawing.Point(-1, -3);
			this.m_userControlValues.Name = "m_userControlValues";
			this.m_userControlValues.ShownColumns = null;
			this.m_userControlValues.ShownRows = 0;
			this.m_userControlValues.Size = new System.Drawing.Size(698, 472);
			this.m_userControlValues.TabIndex = 2;
			this.m_userControlValues.TableCount = "";
			tableInfo1.TableName = null;
			tableInfo1.ValuesLoadedWithFilter = false;
			this.m_userControlValues.TableInfo = tableInfo1;
			// 
			// m_DataGridViewColumnConstrains
			// 
			this.m_DataGridViewColumnConstrains.AllowUserToAddRows = false;
			this.m_DataGridViewColumnConstrains.AllowUserToDeleteRows = false;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
			this.m_DataGridViewColumnConstrains.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.m_DataGridViewColumnConstrains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_DataGridViewColumnConstrains.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.m_DataGridViewColumnConstrains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_DataGridViewColumnConstrains.DefaultCellStyle = dataGridViewCellStyle7;
			this.m_DataGridViewColumnConstrains.Location = new System.Drawing.Point(3, 16);
			this.m_DataGridViewColumnConstrains.Name = "m_DataGridViewColumnConstrains";
			this.m_DataGridViewColumnConstrains.ReadOnly = true;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_DataGridViewColumnConstrains.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.m_DataGridViewColumnConstrains.Size = new System.Drawing.Size(488, 165);
			this.m_DataGridViewColumnConstrains.TabIndex = 0;
			// 
			// m_Label9
			// 
			this.m_Label9.AutoSize = true;
			this.m_Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_Label9.Location = new System.Drawing.Point(3, 0);
			this.m_Label9.Name = "m_Label9";
			this.m_Label9.Size = new System.Drawing.Size(122, 16);
			this.m_Label9.TabIndex = 3;
			this.m_Label9.Text = "Column Constraints";
			// 
			// m_Label10
			// 
			this.m_Label10.AutoSize = true;
			this.m_Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_Label10.Location = new System.Drawing.Point(0, 0);
			this.m_Label10.Name = "m_Label10";
			this.m_Label10.Size = new System.Drawing.Size(64, 16);
			this.m_Label10.TabIndex = 4;
			this.m_Label10.Text = "Parent to:";
			// 
			// m_DataGridViewParent
			// 
			this.m_DataGridViewParent.AllowUserToAddRows = false;
			this.m_DataGridViewParent.AllowUserToDeleteRows = false;
			dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
			this.m_DataGridViewParent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
			this.m_DataGridViewParent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_DataGridViewParent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.m_DataGridViewParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_DataGridViewParent.DefaultCellStyle = dataGridViewCellStyle11;
			this.m_DataGridViewParent.Location = new System.Drawing.Point(3, 16);
			this.m_DataGridViewParent.Name = "m_DataGridViewParent";
			this.m_DataGridViewParent.ReadOnly = true;
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_DataGridViewParent.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.m_DataGridViewParent.Size = new System.Drawing.Size(488, 161);
			this.m_DataGridViewParent.TabIndex = 1;
			// 
			// m_DataGridViewChild
			// 
			this.m_DataGridViewChild.AllowUserToAddRows = false;
			this.m_DataGridViewChild.AllowUserToDeleteRows = false;
			dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
			this.m_DataGridViewChild.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
			this.m_DataGridViewChild.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_DataGridViewChild.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
			this.m_DataGridViewChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_DataGridViewChild.DefaultCellStyle = dataGridViewCellStyle15;
			this.m_DataGridViewChild.Location = new System.Drawing.Point(6, 16);
			this.m_DataGridViewChild.Name = "m_DataGridViewChild";
			this.m_DataGridViewChild.ReadOnly = true;
			dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_DataGridViewChild.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
			this.m_DataGridViewChild.Size = new System.Drawing.Size(485, 221);
			this.m_DataGridViewChild.TabIndex = 0;
			// 
			// m_Label11
			// 
			this.m_Label11.AutoSize = true;
			this.m_Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_Label11.Location = new System.Drawing.Point(3, 0);
			this.m_Label11.Name = "m_Label11";
			this.m_Label11.Size = new System.Drawing.Size(55, 16);
			this.m_Label11.TabIndex = 5;
			this.m_Label11.Text = "Child to:";
			// 
			// m_SplitContainerRightBottom
			// 
			this.m_SplitContainerRightBottom.BackColor = System.Drawing.SystemColors.ControlDark;
			this.m_SplitContainerRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_SplitContainerRightBottom.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.m_SplitContainerRightBottom.Location = new System.Drawing.Point(0, 0);
			this.m_SplitContainerRightBottom.Name = "m_SplitContainerRightBottom";
			this.m_SplitContainerRightBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// m_SplitContainerRightBottom.Panel1
			// 
			this.m_SplitContainerRightBottom.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.m_SplitContainerRightBottom.Panel1.Controls.Add(this.m_Label10);
			this.m_SplitContainerRightBottom.Panel1.Controls.Add(this.m_DataGridViewParent);
			// 
			// m_SplitContainerRightBottom.Panel2
			// 
			this.m_SplitContainerRightBottom.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.m_SplitContainerRightBottom.Panel2.Controls.Add(this.m_SplitContainerLeftSpButtom);
			this.m_SplitContainerRightBottom.Size = new System.Drawing.Size(494, 668);
			this.m_SplitContainerRightBottom.SplitterDistance = 180;
			this.m_SplitContainerRightBottom.SplitterWidth = 8;
			this.m_SplitContainerRightBottom.TabIndex = 0;
			// 
			// m_SplitContainerLeftSpButtom
			// 
			this.m_SplitContainerLeftSpButtom.BackColor = System.Drawing.SystemColors.ControlDark;
			this.m_SplitContainerLeftSpButtom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_SplitContainerLeftSpButtom.Location = new System.Drawing.Point(0, 0);
			this.m_SplitContainerLeftSpButtom.Name = "m_SplitContainerLeftSpButtom";
			this.m_SplitContainerLeftSpButtom.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// m_SplitContainerLeftSpButtom.Panel1
			// 
			this.m_SplitContainerLeftSpButtom.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.m_SplitContainerLeftSpButtom.Panel1.Controls.Add(this.m_Label11);
			this.m_SplitContainerLeftSpButtom.Panel1.Controls.Add(this.m_DataGridViewChild);
			// 
			// m_SplitContainerLeftSpButtom.Panel2
			// 
			this.m_SplitContainerLeftSpButtom.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.m_SplitContainerLeftSpButtom.Panel2.Controls.Add(this.m_DataGridViewSp);
			this.m_SplitContainerLeftSpButtom.Panel2.Controls.Add(this.m_LabelSp);
			this.m_SplitContainerLeftSpButtom.Size = new System.Drawing.Size(494, 480);
			this.m_SplitContainerLeftSpButtom.SplitterDistance = 240;
			this.m_SplitContainerLeftSpButtom.SplitterWidth = 8;
			this.m_SplitContainerLeftSpButtom.TabIndex = 6;
			// 
			// m_DataGridViewSp
			// 
			this.m_DataGridViewSp.AllowUserToAddRows = false;
			this.m_DataGridViewSp.AllowUserToDeleteRows = false;
			dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
			this.m_DataGridViewSp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
			this.m_DataGridViewSp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_DataGridViewSp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
			this.m_DataGridViewSp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_DataGridViewSp.DefaultCellStyle = dataGridViewCellStyle19;
			this.m_DataGridViewSp.Location = new System.Drawing.Point(6, 20);
			this.m_DataGridViewSp.Name = "m_DataGridViewSp";
			this.m_DataGridViewSp.ReadOnly = true;
			dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle20.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_DataGridViewSp.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
			this.m_DataGridViewSp.Size = new System.Drawing.Size(485, 209);
			this.m_DataGridViewSp.TabIndex = 1;
			// 
			// m_LabelSp
			// 
			this.m_LabelSp.AutoSize = true;
			this.m_LabelSp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_LabelSp.Location = new System.Drawing.Point(6, 4);
			this.m_LabelSp.Name = "m_LabelSp";
			this.m_LabelSp.Size = new System.Drawing.Size(120, 16);
			this.m_LabelSp.TabIndex = 0;
			this.m_LabelSp.Text = "Stored procedures";
			// 
			// m_SplitContainerRight
			// 
			this.m_SplitContainerRight.BackColor = System.Drawing.SystemColors.ControlDark;
			this.m_SplitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_SplitContainerRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.m_SplitContainerRight.Location = new System.Drawing.Point(0, 0);
			this.m_SplitContainerRight.Name = "m_SplitContainerRight";
			this.m_SplitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// m_SplitContainerRight.Panel1
			// 
			this.m_SplitContainerRight.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.m_SplitContainerRight.Panel1.Controls.Add(this.m_DataGridViewColumnConstrains);
			this.m_SplitContainerRight.Panel1.Controls.Add(this.m_Label9);
			// 
			// m_SplitContainerRight.Panel2
			// 
			this.m_SplitContainerRight.Panel2.Controls.Add(this.m_SplitContainerRightBottom);
			this.m_SplitContainerRight.Size = new System.Drawing.Size(494, 860);
			this.m_SplitContainerRight.SplitterDistance = 184;
			this.m_SplitContainerRight.SplitterWidth = 8;
			this.m_SplitContainerRight.TabIndex = 7;
			// 
			// m_SplitContainerMain
			// 
			this.m_SplitContainerMain.BackColor = System.Drawing.SystemColors.ControlDark;
			this.m_SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_SplitContainerMain.Location = new System.Drawing.Point(0, 0);
			this.m_SplitContainerMain.Name = "m_SplitContainerMain";
			// 
			// m_SplitContainerMain.Panel1
			// 
			this.m_SplitContainerMain.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.m_SplitContainerMain.Panel1.Controls.Add(this.m_SplitContainerLeft);
			// 
			// m_SplitContainerMain.Panel2
			// 
			this.m_SplitContainerMain.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.m_SplitContainerMain.Panel2.Controls.Add(this.m_SplitContainerRight);
			this.m_SplitContainerMain.Size = new System.Drawing.Size(1204, 860);
			this.m_SplitContainerMain.SplitterDistance = 700;
			this.m_SplitContainerMain.SplitterWidth = 10;
			this.m_SplitContainerMain.TabIndex = 0;
			// 
			// m_ToolStripMenu
			// 
			this.m_ToolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ToolStripButtonLoadDef,
            this.m_ToolStripSplitButtonLoadMain,
            this.m_ToolStripSeparator1,
            this.m_ToolStripLabelDb,
            this.m_ToolStripLabelTableName,
            this.m_ToolStripButtonCloseTab,
            this.m_ToolStripButtonToolBox});
			this.m_ToolStripMenu.Location = new System.Drawing.Point(0, 0);
			this.m_ToolStripMenu.Name = "m_ToolStripMenu";
			this.m_ToolStripMenu.Size = new System.Drawing.Size(1204, 25);
			this.m_ToolStripMenu.TabIndex = 4;
			this.m_ToolStripMenu.Text = "toolStrip1";
			// 
			// m_ToolStripButtonLoadDef
			// 
            this.m_ToolStripButtonLoadDef.Image = global::hackovic.DbInfo.Properties.Resources.LoadDefinitionImage;
			this.m_ToolStripButtonLoadDef.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_ToolStripButtonLoadDef.Name = "m_ToolStripButtonLoadDef";
			this.m_ToolStripButtonLoadDef.Size = new System.Drawing.Size(108, 22);
			this.m_ToolStripButtonLoadDef.Text = "Load Definition";
			this.m_ToolStripButtonLoadDef.ToolTipText = "Load this tables definition";
			this.m_ToolStripButtonLoadDef.Click += new System.EventHandler(this.button_RefreshDef_Click);
			// 
			// m_ToolStripSplitButtonLoadMain
			// 
			this.m_ToolStripSplitButtonLoadMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_LoadAllValuesToolStripMenuItem,
            this.m_LoadTop300ToolStripMenuItem});
            this.m_ToolStripSplitButtonLoadMain.Image = global::hackovic.DbInfo.Properties.Resources.Reload;
			this.m_ToolStripSplitButtonLoadMain.ImageTransparentColor = System.Drawing.Color.White;
			this.m_ToolStripSplitButtonLoadMain.Name = "m_ToolStripSplitButtonLoadMain";
			this.m_ToolStripSplitButtonLoadMain.Size = new System.Drawing.Size(119, 22);
			this.m_ToolStripSplitButtonLoadMain.Text = "Load All Values";
			this.m_ToolStripSplitButtonLoadMain.Click += new System.EventHandler(this.toolStripSplitButton_LoadMain_Click);
			// 
			// m_LoadAllValuesToolStripMenuItem
			// 
            this.m_LoadAllValuesToolStripMenuItem.Image = global::hackovic.DbInfo.Properties.Resources.Reload;
			this.m_LoadAllValuesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
			this.m_LoadAllValuesToolStripMenuItem.Name = "m_LoadAllValuesToolStripMenuItem";
			this.m_LoadAllValuesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.m_LoadAllValuesToolStripMenuItem.Text = "Load All Values";
			this.m_LoadAllValuesToolStripMenuItem.Click += new System.EventHandler(this.loadAllValuesToolStripMenuItem_Click);
			// 
			// m_LoadTop300ToolStripMenuItem
			// 
			this.m_LoadTop300ToolStripMenuItem.Name = "m_LoadTop300ToolStripMenuItem";
			this.m_LoadTop300ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.m_LoadTop300ToolStripMenuItem.Text = "Load Top 300";
			this.m_LoadTop300ToolStripMenuItem.Click += new System.EventHandler(this.loadTop300ToolStripMenuItem_Click);
			// 
			// m_ToolStripSeparator1
			// 
			this.m_ToolStripSeparator1.Name = "m_ToolStripSeparator1";
			this.m_ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// m_ToolStripLabelDb
			// 
			this.m_ToolStripLabelDb.Name = "m_ToolStripLabelDb";
			this.m_ToolStripLabelDb.Size = new System.Drawing.Size(0, 22);
			// 
			// m_ToolStripLabelTableName
			// 
			this.m_ToolStripLabelTableName.DoubleClickEnabled = true;
			this.m_ToolStripLabelTableName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_ToolStripLabelTableName.Name = "m_ToolStripLabelTableName";
			this.m_ToolStripLabelTableName.Size = new System.Drawing.Size(0, 22);
			this.m_ToolStripLabelTableName.ToolTipText = "Doubleclick to copy to clipboard";
			this.m_ToolStripLabelTableName.DoubleClick += new System.EventHandler(this.ToolStripLabelTableName_DoubleClick);
			// 
			// m_ToolStripButtonCloseTab
			// 
			this.m_ToolStripButtonCloseTab.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.m_ToolStripButtonCloseTab.Image = global::hackovic.DbInfo.Properties.Resources.CloseImage;
			this.m_ToolStripButtonCloseTab.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_ToolStripButtonCloseTab.Name = "m_ToolStripButtonCloseTab";
			this.m_ToolStripButtonCloseTab.Size = new System.Drawing.Size(79, 22);
			this.m_ToolStripButtonCloseTab.Text = "Close Tab";
			this.m_ToolStripButtonCloseTab.Click += new System.EventHandler(this.button_CloseTab_Click);
			// 
			// m_ToolStripButtonToolBox
			// 
			this.m_ToolStripButtonToolBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.m_ToolStripButtonToolBox.Image = global::hackovic.DbInfo.Properties.Resources.ToolBoxImage;
			this.m_ToolStripButtonToolBox.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_ToolStripButtonToolBox.Name = "m_ToolStripButtonToolBox";
			this.m_ToolStripButtonToolBox.Size = new System.Drawing.Size(116, 22);
			this.m_ToolStripButtonToolBox.Text = "Show as tool box";
			this.m_ToolStripButtonToolBox.Click += new System.EventHandler(this.ToolStripButtonToolBox_Click);
			// 
			// m_PanelDataView
			// 
			this.m_PanelDataView.Controls.Add(this.m_SplitContainerMain);
			this.m_PanelDataView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_PanelDataView.Location = new System.Drawing.Point(0, 25);
			this.m_PanelDataView.Name = "m_PanelDataView";
			this.m_PanelDataView.Size = new System.Drawing.Size(1204, 860);
			this.m_PanelDataView.TabIndex = 5;
			// 
			// m_ContextMenuStripShowTable
			// 
			this.m_ContextMenuStripShowTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_showDefinitionToolStripMenuItem,
            this.m_showTableToolStripMenuItem});
			this.m_ContextMenuStripShowTable.Name = "m_ContextMenuStripShowTable";
			this.m_ContextMenuStripShowTable.Size = new System.Drawing.Size(173, 48);
			// 
			// m_showDefinitionToolStripMenuItem
			// 
            this.m_showDefinitionToolStripMenuItem.Image = global::hackovic.DbInfo.Properties.Resources.LoadDefinitionImage;
			this.m_showDefinitionToolStripMenuItem.Name = "m_showDefinitionToolStripMenuItem";
			this.m_showDefinitionToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.m_showDefinitionToolStripMenuItem.Text = "Show Definition";
			this.m_showDefinitionToolStripMenuItem.Click += new System.EventHandler(this.ShowTableDefinition_Click);
			// 
			// m_showTableToolStripMenuItem
			// 
            this.m_showTableToolStripMenuItem.Image = global::hackovic.DbInfo.Properties.Resources.LoadAllValues;
			this.m_showTableToolStripMenuItem.Name = "m_showTableToolStripMenuItem";
			this.m_showTableToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.m_showTableToolStripMenuItem.Text = "Show Table Values";
			this.m_showTableToolStripMenuItem.Click += new System.EventHandler(this.ShowTableValues_Click);
			// 
			// m_ContextMenuStripShowDefinition
			// 
			this.m_ContextMenuStripShowDefinition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ToolStripMenuItemShowDefinition});
			this.m_ContextMenuStripShowDefinition.Name = "m_ContextMenuStripShowDefinition";
			this.m_ContextMenuStripShowDefinition.Size = new System.Drawing.Size(159, 26);
			// 
			// m_ToolStripMenuItemShowDefinition
			// 
            this.m_ToolStripMenuItemShowDefinition.Image = global::hackovic.DbInfo.Properties.Resources.LoadDefinitionImage;
			this.m_ToolStripMenuItemShowDefinition.Name = "m_ToolStripMenuItemShowDefinition";
			this.m_ToolStripMenuItemShowDefinition.Size = new System.Drawing.Size(158, 22);
			this.m_ToolStripMenuItemShowDefinition.Text = "Show Definition";
			this.m_ToolStripMenuItemShowDefinition.Click += new System.EventHandler(this.ToolStripMenuItem_ShowDefinition_Click);
			// 
			// UserControlAllTableInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_PanelDataView);
			this.Controls.Add(this.m_ToolStripMenu);
			this.Name = "UserControlAllTableInfo";
			this.Size = new System.Drawing.Size(1204, 885);
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewColumns)).EndInit();
			this.m_SplitContainerLeft.Panel1.ResumeLayout(false);
			this.m_SplitContainerLeft.Panel1.PerformLayout();
			this.m_SplitContainerLeft.Panel2.ResumeLayout(false);
			this.m_SplitContainerLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewColumnConstrains)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewParent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewChild)).EndInit();
			this.m_SplitContainerRightBottom.Panel1.ResumeLayout(false);
			this.m_SplitContainerRightBottom.Panel1.PerformLayout();
			this.m_SplitContainerRightBottom.Panel2.ResumeLayout(false);
			this.m_SplitContainerRightBottom.ResumeLayout(false);
			this.m_SplitContainerLeftSpButtom.Panel1.ResumeLayout(false);
			this.m_SplitContainerLeftSpButtom.Panel1.PerformLayout();
			this.m_SplitContainerLeftSpButtom.Panel2.ResumeLayout(false);
			this.m_SplitContainerLeftSpButtom.Panel2.PerformLayout();
			this.m_SplitContainerLeftSpButtom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewSp)).EndInit();
			this.m_SplitContainerRight.Panel1.ResumeLayout(false);
			this.m_SplitContainerRight.Panel1.PerformLayout();
			this.m_SplitContainerRight.Panel2.ResumeLayout(false);
			this.m_SplitContainerRight.ResumeLayout(false);
			this.m_SplitContainerMain.Panel1.ResumeLayout(false);
			this.m_SplitContainerMain.Panel2.ResumeLayout(false);
			this.m_SplitContainerMain.ResumeLayout(false);
			this.m_ToolStripMenu.ResumeLayout(false);
			this.m_ToolStripMenu.PerformLayout();
			this.m_PanelDataView.ResumeLayout(false);
			this.m_ContextMenuStripShowTable.ResumeLayout(false);
			this.m_ContextMenuStripShowDefinition.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DataGridView m_DataGridViewColumns;
		private Label m_Label7;
		private SplitContainer m_SplitContainerLeft;
		private DataGridView m_DataGridViewColumnConstrains;
		private Label m_Label9;
		private Label m_Label10;
		private DataGridView m_DataGridViewParent;
		private DataGridView m_DataGridViewChild;
		private Label m_Label11;
		private SplitContainer m_SplitContainerRightBottom;
		private SplitContainer m_SplitContainerRight;
		private SplitContainer m_SplitContainerMain;
		private ToolStrip m_ToolStripMenu;
		private ToolStripButton m_ToolStripButtonLoadDef;
		private ToolStripSplitButton m_ToolStripSplitButtonLoadMain;
		private ToolStripMenuItem m_LoadAllValuesToolStripMenuItem;
		private ToolStripMenuItem m_LoadTop300ToolStripMenuItem;
		private ToolStripSeparator m_ToolStripSeparator1;
		private ToolStripLabel m_ToolStripLabelDb;
		private ToolStripLabel m_ToolStripLabelTableName;
		private ToolStripButton m_ToolStripButtonCloseTab;
		private ToolStripButton m_ToolStripButtonToolBox;
		private Panel m_PanelDataView;
		private ContextMenuStrip m_ContextMenuStripShowTable;
		private ToolStripMenuItem m_showTableToolStripMenuItem;
		private ToolStripMenuItem m_showDefinitionToolStripMenuItem;
		private UserControlValues m_userControlValues;
		private SplitContainer m_SplitContainerLeftSpButtom;
		private DataGridView m_DataGridViewSp;
		private Label m_LabelSp;
		private ContextMenuStrip m_ContextMenuStripShowDefinition;
		private ToolStripMenuItem m_ToolStripMenuItemShowDefinition;
		private Form m_toolbox;
		private bool m_getAllRows ;
		private ColumnDependencies m_ParentForm;
	}
}
