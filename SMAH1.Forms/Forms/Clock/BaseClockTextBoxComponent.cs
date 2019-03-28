using System;
using System.Collections.Generic;
using System.Text;
using SMAH1.ExtensionMethod;

namespace SMAH1.Forms.Clock
{
    internal abstract class BaseClockTextBoxComponent
    {
        public BaseClockTextBoxComponent(int _min, int _max, int _length, string _format)
        {
            Min = _min;
            Max = _max;
            Format = _format;
            Length = _length;
            Location = 0;
            keyResult = new char[Length];
            ClearKeyPressed();
        }

        public void ClearKeyPressed()
        {
            for (int i = 0; i < keyResult.Length; i++)
                keyResult[i] = '0';
        }

        char[] keyResult;
        public int Min { get; }
        public int Max { get; }
        public string Format { get; }
        public int Location { get; set; }
        public int Length { get; }

        public string KeyPressed(char key)
        {
            int i;

            if (keyResult[0] != '0')
                for (i = 0; i < keyResult.Length; i++)
                    keyResult[i] = '0';

            char[] text = new char[Length];
            Array.Copy(keyResult, text, Length);
            for (i = 1; i < text.Length; i++)
                text[i - 1] = text[i];
            text[text.Length - 1] = key;

            string ret = new string(text);
            i = Convert.ToInt32(ret);
            if (!(i >= Min && i <= Max))
                ret = string.Empty;
            else
                keyResult = text;

            return ret;
        }

        public string FormatText(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str.Trim("0123456789".ToCharArray()).Length == 0)
                    return string.Format(Format, Math.Abs(int.Parse(str)));
            }
            return string.Format(Format, 0);
        }
    }
}
