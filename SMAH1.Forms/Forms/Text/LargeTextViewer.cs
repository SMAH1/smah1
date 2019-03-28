using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SMAH1.Forms.Text
{
    public partial class LargeTextViewer : UserControl
    {
        #region structure for keep data
        class LineInfo
        {
            public class LinePartInfo
            {
                public LinePartInfo(int startString, int lengthByte, int lengthString,
                    Color foreColor, Color backColor,
                    float widthOnDraw)
                {
                    this.StartString = startString;
                    this.LengthByte = lengthByte;
                    this.EndString = startString + lengthString;
                    this.ForeColor = foreColor;
                    this.BackColor = backColor;
                    this.WidthOnDraw = widthOnDraw;
                }
                public int StartString { get; }
                public int EndString { get; set; }
                public int LengthString { get { return EndString - StartString; } }
                public int LengthByte { get; set; }
                public Color ForeColor { get; set; }
                public Color BackColor { get; set; }
                public float WidthOnDraw { get; set; }
            }

            List<LinePartInfo> Parts;

            public LineInfo()
            {
                Parts = new List<LinePartInfo>();
                Length = 0;
                WidthOnDraw = 0F;
                Parts.Add(new LinePartInfo(0, 0, 0, Color.Transparent, Color.Transparent, 0F));
                backColor = Color.Transparent;
            }

            public void Add(int lenByte, int lenString, Color foreColor, Color backColor, float widthOnDraw)
            {
                if (lenByte < 0)
                    return;

                if (Parts[Parts.Count - 1].LengthByte == 0)
                {
                    Parts[Parts.Count - 1].LengthByte = lenByte;
                    Parts[Parts.Count - 1].EndString = lenString;
                    Parts[Parts.Count - 1].WidthOnDraw = widthOnDraw;
                    Parts[Parts.Count - 1].ForeColor = (foreColor.IsEmpty ? Color.Transparent : foreColor);
                    Parts[Parts.Count - 1].BackColor = (backColor.IsEmpty ? Color.Transparent : backColor);
                }
                else if (
                    (foreColor.IsEmpty || Parts[Parts.Count - 1].ForeColor == foreColor) &&
                    (backColor.IsEmpty || Parts[Parts.Count - 1].BackColor == backColor)
                )
                {
                    Parts[Parts.Count - 1].LengthByte += lenByte;
                    Parts[Parts.Count - 1].EndString += lenString;
                    Parts[Parts.Count - 1].WidthOnDraw += widthOnDraw;
                }
                else
                {
                    Parts.Add(new LinePartInfo(Parts[Parts.Count - 1].EndString, lenByte, lenString,
                        foreColor.IsEmpty ? Color.Transparent : foreColor,
                        backColor.IsEmpty ? Color.Transparent : backColor,
                        widthOnDraw));
                }
                this.Length += lenByte;
                this.WidthOnDraw += widthOnDraw;
                this.backColor = backColor.IsEmpty ? this.backColor : backColor;
            }

            public long Index { get; set; }
            public int Length { get; private set; }
            public bool Appendable { get; set; }
            public float WidthOnDraw { get; private set; }

            public int PartsCount { get { return Parts.Count; } }
            public LinePartInfo this[int i] { get { return Parts[i]; } }

            Color backColor;
            public Color BackColor { get { return backColor; } set { backColor = value; } }

            public void ResetWidthOnDraw()
            {
                WidthOnDraw = 0;
                foreach (var item in Parts)
                    item.WidthOnDraw = 0;
            }

            public void SetWidthOnDraw(int inx, float width)
            {
                WidthOnDraw += width;
                Parts[inx].WidthOnDraw = width;
            }
        }
        readonly LineInfo DEFAULT = new LineInfo { Index = -1, Appendable = false };
        GrowableStore<LineInfo> info;

        FileStream fsData;
        string filename;
        #endregion

        #region enum
        enum ScrollState
        {
            None,
            Begin,
            End,
            Selected
        }
        #endregion

        #region default
        Color defaultColor = Color.Transparent;
        #endregion

        #region variable
        int maxWidth = 0;
        bool redrawable = true;
        Color selectedBackColor = Color.Transparent;
        int selectedIndex = -1;
        int oldVerticalScrollValue = -1;
        int oldHorizontalScrollValue = -1;
        StringFormat stringFormat;
        TextRenderingHint textRenderingHint = TextRenderingHint.ClearTypeGridFit;
        ScrollState scrollState = ScrollState.None;
        #endregion

        public LargeTextViewer()
        {
            InitializeComponent();

            stringFormat = new StringFormat(StringFormat.GenericTypographic);
            stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;

            this.Disposed += new EventHandler(LargeTextViewer_Disposed);

            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(10, 10);

            info = new GrowableStore<LineInfo>(20, DEFAULT);
            if (!this.DesignMode)
            {
                filename = System.IO.Path.GetTempFileName();
                fsData = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }

            this.VerticalScroll.SmallChange = this.Font.Height;

            this.DoubleBuffered = true;
        }

        ~LargeTextViewer()
        {
            if (fsData != null)
            {
                fsData.Close();
                System.IO.File.Delete(filename);
                fsData = null;
            }
        }

        void LargeTextViewer_Disposed(object sender, EventArgs e)
        {
            if (fsData != null)
            {
                fsData.Close();
                System.IO.File.Delete(filename);
                fsData = null;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Redrawable
        {
            get { return redrawable; }
            set
            {
                redrawable = value;
                UpdateScrollValues(true);
                if (scrollState != ScrollState.None)
                    ScrollTo(scrollState);
            }
        }

        private bool Redrawable2
        {
            get { return redrawable; }
            set
            {
                redrawable = value;
                UpdateScrollValues(false);
                if (scrollState != ScrollState.None)
                    ScrollTo(scrollState);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LineCount
        {
            get
            {
                if (info.Length == 0)
                    return 0;

                LineInfo li = info.GetLast();
                if (li.Appendable && li.Length == 0)
                    return info.Length - 1;
                return info.Length;
            }
        }

        public Color SelectedBackColor { get { return selectedBackColor; } set { selectedBackColor = value; Redraw(); } }

        [Browsable(false)]
        [DefaultValue(-1)]
        public int SelectedIndex { get { return selectedIndex; } set { OnSelectedIndex(value); Redraw(); } }

        #region Paint
        protected override void OnPaint(PaintEventArgs e)
        {
            Brush brBC = new SolidBrush(this.BackColor);
            Brush brFC = new SolidBrush(this.ForeColor);

            if (this.DesignMode)
            {
                e.Graphics.FillRectangle(brBC, 0, 0, this.Size.Width, this.Size.Height);

                brBC.Dispose();
                brFC.Dispose();
                base.OnPaint(e);
                return;
            }

            BindToCall();

            int lineHeight = this.Font.Height;

            //Rectangle rcMainView = new Rectangle(0, 0, maxWidth, info.Length * lineHeight);
            Rectangle rcControl = new Rectangle(0, 0,
                this.Size.Width - (this.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarThumbHeight : 0) + 1,
                this.Size.Height - (this.HorizontalScroll.Visible ? SystemInformation.HorizontalScrollBarThumbWidth : 0) + 1
            );
            Rectangle rcVirtualView = new Rectangle(
                this.HorizontalScroll.Value,
                this.VerticalScroll.Value % lineHeight,
                rcControl.Width,
                rcControl.Height);
            RectangleF rcLine = new RectangleF(0, 0, maxWidth, lineHeight);

            int lineIndex = this.VerticalScroll.Value / lineHeight;
            int lineCount = Math.Min(rcVirtualView.Height / lineHeight + 2, info.Length - lineIndex);

            string[] saText = new string[0];
            LineInfo[] arLineInfo = new LineInfo[0];
            if (lineCount > 0)
            {
                int fileIndex = (int)info.Get(lineIndex).Index, fileLen = 0;
                arLineInfo = new LineInfo[lineCount];
                info.Get(lineIndex, arLineInfo, 0, lineCount);
                for (int i = 0; i < lineCount; i++)
                {
                    fileLen += arLineInfo[i].Length;
                }

                byte[] ba = new byte[fileLen];
                fsData.Position = fileIndex;
                fsData.Read(ba, 0, fileLen);
                saText = Encoding.Unicode.GetString(ba).Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                ba = null;//Dispose
            }

            rcLine.Offset(-rcVirtualView.X, -rcVirtualView.Y);

            Graphics gr = e.Graphics;

            gr.PageUnit = GraphicsUnit.Pixel;
            gr.TextRenderingHint = textRenderingHint;

            Dictionary<int, Brush> dicBrFore = new Dictionary<int, Brush>();
            Dictionary<int, Brush> dicBrBack = new Dictionary<int, Brush>();

            gr.FillRectangle(brBC, 0, 0, rcControl.Width, rcControl.Height);

            int selIndex = selectedIndex;
            if (selectedBackColor == Color.Transparent)
                selIndex = -1;

            //might be saText.Length is lineCount+1
            for (int i = 0; i < lineCount; i++)
            {
                int curLineIndex = lineIndex + i;

                if (i < saText.Length)
                {
                    if (!string.IsNullOrEmpty(saText[i]))
                    {
                        RectangleF rcLine2 = rcLine;

                        if (rcLine2.Width < rcControl.Width)
                            rcLine2.Width = rcControl.Width;

                        if (selIndex == curLineIndex)
                        {
                            Color c = selectedBackColor;
                            if (!dicBrBack.ContainsKey(c.ToArgb()))
                                dicBrBack.Add(c.ToArgb(), new SolidBrush(c));
                            gr.FillRectangle(dicBrBack[c.ToArgb()], rcLine2);
                        }
                        else if (arLineInfo[i].BackColor.A != 0)
                        {
                            Color c = arLineInfo[i].BackColor;
                            if (!dicBrBack.ContainsKey(c.ToArgb()))
                                dicBrBack.Add(c.ToArgb(), new SolidBrush(c));
                            gr.FillRectangle(dicBrBack[c.ToArgb()], rcLine2);
                        }


                        rcLine2 = rcLine;
                        rcLine2.Width = 0;
                        for (int j = 0; j < arLineInfo[i].PartsCount; j++)
                        {
                            var item = arLineInfo[i][j];
                            rcLine2.Width = (item.WidthOnDraw);

                            if (item.BackColor.A != 0 && selIndex != curLineIndex)
                            {
                                if (!dicBrBack.ContainsKey(item.BackColor.ToArgb()))
                                    dicBrBack.Add(item.BackColor.ToArgb(), new SolidBrush(item.BackColor));
                                gr.FillRectangle(dicBrBack[item.BackColor.ToArgb()], rcLine2);
                            }

                            if (item.ForeColor.A == 0)
                            {
                                gr.DrawString(saText[i].Substring(item.StartString, item.LengthString),
                                    this.Font, brFC, rcLine2, stringFormat);
                            }
                            else
                            {
                                if (!dicBrFore.ContainsKey(item.ForeColor.ToArgb()))
                                    dicBrFore.Add(item.ForeColor.ToArgb(), new SolidBrush(item.ForeColor));
                                gr.DrawString(saText[i].Substring(item.StartString, item.LengthString),
                                    this.Font, dicBrFore[item.ForeColor.ToArgb()], rcLine2, stringFormat);
                            }
                            rcLine2.Offset(item.WidthOnDraw, 0);
                        }
                    }
                }
                rcLine.Offset(0, lineHeight);
            }

            brBC.Dispose();
            brFC.Dispose();
            foreach (var key in dicBrFore.Keys)
            {
                dicBrFore[key].Dispose();
            }
            foreach (var key in dicBrBack.Keys)
            {
                dicBrBack[key].Dispose();
            }
            dicBrFore = null;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.DesignMode)
                base.OnPaintBackground(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Redraw();
        }
        #endregion

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                UpdateScrollValues(true);
            }
        }

        public override string Text
        {
            get
            {
                if (this.DesignMode)
                    return base.Text;
                else
                {
                    fsData.Position = 0;
                    byte[] ba = new byte[fsData.Length];
                    fsData.Read(ba, 0, (int)fsData.Length);
                    return Encoding.Unicode.GetString(ba);
                }
            }
            set
            {
                if (this.DesignMode)
                    base.Text = value;
                else
                {
                    info.Clear();
                    fsData.Close();
                    System.IO.File.Delete(filename);
                    fsData = File.Open(filename, FileMode.CreateNew, FileAccess.ReadWrite);
                    maxWidth = 0;

                    AppendText(value);
                }
            }
        }
        public void AppendText(string str)
        {
            AppendText(str, Color.Empty);
        }
        public void AppendText(string str, Color color)
        {
            AppendText(str, color, Color.Empty);
        }
        public void AppendText(string str, Color foreColor, Color backColor)
        {
            if (!string.IsNullOrEmpty(str))
            {
                StringBuilder sb = new StringBuilder(str);
                sb.Replace("\r\n", "\n");
                sb.Replace("\r", "\n");
                string[] sa = sb.ToString().Split('\n');
                if (sa.Length > 0)
                {
                    using (var gr = this.CreateGraphics())
                    {
                        gr.PageUnit = GraphicsUnit.Pixel;
                        gr.TextRenderingHint = textRenderingHint;

                        byte[] ba = null;

                        fsData.Position = fsData.Length;
                        LineInfo[] li = new LineInfo[sa.Length];
                        for (int i = 0; i < sa.Length - 1; i++)
                        {
                            li[i] = new LineInfo
                            {
                                Index = fsData.Position,
                                Appendable = false
                            };

                            str = sa[i] + Environment.NewLine;
                            ba = Encoding.Unicode.GetBytes(str);
                            li[i].Add(ba.Length, sa[i].Length,
                                foreColor.IsEmpty ? defaultColor : foreColor,
                                backColor.IsEmpty ? Color.Transparent : backColor,
                                gr.MeasureString(sa[i], this.Font, 0, stringFormat).Width);
                            fsData.Write(ba, 0, ba.Length);

                            if (maxWidth < (int)Math.Ceiling(li[i].WidthOnDraw))
                            {
                                maxWidth = (int)Math.Ceiling(li[i].WidthOnDraw);
                            }
                        }

                        li[sa.Length - 1] = new LineInfo
                        {
                            Index = fsData.Position,
                            Appendable = true
                        };

                        str = sa[sa.Length - 1];
                        ba = Encoding.Unicode.GetBytes(str);
                        li[sa.Length - 1].Add(ba.Length, sa[sa.Length - 1].Length,
                            foreColor.IsEmpty ? defaultColor : foreColor,
                            backColor.IsEmpty ? Color.Transparent : backColor,
                            gr.MeasureString(sa[sa.Length - 1], this.Font, 0, stringFormat).Width);
                        fsData.Write(ba, 0, ba.Length);

                        if (maxWidth < (int)Math.Ceiling(li[sa.Length - 1].WidthOnDraw))
                        {
                            maxWidth = (int)Math.Ceiling(li[sa.Length - 1].WidthOnDraw);
                        }

                        if (info.Length == 0)
                        {
                            info.WriteAppend(li);
                        }
                        else
                        {
                            var last = info.GetLast();
                            if (last.Appendable == true)
                            {
                                for (int i = 0; i < li[0].PartsCount; i++)
                                {
                                    var item = li[0][i];
                                    last.Add(item.LengthByte, item.LengthString,
                                        item.ForeColor, item.BackColor,
                                        item.WidthOnDraw);
                                }
                                last.Appendable = li[0].Appendable;
                                fsData.Position = last.Index;
                                byte[] ba2 = new byte[last.Length];
                                fsData.Read(ba2, 0, last.Length);
                                if (li.Length > 1)
                                {
                                    LineInfo[] li2 = new LineInfo[li.Length - 1];
                                    Array.Copy(li, 1, li2, 0, li.Length - 1);
                                    info.WriteAppend(li2);
                                }

                                if (maxWidth < (int)Math.Ceiling(last.WidthOnDraw))
                                {
                                    maxWidth = (int)Math.Ceiling(last.WidthOnDraw);
                                }
                            }
                            else
                            {
                                info.WriteAppend(li);
                            }
                        }
                    }
                }
            }

            UpdateScrollValues(false);
        }

        private void UpdateScrollValues(bool updateMax)
        {
            if (!redrawable)
                return;

            if (updateMax)
            {
                maxWidth = 0;

                LineInfo[] li = new LineInfo[info.Growup];
                for (int i = 0; i < info.Length; i += info.Growup)
                {
                    int k = Math.Min(info.Length - i, info.Growup);
                    info.Get(i, li, 0, k);

                    int j, len = 0;
                    for (j = 0; j < k; j++)
                        len += li[j].Length;
                    fsData.Position = li[0].Index;

                    byte[] ba = new byte[len];
                    fsData.Read(ba, 0, len);
                    string[] sa = Encoding.Unicode.GetString(ba).Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                    using (var gr = this.CreateGraphics())
                    {
                        gr.PageUnit = GraphicsUnit.Pixel;
                        gr.TextRenderingHint = textRenderingHint;

                        for (j = 0; j < k; j++)
                        {
                            li[j].ResetWidthOnDraw();
                            for (int q = 0; q < li[j].PartsCount; q++)
                            {
                                var item = li[j][q];
                                li[j].SetWidthOnDraw(q,
                                    gr.MeasureString(sa[j].Substring(item.StartString, item.LengthString), this.Font, 0, stringFormat).Width);
                            }
                            if (maxWidth < (int)Math.Ceiling(li[j].WidthOnDraw))
                            {
                                maxWidth = (int)Math.Ceiling(li[j].WidthOnDraw);
                            }
                        }
                    }
                }

                this.VerticalScroll.SmallChange = this.Font.Height;
            }

            int maxHeight = info.Length * this.Font.Height;

            this.AutoScrollMinSize = new Size(Math.Max(maxWidth, 10), Math.Max(maxHeight, 10));

            Redraw();
        }

        private void SetVerticalScrollValue(int value)
        {
            //Reset Scroll value for apply
            this.VerticalScroll.Value = value;
            this.VerticalScroll.Value = value;
        }

        private void Redraw()
        {
            if (!redrawable)
                return;

            Invalidate(new Rectangle(new Point(0, 0), this.Size));
        }

        public void SaveTextToFile(string filename)
        {
            fsData.Close();
            if (File.Exists(filename))
                File.Delete(filename);
            File.Copy(this.filename, filename);
            fsData = File.Open(this.filename, FileMode.Open, FileAccess.ReadWrite);
        }

        #region Scroll
        public void ScrollToEnd()
        {
            if (!redrawable)
            {
                scrollState = ScrollState.End;
                return;
            }

            ScrollTo(ScrollState.End);
        }

        public void ScrollToBegin()
        {
            if (!redrawable)
            {
                scrollState = ScrollState.Begin;
                return;
            }

            ScrollTo(ScrollState.Begin);
        }

        public void ScrollToSelected()
        {
            if (!redrawable)
            {
                scrollState = ScrollState.Selected;
                return;
            }

            ScrollTo(ScrollState.Selected);
        }

        private void ScrollTo(ScrollState state)
        {
            if (!redrawable)
            {
                scrollState = ScrollState.Selected;
                return;
            }

            switch (state)
            {
                case ScrollState.Begin:
                    SetVerticalScrollValue(0);
                    break;
                case ScrollState.End:
                    if (info.Length > 0)
                    {
                        int max = info.Length * this.Font.Height - 1;
                        max += (this.HorizontalScroll.Visible ? SystemInformation.HorizontalScrollBarThumbWidth : 0);
                        max -= this.Size.Height;
                        if (max > 0)
                            SetVerticalScrollValue(max);
                    }
                    break;
                case ScrollState.Selected:
                    if (selectedIndex != -1)
                    {
                        int lineHeight = this.Font.Height;

                        Rectangle rcControl = new Rectangle(0, 0,
                            this.Size.Width - (this.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarThumbHeight : 0) + 1,
                            this.Size.Height - (this.HorizontalScroll.Visible ? SystemInformation.HorizontalScrollBarThumbWidth : 0) + 1
                        );
                        Rectangle rcVirtualView = new Rectangle(
                            this.HorizontalScroll.Value,
                            this.VerticalScroll.Value % lineHeight,
                            rcControl.Width,
                            rcControl.Height);
                        RectangleF rcLine = new RectangleF(0, 0, maxWidth, lineHeight);

                        int lineIndex = this.VerticalScroll.Value / lineHeight;
                        int lineCount = Math.Min(rcVirtualView.Height / lineHeight, info.Length - lineIndex);

                        if (rcVirtualView.Y > 0)
                        {
                            lineIndex++;
                        }
                        lineCount--;

                        if (selectedIndex < lineIndex || selectedIndex >= lineIndex + lineCount)
                        {
                            int max = info.Length * this.Font.Height - 1;
                            max += (this.HorizontalScroll.Visible ? SystemInformation.HorizontalScrollBarThumbWidth : 0);
                            max -= this.Size.Height;

                            int inx = lineHeight * selectedIndex - 1;

                            if (this.VerticalScroll.Value < inx)
                                inx -= lineCount * lineHeight;

                            if (inx > max)
                                inx = max;
                            if (inx < 0)
                                inx = 0;

                            SetVerticalScrollValue(inx);
                        }
                    }
                    break;
            }

            scrollState = ScrollState.None;
        }
        #endregion

        public string[] GetLines(int startLineIndex, int countLines)
        {
            List<string> lst = new List<string>();

            if (startLineIndex < 0)
                startLineIndex = 0;

            int i, j;
            countLines = Math.Min(countLines, LineCount - startLineIndex);
            if (countLines > 0)
            {
                j = 0;

                countLines += startLineIndex;
                for (i = startLineIndex; i < countLines; i++)
                {
                    j += info.Get(i).Length;
                }
                j -= Environment.NewLine.Length * 2 /* Is Unicode */;

                fsData.Position = info.Get(startLineIndex).Index;
                byte[] ba = new byte[j];
                fsData.Read(ba, 0, j);

                lst.AddRange(
                    Encoding.Unicode.GetString(ba).Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                    );
            }

            return lst.ToArray();
        }

        #region Select
        public event EventHandler SelectedIndexChanged;

        private void OnSelectedIndex(int selectedIndex)
        {
            if (selectedIndex < LineCount)
                this.selectedIndex = selectedIndex;
            else
                this.selectedIndex = -1;

            SelectedIndexChanged?.Invoke(this, new EventArgs());
        }

        private void LargeTextViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & System.Windows.Forms.MouseButtons.Left) > 0)
            {
                int lineHeight = this.Font.Height;

                Rectangle rcControl = new Rectangle(0, 0,
                    this.Size.Width - (this.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarThumbHeight : 0) + 1,
                    this.Size.Height - (this.HorizontalScroll.Visible ? SystemInformation.HorizontalScrollBarThumbWidth : 0) + 1
                );
                Rectangle rcVirtualView = new Rectangle(
                    this.HorizontalScroll.Value,
                    this.VerticalScroll.Value % lineHeight,
                    rcControl.Width,
                    rcControl.Height);
                RectangleF rcLine = new RectangleF(0, 0, maxWidth, lineHeight);

                int lineIndex = this.VerticalScroll.Value / lineHeight;
                int lineCount = Math.Min(rcVirtualView.Height / lineHeight + 2, info.Length - lineIndex);

                int y = e.Y + rcVirtualView.Y;
                int selIndex = -1;
                if (y >= 0)
                {
                    selIndex = y / lineHeight;
                }
                else
                {
                    selIndex = -1 + (y + lineHeight) / lineHeight;
                }

                selIndex += lineIndex;
                if (selIndex < LineCount)
                {
                    OnSelectedIndex(selIndex);
                    Redraw();
                }
            }
        }
        #endregion

        #region Key Control
        private void LargeTextViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (ControlByKey(e))
                return;

            if (selectedBackColor.A == 0)
                return;

            int selIndex, old;
            selIndex = old = selectedIndex;

            if (e.KeyCode == Keys.Up)
            {
                if (selectedIndex == -1)
                {
                    selIndex = LineCount - 1;
                }
                else
                {
                    selIndex = selectedIndex - 1;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (selectedIndex == -1)
                {
                    selIndex = 0;
                }
                else
                {
                    selIndex = selectedIndex + 1;
                }
            }

            if (selIndex < LineCount && selIndex >= 0)
            {
                OnSelectedIndex(selIndex);
            }

            if (old != selectedIndex)
            {
                ScrollToSelected();

                Redraw();
            }
        }

        private bool ControlByKey(KeyEventArgs e)
        {
            int viewIndex = -1;

            if (e.KeyCode == Keys.Home && e.Control) { viewIndex = 0; }
            else if (e.KeyCode == Keys.End && e.Control) { viewIndex = 1; }
            else if (e.KeyCode == Keys.PageUp) { viewIndex = 2; }
            else if (e.KeyCode == Keys.PageDown) { viewIndex = 3; }

            if (viewIndex != -1)
            {
                int lineHeight = this.Font.Height;

                int max = info.Length * this.Font.Height - 1;
                max += (this.HorizontalScroll.Visible ? SystemInformation.HorizontalScrollBarThumbWidth : 0);
                max -= this.Size.Height;

                switch (viewIndex)
                {
                    case 0:
                        viewIndex = 0;
                        break;
                    case 1:
                        viewIndex = max;
                        break;
                    case 2:
                        viewIndex = this.VerticalScroll.Value - this.Size.Height
                            + (this.HorizontalScroll.Visible ? SystemInformation.HorizontalScrollBarThumbWidth : 0);
                        viewIndex = Math.Max(0, viewIndex);
                        viewIndex = Math.Min(max, viewIndex);
                        break;
                    case 3:
                        viewIndex = this.VerticalScroll.Value + this.Size.Height
                            - (this.HorizontalScroll.Visible ? SystemInformation.HorizontalScrollBarThumbWidth : 0);
                        viewIndex = Math.Max(0, viewIndex);
                        viewIndex = Math.Min(max, viewIndex);
                        break;
                }

                if (viewIndex != this.VerticalScroll.Value)
                {
                    SetVerticalScrollValue(viewIndex);

                    Redraw();
                }
                return true;
            }

            return false;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down ||
                keyData == Keys.Home || keyData == Keys.End ||
                keyData == Keys.PageUp || keyData == Keys.PageDown)
                return true;
            return false;
        }
        #endregion

        #region Bind to
        private void BindToCall()
        {
            if (oldVerticalScrollValue != this.VerticalScroll.Value ||
                oldHorizontalScrollValue != this.HorizontalScroll.Value)
            {
                oldVerticalScrollValue = this.VerticalScroll.Value;
                oldHorizontalScrollValue = this.HorizontalScroll.Value;
                OnViewportChanged();
            }
        }

        public event EventHandler ViewportChanged;
        private void OnViewportChanged()
        {
            ViewportChanged?.Invoke(this, new EventArgs());
        }

        public void UpdateViewportFrom(LargeTextViewer ltv)
        {
            if (ltv != null)
            {
                bool change = false;
                if (ltv.VerticalScroll.Value <= this.VerticalScroll.Maximum && ltv.VerticalScroll.Value != this.VerticalScroll.Value)
                    change = true;
                if (ltv.HorizontalScroll.Value <= this.HorizontalScroll.Maximum && ltv.HorizontalScroll.Value != this.HorizontalScroll.Value)
                    change = true;
                if (!change)
                    return;

                bool rd = this.Redrawable2;
                if (rd)
                    this.Redrawable2 = false;
                if (ltv.VerticalScroll.Value <= this.VerticalScroll.Maximum && ltv.VerticalScroll.Value != this.VerticalScroll.Value)
                {
                    this.VerticalScroll.Value = ltv.VerticalScroll.Value;
                    this.VerticalScroll.Value = ltv.VerticalScroll.Value;
                }
                if (ltv.HorizontalScroll.Value <= this.HorizontalScroll.Maximum && ltv.HorizontalScroll.Value != this.HorizontalScroll.Value)
                {
                    this.HorizontalScroll.Value = ltv.HorizontalScroll.Value;
                    this.HorizontalScroll.Value = ltv.HorizontalScroll.Value;
                }
                if (rd)
                    this.Redrawable2 = true;
            }
        }
        #endregion
    }
}
