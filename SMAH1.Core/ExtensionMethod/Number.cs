using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMAH1.ExtensionMethod
{
    public static class NumberExtensionMethod
    {
        public static bool IsIntegerNumber(this string str, bool supportNegative = false)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if ((supportNegative && str.StartsWith("-")) || str.StartsWith("+"))
                    str.Substring(1);

                if (!string.IsNullOrEmpty(str))
                    if (str.Trim("0123456789".ToCharArray()).Length == 0)
                        return true;
            }
            return false;
        }

        public static bool IsFloatNumber(this string str, bool supportNegative = false)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if ((supportNegative && str.StartsWith("-")) || str.StartsWith("+"))
                    str.Substring(1);

                if (!string.IsNullOrEmpty(str))
                {
                    str = str.Trim("0123456789".ToCharArray());
                    if (string.IsNullOrEmpty(str) || str == ".")
                        return true;
                }
            }
            return false;
        }

        #region RoundNumber
        /// <summary>
        /// Round number to upper (in negative lower) like 2,5,10 number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static double RoundNumber(this double num)
        {
            if (num == 0)
                return 0;

            double res = 0;

            bool negativ = false;
            if (num < 0)
            {
                negativ = true;
                num = -num;
            }

            double digit = (int)Math.Log10(num);
            if (num < 1)
                digit--;
            double n = Math.Pow(10, digit);

            if (n == num)
                res = n;
            else if (2 * n >= num)
                res = 2 * n;
            else if (5 * n >= num)
                res = 5 * n;
            else if (10 * n >= num)
                res = 10 * n;
            else
                res = 0;

            if (negativ)
                res = -res;

            return res;
        }

        /// <summary>
        /// Round number to upper (in negative lower) like 2,5,10 number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static float RoundNumber(this float num)
        {
            return (float)RoundNumber((double)num);
        }

        /// <summary>
        /// Round number to upper (in negative lower) like 2,5,10 number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int RoundNumber(this int num)
        {
            return (int)RoundNumber((double)num);
        }

        /// <summary>
        /// Round number to upper (in negative lower) like 2,5,10 number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static long RoundNumber(this long num)
        {
            return (long)RoundNumber((double)num);
        }
        #endregion
    }
}
