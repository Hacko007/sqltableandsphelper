using System.Data;
using System.Data.SqlClient;

namespace ColumnDepence.DbInfo
{
public	class DataTableSpDependencies:DataTable
	{

		public bool IsDataLoaded { get; set; }

		/// <summary>
		/// Fill datagrid with inforamtion about SP's dependencies
		/// </summary>
		public void FillDependecies(string SpName)
		{

			try
			{
				if (ConnectionFactory.OpenConnection() == false) return;

				SqlCommand com = new SqlCommand("sp_depends", ConnectionFactory.Instance)
				{
					CommandType = CommandType.StoredProcedure
				};
				com.Parameters.Add("@objname", SqlDbType.NVarChar, 517);
				com.Parameters[0].Value = SpName;

				using (SqlDataAdapter adapter = new SqlDataAdapter(com))
				{					
					adapter.Fill(this);


					if (Rows.Count > 0)
					{

						Columns.Add("MyUpd", typeof(bool), "IIF(updated = 'yes', 1 , 0)");
						Columns.Add("MySel", typeof(bool), "IIF(selected = 'yes', 1 , 0)");
						Columns.Add("MyType", typeof(string), "IIF(type = 'stored procedure', 'SP' , 'TAB')");						

					}
				}
			}
			catch { }
			finally
			{
				ConnectionFactory.CloseConnection();
			}
		}
	}
}
