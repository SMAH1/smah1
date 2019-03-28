using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMAH1.ExtensionMethod.Persian
{
    public static class PersianKeyLayoutExtensionMethod
    {
        public const char SEMI_SPACE = '‌';
        public const char SPACE = ' ';

        /// <summary>
        /// return string contain main alphabet.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Convert ی and ک Arrabic To ی And ک Farsi
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string ToPersianStandardAlphabet(this string str)
        {
            //تبدیل ی و ک عربی به ی و ک فارسی
            char yeFarsi = (char)1740;
            char yeArabi = (char)1610;
            char keFarsi = (char)1705;
            char keArabi = (char)1603;

            return str.Replace(yeArabi, yeFarsi).Replace(keArabi, keFarsi);
        }

        /// <summary>
        /// ژatch runs of any kind of whitespace(e.g.tabs, newlines, etc.) and replace them with a single space. Proper placement for semi space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string ToPersianStandardWord(this string str)
        {
            str = str.Replace(SEMI_SPACE, SPACE).Trim();

            // Since it will catch runs of any kind of whitespace(e.g.tabs, newlines, etc.) and replace them with a single space.
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ");

            //Proper placement for semi space
            foreach (var c in "ءادرزو")
                str = str.Replace("" + c + SPACE, "" + c);

            return str.Replace(SPACE, SEMI_SPACE);
        }
    }
}
