using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SMAH1.Forms.Chart.Component.Axile
{
    public class AxileLabelText
    {
        private string replacedText;
        private bool replaced;

        internal AxileLabelText(int columnIndex, RectangleF rect,
                string defaultText, StringAlignment alignment)
        {
            ColumnIndex = columnIndex;
            Rectangle = rect;
            Alignment = alignment;
            DefaultText = defaultText;
            replacedText = defaultText;
            replaced = false;
        }

        public int ColumnIndex { get; }
        public RectangleF Rectangle { get; }
        public string Text
        {
            get
            {
                if (replaced)
                    return replacedText;
                return DefaultText;
            }
        }
        public string DefaultText { get; }
        public string ReplacedText
        {
            set
            {
                replacedText = value;
                replaced = true;
            }
        }
        internal StringAlignment Alignment { get; }

        public void ClearReplaceText()
        {
            replacedText = DefaultText;
            replaced = false;
        }
    }
}
