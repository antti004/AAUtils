using System;
using System.Collections.Generic;
using System.Text;

namespace AAUtilities.GenericUtils
{
    public class EnumUtils
    {
        public static T GetAttributeOfType<T>(Enum enumVal) where T : System.Attribute
        {
            Type type = enumVal.GetType();
            System.Reflection.MemberInfo[] memInfo = type.GetMember(enumVal.ToString());
            object[] attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }


        /// <summary>
        /// EnumType ToEnum[EnumType](stringEnumValue,DevaultEnumValueToReturnIfStringIsNotInEnum)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strEnumValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ToEnum<T>(string strEnumValue, T defaultValue)
        {
            if (!Enum.IsDefined(typeof(T), strEnumValue))
                return defaultValue;
            return (T)Enum.Parse(typeof(T), strEnumValue);
        }
    }
}
