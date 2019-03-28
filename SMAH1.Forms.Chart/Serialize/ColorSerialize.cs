using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SMAH1.Serialize
{
    public static class ColorSerialize
    {
        private enum ColorFormat
        {
            NamedColor,
            ARGBColor
        }

        public static string SerializeColor(Color color)
        {
            if (color.IsNamedColor)
                return string.Format("{0}:{1}",
                    ColorFormat.NamedColor, color.Name);
            else
                return string.Format("{0}:{1}:{2}:{3}:{4}",
                    ColorFormat.ARGBColor,
                    color.A, color.R, color.G, color.B);
        }

        public static Color DeserializeColor(string color)
        {
            byte a, r, g, b;

            string[] pieces = color.Split(new char[] { ':' });

            ColorFormat colorType = (ColorFormat)
                Enum.Parse(typeof(ColorFormat), pieces[0], true);

            switch (colorType)
            {
                case ColorFormat.NamedColor:
                    return Color.FromName(pieces[1]);

                case ColorFormat.ARGBColor:
                    a = byte.Parse(pieces[1]);
                    r = byte.Parse(pieces[2]);
                    g = byte.Parse(pieces[3]);
                    b = byte.Parse(pieces[4]);

                    return Color.FromArgb(a, r, g, b);
            }
            return Color.Empty;
        }
    }
}
