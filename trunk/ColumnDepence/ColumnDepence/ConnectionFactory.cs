using System.Data;
using System.Data.SqlClient;
using ColumnDepence.Properties;

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
			if (Settings.Default.LastUsedServer == ""
				|| Settings.Default.LastUsedDatabase == "") 
				return;

			SqlConnectionStringBuilder con = new SqlConnectionStringBuilder
												{
													DataSource = Settings.Default.LastUsedServer,
													InitialCatalog = Settings.Default.LastUsedDatabase,
													UserID = Settings.Default.LastUsedUsername,
													Password = Settings.Default.LastUsedPassword,
													IntegratedSecurity = Settings.Default.LastUsedIntegratedSecurity
												};

			ConnectionString = con.ConnectionString;
		}


		/// <summary>
		/// Save current connection as latest connection in history
		/// </summary>
		private static void SaveConnectionStringToHistory()
		{
			if( Instance == null ) return ;
			try
			{
				SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(Instance.ConnectionString);
				Settings.Default.LastUsedServer = sqlBuilder.DataSource;
				Settings.Default.LastUsedDatabase = sqlBuilder["Initial Catalog"].ToString();
				Settings.Default.LastUsedUsername = sqlBuilder.UserID;
				Settings.Default.LastUsedPassword = sqlBuilder.Password;
				Settings.Default.LastUsedIntegratedSecurity = sqlBuilder.IntegratedSecurity;
				Settings.Default.Save();
			}
			catch { }
		}

		private static string m_ConnectionString ;
		public static string ConnectionString { 
			get {
				if (m_ConnectionString == null) {
					InitConnectionStringFromHistory();
				}
				return m_ConnectionString; 
			}
			set
			{
				m_ConnectionString = value;
				m_Instance = new SqlConnection(m_ConnectionString);				
			}
		}

		public static string ShortConnectionName {
			get
			{
				if (Instance == null)
				{
					return "";
				}
				return Instance.DataSource + " . " + Instance.Database;
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
					SaveConnectionStringToHistory();
				}

				if (Instance != null) 
					return (Instance.State == ConnectionState.Open);
				
				return false;
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
