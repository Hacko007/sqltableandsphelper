using System.Data;
using System.Data.SqlClient;

namespace ColumnDepence
{
	/// <summary>
	/// Singlton for applications Sql Connection
	/// </summary>
	public class ConnectionFactory
	{
		private ConnectionFactory() { }

		private static void InitConnectionStringFromHistory()
		{
			SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
			con.DataSource = global::ColumnDepence.Properties.Settings.Default.LastUsedServer;
			con.InitialCatalog = global::ColumnDepence.Properties.Settings.Default.LastUsedDatabase;
			con.UserID = global::ColumnDepence.Properties.Settings.Default.LastUsedUsername;
			con.Password = global::ColumnDepence.Properties.Settings.Default.LastUsedPassword;
			
			ConnectionString = con.ConnectionString;
		}

		private static string connectionString = null;
		public static string ConnectionString { 
			get {
				if (connectionString == null) {
					InitConnectionStringFromHistory();
				}
				return connectionString; 
			}
			set
			{
				connectionString = value;
				m_Instance = new SqlConnection(connectionString);				
			}
		}

		public static string ShortConnectionName {
			get {
				if (Instance == null)
				{
					return "";
				}
				else {
					return Instance.DataSource + " . " + Instance.Database;
				}
			} 
		}

		#region Connection factory method
		private static SqlConnection m_Instance;


		public static SqlConnection Instance
		{
			get
			{
				lock (typeof(ConnectionFactory))
				{
					if (ConnectionString == null) return null;

					if (m_Instance == null)
					{
						m_Instance = new SqlConnection(ConnectionString);
					}
				}
				return m_Instance;
			}
		}

		public static bool OpenConnection()
		{
			try
			{
				if (Instance != null && Instance.State != ConnectionState.Open)
				{
					Instance.Open();
				}
				
				return (Instance.State == ConnectionState.Open);
			}
			catch {
				return false;
			}
		}
		public static void CloseConnection()
		{
			try
			{
				if (Instance != null && Instance.State != ConnectionState.Closed)
				{
					Instance.Close();
				}
			}
			catch { }
		}
		#endregion

	}
}
