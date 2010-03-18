using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ColumnDepence.DbInfo;

namespace ColumnDepence
{
	public class DataRowEditHelper
	{

		public static SqlCommand CreateInsertSqlCommand(DataRowView rowView, DataTableColumnInfo columnInfo)
		{
			SqlCommand sqlCmd = new SqlCommand();
			StringBuilder sqlColumns = new StringBuilder();
			StringBuilder sqlValues = new StringBuilder();

			foreach (DataColumn col in rowView.Row.Table.Columns)
			{
				if (columnInfo.IsIdentityColumn(col.ColumnName)) continue;

				sqlColumns.Append(string.Format("[{0}] ,", col.ColumnName));
				sqlValues.Append(string.Format("@{0} ,", col.ColumnName));
				if (rowView.Row.HasVersion(DataRowVersion.Proposed))
				{
					sqlCmd.Parameters.Add(new SqlParameter("@" + col.ColumnName, rowView.Row[col, DataRowVersion.Proposed]));
				}
				else
				{
					sqlCmd.Parameters.Add(new SqlParameter("@" + col.ColumnName, DBNull.Value));
				}
			}
			if (sqlColumns.Length > 0)
			{
				sqlColumns.Remove(sqlColumns.Length - 1, 1);
			}
			else
			{
				return null;
			}

			if (sqlValues.Length > 0)
			{
				sqlValues.Remove(sqlValues.Length - 1, 1);
			}
			else
			{
				return null;
			}

			sqlCmd.CommandText = "INSERT INTO " + rowView.Row.Table.TableName + " (" + sqlColumns.ToString() + ") Values( " + sqlValues.ToString() + ")";
			return sqlCmd;
		}
		
		
		public static SqlCommand CreateUpdateRowSqlCommand(DataRowView rowView)
		{
			SqlCommand sqlCmd = new SqlCommand();

			StringBuilder sql = new StringBuilder();
			StringBuilder sqlWhere = new StringBuilder();

			foreach (DataColumn col in rowView.Row.Table.Columns)
			{
				if (rowView.Row.HasVersion(DataRowVersion.Original) &&
					rowView.Row.HasVersion(DataRowVersion.Proposed) &&
					!rowView.Row[col, DataRowVersion.Proposed].Equals(rowView.Row[col, DataRowVersion.Original]))
				{
					sql.Append(string.Format("[{0}] = @{0} ,", col.ColumnName));
					sqlCmd.Parameters.Add(new SqlParameter("@" + col.ColumnName, rowView.Row[col, DataRowVersion.Proposed]));
				}

				if (rowView.Row[col, DataRowVersion.Original] is DBNull)
				{
					sqlWhere.Append(string.Format(" ([{0}] IS NULL) AND", col.ColumnName));
				}
				else
				{
					sqlWhere.Append(string.Format(" ([{0}] = @Original_{0}) AND", col.ColumnName));
					sqlCmd.Parameters.Add(new SqlParameter("@Original_" + col.ColumnName, rowView.Row[col, DataRowVersion.Original]));
				}
			}
			if (sql.Length > 0)
			{
				sql.Remove(sql.Length - 1, 1);
			}
			else
			{
				return null;
			}

			if (sqlWhere.Length > 0)
			{
				sqlWhere.Remove(sqlWhere.Length - 3, 3);
			}
			else
			{
				return null;
			}

			sqlCmd.CommandText = "UPDATE " + rowView.Row.Table.TableName + " SET " + sql.ToString() + " WHERE " + sqlWhere.ToString();
			return sqlCmd;
		}

	}
}
