using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ColumnDepence.DbInfo
{
	public static class SqlDbTypeExtension 
	{
		public static SqlDbType ToSqlDbType(this string value)
		{
			return SqlDbType.VarChar;
		}
		public static SqlDbType ToSqlDbType(this bool value)
		{
			return SqlDbType.Bit;
		}
		public static SqlDbType ToSqlDbType(this int value)
		{
			return SqlDbType.Int;
		}
		public static SqlDbType ToSqlDbType(this float value)
		{
			return SqlDbType.Float;
		}
		public static SqlDbType ToSqlDbType(this DateTime value)
		{
			return SqlDbType.DateTime;
		}
		public static SqlDbType ToSqlDbType(this Guid value)
		{
			return SqlDbType.UniqueIdentifier;
		}
	}
}
