using System;
using System.Data;
using System.Windows.Forms;

namespace ColumnDepence
{
	public partial class FormShowOneRow : Form
	{
		public DataGridView DataGridValues { get; set; }
		public DataTable DataTable {
			get
			{

				if (DataGridValues != null && (DataGridValues.DataSource is DataView))
					return ((DataView) DataGridValues.DataSource).Table;
				if (DataGridValues == null || (DataGridValues.DataSource is DataTable) == false)
					return null;

				return DataGridValues.DataSource as DataTable;
			}
		}
		private int m_RowIndex = -1;
		public int RowIndex
		{
			get {
				if (DataTable == null || DataTable.Rows.Count == 0)
					return -1;

				if (m_RowIndex >= DataTable.Rows.Count)
				{
					m_RowIndex = DataTable.Rows.Count - 1;
				}
				else if (m_RowIndex < 0)
				{
					m_RowIndex = 0;
				}
				return m_RowIndex; 
			}
			set { m_RowIndex = value; }
		}

		public DataRow ActiveRow {
			get {
				try
				{
					return (RowIndex == -1) ? null : DataTable.Rows[RowIndex];
				}
				catch {
					return null;
				}
			}
		}
		
		
		public FormShowOneRow()
		{
			InitializeComponent();
			DisableAllButtons();
		}

		public void LoadRowItnoView() 
		{
			if (ActiveRow == null)
			{
				DisableAllButtons();
				return;
			}

			m_dataGridViewValue.Rows.Clear();

			foreach (DataColumn column in ActiveRow.Table.Columns)
			{
				m_dataGridViewValue.Rows.Add(column.ColumnName, ActiveRow[column]);
			}
			
			m_ButtonUpdate.Enabled = false;
			m_ButtonCancel.Enabled = false;

			if (DataTable == null) return;

			m_labelTabName.Text = DataTable.TableName;
			Text = "Show one row in " + DataTable.TableName;
		}

		/// <summary>
		/// Resize window to fit all columns or to fit 
		/// desktops working area.
		/// </summary>
		public void ResizeWindow()
		{
			if(ActiveRow == null)return;
			if (m_dataGridViewValue == null || m_dataGridViewValue.RowCount == 0) return;

			int height = ((m_dataGridViewValue.RowTemplate.Height * m_dataGridViewValue.RowCount) + m_dataGridViewValue.ColumnHeadersHeight);
			height += 100;
			Height = Math.Min(height, Screen.FromControl(this).WorkingArea.Height);
			if(Height == Screen.FromControl(this).WorkingArea.Height)
			{
				Top = 0;
			}
		}

		private void ButtonPrev_Click(object sender, EventArgs e)
		{
			if (RowIndex <= 0) return;

			RowIndex--;
			LoadRowItnoView();
		}

		private void ButtonNext_Click(object sender, EventArgs e)
		{			
				RowIndex++;
				LoadRowItnoView();			
		}


		private void ButtonUpdate_Click(object sender, EventArgs e)
		{
			//TODO: Save changes
			MessageBox.Show("Not implemented");
			DataTable.RejectChanges();
			LoadRowItnoView();						
			EnableEditButtons(false);
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DataTable.RejectChanges();
			LoadRowItnoView();			
			EnableEditButtons(false);
		}

		private void EnableEditButtons(bool enable)
		{
			m_ButtonUpdate.Enabled = enable;
			m_ButtonCancel.Enabled = enable;
		}

		private void DisableAllButtons() {
			m_ButtonPrev.Enabled = true;
			m_ButtonNext.Enabled = true;
			m_ButtonUpdate.Enabled = true;
			m_ButtonCancel.Enabled = true;
		
		}

		private void DataGridViewValue_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			EnableEditButtons(true);			
		}
	}
}
