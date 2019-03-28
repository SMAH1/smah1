using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMAH1.ExtensionMethod.Persian
{
    public static class FarsiDigitExtensionMethod
    {
        /// <summary>
        /// Replace English digit by Persian digit
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ConvertEnDigitToFaDigit(this string data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= data.Length - 1; i++)
            {
                int c = Convert.ToInt32(data[i]);
                if (c >= 48 && c <= 57)
                    sb.Append(Convert.ToChar(c + 1728));
                else
                    sb.Append(Convert.ToChar(c));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Replace Persian digit by English digit
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ConvertFaDigitToEnDigit(this string data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= data.Length - 1; i++)
            {
                int c = Convert.ToInt32(data[i]);
                if (c >= 1776 && c <= 1785)
                    sb.Append(Convert.ToChar(c - 1728));
                else
                    sb.Append(Convert.ToChar(c));
            }
            return sb.ToString();
        }
    }
}
