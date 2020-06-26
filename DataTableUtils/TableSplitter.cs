using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AAUtilities.DataTableUtils
{
    public static class TableSplitter
    {
        /// <summary>
        /// Split big table into multiple smaller tables.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rowsInTable">how many rows in smaller tables.</param>
        /// <returns></returns>
        public static IEnumerable<DataTable> Split(this DataTable data, int rowsInTable)
        {
            List<DataTable> result = new List<DataTable>();
            string szTableName = data.TableName;
            if (data.Rows.Count < rowsInTable)
            {
                data.TableName = szTableName;
                result.Add(data);
                return result;
            }

            int counter = 0;
            int tableNr = 1;
            DataTable tmpData = data.Clone();
            tmpData.TableName = szTableName;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (counter >= rowsInTable)
                {
                    tableNr++;
                    result.Add(tmpData);
                    tmpData = data.Clone();
                    tmpData.TableName = szTableName;
                    counter = 0;
                }
                tmpData.ImportRow(data.Rows[i]);
                counter++;
            }

            if (tmpData.Rows.Count > 0)
                result.Add(tmpData);
            return result;
        }


    }
}
