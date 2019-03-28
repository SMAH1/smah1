using System;
using System.Drawing;
using System.Xml.Serialization;


/**********************************************************************
 How to use:
    [XmlElement(Type = typeof(XmlColor))]
    public System.Drawing.Color BackgroundColor { get; set; }
**********************************************************************/

/*
 * in this develop use code of:
 *      Address :  https://stackoverflow.com/questions/3280362/most-elegant-xml-serialization-of-color-structure
 *      Author : bvj, SMAH1
 */

#if NETFULL
namespace SMAH1.Serialize
{
    public class XmlColor
    {
        private Color color = Color.Black;

        public XmlColor() { }
        public XmlColor(Color c) { color = c; }

        public Color ToColor() { return color; }
        public void SetColor(Color c) { color = c; }

        public static implicit operator Color(XmlColor x) { return x.ToColor(); }
        public static implicit operator XmlColor(Color c) { return new XmlColor(c); }

        [XmlText]
        public string Data
        {
            get
            {
                var ret = ColorTranslator.ToHtml(color);

                if (ret.StartsWith("#"))
                {
                    ret = "#" + color.A.ToString("X2") + ret.Substring(1);
                }

                return ret;
            }
            set
            {
                try
                {
                    if (value.Length == 9 && value.StartsWith("#"))
                    {
                        string str = value.Substring(1);
                        string alpha = str.Substring(0, 2);
                        string color = str.Substring(2);

                        var c = ColorTranslator.FromHtml("#" + color);
                        byte a = byte.Parse(alpha, System.Globalization.NumberStyles.HexNumber);

                        if (a != c.A)
                            c = Color.FromArgb(a, c);

                        this.color = c;
                    }
                    else
                        color = ColorTranslator.FromHtml(value);
                }
                catch (Exception)
                {
                    color = Color.Black;
                }
            }
        }
    }
}
#endif
