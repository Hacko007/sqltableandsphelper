using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColumnDepence
{
	public partial class FormShowOneRow : Form
	{
		public DataGridView DataGridValues { get; set; }
		public DataTable DataTable {
			get {
				if (DataGridValues == null || (DataGridValues.DataSource is DataView) == false )
					return null;
				
				return ((DataView)DataGridValues.DataSource).Table as DataTable;
			}
		}

		private DataRow m_ActiveRow;
		public DataRow ActiveRow {
			get {
				if (DataTable == null || DataTable.Rows.Count == 0)
					return null;

				if (m_ActiveRow == null)
				{
					ActiveRow = DataTable.Rows[0];
				}
				return m_ActiveRow; 
			}

			set { m_ActiveRow = value; }
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

			m_PropertyGridRowData.SelectedObject = ActiveRow.ItemArray ;//ActiveRowValues;
			m_ButtonUpdate.Enabled = false;
			m_ButtonCancel.Enabled = false;
		}

		private object[] ActiveRowValues {
			get {
				if (ActiveRow == null) return null;
				List<object> values = new List<object>();
				
				//foreach (DataGridViewCell item in ActiveRow.Cells)
				//{
				//    values.Add(item.Value);
				//}
				return values.ToArray();
			}
		}

		private void ButtonPrev_Click(object sender, EventArgs e)
		{
			if (DataTable == null || DataTable.Rows.Count == 0)
			{
				DisableAllButtons(); 
				return;
			}
			

			//foreach (DataGridViewRow item in SelectedRows)
			//{

			//}

		}

		private void ButtonNext_Click(object sender, EventArgs e)
		{
			if (DataTable == null || DataTable.Rows.Count == 0)
			{
				DisableAllButtons();
				return;
			}
			
		}


		private void ButtonUpdate_Click(object sender, EventArgs e)
		{

		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{

		}

		private void PropertyGridRowData_SelectedObjectsChanged(object sender, EventArgs e)
		{
			m_ButtonUpdate.Enabled = true;
			m_ButtonCancel.Enabled = true;
		}

		private void DisableAllButtons() {
			m_ButtonPrev.Enabled = true;
			m_ButtonNext.Enabled = true;
			m_ButtonUpdate.Enabled = true;
			m_ButtonCancel.Enabled = true;
		
		}
	}
}
