using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAUtilities
{
    public static class QueryHelper
    {
        public static string ToCSV(this string[] self) => string.Join(",", self.Select(a => $"'{a}'").ToArray());


        public static string ToCSV<T>(this IEnumerable<T> argArray) => "'" + string.Join("','", argArray.Select(i => i.ToString().Trim()).ToArray()) + "'";

        public static string ToSql102(this DateTime dtTime) => dtTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
