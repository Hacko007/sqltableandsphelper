﻿using System.Data;
using System.Data.SqlClient;

namespace ColumnDepence.DbInfo
{
	public class TableInfo
	{
		public DataTableColumnConstrains ColumnConstrains { get; set; }
		public DataTableChildTables ChildTables { get; set; }
		public DataTableParentTables ParentTables { get; set; }
		public DataTable Values { get; set; }

		public TableInfo() {
			ColumnConstrains = new DataTableColumnConstrains();
			ChildTables = new DataTableChildTables();
			ParentTables = new DataTableParentTables();
			Values = new DataTable();
		}

		public void LoadTableInfo(string tableName) { 
			LoadColumnConstrains(tableName);
			LoadParentTables(tableName);
			LoadChildTables(tableName);
		}



		private void LoadColumnConstrains(string tableName) {
			if (ColumnConstrains != null && ColumnConstrains.IsDataLoaded) return;

			ColumnConstrains =(DataTableColumnConstrains) FillDataTable(
				tableName, 
				Properties.Resources.SqlGetColumnConstrains,   
				new DataTableColumnConstrains());
			if(ColumnConstrains == null)
			{
				ColumnConstrains = new DataTableColumnConstrains();
				return;
			}
			
			ColumnConstrains.IsDataLoaded = true;
		}

		private void LoadChildTables(string tableName)
		{
			if (ChildTables != null && ChildTables.IsDataLoaded) return;

			ChildTables = (DataTableChildTables)FillDataTable(
				tableName,
				Properties.Resources.SqlGetChildTables,
				new DataTableChildTables());
			if (ChildTables == null)
			{
				ChildTables = new DataTableChildTables();
				return;
			}

			ChildTables.IsDataLoaded = true;
		}


		private void LoadParentTables(string tableName)
		{
			if (ParentTables != null && ParentTables.IsDataLoaded) return;

			ParentTables = (DataTableParentTables)FillDataTable(
				tableName,
				Properties.Resources.SqlGetParentTables,
				new DataTableParentTables());
			if (ParentTables == null)
			{
				ParentTables = new DataTableParentTables();
				return;
			}

			ParentTables.IsDataLoaded = true;
		}



		public static DataTable FillDataTable(string tableName, string sqlCmdStr, DataTable dataTable)
		{
			try
			{
				if (ConnectionFactory.Instance == null) return null;

				ConnectionFactory.OpenConnection();

				SqlCommand com = new SqlCommand(sqlCmdStr, ConnectionFactory.Instance);
				if (sqlCmdStr.IndexOf("@TABSEARCH") > -1)
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