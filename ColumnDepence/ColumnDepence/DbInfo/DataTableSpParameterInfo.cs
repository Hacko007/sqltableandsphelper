using System.Data;
using System.Data.SqlClient;

namespace hackovic.DbInfo.DbInfo
{
	/// <summary>
	/// </summary>
	public class DataTableSpParameterInfo :DataTable
	{
		public const string ParameterMode = "PARAMETER_MODE";
		public const string Length = "LENGTH";
		private const string SpSearchParameterName = "@SPSEARCH";

		public bool IsDataLoaded { get; set; }

		public DataColumn ColumnParameterName { get; set; }
		public DataColumn ColumnDataType{ get; set; }
		public DataColumn ColumnLength { get; set; }
		public DataColumn ColumnParameterMode{ get; set; }

		public DataTableSpParameterInfo()
		{
			InitializeColumns();
		}
		
		public static int? GetLength(DataRow row)
		{
			int? length = null;
			int pars;
			string str = row[Length].ToString();
			if(int.TryParse(str,out pars))
			{
				length = pars;
			}
			return length;
		}


		public static bool IsInputParameter(DataRow row)
		{
			return
				(row[ParameterMode].ToString() == "IN")
				|| (row[ParameterMode].ToString() == "INOUT");
		}

		private void InitializeColumns()
		{
			ColumnParameterName = new DataColumn("PARAMETER_NAME", typeof (string))
			                      	{
			                      		Caption = "Parameter name"
			                      	};

			ColumnDataType = new DataColumn("DATA_TYPE", typeof (string))
			                 	{
			                 		Caption = "Type"
			                 	};

			ColumnLength = new DataColumn("LENGTH", typeof (int))
			               	{
			               		Caption = "Length"
			               	};
			ColumnParameterMode = new DataColumn(ParameterMode, typeof(string))
			                      	{
			                      		Caption = "Parameter Mode"
			                      	};

			Columns.Clear();
			Columns.AddRange(new[] {ColumnParameterName, ColumnDataType, ColumnLength, ColumnParameterMode});

		}

		/// <summary>
		/// Fill datagrid with inforamtion about SP's parameters
		/// </summary>
		public void FillParameters(string spName)
		{
			const string sqlStr =
				"SELECT PARAMETER_NAME , DATA_TYPE, CASE "
				+ "WHEN CHARACTER_MAXIMUM_LENGTH is not null THEN CHARACTER_MAXIMUM_LENGTH "
				+ "ELSE NUMERIC_PRECISION END AS [LENGTH], PARAMETER_MODE "
				+ "FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME LIKE "
				+ SpSearchParameterName + " Order by ORDINAL_POSITION ";

			FillDataSet(spName, sqlStr, this);
		}
		
		
		/// <summary>
		/// Execute sql string and return result in DataTable
		/// </summary>
		/// <param name="spName"></param>
		/// <param name="sqlCmdStr">SQL to execute</param>
		/// <param name="dataTable"></param>
		/// <returns>Result of SQL executtion</returns>
		public static DataTable FillDataSet(string spName, string sqlCmdStr, DataTable dataTable)
		{
			try
			{
				if (ConnectionFactory.OpenConnection() == false) return null;

				SqlCommand com = new SqlCommand(sqlCmdStr, ConnectionFactory.Instance);
				if (sqlCmdStr.IndexOf(SpSearchParameterName) > -1)
				{
					com.Parameters.Add(SpSearchParameterName, SqlDbType.NVarChar);
					com.Parameters[SpSearchParameterName].Value = spName;
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
