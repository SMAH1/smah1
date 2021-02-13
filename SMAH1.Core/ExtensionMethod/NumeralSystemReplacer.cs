using SMAH1.Character;
using System;
using System.Linq;
using System.Text;

namespace SMAH1.ExtensionMethod
{
    public static class NumeralSystemReplacerExtensionMethod
    {
        /// <summary>
        /// Replace digit character from 'numeral system' to another 'numeral system'
        /// </summary>
        /// <param name="data"></param>
        /// <param name="distination">To language</param>
        /// <param name="sources">From languages</param>
        /// <returns></returns>
        public static string NumeralSystemReplacer(this string data, NumeralSystemSign distination, params NumeralSystemSign[] sources)
        {
            if (sources == null || sources.Length == 0) throw new ArgumentNullException("sources");
            sources = sources.Distinct().ToArray();

            StringBuilder sbSrc = new StringBuilder();
            StringBuilder sbDis = new StringBuilder();
            StringBuilder sbData = new StringBuilder();

            foreach (var f in sources)
                sbSrc.Append(SMAH1.EnumInfoBase<NumeralSystemSign>.GetFieldDescription(f, 0));
            sbDis.Append(SMAH1.EnumInfoBase<NumeralSystemSign>.GetFieldDescription(distination, 0));

            string src = sbSrc.ToString();
            string dist = sbDis.ToString();

            sbData.Append(data);

            for (int i = 0, j = 0; i < src.Length; i++, j++)
            {
                if (j == 10) j = 0; // Or user %

                sbData.Replace(src[i], dist[j]);
            }

            return sbData.ToString();
        }

        /// <summary>
        /// Replace digit character from 'all numeral system' to specified 'numeral system'
        /// </summary>
        /// <param name="data"></param>
        /// <param name="distination">To language</param>
        /// <returns></returns>
        public static string NumeralSystemReplacerForAll(this string data, NumeralSystemSign distination)
        {
            var sources = SMAH1.EnumInfoBase<NumeralSystemSign>.GetFields().ToArray();
            return NumeralSystemReplacer(data, distination, sources);
        }
    }
}
