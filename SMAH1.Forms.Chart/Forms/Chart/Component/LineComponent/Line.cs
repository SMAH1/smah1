using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using SMAH1.Attributes;
using SMAH1.Forms.Chart.Configuration;
using SMAH1.Forms.PropertyGridComponent;
using System.Drawing.Drawing2D;
using SMAH1.BindingData;
using SMAH1.Forms.Chart.Component.Axile;
using SMAH1.ExtensionMethod;

namespace SMAH1.Forms.Chart.Component.LineComponent
{
    [DesignerCategory("SMAH1")]
    [ToolboxBitmap(typeof(Line), "Line.bmp")]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public class Line : AxileBase
    {
        #region Fields

        private int nWidthColumn;
        private float nWidthLine;
        private int nDiagonalPoint;
        private LayoutMode layoutMode;
        private PointType pointType;
        private HorizontalGridMode verticalGrid;
        private bool bColorOverTransparency;

        //Use in Events
        private bool bMouseEnterPoint;
        private ItemPointInfo itemLastPointEnter;
        private List<ItemPointInfo> pointLocation;

        #endregion

        #region Property

        [Browsable(true)]
        [Description("Width of each Column")]
        [Category("Custom")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(4, int.MaxValue)]
        public int WidthColumns
        {
            get { return nWidthColumn; }
            set { nWidthColumn = (value > 4 ? value : 4); RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Width of line")]
        [Category("Custom")]
        [DefaultValue(2F)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericFloatUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForFloat(0.5F, 100F, 1, 0.1F)]
        public float WidthLine
        {
            get { return nWidthLine; }
            set { nWidthLine = (value > 0.5F ? value : 0.5F); RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Diagonal of point of each column")]
        [Category("Custom")]
        [DefaultValue(2)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(1, int.MaxValue)]
        public int DiagonalPoint
        {
            get { return nDiagonalPoint; }
            set { nDiagonalPoint = (value > 1 ? value : 1); RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Show line,point or both in chart")]
        [Category("Custom")]
        [DefaultValue(LayoutMode.LineAndPoint)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public LayoutMode Layout
        {
            get { return layoutMode; }
            set { layoutMode = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Point is circle or square")]
        [Category("Custom")]
        [DefaultValue(PointType.Circle)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public PointType PointKind
        {
            get { return pointType; }
            set { pointType = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Draw vertical grid on chart")]
        [DefaultValue(HorizontalGridMode.None)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public HorizontalGridMode VerticalGrid
        {
            get { return verticalGrid; }
            set { verticalGrid = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Draw column by scale")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public new bool ColumnScaling
        {
            get { return base.ColumnScaling; }
            set { base.ColumnScaling = value; }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Color of line and point Transparency")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public bool ColorOverTransparency
        {
            get { return bColorOverTransparency; }
            set { bColorOverTransparency = value; RedrawChart(); }
        }
        #endregion

        #region Method main
        public Line()
        {
            //Initalize variables
            nWidthColumn = 20;
            nWidthLine = 2F;
            nDiagonalPoint = 2;
            layoutMode = LayoutMode.LineAndPoint;
            pointType = PointType.Circle;
            bMouseEnterPoint = false;
            pointLocation = new List<ItemPointInfo>(); //For not throw exception,If mouse move event fire
            itemLastPointEnter = new ItemPointInfo();
            verticalGrid = HorizontalGridMode.None;
            bColorOverTransparency = false;
        }

        public override string Guid
        {
            get { return "937c88b0-304d-469c-ac5c-d625fd4950cd"; }
        }
        #endregion

        #region Paint of lines and points

        protected override void InternalPaintStart(Graphics grChart, IBindingData data)
        {
            pointLocation = new List<ItemPointInfo>();
        }

        protected override void InternalPaintFinish(Graphics grChart, IBindingData data)
        {
            //TODO : active VerticalGrid in BackOfData
            if (this.VerticalGrid != HorizontalGridMode.None)
            {
                Pen penGrid = new Pen(base.GridColor, 1);
                AxileBase.SetDashStyle(penGrid, this.GridDashStyle);

                int wBegin = (int)this.DrawArea.Top;
                int wEnd = (int)this.DrawArea.Bottom;

                foreach (AxileLabelText dt in LabelsX)
                {
                    ItemPointInfo ipi = new ItemPointInfo
                    {
                        ColIndex = -1
                    };

                    foreach (ItemPointInfo ipi2 in pointLocation)
                    {
                        if (ipi2.ColIndex == dt.ColumnIndex)
                        {
                            ipi = ipi2;
                            break;
                        }
                    }

                    if (ipi.ColIndex != -1)
                    {
                        int x = (int)(ipi.Center.X);
                        grChart.DrawLine(penGrid, x, wBegin, x, wEnd);
                    }
                    else
                    {
                        grChart.FillRectangle(Brushes.DarkKhaki, dt.Rectangle);
                    }
                }

                penGrid.Dispose();
            }
        }

        protected override void InternalPaintChart(Graphics grChart,
                    IBindingData data, Rectangle rcArea,
                    ref double xAxisBetweenTextSpace, ref double xAxisTextWidth
                    )
        {
            bool bR2L = Parent.Chart.IsRTL();

            //Draw lines and points
            if ((int)rcChartDrawArea.Height > 0 && (int)rcChartDrawArea.Width > 0)
            {
                double maxminHeight = (double)(rcChartDrawArea.Height / (MaxInTopOfChartArea - MinInBottomOfChartArea));
                double maxOfValueInX = data.ColumnValue(data.ColumnCount - 1);   //Use in ColumnScaling mode

                double xScale = 1;
                if (!ColumnScaling)
                {
                    if (SizingModeLabel == SizingModeLabel.Fit ||
                        SizingModeLabel == SizingModeLabel.FitIfLarge)
                    {
                        double x = 0;
                        x += data.ColumnCount * nWidthColumn;

                        xScale = rcChartDrawArea.Width / x;
                    }

                    if (SizingModeLabel == SizingModeLabel.FitIfLarge && xScale > 1)
                        xScale = 1;

                    xAxisBetweenTextSpace = 0;
                    xAxisTextWidth = nWidthColumn * xScale;
                }
                else
                {
                    double x = 0;

                    x = maxOfValueInX * nWidthColumn;
                    xScale = rcChartDrawArea.Width / x;
                    xAxisBetweenTextSpace = 0;
                    xAxisTextWidth = nWidthColumn * xScale;
                }

                Color[] colLineInner = new Color[Parent.Chart.Colors.Length];

                for (int i = 0; i < colLineInner.Length; i++)
                    colLineInner[i] = Parent.Chart.Colors[i];

                if (ColorOverTransparency && data.RowCount > 1)
                {
                    for (int i = 0; i < colLineInner.Length && i < data.RowCount; i++)
                    {
                        int minTransparency = 128;
                        if (data.RowCount > 3)
                            minTransparency = 64;
                        double def = 255 - minTransparency;
                        def /= (data.RowCount - 1);
                        double ri = 255 - def * i;
                        colLineInner[i] = Color.FromArgb((byte)ri, colLineInner[i].R, colLineInner[i].G, colLineInner[i].B);
                    }
                }

                Brush[] brPoint = new Brush[colLineInner.Length];
                Pen[] penLine = new Pen[colLineInner.Length];
                for (int i = 0; i < colLineInner.Length; i++)
                {
                    brPoint[i] = new SolidBrush(colLineInner[i]);
                    penLine[i] = new Pen(colLineInner[i], nWidthLine)
                    {
                        LineJoin = LineJoin.Bevel   //If use default (Miter) may be infringe
                    };
                }

                double nWidthColumnWithScale = (nWidthColumn * xScale);

                RectangleF rcChartDrawArea2 = new RectangleF(
                    rcChartDrawArea.Left - nDiagonalPoint,
                    rcChartDrawArea.Top - nDiagonalPoint,
                    rcChartDrawArea.Width + nDiagonalPoint * 2,
                    rcChartDrawArea.Height + nDiagonalPoint * 2
                    );

                for (int rowIndex = 0; rowIndex < data.RowCount; rowIndex++)
                {
                    drawAllDataField = true;
                    double xDraw = 0;
                    int curConntOfPointLocation = pointLocation.Count;
                    List<PointF> lst = new List<PointF>();
                    List<List<PointF>> lstLines = new List<List<PointF>>();

                    int columnCount = data.ColumnCount;
                    int columnCount2 = columnCount / 2;
                    for (int colIndex = 0; colIndex < columnCount; colIndex++)
                    {
                        if (!drawAllDataField)
                            break;

                        #region Calculate points

                        if (ColumnScaling)
                            xDraw = data.ColumnValue(colIndex) * nWidthColumnWithScale + xAxisBetweenTextSpace;

                        double d = data.ValueDouble(rowIndex, colIndex);
                        bool isOverflow = false;
                        double yDrawCenterOfPoint = ((d - MinInBottomOfChartArea) * maxminHeight);
                        if (d > MaxInTopOfChartArea)
                        {
                            isOverflow = true;
                            d = MaxInTopOfChartArea;
                            yDrawCenterOfPoint = ((d - MinInBottomOfChartArea) * maxminHeight);

                        }
                        if (d < MinInBottomOfChartArea)
                        {
                            isOverflow = true;
                            d = MinInBottomOfChartArea;
                            yDrawCenterOfPoint = ((d - MinInBottomOfChartArea) * maxminHeight);

                        }
                        yDrawCenterOfPoint = rcChartDrawArea.Bottom - yDrawCenterOfPoint;

                        RectangleF rcPoint;

                        double xDrawCenterOfPoint = 0;
                        if (bR2L)
                        {
                            xDrawCenterOfPoint = rcChartDrawArea.Right - xDraw;
                            if (!ColumnScaling)//In ColumnScaling is ignore
                                xDrawCenterOfPoint -= nWidthColumnWithScale / 2;
                        }
                        else
                        {
                            xDrawCenterOfPoint = xDraw + rcChartDrawArea.Left;
                            if (!ColumnScaling)//In ColumnScaling is ignore
                                xDrawCenterOfPoint += nWidthColumnWithScale / 2;
                        }

                        rcPoint = new RectangleF(
                            (float)xDrawCenterOfPoint - nDiagonalPoint,
                            (float)yDrawCenterOfPoint - nDiagonalPoint,
                            nDiagonalPoint * 2,
                            nDiagonalPoint * 2);
                        PointF center = new PointF(
                                    (float)xDrawCenterOfPoint,
                                    (float)yDrawCenterOfPoint);

                        if (rcChartDrawArea2.Contains(center))
                        {
                            ItemPointInfo item = new ItemPointInfo
                            {
                                Rect = rcPoint,
                                Center = center
                            };
                            bool bValidValue = data.Valid(rowIndex, colIndex);
                            if (bValidValue)
                                lst.Add(item.Center);
                            else
                            {
                                if (lst.Count > 0)
                                {
                                    lstLines.Add(lst);
                                    lst = new List<PointF>();
                                }
                            }
                            item.IsOverflow = isOverflow;
                            item.ColIndex = colIndex;
                            item.RowIndex = rowIndex;
                            pointLocation.Add(item);
                        }
                        else
                        {
                            if (pointLocation.Count > 0 &&
                                curConntOfPointLocation != pointLocation.Count)
                            {//If Point is Out,Draw line that is seen
                                ItemPointInfo item = pointLocation[pointLocation.Count - 1];

                                bool bValidValue = data.Valid(rowIndex, colIndex);
                                if (bValidValue)
                                {
                                    PointF centerBeginPaint = new PointF();
                                    float m = (center.X - item.Center.X);
                                    if (m == 0f)
                                    {
                                        centerBeginPaint.X = center.X;
                                        //Exactly : center.Y != item.center.Y
                                        if (center.Y < item.Center.Y)
                                            centerBeginPaint.Y = rcChartDrawArea2.Bottom;
                                        else
                                            centerBeginPaint.Y = rcChartDrawArea2.Top;
                                    }
                                    else
                                    {
                                        float x = (bR2L ? rcChartDrawArea2.Left : rcChartDrawArea2.Right);
                                        m =
                                            (center.Y - item.Center.Y) /
                                            m;
                                        centerBeginPaint.X = x;
                                        centerBeginPaint.Y = m * (x - center.X) + center.Y;
                                    }
                                    lst.Add(centerBeginPaint);
                                }
                            }

                            drawAllDataField = false;
                            break;
                        }

                        if (!ColumnScaling)
                            xDraw += nWidthColumnWithScale;

                        #endregion
                    }

                    if (lst.Count > 0)
                    {
                        lstLines.Add(lst);
                        lst = null;
                    }

                    Graphics gr = grChart;

                    //Draw Lines
                    if (layoutMode != LayoutMode.Point)
                        foreach (List<PointF> lst2 in lstLines)
                            if (lst2.Count > 1)
                                gr.DrawLines(penLine[rowIndex % colLineInner.Length], lst2.ToArray());

                    //Draw Points
                    if (layoutMode != LayoutMode.Line)
                    {
                        for (int i = curConntOfPointLocation; i < pointLocation.Count; i++)
                        {
                            ItemPointInfo item = pointLocation[i];
                            bool bValidValue = data.Valid(item.RowIndex, item.ColIndex);
                            if (!bValidValue)
                                continue;   //No need Draw
                            int selectedLineColor = item.RowIndex % colLineInner.Length;
                            if (pointType == PointType.Square)
                                gr.FillRectangle(brPoint[selectedLineColor], item.Rect);
                            else if (pointType == PointType.Circle)
                                gr.FillEllipse(brPoint[selectedLineColor], item.Rect);
                        }
                    }
                }

                for (int i = 0; i < colLineInner.Length; i++)
                {
                    brPoint[i].Dispose();
                    penLine[i].Dispose();
                }
            }
        }
        #endregion

        #region override abstract
        public override BaseChartConfiguration CreateChartConfiguration(
                ChartConfigurationForm form)
        {
            if (Parent == null)
                throw new ArgumentException("Component is unattached any chart!");

            return new Configuration.LineChartConfiguration(Parent.Chart, form);
        }
        #endregion

        #region Nearest
        /// <summary>
        /// Find nearest column of existing columns for the defined point
        /// </summary>
        /// <param name="point">The point that we want nearest column</param>
        /// <returns>Index of column ( -1 for not found)</returns>
        public int NearestColumnIndex(Point point)
        {
            int colIndex = -1;

            if (pointLocation.Count != 0)
            {
                ItemPointInfo l = pointLocation[0];
                ItemPointInfo g = pointLocation[pointLocation.Count - 1];
                float xl = l.Center.X;
                float xg = g.Center.X;

                bool bR2L = Parent.Chart.IsRTL();
                if (bR2L)
                {
                    ItemPointInfo e = l;
                    l = g;
                    g = e;

                    float xe = xl;
                    xl = xg;
                    xg = xe;

                }

                foreach (ItemPointInfo ipi in pointLocation)
                {
                    float x = ipi.Center.X;
                    if (x > xl && x <= point.X)
                    {
                        l = ipi;
                        xl = x;
                    }
                    if (x < xg && x >= point.X)
                    {
                        g = ipi;
                        xg = x;
                    }
                }

                if (xl == xg)
                {
                    colIndex = l.ColIndex;
                }
                else
                {
                    float x1 = Math.Abs(xl - point.X);
                    float x2 = Math.Abs(xg - point.X);

                    if (x1 > x2)
                    {
                        colIndex = g.ColIndex;
                    }
                    else
                    {
                        colIndex = l.ColIndex;
                    }
                }
            }

            return colIndex;
        }

        /// <summary>
        /// Find nearest columns of existing columns for the defined point
        /// </summary>
        /// <param name="point">The point that we want nearest columns</param>
        /// <param name="columnBefor">Column befor of the point</param>
        /// <param name="columnAfter">Column after of the point</param>
        public void NearestColumnsIndex(Point point, out int columnBefor, out int columnAfter)
        {
            columnBefor = -1;
            columnAfter = -1;

            if (pointLocation.Count != 0)
            {
                ItemPointInfo l = pointLocation[0];
                ItemPointInfo g = pointLocation[pointLocation.Count - 1];
                float xl = l.Center.X;
                float xg = g.Center.X;

                bool bR2L = Parent.Chart.IsRTL();
                if (bR2L)
                {
                    ItemPointInfo e = l;
                    l = g;
                    g = e;

                    float xe = xl;
                    xl = xg;
                    xg = xe;

                }

                if (l.Center.X == point.X)
                {
                    columnBefor = l.ColIndex;
                    columnAfter = l.ColIndex;
                }
                else if (g.Center.X == point.X)
                {
                    columnBefor = g.ColIndex;
                    columnAfter = g.ColIndex;
                }
                else if (l.Center.X > point.X)
                {
                    columnBefor = -1;
                    columnAfter = l.ColIndex;
                }
                else if (g.Center.X < point.X)
                {
                    columnBefor = g.ColIndex;
                    columnAfter = -1;
                }
                else
                {
                    foreach (ItemPointInfo ipi in pointLocation)
                    {
                        float x = ipi.Center.X;
                        if (x > xl && x <= point.X)
                        {
                            l = ipi;
                            xl = x;
                        }
                        if (x < xg && x >= point.X)
                        {
                            g = ipi;
                            xg = x;
                        }
                    }

                    if (xl == xg)
                    {
                        columnBefor = columnAfter = l.ColIndex;
                    }
                    else
                    {
                        columnBefor = l.ColIndex;
                        columnAfter = g.ColIndex;

                        if (bR2L)
                        {
                            int ebf = columnBefor;
                            columnBefor = columnAfter;
                            columnAfter = ebf;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Estimate of column from Main DataMember
        /// </summary>
        /// <param name="point">The point that we want estimate columns</param>
        /// <returns></returns>
        public object EstimateByNearestColumnsInDataMember(Point point)
        {
            IBindingData bd = Parent.Chart.DataMember;
            if (bd == null)
                throw new Exception("DataMember of chart not define");

            return EstimateByNearestColumns(point, bd);
        }

        /// <summary>
        /// Estimate of column from Second DataMember
        /// </summary>
        /// <param name="point">The point that we want estimate columns</param>
        /// <returns></returns>
        public object EstimateByNearestColumnsInSecondDataMember(Point point)
        {
            if (this.SecondDataMember == null)
                throw new Exception("SecondDataMember not define");
            IBindingData bd = this.SecondDataMember.DataMember;
            if (bd == null)
                throw new Exception("DataMember of SecondDataMember not define");

            return EstimateByNearestColumns(point, bd);
        }

        private object EstimateByNearestColumns(Point point, IBindingData bd)
        {
            NearestColumnsIndex(point, out int befor, out int after);

            if (befor == -1 && after == -1)
                return null;
            if (befor == -1)
                return bd.ColumnValue(pointLocation[after].ColIndex);
            if (after == -1)
                return bd.ColumnValue(pointLocation[befor].ColIndex);
            if (after == befor)
                return bd.ColumnValue(pointLocation[after].ColIndex);

            ItemPointInfo l = pointLocation[befor];
            ItemPointInfo g = pointLocation[after];

            double x1 = l.Center.X;
            double x2 = g.Center.X;
            double y1 = bd.ColumnValue(l.ColIndex);
            double y2 = bd.ColumnValue(g.ColIndex);
            double x = point.X;

            double y = 0;
            if (x1 == x2)    //Not equal but for ....
                y = y1;
            else
            {
                double m = (y1 - y2) / (x1 - x2);
                y = m * (x - x1) + y1;
            }

            return bd.CalculateColumnValue(y);
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

        #region Mouse Enter Point
        public delegate void MouseAndItemEventHandler(object sender, MouseAndItemEventArgs e);

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Chart")]
        [Description("Mouse enter the Point.")]
        public event MouseAndItemEventHandler MouseEnterPoint;

        private void OnMouseEnterPoint(int col, int row)
        {
            MouseEnterPoint?.Invoke(this, new MouseAndItemEventArgs(col, row));
        }
        #endregion

        #region Mouse Leave Point
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Chart")]
        [Description("Mouse leave the Point.")]
        public event MouseAndItemEventHandler MouseLeavePoint;

        private void OnMouseLeavePoint(int col, int row)
        {
            MouseLeavePoint?.Invoke(this, new MouseAndItemEventArgs(col, row));
        }
        #endregion

        #endregion

        #region Get Events are Fired by chart
        private void Chart_MouseLeave(object sender, EventArgs e)
        {
            if (bMouseEnterPoint)
            {
                bMouseEnterPoint = false;
                OnMouseLeavePoint(itemLastPointEnter.ColIndex, itemLastPointEnter.RowIndex);
            }
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (rcChartDrawArea.Contains(e.Location))
            {
                //Line enter exit
                if (bMouseEnterPoint)
                    if (!itemLastPointEnter.Rect.Contains(e.Location))
                    {
                        bMouseEnterPoint = false;
                        OnMouseLeavePoint(itemLastPointEnter.ColIndex, itemLastPointEnter.RowIndex);
                        itemLastPointEnter.ColIndex = itemLastPointEnter.RowIndex = -1;
                    }
                if (!bMouseEnterPoint)
                {
                    foreach (ItemPointInfo item in pointLocation)
                    {
                        if (item.Rect.Contains(e.Location))
                        {
                            bMouseEnterPoint = true;
                            itemLastPointEnter = item;
                            OnMouseEnterPoint(itemLastPointEnter.ColIndex, itemLastPointEnter.RowIndex);
                            break;
                        }
                    }
                }
            }
            else
            {
                if (bMouseEnterPoint)
                {
                    bMouseEnterPoint = false;
                    OnMouseLeavePoint(itemLastPointEnter.ColIndex, itemLastPointEnter.RowIndex);
                }
            }
        }
        #endregion
    }
}
