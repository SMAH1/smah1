using System;
using System.Windows.Forms;

namespace SMAH1.Forms.Text
{
    public partial class TextBoxNumeric : TextBox
    {
        interface IStateFunctions
        {
            string OnTextChanged(TextBoxNumeric owner,
                string text, ref int selectionStart, ref int selectionLength,
                bool discreteNumeric, string separator);
            void OnKeyPress(TextBoxNumeric owner, KeyPressEventArgs e);
        }

        #region PositiveInteger
        class PositiveInteger : IStateFunctions
        {
            public string OnTextChanged(TextBoxNumeric owner,
                string text, ref int selectionStart, ref int selectionLength,
                bool discreteNumeric, string separator)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (!(text[i] >= 48 && text[i] <= 57))
                    {
                        text = text.Remove(i, 1);
                        if (i < selectionStart)
                            selectionStart--;
                        if (i >= selectionStart)
                        {
                            int j = i - selectionStart;
                            if (j < selectionLength)
                                selectionLength--;
                        }
                        i--;
                    }
                }
                if (discreteNumeric)
                {
                    for (int i = text.Length - 3; i > 0; i = i - 3)
                    {
                        text = text.Insert(i, separator);

                        if (i < selectionStart)
                            selectionStart++;
                        if (i >= selectionStart)
                        {
                            int j = i - selectionStart;
                            if (j < selectionLength)
                                selectionLength++;
                        }
                    }
                }

                return text;
            }

            public void OnKeyPress(TextBoxNumeric owner, KeyPressEventArgs e)
            {
                if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) && e.KeyChar != 8)
                    e.KeyChar = char.MinValue;
            }
        }
        #endregion

        #region Integer
        class Integer : IStateFunctions
        {
            const char EMPTYCHAR = ' ';

            public string OnTextChanged(TextBoxNumeric owner,
                string text, ref int selectionStart, ref int selectionLength,
                bool discreteNumeric, string separator)
            {
                char sign = text[0];
                bool delSel = false;
                if (sign == '+' || sign == '-')
                {
                    text = text.Remove(0, 1);
                    if (selectionStart > 0)
                    {
                        selectionStart--;
                        delSel = true;
                    }
                }
                else
                    sign = EMPTYCHAR;

                for (int i = 0; i < text.Length; i++)
                {
                    if (!(text[i] >= 48 && text[i] <= 57))
                    {
                        text = text.Remove(i, 1);
                        if (i < selectionStart)
                            selectionStart--;
                        if (i >= selectionStart)
                        {
                            int j = i - selectionStart;
                            if (j < selectionLength)
                                selectionLength--;
                        }
                        i--;
                    }
                }
                if (discreteNumeric)
                {
                    for (int i = text.Length - 3; i > 0; i = i - 3)
                    {
                        text = text.Insert(i, separator);

                        if (i < selectionStart)
                            selectionStart++;
                        if (i >= selectionStart)
                        {
                            int j = i - selectionStart;
                            if (j < selectionLength)
                                selectionLength++;
                        }
                    }
                }

                if (sign != EMPTYCHAR)
                {
                    text = text.Insert(0, sign.ToString());
                    if (delSel)
                        selectionStart++;
                }

                return text;
            }

            public void OnKeyPress(TextBoxNumeric owner, KeyPressEventArgs e)
            {
                if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) && e.KeyChar != 8 && e.KeyChar != '+' && e.KeyChar != '-')
                    e.KeyChar = char.MinValue;
            }
        }
        #endregion

        #region PositiveDouble
        class PositiveDouble : IStateFunctions
        {
            public string OnTextChanged(TextBoxNumeric owner,
                string text, ref int selectionStart, ref int selectionLength,
                bool discreteNumeric, string separator)
            {
                bool notDelFirstDot = true;

                for (int i = 0; i < text.Length; i++)
                {
                    if (!(text[i] >= 48 && text[i] <= 57))
                    {
                        bool del = true;
                        if (text[i] == '.')
                            if (notDelFirstDot)
                            {
                                notDelFirstDot = false;
                                del = false;
                            }
                        if (del)
                        {
                            text = text.Remove(i, 1);
                            if (i < selectionStart)
                                selectionStart--;
                            if (i >= selectionStart)
                            {
                                int j = i - selectionStart;
                                if (j < selectionLength)
                                    selectionLength--;
                            }
                            i--;
                        }
                    }
                }
                if (discreteNumeric)
                {
                    int index = text.IndexOf('.');
                    if (index == -1)
                        index = text.Length;
                    for (int i = index - 3; i > 0; i = i - 3)
                    {
                        text = text.Insert(i, separator);

                        if (i < selectionStart)
                            selectionStart++;
                        if (i >= selectionStart)
                        {
                            int j = i - selectionStart;
                            if (j < selectionLength)
                                selectionLength++;
                        }
                    }
                }

                return text;
            }

            public void OnKeyPress(TextBoxNumeric owner, KeyPressEventArgs e)
            {
                if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) && e.KeyChar != 8 && e.KeyChar != '.')
                    e.KeyChar = char.MinValue;
            }
        }
        #endregion

        #region Double
        class Double : IStateFunctions
        {
            const char EMPTYCHAR = ' ';

            public string OnTextChanged(TextBoxNumeric owner,
                string text, ref int selectionStart, ref int selectionLength,
                bool discreteNumeric, string separator)
            {
                char sign = text[0];
                bool delSel = false;
                if (sign == '+' || sign == '-')
                {
                    text = text.Remove(0, 1);
                    if (selectionStart > 0)
                    {
                        selectionStart--;
                        delSel = true;
                    }
                }
                else
                    sign = EMPTYCHAR;

                bool notDelFirstDot = true;

                for (int i = 0; i < text.Length; i++)
                {
                    if (!(text[i] >= 48 && text[i] <= 57))
                    {
                        bool del = true;
                        if (text[i] == '.')
                            if (notDelFirstDot)
                            {
                                notDelFirstDot = false;
                                del = false;
                            }
                        if (del)
                        {
                            text = text.Remove(i, 1);
                            if (i < selectionStart)
                                selectionStart--;
                            if (i >= selectionStart)
                            {
                                int j = i - selectionStart;
                                if (j < selectionLength)
                                    selectionLength--;
                            }
                            i--;
                        }
                    }
                }
                if (discreteNumeric)
                {
                    int index = text.IndexOf('.');
                    if (index == -1)
                        index = text.Length;
                    for (int i = index - 3; i > 0; i = i - 3)
                    {
                        text = text.Insert(i, separator);

                        if (i < selectionStart)
                            selectionStart++;
                        if (i >= selectionStart)
                        {
                            int j = i - selectionStart;
                            if (j < selectionLength)
                                selectionLength++;
                        }
                    }
                }

                if (sign != EMPTYCHAR)
                {
                    text = text.Insert(0, sign.ToString());
                    if (delSel)
                        selectionStart++;
                }

                return text;
            }

            public void OnKeyPress(TextBoxNumeric owner, KeyPressEventArgs e)
            {
                if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) && e.KeyChar != 8 && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '.')
                    e.KeyChar = char.MinValue;
            }
        }
        #endregion

    }
}
