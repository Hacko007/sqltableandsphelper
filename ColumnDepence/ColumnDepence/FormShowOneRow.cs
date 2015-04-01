using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace hackovic.DbInfo
{
	public partial class FormShowOneRow : Form
	{
		public event EventHandler RowChanged;
		private DataTable m_DataTableOneRow;
		private int m_RowIndex = -1;


		public BindingSource ParentBidingSource { get; set; }

		public DataTable DataTable
		{
			get
			{

				if (ParentBidingSource != null && (ParentBidingSource.DataSource is DataView))
					return ((DataView)ParentBidingSource.DataSource).Table;
				if (ParentBidingSource == null || (ParentBidingSource.DataSource is DataTable) == false)
					return null;

				return ParentBidingSource.DataSource as DataTable;
			}
		}

		
		public DataTable DataTableOneRow
		{
			get
			{
				if (m_DataTableOneRow == null)
				{
					m_DataTableOneRow = new DataTable("OneRowTable");
					DataColumn col1 = m_DataTableOneRow.Columns.Add("Column", typeof(string));
					m_ColumnName.DataPropertyName = col1.ColumnName;
					DataColumn col2 = m_DataTableOneRow.Columns.Add("Value", typeof(object));
					m_ColumnValue.DataPropertyName = col2.ColumnName;
				}
				return m_DataTableOneRow;
			}
		}

		public int RowIndex
		{
			get
			{
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

		public DataRow ActiveRow
		{
			get
			{
				try
				{
					return (RowIndex == -1) ? null : DataTable.Rows[RowIndex];
				}
				catch
				{
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
			if (DataTableOneRow.Rows.Count > 0)
				DataTableOneRow.Clear();

			foreach (DataColumn column in ActiveRow.Table.Columns)
			{
				DataRow row = DataTableOneRow.NewRow();
				row[0] = column.ColumnName;
				row[1] = ActiveRow[column];
				DataTableOneRow.Rows.Add(row);
			}
			DataTableOneRow.AcceptChanges();
			m_dataGridViewValue.DataSource = DataTableOneRow;



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
			if (ActiveRow == null) return;
			if (m_dataGridViewValue == null || m_dataGridViewValue.RowCount == 0) return;

			int height = ((m_dataGridViewValue.RowTemplate.Height * m_dataGridViewValue.RowCount) + m_dataGridViewValue.ColumnHeadersHeight);
			height += 100;
			Height = Math.Min(height, Screen.FromControl(this).WorkingArea.Height);
			if (Height == Screen.FromControl(this).WorkingArea.Height)
			{
				Top = 0;
			}
		}

		private void RaisRowChanged() {
			if (RowChanged != null)
			{
				RowChanged(this, EventArgs.Empty);
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

		private void DisableAllButtons()
		{
			m_ButtonPrev.Enabled = true;
			m_ButtonNext.Enabled = true;
		}

		private void DataGridViewValue_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			Save();
		}


		private void Save()
		{
			SqlCommand uppdateCmd = CreateUpdateRowSqlCommand();
			if (uppdateCmd == null) return;
			try
			{
				if (ConnectionFactory.OpenConnection())
				{
					uppdateCmd.Connection = ConnectionFactory.Instance;
					uppdateCmd.ExecuteNonQuery();
					
					DataTableOneRow.AcceptChanges();
					DataTable.AcceptChanges();
					ParentBidingSource.EndEdit();
					RaisRowChanged();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				ConnectionFactory.CloseConnection();
			}
		}


		public SqlCommand CreateUpdateRowSqlCommand()
		{
			SqlCommand sqlCmd = new SqlCommand();

			StringBuilder sql = new StringBuilder();
			StringBuilder sqlWhere = new StringBuilder();

			foreach (DataRow row in DataTableOneRow.Rows)
			{
				if (row.HasVersion(DataRowVersion.Original) &&
					row.HasVersion(DataRowVersion.Proposed) &&
					!row[1, DataRowVersion.Proposed].Equals(row[1, DataRowVersion.Original]))
				{
					sql.Append(string.Format("[{0}] = @{0} ,", row[0]));
					sqlCmd.Parameters.Add(new SqlParameter("@" + row[0], row[1, DataRowVersion.Proposed]));
				}

				if (row[1, DataRowVersion.Original] is DBNull)
				{
					sqlWhere.Append(string.Format(" ([{0}] IS NULL) AND", row[0]));
				}
				else
				{
					sqlWhere.Append(string.Format(" ([{0}] = @Original_{0}) AND", row[0]));
					sqlCmd.Parameters.Add(new SqlParameter("@Original_" + row[0], row[1, DataRowVersion.Original]));
				}
			}
			if (sql.Length > 0)
			{
				sql.Remove(sql.Length - 1, 1);
			}
			else
			{
				return null;
			}

			if (sqlWhere.Length > 0)
			{
				sqlWhere.Remove(sqlWhere.Length - 3, 3);
			}
			else
			{
				return null;
			}

			sqlCmd.CommandText = "UPDATE " + DataTable.TableName + " SET " + sql.ToString() + " WHERE " + sqlWhere.ToString();
			return sqlCmd;
		}

	}
}
