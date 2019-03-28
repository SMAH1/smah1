using System;
using System.Drawing;
using System.Text.RegularExpressions;


/**********************************************************************
 How to use:
    [XmlIgnore()]
    public Font Font {
        get { return mFont; }
        set { mFont = value; }
    }

    [Browsable(false)]
    [XmlElement("Font")]
    public string FontHidden {
        get { return FontSerializationHelper.Serialize(mFont); }
        set { mFont = FontSerializationHelper.Deserialize(value); }
    }
**********************************************************************/

/*
 * in this develop use code of:
 *      Address :  https://stackoverflow.com/questions/19263202/how-to-serialize-font
 *      Author : dotNET, SMAH1
 */

#if NETFULL
namespace SMAH1.Serialize
{
    public class XmlFontSerializationHelper
    {
        public static Font Deserialize(string value)
        {
            Font ret = null;

            Match mFontByDescription = Regex.Match(value, "^(?<Font>[\\w ]+),(?<Size>(\\d+(\\.\\d+)?))(,(?<Style>(R|[BISU]{1,4})))?$", RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);

            if (mFontByDescription.Success)
            {
                if (mFontByDescription.Groups.Count < 4 || mFontByDescription.Groups[3].Value == "R")
                {
                    return new Font(mFontByDescription.Groups["Font"].Value, Single.Parse(mFontByDescription.Groups["Size"].Value));
                }
                else
                {
                    FontStyle fs =
                        (mFontByDescription.Groups[3].Value.IndexOf("B") >= 0 ? FontStyle.Bold : FontStyle.Regular) |
                        (mFontByDescription.Groups[3].Value.IndexOf("I") >= 0 ? FontStyle.Italic : FontStyle.Regular) |
                        (mFontByDescription.Groups[3].Value.IndexOf("U") >= 0 ? FontStyle.Underline : FontStyle.Regular) |
                        (mFontByDescription.Groups[3].Value.IndexOf("S") >= 0 ? FontStyle.Strikeout : FontStyle.Regular);
                    return new Font(mFontByDescription.Groups["Font"].Value, Single.Parse(mFontByDescription.Groups["Size"].Value), fs);
                }
            }
            else
            {
                ret = SystemFonts.GetFontByName(value);
            }

            if (ret == null) ret = SystemFonts.DefaultFont;
            return ret;
        }

        public static string Serialize(Font value)
        {
            string str;

            if (value.IsSystemFont)
            {
                str = value.SystemFontName;
            }
            else
            {
                str = value.Name + "," + value.Size.ToString() + ",";
                if (value.Style == FontStyle.Regular)
                {
                    str += "R";
                }
                else
                {
                    if (value.Bold) str += "B";
                    if (value.Italic) str += "I";
                    if (value.Strikeout) str += "S";
                    if (value.Underline) str += "U";
                }
            }

            return str;
        }
    }
}
#endif
