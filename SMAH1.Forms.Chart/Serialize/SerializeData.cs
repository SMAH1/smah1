using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SMAH1.Serialize
{
    public static class SerializeData
    {
        /// <summary>
        /// Convert Valuetype,Font,Color and enum to Text
        /// </summary>
        /// <param name="type">Type of value</param>
        /// <param name="value">Value must be converted</param>
        /// <param name="valueText">Final text of value (output)</param>
        /// <returns>If detect type,return true.if not detect,return false and message in valueText</returns>
        public static bool Serialize(Type type, object value, out string valueText)
        {
            bool ret = false;
            valueText = "";
            if (
                    type == typeof(bool) ||
                    type == typeof(byte) ||
                    type == typeof(sbyte) ||
                    type == typeof(char) ||
                    type == typeof(decimal) ||
                    type == typeof(double) ||
                    type == typeof(float) ||
                    type == typeof(int) ||
                    type == typeof(uint) ||
                    type == typeof(long) ||
                    type == typeof(ulong) ||
                    type == typeof(short) ||
                    type == typeof(ushort) ||
                    type == typeof(string)
                    )
            {
                valueText = value.ToString();
                ret = true;
            }
            else if (type == typeof(Font))
            {
                valueText = FontSerialize.SerializeFont((Font)value);
                ret = true;
            }
            else if (type == typeof(Color))
            {
                valueText = ColorSerialize.SerializeColor((Color)value);
                ret = true;
            }
            else if (type.IsEnum)
            {
                valueText = EnumSerialize.SerializeEnumToName(value);
                ret = true;
            }
            else
            {
                valueText = "in '" + type + "' ,Can not determine type ";
            }
            return ret;
        }

        /// <summary>
        /// COnvert text to value
        /// </summary>
        /// <param name="type">Final type of value</param>
        /// <param name="valueText">Input text</param>
        /// <param name="value">Output vlaue (after converted)</param>
        /// <returns>If detect type,return true.if not detect,return false and message in value</returns>
        public static bool Deserialize(Type type, string valueText, out object value)
        {
            bool ret = true;
            value = null;

            try
            {
                if (type == typeof(bool))
                {
                    value = bool.Parse(valueText);
                }
                else if (type == typeof(byte))
                {
                    value = byte.Parse(valueText);
                }
                else if (type == typeof(sbyte))
                {
                    value = sbyte.Parse(valueText);
                }
                else if (type == typeof(char))
                {
                    value = char.Parse(valueText);
                }
                else if (type == typeof(decimal))
                {
                    value = decimal.Parse(valueText);
                }
                else if (type == typeof(double))
                {
                    value = double.Parse(valueText);
                }
                else if (type == typeof(float))
                {
                    value = float.Parse(valueText);
                }
                else if (type == typeof(int))
                {
                    value = int.Parse(valueText);
                }
                else if (type == typeof(uint))
                {
                    value = uint.Parse(valueText);
                }
                else if (type == typeof(long))
                {
                    value = long.Parse(valueText);
                }
                else if (type == typeof(ulong))
                {
                    value = ulong.Parse(valueText);
                }
                else if (type == typeof(short))
                {
                    value = short.Parse(valueText);
                }
                else if (type == typeof(ushort))
                {
                    value = ushort.Parse(valueText);
                }
                else if (type == typeof(string))
                {
                    value = valueText;
                }
                else if (type == typeof(Font))
                {
                    value = FontSerialize.DeserializeFont(valueText);
                }
                else if (type == typeof(Color))
                {
                    value = ColorSerialize.DeserializeColor(valueText);
                }
                else if (type.IsEnum)
                {
                    value = EnumSerialize.DeserializeEnumFromName(type, valueText);
                }
                else
                {
                    value = "in '" + type + "' ,Can not determine type ";
                    ret = false;
                }
            }
            catch (Exception exc)
            {
                value = exc.Message;
                ret = false;
            }
            return ret;
        }
    }
}
