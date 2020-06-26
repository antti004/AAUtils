using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AAUtilities.DataTableUtils
{
    public static class TableHelper
    {
        public static string ToXml(this DataTable table, bool writeShema = false)
        {
            System.IO.StringWriter writer = new System.IO.StringWriter();
            if (writeShema)  table.WriteXml(writer, XmlWriteMode.WriteSchema, true);
            if (!writeShema) table.WriteXml(writer, XmlWriteMode.IgnoreSchema, false);
            return writer.ToString();
        }

        /// <summary>
        /// Return max value length per column.
        /// If column rows have no value, then return column name length
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Dictionary<string, int> MaxColumnsValueLengths(this DataTable table,bool fillEmpty=true)
        {

            Dictionary<string,int> result = table.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, v => table.Rows.Cast<DataRow>().Max(x => x[v.ColumnName].ToString().Length));
            if (fillEmpty)
            {
                foreach (var pair in result)
                {
                    if (pair.Value < pair.Key.Length)
                        result[pair.Key] = pair.Key.Length;
                }
            }
            return result;
        }


    }
}
