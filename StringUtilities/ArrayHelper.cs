using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAUtilities.StringUtilities
{
    public static class ArrayHelper
    {
        /// <summary>
        /// Remove empty items from array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string[] Trim(this string[] array) => array.Where(x => !string.IsNullOrEmpty(x)).ToArray();
    }
}
