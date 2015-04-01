using System;
using System.Data;

namespace hackovic.DbInfo.DbInfo
{
    public class DataTableColumnInfo : DataTable
    {
        public const string TABLE_NAME = "ColumnInfo";

        public DataTableColumnInfo()
            : base(TABLE_NAME)
        {
            InitColumns();
            IsDataLoaded = false;
        }

        public bool IsDataLoaded { get; set; }
        public DataColumn ColumnColumnName { get; set; }
        public DataColumn ColumnType { get; set; }
        public DataColumn ColumnNullable { get; set; }
        public DataColumn ColumnMax { get; set; }
        public DataColumn ColumnDefault { get; set; }
        public DataColumn ColumnIdentity { get; set; }

        private void InitColumns()
        {
            ColumnColumnName = new DataColumn("Name", typeof(string));
            ColumnType = new DataColumn("Type", typeof(string));
            ColumnNullable = new DataColumn("Nullable", typeof(bool));
            ColumnMax = new DataColumn("Max", typeof(int));
            ColumnDefault = new DataColumn("Default", typeof(string));
            ColumnIdentity = new DataColumn("Identity", typeof(Boolean));
            Columns.Clear();
            Columns.AddRange(
                new[]
                {
                    ColumnColumnName,
                    ColumnType,
                    ColumnNullable,
                    ColumnMax,
                    ColumnDefault,
                    ColumnIdentity
                });
        }

        internal void SetIdentityColumns(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return;
            }
            foreach (DataRow row in Rows)
            {
                row[ColumnIdentity] = false;
                foreach (DataRow columnIdentityRow in dataTable.Rows)
                {
                    if (row[ColumnColumnName].ToString() == columnIdentityRow[0].ToString())
                    {
                        row[ColumnIdentity] = true;
                    }
                }
            }
        }

        internal bool IsIdentityColumn(string ColumnName)
        {
            foreach (DataRow row in Rows)
            {
                if (row[ColumnColumnName].ToString() == ColumnName && (bool)row[ColumnIdentity])
                {
                    return true;
                }
            }
            return false;
        }
    }
}