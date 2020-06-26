using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AAUtilities.DataTableUtils
{
    public static class TableTrimmer
    {
        /// <summary>
        /// Remove rows which given column cell "column" is null 
        /// </summary>
        /// <param name="argData"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static DataTable RemoveEmptyRows(this DataTable argData, string column)
        {
            DataTable result = argData.Clone();
            DataRow[] rows = argData.Select(string.Format("{0} is not null", column));
            foreach (DataRow row in rows)
                result.ImportRow(row);
            return result;
        }

        public static DataTable RemoveEmptyColumns(this DataTable data)
        {
            string[] columns = data.Columns.Names().ToArray();
            foreach (string column in columns)
            {
                if (data.Rows.Cast<DataRow>().All(dr => dr.IsNull(column)))
                    data.Columns.Remove(column);
            }
            return data;
        }
    }
}
