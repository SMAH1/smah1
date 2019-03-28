using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMAH1.ExtensionMethod.Persian
{
    public static class IranNationCodeExtensionMethod
    {
        /// <summary>
        /// string contain 10 digits
        /// </summary>
        /// <param name="nationCode"></param>
        /// <returns></returns>
        public static bool IsValidIranianNationCode(this string nationCode)
        {
            bool ret = false;
            try
            {
                if (nationCode.Length == 10)
                {
                    int digit = GetIranianNationCodeCheckDigit(nationCode.Substring(0, 9));

                    if (digit == int.Parse(nationCode[9].ToString()))
                        ret = true;
                }
            }
            catch { }
            return ret;
        }

        /// <summary>
        /// string contain 9 digits
        /// </summary>
        /// <param name="nationCode"></param>
        /// <returns>Check-sum digit</returns>
        public static int GetIranianNationCodeCheckDigit(this string nationCode)
        {
            if (nationCode.Length != 9) throw new Exception("Length of nationCode is 9");

            int ret = -1;
            try
            {
                if (nationCode.IsIntegerNumber())
                {
                    char[] codeChar = nationCode.ToCharArray();
                    long j = 0;
                    for (int i = 0; i < 9; i++)
                        j += int.Parse(codeChar[i].ToString()) * (10 - i);
                    j %= 11;
                    if (j > 1)
                        j = 11 - j;

                    ret = (int)j;
                }
            }
            catch { }
            return ret;
        }
    }
}
