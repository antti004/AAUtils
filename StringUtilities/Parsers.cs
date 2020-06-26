using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AAUtilities.StringUtilities
{
    public static class Parsers
    {
        public static string Letters(this string input) => Regex.Replace(input, "[^a-zA-Z]", "");
        public static string Numbers(this string input) => Regex.Replace(input, "[^0-9]", "");


        /// <summary>
        /// Remove non-numeric chars from string.
        /// Example "57.200 KG" -> 57.200
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StipNonNumeric(this string input) => new string(input.Where(c => (Char.IsDigit(c) || c == '.' || c == ',')).ToArray());
    }
}
