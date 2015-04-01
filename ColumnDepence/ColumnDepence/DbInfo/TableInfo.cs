using System.Data;
using System.Data.SqlClient;

namespace hackovic.DbInfo.DbInfo
{
	public class TableInfo
	{
		public string TableName { get; set; }
		public DataTableColumnInfo ColumnInfo { get; set; }
		public DataTableColumnConstrains ColumnConstrains { get; set; }
		public DataTableChildTables ChildTables { get; set; }
		public DataTableParentTables ParentTables { get; set; }
		public DataTable Values { get; set; }
		public bool ValuesLoadedWithFilter { get; set; }

		public TableInfo() {
			ColumnConstrains = new DataTableColumnConstrains();
			ChildTables = new DataTableChildTables();
			ParentTables = new DataTableParentTables();
			Values = new DataTable();
			ColumnInfo = new DataTableColumnInfo();
			ValuesLoadedWithFilter = false;
		}

		public void LoadTableInfo() {
			LoadColumnInfo();
			LoadColumnConstrains();
			LoadParentTables();
			LoadChildTables();
		}

		private void LoadColumnInfo()
		{
			if (ColumnInfo != null && ColumnInfo.IsDataLoaded) return;

			ColumnInfo = (DataTableColumnInfo)FillDataTable(
				TableName,
				Properties.Resources.GetColumnInfoForTable,
				new DataTableColumnInfo());
			if (ColumnInfo== null)
			{
				ColumnInfo = new DataTableColumnInfo();
				return;
			}
			ColumnInfo.SetIdentityColumns(GetIdentityColumns());
			ColumnInfo.IsDataLoaded = true;
		}

		private DataTable GetIdentityColumns()
		{
			return FillDataTable(
			    TableName,
			    Properties.Resources.SqlGetIdentityColumns,
			    new DataTable());
		}

		private void LoadColumnConstrains() {
			if (ColumnConstrains != null && ColumnConstrains.IsDataLoaded) return;

			ColumnConstrains =(DataTableColumnConstrains) FillDataTable(
				TableName, 
				Properties.Resources.SqlGetColumnConstrains,   
				new DataTableColumnConstrains());
			if(ColumnConstrains == null)
			{
				ColumnConstrains = new DataTableColumnConstrains();
				return;
			}
			
			ColumnConstrains.IsDataLoaded = true;
		}

		private void LoadChildTables()
		{
			if (ChildTables != null && ChildTables.IsDataLoaded) return;

			ChildTables = (DataTableChildTables)FillDataTable(
				TableName,
				Properties.Resources.SqlGetChildTables,
				new DataTableChildTables());
			if (ChildTables == null)
			{
				ChildTables = new DataTableChildTables();
				return;
			}

			ChildTables.IsDataLoaded = true;
		}


		private void LoadParentTables()
		{
			if (ParentTables != null && ParentTables.IsDataLoaded) return;

			ParentTables = (DataTableParentTables)FillDataTable(
				TableName,
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
