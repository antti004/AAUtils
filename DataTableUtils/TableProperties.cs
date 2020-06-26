using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AAUtilities.DataTableUtils
{
    public static class TableProperties
    {
        public static T MaxValue<T>(this DataTable data, string columnName, string filter = null)
        {
            return (T)data.Compute(string.Format("Max({0})", columnName), filter);
        }

        public static T MinValue<T>(this DataTable data, string columnName, string filter = null)
        {
            return (T)data.Compute(string.Format("Min({0})", columnName), filter);
        }

        public static IEnumerable<string> Names(this DataColumnCollection cols)
        {
            return cols.Cast<DataColumn>().Select(c => c.ColumnName);
        }

        public static IEnumerable<string> ColumnsNames(this DataTable source)
        {
            return source?.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
        }

    }
}
