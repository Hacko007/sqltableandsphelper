using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ColumnDepence.DbInfo;
using System.Data.SqlClient;

namespace ColumnDepence
{
	public partial class FormRunSp : Form
	{
		public FormRunSp()
		{
			InitializeComponent();			
		}

		public SpInfo SpInfo
		{
			get { return m_SpInfo; }
			set { 
				m_SpInfo = value;
				Text = "Execute :  " + m_SpInfo.SpName;
			}
		}

		/// <summary>
		/// Gets and Sets results of executing stored procedure
		/// </summary>
		private DataSet DataSetResult { get; set; }


		/// <summary>
		/// Executes stored procedure with 
		/// given parameter values
		/// </summary>
		private void ExecuteSp()
		{
			// 
			// Create Command
			// 
			SqlCommand cmd = new SqlCommand(SpInfo.SpName, ConnectionFactory.Instance)
			                 	{CommandType = CommandType.StoredProcedure};

			const string retParam = "ReturnValue";
			cmd.Parameters.Add(new SqlParameter(retParam,null));
			cmd.Parameters[retParam].Direction = ParameterDirection.ReturnValue;
			object retValue ;

			m_DataGridViewInputParameters.EndEdit();


			foreach (DataGridViewRow row in m_DataGridViewInputParameters.Rows)
			{
				string paramName = row.Cells[m_ColumnParameterName.Index].Value.ToString();
				
				if((bool)row.Cells[m_ColumnSetNull.Index].EditedFormattedValue )
				{
					cmd.Parameters.AddWithValue(paramName, DBNull.Value);
				}
				else
				{
					cmd.Parameters.AddWithValue(paramName, row.Cells[m_ColumnValue.Index].Value);
				}				
			}
			// 
			// Execute command
			// 
			DataSetResult = new DataSet();
			using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
			{
				try
				{
					adapter.Fill(DataSetResult);
					retValue = adapter.SelectCommand.Parameters[retParam].Value;
				}catch(SqlException exception)
				{
					MessageBox.Show(exception.Message);
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}

			}
			if (retValue != null)
			{
				const string columnName = "Return Value";
				DataSetResult.Tables.Add(columnName).Columns.Add(columnName);
				DataSetResult.Tables[columnName].Rows.Add(retValue);
			}

			if (DataSetResult.Tables.Count == 0)
			{
				const string columnName = "No Value";
				DataSetResult.Tables.Add(columnName).Columns.Add(columnName);
				DataSetResult.Tables[columnName].Rows.Add("No value returned");
			}


			// 
			// Place result on window
			// 
			m_TableLayoutPanel.RowCount = DataSetResult.Tables.Count;
			m_TableLayoutPanel.RowStyles.Clear();
			m_TableLayoutPanel.Controls.Clear();

			float percentage = (float)100 / DataSetResult.Tables.Count;
			int rowNr = 0;
			foreach (DataTable table in DataSetResult.Tables)
			{
				
				m_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, percentage ));
			    var dataGrid = new DataGridView
			                       {
			                           DataSource = table,
			                           Width = Width,
			                           Dock = DockStyle.Fill,
			                           AllowUserToAddRows = false,
			                           AllowUserToDeleteRows = false
			                       };
                dataGrid.DataError += delegate {};
				m_TableLayoutPanel.Controls.Add(dataGrid, 0, rowNr);
				rowNr++;
			}
			m_SplitContainer.Panel2Collapsed = false;
			ResizeWindow();
		}

		/// <summary>
		/// Resize window so that all DataGridViews fits on it.
		/// </summary>
		private void ResizeWindow()
		{
			int height = 20 + m_SplitContainer.Panel1.Height;
			if(DataSetResult != null && DataSetResult.Tables.Count > 0)
			{
				height += DataSetResult.Tables.Count*180;
			}
			Rectangle workArea = Screen.FromControl(this).WorkingArea;
			height = Math.Min(height, workArea.Height);

			Height = height;
			
			if (Bottom <= workArea.Bottom) return;

			Top = Top - (Bottom - workArea.Bottom);
			Top = (Top >= 0) ? Top : 0;
		}


		internal void InitDataGridView()
		{
			if(SpInfo.ParameterInfo.Rows.Count == 0) return;

			foreach (DataRow row in SpInfo.ParameterInfo.Rows)
			{
				int i = m_DataGridViewInputParameters.Rows.Add();
				DataGridViewRow dataGridViewRow = m_DataGridViewInputParameters.Rows[i];
				dataGridViewRow.Cells[m_ColumnParameterName.Index].Value = row[SpInfo.ParameterInfo.ColumnParameterName].ToString();

				int? length = DataTableSpParameterInfo.GetLength(row);
				string lenStr = length.HasValue ? "  (" + length.Value + ")" : "";
				
				dataGridViewRow.Cells[m_ColumnTypeAndLength.Index].Value = row[SpInfo.ParameterInfo.ColumnDataType]+ lenStr;
				dataGridViewRow.ReadOnly = !DataTableSpParameterInfo.IsInputParameter(row);
				dataGridViewRow.Cells[m_ColumnSetNull.Index].Value = true;
				dataGridViewRow.Cells[m_ColumnValue.Index].ReadOnly = true;
			}
		}


		#region Event handlers
		private void ToolStripButtonExec_Click(object sender, EventArgs e)
		{
			ExecuteSp();
		}

		private void ToolStripButtonClearInputValues_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (DataGridViewRow row in m_DataGridViewInputParameters.Rows)
				{
					row.Cells[m_ColumnValue.Index].Value = "";
				}
			}catch
			{}
		}
		private void ToolStripButtonClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void DataGridViewInputParameters_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			
			if (e.ColumnIndex != m_ColumnSetNull.Index) return;
			try
			{
				bool isNull =! (bool) m_DataGridViewInputParameters.Rows[e.RowIndex].Cells[m_ColumnSetNull.Index].EditedFormattedValue;
				m_DataGridViewInputParameters.Rows[e.RowIndex].Cells[m_ColumnValue.Index].ReadOnly = isNull;
				m_DataGridViewInputParameters.Rows[e.RowIndex].Cells[m_ColumnValue.Index].Style.ForeColor = isNull ? SystemColors.InactiveCaptionText : SystemColors.ActiveCaption;
			}
			catch
			{
			}
		}

		#endregion Event handlers


	}
}
