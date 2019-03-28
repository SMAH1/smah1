using System;

namespace SMAH1
{
    public class Wildcard
    {
        #region static
        /// <summary>
        /// Compare input string by pattern.Only Support * and ? (Escape those characters by '\' if no sensitive themselves)
        /// </summary>
        /// <param name="input">Main string for check</param>
        /// <param name="pattern">Pattern (or mask) string for check</param>
        /// <returns></returns>
        public static bool Compare(string input, string pattern)
        {
            CharEnumerator ie = input.GetEnumerator();
            CharEnumerator me = pattern.GetEnumerator();

            Wildcard sc = new Wildcard(input.ToCharArray());
            return sc.Compare(pattern.ToCharArray());
        }

        /// <summary>
        /// Convert pattern string to regex.Only Support * and ?
        /// </summary>
        /// <param name="pattern">Pattern (or mask) string for check</param>
        /// <returns></returns>
        public static string ToRegex(string pattern)
        {
            return "^" + System.Text.RegularExpressions.Regex.Escape(pattern)
                              .Replace(@"\*", ".*")
                              .Replace(@"\?", ".")
                       + "$";
        }
        #endregion static

        #region Use
        private Wildcard(char[] str)
        {
            this.str = str;
        }

        private bool Compare(char[] pattern)
        {
            this.pat = pattern;
            return CompareInternal(-1, -1);
        }
        #endregion

        #region private
        char[] str;
        char[] pat;
        private bool MoveNextInput(ref int index)
        {
            index++;
            return (index < str.Length);
        }
        private bool MoveNextPattern(ref int index)
        {
            index++;
            return (index < pat.Length);
        }

        private bool CompareInternal(int indexInput, int indexPattern)
        {
            while (MoveNextPattern(ref indexPattern))
            {
                switch (pat[indexPattern])
                {
                    case '?':
                        if (!MoveNextInput(ref indexInput))
                        {
                            return false;
                        }
                        break;
                    case '*': // non greedy match, first try * matches nothing
                        do
                        {
                            if (CompareInternal(indexInput, indexPattern))
                                return true;
                        } while (MoveNextInput(ref indexInput));
                        return false;
                    case '\\':
                        MoveNextPattern(ref indexPattern);
                        goto default;
                    default:
                        if (!MoveNextInput(ref indexInput) || str[indexInput] != pat[indexPattern])
                            return false;
                        break;
                }
            }

            return !MoveNextInput(ref indexInput);
        }
        #endregion

        #region Test
        /*public static void Main()
        {
            string[] sa = new string[] {
                // Positive Tests
                "ran.jpg", "*.jpg",
                "", "*",
                " ", "?",
                "a", "*",
                "ab", "*",
                "a", "?",
                "abc", "*?",
                "abc", "?*",
                "abc", "*abc",
                "abc", "*abc*",
                "aXXXbc", "*a*bc*",
                "a?bc", @"*a\?bc*",
 
                // Negative Tests
                "", "*a",
                "", "a*",
                "", "?",
                "a", "*b*",
                "ab", "b*a",
                "a", "??",
                "", "*?",
                "a", "??*",
                "abX", "*abc",
                "Xbc", "*abc*",
                "ac", "*a*bc*",
                "a*bc", @"*a\?bc*",
                "adbc", @"*a\?bc*",


                ""
            };

            int i, j = sa.Length - 2;
            for (i = 0; i < j; i += 2)
            {
                bool ret = TTT.Wildcard.Compare(sa[i], sa[i + 1]);
                Console.Write("\r\t\t\t\t\t" + ret + "\t" + ((i / 2) + 1));
                Console.Write("\r\t\t\t" + sa[i]);
                Console.Write("\r" + ((i / 2) + 1) + "\t" + sa[i + 1]);
                Console.WriteLine("");
            }
        }*/
        #endregion
    }
}
