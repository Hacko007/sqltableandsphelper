using System.Data.SqlClient;

namespace hackovic.DbInfo
{

	public class ConnectionStringItem 
	{

		public SqlConnectionStringBuilder SqlConnectionStringBuilder { get; set; }


		public string SqlConnectionString
		{
			get
			{
				return SqlConnectionStringBuilder == null ? "" : SqlConnectionStringBuilder.ConnectionString;
			}

			set 
			{
				SqlConnectionStringBuilder = new SqlConnectionStringBuilder(value);
			}
		}

		public string SqlDbOnlyConnectionString
		{
			get
			{
				return SqlConnectionStringBuilder == null ? "" : SqlConnectionStringBuilder.ConnectionString;
			}

			set
			{
				SqlConnectionStringBuilder = new SqlConnectionStringBuilder(value) {InitialCatalog = ""};
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

		public string DisplayDbOnly
		{
			get
			{
				if (SqlConnectionStringBuilder == null)
					return "";

				return SqlConnectionStringBuilder.DataSource					
					+ " . " + SqlConnectionStringBuilder.UserID;
			}
		}

		public override bool Equals(object obj)
		{
			if ((obj is ConnectionStringItem) == false || (SqlConnectionStringBuilder == null)) return false;

			ConnectionStringItem item2 = obj as ConnectionStringItem;

			return Equals(item2);
		}

		public bool Equals(ConnectionStringItem other)
		{
			if (ReferenceEquals(null, other)) return false;
			
			return ReferenceEquals(this, other) || Equals(other.SqlConnectionStringBuilder, SqlConnectionStringBuilder);
		}

		public override int GetHashCode()
		{
			return (SqlConnectionStringBuilder != null ? SqlConnectionStringBuilder.GetHashCode() : 0);
		}
	}	
}
