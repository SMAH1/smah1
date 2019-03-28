using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using SMAH1.Attributes;
using SMAH1.ExtensionMethod;
using SMAH1.Forms.Chart.Component.Axile;
using SMAH1.Forms.Chart.Configuration;
using SMAH1.Forms.PropertyGridComponent;
using SMAH1.BindingData;

namespace SMAH1.Forms.Chart.Component.BarComponent
{
    [DesignerCategory("SMAH1")]
    [ToolboxBitmap(typeof(Bar), "Bar.bmp")]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public class Bar : AxileBase
    {
        #region Fields

        private int nWidthBar;
        private int nWidthBorderOfBarLine;
        private int nGapBarOfColumn;
        private int nGapColumns;
        private Color colBorderOfBar;

        //Use in Events
        private bool bMouseEnterBar;
        private ItemDrawInfo itemLastBarEnter;
        private List<ItemDrawInfo> barLocation;

        #endregion

        #region Property

        [Browsable(true)]
        [Description("Color of border of bar")]
        [Category("Custom")]
        [SaveLoad]
        public Color BorderOfBarColor
        {
            get { return colBorderOfBar; }
            set { colBorderOfBar = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Width of each bar")]
        [Category("Custom")]
        [DefaultValue(10)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(4, int.MaxValue)]
        public int WidthBar
        {
            get { return nWidthBar; }
            set { nWidthBar = (value > 4 ? value : 4); RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Width of border line of bar")]
        [Category("Custom")]
        [DefaultValue(2)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(0, int.MaxValue)]
        public int WidthBorderOfBarLine
        {
            get { return nWidthBorderOfBarLine; }
            set { nWidthBorderOfBarLine = (value > 0 ? value : 0); RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Gap between of bars of each column")]
        [Category("Custom")]
        [DefaultValue(4)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(0, int.MaxValue)]
        public int GapBarOfColumn
        {
            get { return nGapBarOfColumn; }
            set { nGapBarOfColumn = (value > 0 ? value : 0); RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Gap between of group bars of columns")]
        [Category("Custom")]
        [DefaultValue(8)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(1, int.MaxValue)]
        public int GapColumns
        {
            get { return nGapColumns; }
            set { nGapColumns = (value > 1 ? value : 1); RedrawChart(); }
        }

        #region override
        [Browsable(false)]
        [Description("Second DataMember (if defined) draw with independent zero in Y-Axile")]
        public override bool SecondDataMemberIndependentZero
        {
            get { return base.SecondDataMemberIndependentZero; }
            set { base.SecondDataMemberIndependentZero = false; }
        }
        #endregion

        #endregion

        #region Method main
        public Bar()
        {
            //Initalize variables
            nWidthBar = 10;
            nWidthBorderOfBarLine = 2;
            nGapBarOfColumn = 4;
            nGapColumns = 8;
            colBorderOfBar = SystemColors.WindowText;
            bMouseEnterBar = false;
            barLocation = new List<ItemDrawInfo>(); //For not throw exception,If mouse move event fire
            itemLastBarEnter = new ItemDrawInfo();
            SecondDataMemberIndependentZero = false;
        }

        public override string Guid
        {
            get { return "bb5fe4ea-aed0-46eb-84f4-a1ebbdef79bc"; }
        }
        #endregion

        #region Paint of bar

        protected override void InternalPaintStart(Graphics grChart, IBindingData data)
        {
            barLocation.Clear();
        }

        protected override void InternalPaintFinish(Graphics grChart, IBindingData data)
        { }

        protected override void InternalPaintChart(Graphics grChart,
                    IBindingData data, Rectangle rcArea,
                    ref double xAxisBetweenTextSpace, ref double xAxisTextWidth
                    )
        {
            bool bR2L = Parent.Chart.IsRTL();

            Pen penLine = new Pen(colBorderOfBar, nWidthBorderOfBarLine);

            //Draw bars
            if ((int)rcChartDrawArea.Height > 0 && (int)rcChartDrawArea.Width > 0)
            {
                int xDraw = nGapColumns;

                double maxminHeight = (double)(rcChartDrawArea.Height / (MaxInTopOfChartArea - MinInBottomOfChartArea));

                double xScale = 1;
                if (SizingModeLabel == SizingModeLabel.Fit ||
                    SizingModeLabel == SizingModeLabel.FitIfLarge)
                {
                    int x = xDraw;
                    x += data.ColumnCount * data.RowCount * nWidthBar;
                    x += nGapBarOfColumn * (data.RowCount - 1) * data.ColumnCount;
                    x += nGapColumns * (data.ColumnCount - 1);
                    x += nGapBarOfColumn;   //For space end Axis and last bar

                    xScale = rcChartDrawArea.Width / (double)x;
                }

                if (SizingModeLabel == SizingModeLabel.FitIfLarge && xScale > 1)
                    xScale = 1;

                xAxisBetweenTextSpace = nGapColumns * xScale;
                xAxisTextWidth = data.RowCount * nWidthBar +
                    (data.RowCount - 1) * nGapBarOfColumn;
                xAxisTextWidth *= xScale;

                Color[] colBarInner = Parent.Chart.Colors;
                Brush[] brBar = new Brush[colBarInner.Length];
                for (int i = 0; i < colBarInner.Length; i++)
                    brBar[i] = new SolidBrush(colBarInner[i]);

                int nWidthBarWithScale = (int)(nWidthBar * xScale);

                for (int colIndex = 0; colIndex < data.ColumnCount; colIndex++)
                {
                    if (!drawAllDataField)
                        break;

                    #region Draw bars
                    int selectedBarColor = 0;
                    for (int rowIndex = 0; rowIndex < data.RowCount; rowIndex++)
                    {
                        double d = data.ValueDouble(rowIndex, colIndex);
                        bool isOverflow = false;
                        if (d > 0 && d > MaxInTopOfChartArea)
                        {
                            isOverflow = true;
                            d = MaxInTopOfChartArea;
                        }
                        if (d < 0 && d < MinInBottomOfChartArea)
                        {
                            isOverflow = true;
                            d = MinInBottomOfChartArea;
                        }
                        int yMustDraw = (int)(d * maxminHeight);
                        if (yMustDraw == 0)
                            yMustDraw = nWidthBorderOfBarLine;

                        Rectangle rcDraw;

                        int xDraw2 = 0;
                        if (bR2L)
                        {
                            xDraw2 = (int)rcChartDrawArea.Right - (int)(xDraw * xScale) - nWidthBarWithScale;
                        }
                        else
                        {
                            xDraw2 = (int)(xDraw * xScale) + (int)rcChartDrawArea.Left;
                        }

                        if (yMustDraw >= 0)
                        {
                            rcDraw = new Rectangle(
                                xDraw2, AxisFromTop - yMustDraw,
                                nWidthBarWithScale, yMustDraw);
                        }
                        else
                        {
                            rcDraw = new Rectangle(
                                xDraw2, AxisFromTop,
                                nWidthBarWithScale, -yMustDraw);
                        }

                        if (rcChartDrawArea.Contains(rcDraw))
                        {
                            bool bValidValue = data.Valid(rowIndex, colIndex);
                            if (bValidValue)
                                grChart.FillRectangle(brBar[selectedBarColor], rcDraw);
                            ItemDrawInfo item = new ItemDrawInfo
                            {
                                Rect = rcDraw,
                                IsOverflow = isOverflow,
                                ColIndex = colIndex,
                                RowIndex = rowIndex
                            };
                            barLocation.Add(item);
                            if (bValidValue)
                            {
                                if (nWidthBorderOfBarLine > 0 || d == 0)
                                    grChart.DrawRectangle(penLine, rcDraw);
                                if (isOverflow && rcDraw.Height > nWidthBorderOfBarLine * 2)
                                {
                                    if (d > 0)
                                        grChart.DrawLine(penLine,
                                            rcDraw.Left, rcDraw.Top - nWidthBorderOfBarLine,
                                            rcDraw.Right, rcDraw.Top - nWidthBorderOfBarLine);
                                    else if (d < 0)
                                        grChart.DrawLine(penLine,
                                            rcDraw.Left, rcDraw.Bottom + nWidthBorderOfBarLine,
                                            rcDraw.Right, rcDraw.Bottom + nWidthBorderOfBarLine);
                                }
                            }
                        }
                        else
                        {
                            drawAllDataField = false;
                            break;
                        }
                        xDraw += (nWidthBar + nGapBarOfColumn);

                        selectedBarColor++;
                        selectedBarColor %= brBar.Length;
                    }
                    #endregion

                    xDraw -= nGapBarOfColumn;
                    xDraw += nGapColumns;
                }
                for (int i = 0; i < colBarInner.Length; i++)
                    brBar[i].Dispose();
            }

            penLine.Dispose();
        }
        #endregion

        #region override abstract

        public override BaseChartConfiguration CreateChartConfiguration(
                ChartConfigurationForm form)
        {
            if (Parent == null)
                throw new ArgumentException("Component is unattached any chart!");

            return new Configuration.BarChartConfiguration(Parent.Chart, form);
        }

        #endregion

        #region Nearest
        public void NearestBar(Point point, out int rowIndex, out int colIndex)
        {
            rowIndex = colIndex = -1;

            if (barLocation.Count != 0)
            {
                ItemDrawInfo l = barLocation[0];
                ItemDrawInfo g = barLocation[barLocation.Count - 1];
                int xl = l.Rect.Left + l.Rect.Width / 2;
                int xg = g.Rect.Left + g.Rect.Width / 2;

                bool bR2L = Parent.Chart.IsRTL();
                if (bR2L)
                {
                    ItemDrawInfo e = l;
                    l = g;
                    g = e;

                    int xe = xl;
                    xl = xg;
                    xg = xe;

                }

                foreach (ItemDrawInfo idi in barLocation)
                {
                    int x = idi.Rect.Left + idi.Rect.Width / 2;
                    if (x > xl && x <= point.X)
                    {
                        l = idi;
                        xl = x;
                    }
                    if (x < xg && x >= point.X)
                    {
                        g = idi;
                        xg = x;
                    }
                }

                if (xl == xg)
                {
                    rowIndex = l.RowIndex;
                    colIndex = l.ColIndex;
                }
                else
                {
                    int x1 = Math.Abs(xl - point.X);
                    int x2 = Math.Abs(xg - point.X);

                    if (x1 > x2)
                    {
                        rowIndex = g.RowIndex;
                        colIndex = g.ColIndex;
                    }
                    else
                    {
                        rowIndex = l.RowIndex;
                        colIndex = l.ColIndex;
                    }
                }
            }
        }
        #endregion

        #region Initialize & Terminate
        protected override void Initialize()
        {
            base.Initialize();
            Parent.Chart.MouseLeave += new EventHandler(Chart_MouseLeave);
            Parent.Chart.MouseMove += new MouseEventHandler(Chart_MouseMove);
        }
        protected override void Terminate()
        {
            base.Terminate();
            Parent.Chart.MouseLeave -= new EventHandler(Chart_MouseLeave);
            Parent.Chart.MouseMove -= new MouseEventHandler(Chart_MouseMove);
        }
        #endregion

        #region Chart Component Custom Events

        #region Mouse Enter Bar
        public delegate void MouseAndItemEventHandler(object sender, MouseAndItemEventArgs e);

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Chart")]
        [Description("Mouse enter the bar.")]
        public event MouseAndItemEventHandler MouseEnterBar;

        private void OnMouseEnterBar(int col, int row)
        {
            MouseEnterBar?.Invoke(this, new MouseAndItemEventArgs(col, row));
        }
        #endregion

        #region Mouse Leave Bar
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Chart")]
        [Description("Mouse leave the bar.")]
        public event MouseAndItemEventHandler MouseLeaveBar;

        private void OnMouseLeaveBar(int col, int row)
        {
            MouseLeaveBar?.Invoke(this, new MouseAndItemEventArgs(col, row));
        }
        #endregion

        #endregion

        #region Get Events are Fired by chart
        private void Chart_MouseLeave(object sender, EventArgs e)
        {
            if (bMouseEnterBar)
            {
                bMouseEnterBar = false;
                OnMouseLeaveBar(itemLastBarEnter.ColIndex, itemLastBarEnter.RowIndex);
            }
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (rcChartDrawArea.Contains(e.Location))
            {
                //Bar enter exit
                if (bMouseEnterBar)
                    if (!itemLastBarEnter.Rect.Contains(e.Location))
                    {
                        bMouseEnterBar = false;
                        OnMouseLeaveBar(itemLastBarEnter.ColIndex, itemLastBarEnter.RowIndex);
                        itemLastBarEnter.ColIndex = itemLastBarEnter.RowIndex = -1;
                    }
                if (!bMouseEnterBar)
                {
                    foreach (ItemDrawInfo item in barLocation)
                    {
                        if (item.Rect.Contains(e.Location))
                        {
                            bMouseEnterBar = true;
                            itemLastBarEnter = item;
                            OnMouseEnterBar(itemLastBarEnter.ColIndex, itemLastBarEnter.RowIndex);
                            break;
                        }
                    }
                }
            }
            else
            {
                if (bMouseEnterBar)
                {
                    bMouseEnterBar = false;
                    OnMouseLeaveBar(itemLastBarEnter.ColIndex, itemLastBarEnter.RowIndex);
                }
            }
        }
        #endregion
    }
}
