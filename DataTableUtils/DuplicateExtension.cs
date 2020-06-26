using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AAUtilities.DataTableUtils
{
    public static class DuplicateExtension
    {
        /// <summary>
        /// Find tuplicate rows. Find by given column
        /// </summary>
        /// <param name="data"></param>
        /// <param name="columnToCheck"></param>
        /// <returns></returns>
        public static IEnumerable<DataRow> Uniques(this DataTable data, string columnToCheck)
        {
            return data.Rows.Cast<DataRow>()
                 .GroupBy(dr => dr[columnToCheck])
                 .Where(g => g.Count() == 1)
                 .SelectMany(g => g);
        }


        /// <summary>
        /// Find tuplicate rows. Find by given column
        /// </summary>
        /// <param name="data"></param>
        /// <param name="columnToCheck"></param>
        /// <returns></returns>
        public static IEnumerable<DataRow> Dublicates(this DataTable data, string columnToCheck)
        {
            return data.Rows.Cast<DataRow>()
                 .GroupBy(dr => dr[columnToCheck])
                 .Where(g => g.Count() > 1)
                 .SelectMany(g => g);
        }


        public static void RemoveDublicates(this DataTable data, string columnToCheck)
        {
            var rows = data.Dublicates(columnToCheck);
            foreach (DataRow row in rows)
            {
                data.Rows.Remove(row);
            }
        }
    }
}
