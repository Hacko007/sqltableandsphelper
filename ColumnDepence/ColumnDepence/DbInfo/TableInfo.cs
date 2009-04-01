using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ColumnDepence.DbInfo
{
	public class TableInfo
	{
		public DataTableColumnConstrains ColumnConstrains { get; set; }
		public DataTableReferencedColumnTable ParentReferencedTable { get; set; }
		public DataTableReferencedColumnTable ChildReferencedTable { get; set; }
		public DataTable Values { get; set; }

		public TableInfo() {
			ColumnConstrains = new DataTableColumnConstrains();
			ParentReferencedTable = new DataTableReferencedColumnTable();
			ChildReferencedTable = new DataTableReferencedColumnTable();
			Values = new DataTable();
		}

		public void LoadTableInfo(string tableName) { 
			LoadColumnConstrains(tableName);
			LoadChildReferencedTable(tableName);
			LoadParentReferencedTable(tableName);
		}



		private void LoadColumnConstrains(string tableName) {
			if (ColumnConstrains != null && ColumnConstrains.IsDataLoaded) return;

			ColumnConstrains =(DataTableColumnConstrains) FillDataTable(
				tableName, 
				global::ColumnDepence.Properties.Resources.SqlColumnConstrains,   
				new DataTableColumnConstrains());
			if(ColumnConstrains == null)
			{
				ColumnConstrains = new DataTableColumnConstrains();
				return;
			}
			
			ColumnConstrains.IsDataLoaded = true;
		}

		private void LoadParentReferencedTable(string tableName)
		{
			if (ParentReferencedTable != null && ParentReferencedTable.IsDataLoaded) return;

			ParentReferencedTable = (DataTableReferencedColumnTable)FillDataTable(
				tableName,
				global::ColumnDepence.Properties.Resources.SqlParentReferenes,
				new DataTableReferencedColumnTable());
			if (ParentReferencedTable == null)
			{
				ParentReferencedTable = new DataTableReferencedColumnTable();
				return;
			}

			ParentReferencedTable.IsDataLoaded = true;
		}


		private void LoadChildReferencedTable(string tableName)
		{
			if (ChildReferencedTable != null && ChildReferencedTable.IsDataLoaded) return;

			ChildReferencedTable = (DataTableReferencedColumnTable)FillDataTable(
				tableName,
				global::ColumnDepence.Properties.Resources.SqlChildReferences,
				new DataTableReferencedColumnTable());
			if (ChildReferencedTable == null)
			{
				ChildReferencedTable = new DataTableReferencedColumnTable();
				return;
			}

			ChildReferencedTable.IsDataLoaded = true;
		}



		public static DataTable FillDataTable(string tableName, string sql_cmd_str, DataTable dataTable)
		{
			try
			{
				if (ConnectionFactory.Instance == null) return null;

				ConnectionFactory.OpenConnection();

				SqlCommand com = new SqlCommand(sql_cmd_str, ConnectionFactory.Instance);
				if (sql_cmd_str.IndexOf("@TABSEARCH") > -1)
				{
					com.Parameters.Add("@TABSEARCH", SqlDbType.NVarChar);
					com.Parameters["@TABSEARCH"].Value = tableName;
				}
				using (SqlDataAdapter adapter = new SqlDataAdapter(com))
				{

					if (dataTable == null)
					{
						dataTable = new DataTable();
					}
					adapter.Fill(dataTable);
					return dataTable;
				}
			}
			catch
			{
				return null;
			}
			finally
			{
				ConnectionFactory.CloseConnection();
			}
		}

	}
}
