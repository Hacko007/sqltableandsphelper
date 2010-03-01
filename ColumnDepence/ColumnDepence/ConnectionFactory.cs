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
			if (Properties.Settings.Default.LastUsedServer == ""
				|| Properties.Settings.Default.LastUsedDatabase == "") 
				return;

			SqlConnectionStringBuilder con = new SqlConnectionStringBuilder
												{
													DataSource = Properties.Settings.Default.LastUsedServer,
													InitialCatalog = Properties.Settings.Default.LastUsedDatabase,
													UserID = Properties.Settings.Default.LastUsedUsername,
													Password = Properties.Settings.Default.LastUsedPassword,
													IntegratedSecurity = Properties.Settings.Default.LastUsedIntegratedSecurity
												};

			ConnectionString = con.ConnectionString;
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
