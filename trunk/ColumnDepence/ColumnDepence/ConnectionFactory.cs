using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ColumnDepence
{
	/// <summary>
	/// Singlton for applications Sql Connection
	/// </summary>
	public class ConnectionFactory
	{
		private ConnectionFactory() { }

		private static string connectionString = null;
		public static string ConnectionString { 
			get { return connectionString; }
			set
			{
				connectionString = value;
				m_Instance = new SqlConnection(connectionString);				
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
		#endregion

	}
}
