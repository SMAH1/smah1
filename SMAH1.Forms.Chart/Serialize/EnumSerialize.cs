using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Serialize
{
    public static class EnumSerialize
    {
        #region Name
        /// <summary>
        /// Convert enum value to name
        /// </summary>
        /// <param name="enumValue">Value of enum</param>
        /// <returns>String of enum value</returns>
        public static string SerializeEnumToName(object enumValue)
        {
            Type enumType = enumValue.GetType();
            if (enumType.IsEnum)
                return enumValue.ToString();
            return "";
        }

        /// <summary>
        /// Convert name of enum value to enum value
        /// </summary>
        /// <typeparam name="EnumType">Type of enum</typeparam>
        /// <param name="enumName">Name of enum value</param>
        /// <returns>enum value</returns>
        public static EnumType DeserializeEnumFromName<EnumType>(string enumName)
        {
            return (EnumType)
                DeserializeEnumFromName(typeof(EnumType), enumName);
        }

        /// <summary>
        /// Convert name of enum value to enum value
        /// </summary>
        /// <param name="enumType">Type of enum</param>
        /// <param name="enumName">Name of enum value</param>
        /// <returns>enum value</returns>
        public static object DeserializeEnumFromName(Type enumType, string enumName)
        {
            object oSerialize = null;
            if (enumType.IsEnum)
            {
                try
                {
                    oSerialize = Enum.Parse(enumType, enumName);
                }
                catch
                {
                    throw new ArgumentException(string.Format(
                        "'{0}' is not member of '{1}'",
                        enumName, enumType.ToString()));
                }
            }
            return oSerialize;
        }
        #endregion

        #region Valuetype
        /// <summary>
        /// Convert enum value to value type object string (like 0,5,-1,...)
        /// </summary>
        /// <param name="enumValue">Value of enum</param>
        /// <returns>value type object string (like 0,5,-1,...)</returns>
        public static string SerializeEnumToValuetype(object enumValue)
        {
            Type enumType = enumValue.GetType();
            string sSerialize = "";
            if (enumType.IsEnum)
            {
                try
                {
                    TypeCode typeCode = Type.GetTypeCode(enumType);
                    switch (typeCode)
                    {
                        case TypeCode.Byte:
                            sSerialize = ((Byte)enumValue).ToString();
                            break;
                        case TypeCode.SByte:
                            sSerialize = ((SByte)enumValue).ToString();
                            break;

                        case TypeCode.Int16:
                            sSerialize = ((Int16)enumValue).ToString();
                            break;
                        case TypeCode.UInt16:
                            sSerialize = ((UInt16)enumValue).ToString();
                            break;

                        case TypeCode.Int32:
                            sSerialize = ((Int32)enumValue).ToString();
                            break;
                        case TypeCode.UInt32:
                            sSerialize = ((UInt32)enumValue).ToString();
                            break;

                        case TypeCode.Int64:
                            sSerialize = ((Int64)enumValue).ToString();
                            break;
                        case TypeCode.UInt64:
                            sSerialize = ((UInt64)enumValue).ToString();
                            break;

                        default:
                            sSerialize = "";
                            break;
                    }
                }
                catch { }
            }
            return sSerialize;
        }

        /// <summary>
        /// Convert value type object string (like 0,5,-1,...) to enum value
        /// </summary>
        /// <typeparam name="EnumType">Type of enum</typeparam>
        /// <param name="enumValue">value type object string (like 0,5,-1,...)</param>
        /// <returns>enum value</returns>
        public static EnumType DeserializeEnumFromValuetype<EnumType>(string enumValue)
        {
            return (EnumType)
                DeserializeEnumFromValuetype(typeof(EnumType), enumValue);
        }

        /// <summary>
        /// Convert value type object string (like 0,5,-1,...) to enum value
        /// </summary>
        /// <typeparam name="EnumType">Type of enum</typeparam>
        /// <param name="enumValue">value type object string (like 0,5,-1,...)</param>
        /// <returns>enum value</returns>
        public static object DeserializeEnumFromValuetype(Type enumType, string enumValue)
        {
            object oSerialize = null;
            if (enumType.IsEnum)
            {
                try
                {
                    TypeCode typeCode = Type.GetTypeCode(enumType);
                    switch (typeCode)
                    {
                        case TypeCode.Byte:
                            oSerialize = Byte.Parse(enumValue);
                            break;
                        case TypeCode.SByte:
                            oSerialize = SByte.Parse(enumValue);
                            break;

                        case TypeCode.Int16:
                            oSerialize = Int16.Parse(enumValue);
                            break;
                        case TypeCode.UInt16:
                            oSerialize = UInt16.Parse(enumValue);
                            break;

                        case TypeCode.Int32:
                            oSerialize = Int32.Parse(enumValue);
                            break;
                        case TypeCode.UInt32:
                            oSerialize = UInt32.Parse(enumValue);
                            break;

                        case TypeCode.Int64:
                            oSerialize = Int64.Parse(enumValue);
                            break;
                        case TypeCode.UInt64:
                            oSerialize = UInt64.Parse(enumValue);
                            break;

                        default:
                            throw new ArgumentException(string.Format(
                                "'{0}' is not member of '{1}'",
                                enumValue, enumType.ToString()));
                    }
                }
                catch
                {
                    throw new ArgumentException(string.Format(
                        "'{0}' is not member of '{1}'",
                        enumValue, enumType.ToString()));
                }
            }
            return oSerialize;
        }
        #endregion
    }
}
