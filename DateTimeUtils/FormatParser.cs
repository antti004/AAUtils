using System;
using System.Collections.Generic;
using System.Text;

namespace AAUtilities.DateTimeUtils
{
    class FormatParser
    {
        public static string Map(DateTimeFormat src)
        {
            switch (src)
            {
                case DateTimeFormat.ISO8601: return "yyMMddTHHmmss";
                case DateTimeFormat.Linux: return "yyyyMMddhhmmss.fff";
                case DateTimeFormat.Sql102: return "yyyy-MM-dd HH:mm:ss";

                default: throw new ArgumentException($"Unknwon DateTimeFormat {src}.");
            }
        }
    }
    public enum DateTimeFormat
    {
        Sql102,
        Linux,
        ISO8601
    }


}
