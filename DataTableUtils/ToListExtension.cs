using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AAUtilities.DataTableUtils
{
    public static class ToListExtension
    {
        public static IList<T> ToList<T>(this DataTable table) where T : new()
        {
            if (table == null) return null;
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, table.Columns, properties);
                result.Add(item);
            }
            return result;
        }

        public static IList<T> ToList<T>(this DataTable table, Dictionary<string, string> mappings) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, table.Columns, properties, mappings);
                result.Add(item);
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, DataColumnCollection columns, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (!columns.Contains(property.Name)) continue;

                if (row[property.Name] == DBNull.Value) continue;
                property.SetValue(item, row[property.Name], null);
            }
            return item;
        }

        private static T CreateItemFromRow<T>(DataRow row, DataColumnCollection columns, IList<PropertyInfo> properties, Dictionary<string, string> mappings) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (!columns.Contains(property.Name)) continue;
                if (mappings.ContainsKey(property.Name))
                    property.SetValue(item, row[mappings[property.Name]], null);
            }
            return item;
        }
    }
}
