using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SMAH1.ExtensionMethod
{
    public static class SelectTextIfFocusExtensionMethod
    {
        public static void SelectTextIfFocus(this TextBox txt)
        {
            if (txt == null)
                throw new ArgumentNullException("txt");

            if (dic == null)
                dic = new Dictionary<TextBox, TextFocusSelectText>();

            if (!dic.ContainsKey(txt))
            {
                TextFocusSelectText tfs = new TextFocusSelectText(txt, dic);
            }
        }

        public static void SelectTextIfFocusClear(this TextBox txt)
        {
            if (txt == null)
                throw new ArgumentNullException("txt");

            if (dic == null)
                dic = new Dictionary<TextBox, TextFocusSelectText>();

            if (dic.ContainsKey(txt))
            {
                TextFocusSelectText tfs = dic[txt];
                tfs.Clear();
            }
        }

        #region Selected Text on Focus
        static Dictionary<TextBox, TextFocusSelectText> dic;

        class TextFocusSelectText
        {
            TextBox txt = null;
            bool alreadyFocused = false;
            Dictionary<TextBox, TextFocusSelectText> dic;

            public TextFocusSelectText(TextBox txt, Dictionary<TextBox, TextFocusSelectText> dic)
            {
                txt.GotFocus += new EventHandler(TextBoxGotFocus);
                txt.MouseUp += new MouseEventHandler(TextBoxMouseUp);
                txt.Leave += new EventHandler(TextBoxLeave);
                txt.Disposed += new EventHandler(TextBoxDisposed);
                this.txt = txt;
                this.dic = dic;

                dic.Add(txt, this);
            }

            void TextBoxDisposed(object sender, EventArgs e)
            {
                Clear();
            }

            public void Clear()
            {
                txt.GotFocus -= new EventHandler(TextBoxGotFocus);
                txt.MouseUp -= new MouseEventHandler(TextBoxMouseUp);
                txt.Leave -= new EventHandler(TextBoxLeave);
                txt.Disposed -= new EventHandler(TextBoxDisposed);

                dic.Remove(txt);
            }

            void TextBoxLeave(object sender, EventArgs e)
            {
                TextBox txt = sender as TextBox;
                alreadyFocused = false;
            }

            void TextBoxGotFocus(object sender, EventArgs e)
            {
                if (System.Windows.Forms.Control.MouseButtons == MouseButtons.None)
                {
                    txt.SelectAll();
                    alreadyFocused = true;
                }
            }

            void TextBoxMouseUp(object sender, MouseEventArgs e)
            {
                if (!alreadyFocused && txt.SelectionLength == 0)
                {
                    alreadyFocused = true;
                    txt.SelectAll();
                }
            }
        }
        #endregion
    }
}
