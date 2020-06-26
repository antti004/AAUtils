using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AAUtilities.AssemblyUtils
{
    public static class ClassHelper
    {
        /// <summary>
        /// Return properties names in claass.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string[] ClassPropertiesNames(Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public |
            BindingFlags.Static | BindingFlags.FlattenHierarchy);
            return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly).Select(i => i.Name).ToArray();
        }
    }
}
