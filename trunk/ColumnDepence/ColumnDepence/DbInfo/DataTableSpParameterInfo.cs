using System.Data.SqlClient;
using System.Data;

namespace ColumnDepence.DbInfo
{
	/// <summary>
	/// </summary>
	public class DataTableSpParameterInfo :DataTable
	{
		public const string ParameterMode = "PARAMETER_MODE";
		public const string LENGTH = "LENGTH";

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
			string str = row[LENGTH].ToString();
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
		public void FillParameters(string SpName)
		{
			const string sqlStr =
				@"SELECT PARAMETER_NAME , DATA_TYPE, 
		CASE 
			WHEN CHARACTER_MAXIMUM_LENGTH is not null THEN CHARACTER_MAXIMUM_LENGTH
			ELSE NUMERIC_PRECISION END AS [LENGTH], PARAMETER_MODE 
		FROM INFORMATION_SCHEMA.PARAMETERS "
				+ "WHERE SPECIFIC_NAME LIKE @SPSEARCH Order by ORDINAL_POSITION ";

			FillDataSet(SpName, sqlStr, this);
		}
		
		
		/// <summary>
		/// Execute sql string and return result in DataTable
		/// </summary>
		/// <param name="SpName"></param>
		/// <param name="sqlCmdStr">SQL to execute</param>
		/// <param name="dataTable"></param>
		/// <returns>Result of SQL executtion</returns>
		public static DataTable FillDataSet(string SpName, string sqlCmdStr, DataTable dataTable)
		{
			try
			{
				if (ConnectionFactory.OpenConnection() == false) return null;

				SqlCommand com = new SqlCommand(sqlCmdStr, ConnectionFactory.Instance);
				if (sqlCmdStr.IndexOf("@SPSEARCH") > -1)
				{
					com.Parameters.Add("@SPSEARCH", SqlDbType.NVarChar);
					com.Parameters["@SPSEARCH"].Value = SpName;
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
