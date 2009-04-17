using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ColumnDepence
{
	public class ConnectionStringItem
	{

		public SqlConnectionStringBuilder SqlConnectionStringBuilder { get; set; }


		public string SqlConnectionString
		{
			get
			{
				if (SqlConnectionStringBuilder == null)
					return "";

				return SqlConnectionStringBuilder.ConnectionString;
			}

			set 
			{
				SqlConnectionStringBuilder = new SqlConnectionStringBuilder(value);
			}
		}


		public string Display
		{
			get
			{
				if (SqlConnectionStringBuilder == null)
					return "";

				return SqlConnectionStringBuilder.DataSource
					+ " . " + SqlConnectionStringBuilder.InitialCatalog
					+ " . " + SqlConnectionStringBuilder.UserID;
			}
		}

	}
}
