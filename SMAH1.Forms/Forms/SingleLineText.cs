using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace SMAH1.Forms
{
    public class SingleLineText
    {
        public enum TextFromBaseLine
        {
            Normal,
            Subscript,
            Superscript
        }

        public class TextAndState
        {
            public TextFromBaseLine Stat { get; }
            public string Text { get; }
            public bool Continuous { get; }

            public TextAndState(TextFromBaseLine stat, string text, bool continuous)
            {
                Stat = stat;
                Text = text;
                Continuous = continuous;
            }
        }

        private List<TextAndState> lst;

        public SingleLineText()
        {
            lst = new List<TextAndState>();
        }

        public SingleLineText(string text)
            : this()
        {
            Add(text, TextFromBaseLine.Normal);
        }

        public void Clear()
        {
            lst.Clear();
            OnTextChanged();
        }

        public int Count
        {
            get { return lst.Count; }
        }

        public void Add(string text, TextFromBaseLine stat)
        {
            if (!string.IsNullOrEmpty(text))
            {
                lst.Add(new TextAndState(stat, text, false));
                OnTextChanged();
            }
        }

        public void Add(string text, TextFromBaseLine stat, bool continuous)
        {
            if (!string.IsNullOrEmpty(text))
            {
                lst.Add(new TextAndState(stat, text, continuous));
                OnTextChanged();
            }
        }

        public void Add(string text,
                char normal, char subscript, char superscript)
        {
            StringBuilder sb = new StringBuilder();
            TextFromBaseLine stat = TextFromBaseLine.Normal;
            TextFromBaseLine statHelper = TextFromBaseLine.Normal;
            bool bNew = true;
            bool bAdd = false;
            sb.Remove(0, sb.Length);
            foreach (char c in text.ToCharArray())
            {
                bNew = true;
                if (c == normal)
                    statHelper = TextFromBaseLine.Normal;
                else if (c == subscript)
                    statHelper = TextFromBaseLine.Subscript;
                else if (c == superscript)
                    statHelper = TextFromBaseLine.Superscript;
                else
                {
                    bNew = false;
                    sb.Append(c);
                }

                if (bNew)
                {
                    string s = sb.ToString();
                    if (!string.IsNullOrEmpty(s))
                    {
                        lst.Add(new TextAndState(stat, s, false));
                        bAdd = true;
                    }
                    sb.Remove(0, sb.Length);
                }

                stat = statHelper;
            }
            string ss = sb.ToString();
            if (!string.IsNullOrEmpty(ss))
            {
                lst.Add(new TextAndState(stat, ss, false));
                bAdd = true;
            }

            if (bAdd)
                OnTextChanged();
        }

        public void AddRange(System.Collections.Generic.IEnumerable<TextAndState> collection)
        {
            lst.AddRange(collection);
            OnTextChanged();
        }

        public void RemoveAt(int index)
        {
            lst.RemoveAt(index);
            OnTextChanged();
        }

        public void Insert(int index, string text, TextFromBaseLine stat)
        {
            lst.Insert(index, new TextAndState(stat, text, false));
            OnTextChanged();
        }

        public void Insert(int index, string text, TextFromBaseLine stat, bool continuous)
        {
            lst.Insert(index, new TextAndState(stat, text, continuous));
            OnTextChanged();
        }

        public TextAndState[] ToArray()
        {
            return lst.ToArray();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            foreach (TextAndState ts in lst)
                sb.Append(ts.Text);
            return sb.ToString();
        }

        public TextAndState this[int index]
        {
            get { return lst[index]; }
        }

        /************************ Draw and Measure *******************/
        private static void Init(Font font, out Font subsup, out int subsupY)
        {
            subsup = new Font(font.FontFamily, font.Size * 4 / 5, font.Style);
            subsupY = subsup.Height / 2;
        }

        public void DrawString(Graphics g, Font font, Brush br,
                    float x, float y)
        {
            DrawString(g, font, br, x, y, true);
        }

        public void DrawString(Graphics g, Font font, Brush br,
                    float x, float y, bool fixedHeight)
        {
            OperatingSystem os = Environment.OSVersion;
            if (os.Platform == PlatformID.Unix
                || os.Platform == PlatformID.MacOSX)
            {
                DrawStringLinux(g, font, br, x, y, fixedHeight);
            }
            else
            {
                DrawStringWindows(g, font, br, x, y, fixedHeight);
            }
        }

        public SizeF MeasureString(Graphics g, Font font)
        {
            return MeasureString(g, font, true);
        }

        public SizeF MeasureString(Graphics g, Font font, bool fixedHeight)
        {
            SizeF sf = new SizeF(0, 0);

            OperatingSystem os = Environment.OSVersion;
            if (os.Platform == PlatformID.Unix
                || os.Platform == PlatformID.MacOSX)
            {
                sf = MeasureStringLinux(g, font, fixedHeight);
            }
            else
            {
                sf = MeasureStringWindows(g, font, fixedHeight);
            }

            return sf;
        }

        private void DrawStringLinux(Graphics g, Font font, Brush br,
                    float x, float y, bool fixedHeight)
        {
            Init(font, out Font subsup, out int subsupY);

            y += subsupY;

            bool allIsNormal = true;
            foreach (TextAndState ts in lst)
                allIsNormal &= (ts.Stat == TextFromBaseLine.Normal);

            foreach (TextAndState ts in lst)
            {
                SizeF size = g.MeasureString(ts.Text,
                    (ts.Stat == TextFromBaseLine.Normal ? font : subsup));
                if (allIsNormal && !fixedHeight)
                {
                    g.DrawString(ts.Text,
                           font,
                           br,
                           x, y - subsupY
                           );
                }
                else
                {
                    g.DrawString(ts.Text,
                        (ts.Stat == TextFromBaseLine.Normal ? font : subsup),
                        br,
                        x, (ts.Stat == TextFromBaseLine.Normal ? y :
                            (ts.Stat == TextFromBaseLine.Subscript ?
                            y + font.Height / 2 : y - subsupY))
                        );
                }
                x += size.Width;
            }
        }

        private SizeF MeasureStringLinux(Graphics g, Font font, bool fixedHeight)
        {
            Init(font, out Font subsup, out int subsupY);

            float x = 0;
            float y = subsupY;

            float xx = x;
            foreach (TextAndState ts in lst)
            {
                SizeF size = g.MeasureString(ts.Text,
                    (ts.Stat == TextFromBaseLine.Normal ? font : subsup));
                xx += size.Width;
            }

            if (fixedHeight)
                return new SizeF(xx - x, 2 * subsupY + font.Height);

            foreach (TextAndState ts in lst)
                if (ts.Stat != TextFromBaseLine.Normal)
                    return new SizeF(xx - x, 2 * subsupY + font.Height);

            return new SizeF(xx - x, font.Height);
        }

        private void DrawStringWindows(Graphics g, Font font, Brush br,
                    float x, float y, bool fixedHeight)
        {
            Init(font, out Font subsup, out int subsupY);

            y += subsupY;

            bool allIsNormal = true;
            foreach (TextAndState ts in lst)
                allIsNormal &= (ts.Stat == TextFromBaseLine.Normal);

            float xx = x;
            TextFromBaseLine old = TextFromBaseLine.Normal;
            foreach (TextAndState ts in lst)
            {
                xx = x;
                if (old != ts.Stat)
                    xx += 2;

                float yy = (ts.Stat == TextFromBaseLine.Normal ? y :
                        (ts.Stat == TextFromBaseLine.Subscript ?
                        y + font.Height / 2 : y - subsupY));

                if (allIsNormal && !fixedHeight)
                    yy = y - subsupY;

                x += MyDrawString(ts.Text, g,
                    br,
                    (ts.Stat == TextFromBaseLine.Normal ? font : subsup),
                    ref xx, ref yy, false, ts.Continuous);
                old = ts.Stat;
            }
        }

        private SizeF MeasureStringWindows(Graphics g, Font font, bool fixedHeight)
        {
            Init(font, out Font subsup, out int subsupY);

            float x = 0;
            float y = subsupY;

            float xx, yy;
            xx = yy = 0;
            float x2 = x;
            TextFromBaseLine old = TextFromBaseLine.Normal;
            foreach (TextAndState ts in lst)
            {
                xx = x2;
                if (old != ts.Stat)
                    xx += 2;

                yy = (ts.Stat == TextFromBaseLine.Normal ? y :
                        (ts.Stat == TextFromBaseLine.Subscript ?
                        y + font.Height / 2 : y - subsupY));

                x2 += MyDrawString(ts.Text, g,
                    null,
                    (ts.Stat == TextFromBaseLine.Normal ? font : subsup),
                    ref xx, ref yy, true, ts.Continuous);
                old = ts.Stat;
            }

            if (fixedHeight)
                return new SizeF(xx - x, 2 * subsupY + font.Height);

            foreach (TextAndState ts in lst)
                if (ts.Stat != TextFromBaseLine.Normal)
                    return new SizeF(xx - x, 2 * subsupY + font.Height);

            return new SizeF(xx - x, font.Height);
        }

        //Return Width
        private float MyDrawString(string text,
                    Graphics g, Brush br, Font font,
                    ref float x, ref float y, bool measure, bool continuousDraw)
        {
            float width = 0;
            if (continuousDraw)
            {
                SizeF sz = g.MeasureString(text, font);
                width = sz.Width;

                if (!measure)
                    g.DrawString(text, font, br, x, y);

                x += sz.Width;
                y += sz.Height;
            }
            else
            {
                int numChars = text.Length;

                List<string> lst = new List<string>();
                if (numChars < 32)
                    lst.Add(text);
                else
                {
                    int i = 0;
                    int j = 30;
                    for (; i < numChars - j; i += j)
                        lst.Add(text.Substring(i, j));
                    if (i < numChars)
                        lst.Add(text.Substring(i, numChars - i));
                }

                float xx = x;
                foreach (string str in lst)
                {
                    numChars = str.Length;
                    CharacterRange[] characterRanges = new CharacterRange[numChars];
                    for (int i = 0; i < numChars; i++)
                        characterRanges[i] = new CharacterRange(i, 1);

                    StringFormat stringFormat = new StringFormat
                    {
                        // Make sure the characters are not clipped
                        FormatFlags = StringFormatFlags.NoClip,
                        Alignment = StringAlignment.Center
                    };
                    stringFormat.SetMeasurableCharacterRanges(characterRanges);

                    Region[] stringRegions = new Region[numChars];

                    SizeF size = g.MeasureString(str, font);

                    RectangleF layoutRect = new RectangleF(xx + width, y, size.Width, size.Height);

                    stringRegions = g.MeasureCharacterRanges(
                        str,
                        font,
                        layoutRect,
                        stringFormat);

                    for (int indx = 0; indx < numChars; indx++)
                    {
                        Region region = stringRegions[indx];
                        RectangleF rect = region.GetBounds(g);
                        if (indx == 0)
                        {
                            x = rect.X;
                            y = rect.Y;
                        }
                        x += rect.Width;
                        width += rect.Width;
                        if (!measure)
                            g.DrawString(str.Substring(indx, 1), font, br, rect, stringFormat);
                    }
                }
            }

            return width;
        }

        #region Custom Events;
        public event EventHandler TextChanged;
        private void OnTextChanged()
        {
            TextChanged?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
