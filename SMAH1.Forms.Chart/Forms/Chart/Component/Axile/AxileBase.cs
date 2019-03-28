using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SMAH1.Attributes;
using SMAH1.ExtensionMethod;
using SMAH1.Forms.PropertyGridComponent;
using SMAH1.BindingData;

namespace SMAH1.Forms.Chart.Component.Axile
{
    [DesignerCategory("SMAH1")]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public abstract class AxileBase : BaseChartComponent
    {
        #region Fields

        private SizingModeLabel sizingModeLabel;
        private SizingModeValue sizingModeValue;
        private float fVerticalScale;   //Use when sizingModeValue = Auto
        private float fVerticalMax;     //Use when sizingModeValue = Fix
        private float fVerticalMin;     //Use when sizingModeValue = Fix

        private int nWidthAxisLine;
        private XAxileLocation xAxileLocation;

        private Color gridColor;
        private HorizontalGridMode horizontalGrid;
        private int gridCount;
        private GridDashStyle gridDashStyle;

        private ShowTextAxisMode showTextOfAxis;
        private StringAlignment labelAlign;

        private string perfixValue;
        private string postfixValue;
        private string perfixLabel;
        private string postfixLabel;
        private AxileName axileNameVisible;
        private bool axileNameColorEnable;
        private Font fFontAxileName;

        private bool columnScaling;

        //Use in Events
        private bool bMouseEnterDrawChart;
        private double maxInTopOfChartArea;
        private double minInBottomOfChartArea;
        private DataDefine secondDataMember = null;
        private bool secondDataMemberIndependentZero;

        private bool ignoreEmptyColumnName;

        #endregion

        #region Property

        [Browsable(true)]
        [Description("String to add begin of Value Text")]
        [Category("Custom")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public string PerfixValue
        {
            get { return perfixValue; }
            set { perfixValue = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("String to add end of Value Text")]
        [Category("Custom")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public string PostfixValue
        {
            get { return postfixValue; }
            set { postfixValue = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("String to add begin of Label Text")]
        [Category("Custom")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public string PerfixLabel
        {
            get { return perfixLabel; }
            set { perfixLabel = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("String to add end of Label Text")]
        [Category("Custom")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public string PostfixLabel
        {
            get { return postfixLabel; }
            set { postfixLabel = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Show and location of axile name")]
        [Category("Custom")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public AxileName AxileNameVisible
        {
            get { return axileNameVisible; }
            set { axileNameVisible = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Set color compatible with legend for axile name,If axile name is Shown")]
        [Category("Custom")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public bool AxileNameColorEnable
        {
            get { return axileNameColorEnable; }
            set { axileNameColorEnable = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Font of Axile Name")]
        [Category("Custom")]
        [SaveLoad]
        public Font FontAxileName
        {
            get { return fFontAxileName; }
            set { fFontAxileName = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Show/Hide text of axis labels and values")]
        [Category("Custom")]
        [DefaultValue(ShowTextAxisMode.Both)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public ShowTextAxisMode ShowTextOfAxis
        {
            get { return showTextOfAxis; }
            set { showTextOfAxis = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Alignment of X-Axis label text")]
        [Category("Custom")]
        [DefaultValue(StringAlignment.Center)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public StringAlignment LabelAlign
        {
            get { return labelAlign; }
            set { labelAlign = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Scale of height (use when SizingModeValue is Auto)")]
        [DefaultValue(1.05F)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericFloatUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForFloat(1, 10, 2, 0.01F)]
        public float VerticalScale
        {
            get { return fVerticalScale; }
            set
            {
                if (value < 1F)
                    fVerticalScale = 1F;
                else if (value > 10F)
                    fVerticalScale = 10F;
                else
                    fVerticalScale = value;
                RedrawChart();
            }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Maximum value of height (use when SizingModeValue is Fix)")]
        [DefaultValue(100F)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [RefreshProperties(RefreshProperties.All)]
        [SaveLoad]
        [Editor(typeof(NumericFloatUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForFloat(0, (float)(decimal.MaxValue / 2), 0, 1F)]
        public float ValueMax
        {
            get { return fVerticalMax; }
            set
            {
                if (value > fVerticalMin && value >= 0)
                    fVerticalMax = value;
                else
                {
                    fVerticalMax = fVerticalMin + 1;
                }
                RedrawChart();
            }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Minimum value of height (use when SizingModeValue is Fix)")]
        [DefaultValue(0.0F)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [RefreshProperties(RefreshProperties.All)]
        [SaveLoad]
        [Editor(typeof(NumericFloatUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForFloat((float)(decimal.MinValue / 2), 0, 0, 1F)]
        public float ValueMin
        {
            get { return fVerticalMin; }
            set
            {
                if (value < fVerticalMax && value <= 0)
                    fVerticalMin = value;
                else
                {
                    fVerticalMin = fVerticalMax - 1;
                }
                RedrawChart();
            }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Draw normal mode or fit width graph to drawn control")]
        [DefaultValue(SizingModeLabel.Normal)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public SizingModeLabel SizingModeLabel
        {
            get { return sizingModeLabel; }
            set { sizingModeLabel = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Scale for use in value axis in graph")]
        [DefaultValue(SizingModeValue.Auto)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [RefreshProperties(RefreshProperties.All)]
        [SaveLoad]
        public SizingModeValue SizingModeValue
        {
            get { return sizingModeValue; }
            set { sizingModeValue = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Color of grid on chart")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public Color GridColor
        {
            get { return gridColor; }
            set { gridColor = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Draw horizontal grid on chart")]
        [DefaultValue(HorizontalGridMode.None)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public HorizontalGridMode HorizontalGrid
        {
            get { return horizontalGrid; }
            set { horizontalGrid = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Count of horizontal grid on chart")]
        [DefaultValue(10)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(2, 20)]
        public int CountOfGrid
        {
            get { return gridCount; }
            set
            {
                gridCount = value;
                if (gridCount < 2)
                    gridCount = 2;
                if (gridCount > 20)
                    gridCount = 20;
                RedrawChart();
            }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Style of horizontal grid on chart")]
        [DefaultValue(GridDashStyle.Dash)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public GridDashStyle GridDashStyle
        {
            get { return gridDashStyle; }
            set { gridDashStyle = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Axis width")]
        [Category("Custom")]
        [DefaultValue(2)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(0, int.MaxValue)]
        public int WidthAxisLine
        {
            get { return nWidthAxisLine; }
            set { nWidthAxisLine = (value > 0 ? value : 0); RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Horizontal Axile Location")]
        [Category("Custom")]
        [DefaultValue(XAxileLocation.OnZero)]
        [SaveLoad]
        public XAxileLocation XAxileLocation
        {
            get { return xAxileLocation; }
            set { xAxileLocation = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Show/Hide column lable if is empty")]
        [Category("Custom")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public bool IgnoreEmptyColumnName
        {
            get { return ignoreEmptyColumnName; }
            set { ignoreEmptyColumnName = value; RedrawChart(); }
        }

        protected double MaxInTopOfChartArea { get { return maxInTopOfChartArea; } }
        protected double MinInBottomOfChartArea { get { return minInBottomOfChartArea; } }
        protected int AxisFromTop { get; set; }
        protected List<AxileLabelText> LabelsX { get; }
        protected List<AxileLabelText> LabelsY { get; }

        [Browsable(false)]
        [Description("Second DataMember (show second vertical axile and add data with scale to DataMember)")]
        public DataDefine SecondDataMember
        {
            get { return secondDataMember; }
            set { secondDataMember = value; RedrawChart(); }
        }

        [Browsable(false)]
        [Description("Second DataMember (if defined) draw with independent zero in Y-Axile")]
        public virtual bool SecondDataMemberIndependentZero
        {
            get { return secondDataMemberIndependentZero; }
            set { secondDataMemberIndependentZero = value; RedrawChart(); }
        }

        [Browsable(false)]
        [Description("Draw column by scale")]
        protected virtual bool ColumnScaling
        {
            get { return columnScaling; }
            set { columnScaling = value; RedrawChart(); }
        }
        #endregion

        #region Method main
        public AxileBase()
        {
            //Initalize variables
            perfixValue = "";
            postfixValue = "";
            perfixLabel = "";
            postfixLabel = "";
            nWidthAxisLine = 2;
            xAxileLocation = XAxileLocation.OnZero;
            showTextOfAxis = ShowTextAxisMode.Both;
            labelAlign = StringAlignment.Center;
            maxInTopOfChartArea = 0;
            minInBottomOfChartArea = 0;
            sizingModeLabel = SizingModeLabel.Normal;
            sizingModeValue = SizingModeValue.Auto;
            fVerticalScale = 1.05F;
            fVerticalMax = 100F;
            fVerticalMin = 0F;
            gridColor = SystemColors.WindowText;
            horizontalGrid = HorizontalGridMode.None;
            gridCount = 10;
            gridDashStyle = GridDashStyle.Dash;
            bMouseEnterDrawChart = false;
            secondDataMemberIndependentZero = false;
            columnScaling = false;
            axileNameVisible = AxileName.None;
            axileNameColorEnable = false;
            fFontAxileName = null;
            ignoreEmptyColumnName = false;
            AxisFromTop = 0;
            LabelsX = new List<AxileLabelText>();
            LabelsY = new List<AxileLabelText>();
        }

        protected void RedrawChart()
        {
            if (Parent != null)
                Parent.Chart.RedrawChart();
        }

        public static void SetDashStyle(Pen pen, GridDashStyle style)
        {
            switch (style)
            {
                case GridDashStyle.Solid:
                    pen.DashStyle = DashStyle.Solid;
                    break;
                case GridDashStyle.Dash:
                    pen.DashStyle = DashStyle.Dash;
                    break;
                case GridDashStyle.Dot:
                    pen.DashStyle = DashStyle.Dot;
                    break;
                case GridDashStyle.DashDot:
                    pen.DashStyle = DashStyle.DashDot;
                    break;
                case GridDashStyle.DashDotDot:
                    pen.DashStyle = DashStyle.DashDotDot;
                    break;
                case GridDashStyle.DotSpace:
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[] { 1.0F, 2.0F };
                    break;
                case GridDashStyle.DotSpaceSpace:
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[] { 1.0F, 4.0F };
                    break;
                case GridDashStyle.DotSpace3:
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[] { 1.0F, 6.0F };
                    break;
                case GridDashStyle.DotSpace4:
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[] { 1.0F, 8.0F };
                    break;
                case GridDashStyle.DashSpace:
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[] { 3.0F, 3.0F };
                    break;
                case GridDashStyle.DashSpaceSpace:
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[] { 3.0F, 6.0F };
                    break;
            }
        }
        #endregion

        #region Paint of chart

        protected abstract void InternalPaintStart(Graphics grChart, IBindingData data);
        protected abstract void InternalPaintFinish(Graphics grChart, IBindingData data);
        protected abstract void InternalPaintChart(Graphics grChart,
            IBindingData data, Rectangle rcArea,
            ref double xAxisBetweenTextSpace, ref double xAxisTextWidth
            );

        protected virtual void InternalFindMaxMinOfData(IBindingData data, ref double max, ref double min)
        {
            BindingDataBase.FindMaxMin(data, ref max, ref min);
        }

        internal protected override void PaintStart(Graphics grChart, IBindingData data)
        {
            AxisFromTop = 0;
            LabelsX.Clear();
            LabelsY.Clear();
            InternalPaintStart(grChart, data);
        }

        internal protected override void PaintFinish(Graphics grChart, IBindingData data)
        {
            InternalPaintFinish(grChart, data);
        }

        internal protected override void Paint(Graphics grChart, IBindingData dataMain, Rectangle rcArea)
        {
            drawAllDataField = true;
            float gridHeightInRound = 0;
            IBindingData data = dataMain;

            bool bR2L = Parent.Chart.IsRTL();

            Pen penAxis = new Pen(Parent.Chart.ForeColor, nWidthAxisLine);
            Brush brAxis = new SolidBrush(Parent.Chart.ForeColor);

            StringFormat stringFormat = StringFormat.GenericDefault;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.Trimming = StringTrimming.None;
            stringFormat.FormatFlags =
                StringFormatFlags.NoWrap |
                StringFormatFlags.LineLimit |
                StringFormatFlags.DirectionVertical;

            const int constSpeceEndOfYTextAndAxis = SPACE_NEED;

            rcChartDrawArea = new RectangleF(
                rcArea.Left,
                rcArea.Top,
                //Width
                rcArea.Width,
                //Height
                rcArea.Height
                );
            AxisFromTop = (int)rcChartDrawArea.Bottom;

            //Draw chart
            if (data.RowCount > 0 && (int)rcChartDrawArea.Height > 0 && (int)rcChartDrawArea.Width > 0)
            {
                #region Max & Min Of Chart Area
                maxInTopOfChartArea = 0;
                minInBottomOfChartArea = 0;
                InternalFindMaxMinOfData(data, ref maxInTopOfChartArea, ref minInBottomOfChartArea);
                if (maxInTopOfChartArea == minInBottomOfChartArea)
                    maxInTopOfChartArea = minInBottomOfChartArea + 1;

                if (sizingModeValue == SizingModeValue.Auto)
                {
                    maxInTopOfChartArea *= fVerticalScale;
                    minInBottomOfChartArea *= fVerticalScale;
                }
                else if (sizingModeValue == SizingModeValue.Fix)
                {
                    maxInTopOfChartArea = this.ValueMax;
                    minInBottomOfChartArea = this.ValueMin;
                }
                else //sizingModeValue == SizingModeValue.Round
                {
                    double diff = maxInTopOfChartArea - minInBottomOfChartArea;
                    diff /= 10;
                    gridHeightInRound = (float)diff.RoundNumber();

                    int n;

                    if (maxInTopOfChartArea != 0)
                    {
                        n = (int)(maxInTopOfChartArea / gridHeightInRound);
                        n++;
                        maxInTopOfChartArea = n * gridHeightInRound;
                    }

                    if (minInBottomOfChartArea != 0)
                    {
                        n = (int)(minInBottomOfChartArea / gridHeightInRound);
                        n--;
                        minInBottomOfChartArea = n * gridHeightInRound;
                    }
                }

                data = SetupSecondDataMember(data);
                #endregion

                #region Column text space need (X Axis)
                int nAddSpaceOfBottom = 0;
                int nAddSpaceOfLeft = 0;
                int nAddSpaceOfRight = 0;

                if (showTextOfAxis == ShowTextAxisMode.Label ||
                        showTextOfAxis == ShowTextAxisMode.Both)
                {
                    float szColumnTextHeight = 0;
                    int colIndex;
                    for (colIndex = 0; colIndex < data.ColumnCount; colIndex++)
                    {
                        SizeF szColumnTextTmp = new SizeF(0, 0);
                        szColumnTextTmp = grChart.MeasureString(
                            perfixLabel + data.ColumnName(colIndex) + postfixLabel, Parent.Chart.Font);
                        float tmpHeight = szColumnTextTmp.Width;
                        if (szColumnTextHeight < tmpHeight)
                            szColumnTextHeight = tmpHeight;
                    }
                    szColumnTextHeight += 5; //5 pixel for space in text and X axis

                    if (xAxileLocation == Component.Axile.XAxileLocation.OnZero)
                    {
                        if (Math.Abs(rcChartDrawArea.Height / (maxInTopOfChartArea - minInBottomOfChartArea) * minInBottomOfChartArea) < szColumnTextHeight)
                        {
                            double extraOfTextHeight =
                                (szColumnTextHeight * maxInTopOfChartArea - (rcChartDrawArea.Height - szColumnTextHeight) * minInBottomOfChartArea)
                                /
                                (maxInTopOfChartArea - 2 * minInBottomOfChartArea)
                                ;
                            nAddSpaceOfBottom += (int)extraOfTextHeight;
                        }
                    }
                    else if (xAxileLocation == Component.Axile.XAxileLocation.Bottom)
                    {
                        if (nAddSpaceOfBottom < (int)szColumnTextHeight)
                            nAddSpaceOfBottom = (int)szColumnTextHeight;
                    }
                }
                #endregion

                if ((int)rcChartDrawArea.Height > 0 && (int)rcChartDrawArea.Width > 0)
                {
                    #region Calculate text position and space need of Y Axis
                    List<string> yTextPositive = new List<string>();
                    List<string> yTextNegative = new List<string>();
                    List<string> yTextPositiveSecond = new List<string>();
                    List<string> yTextNegativeSecond = new List<string>();
                    gridHeightInRound = CalculateYAxileTextPosition(
                        grChart, bR2L, constSpeceEndOfYTextAndAxis,
                        gridHeightInRound,
                        yTextPositive, yTextNegative,
                        maxInTopOfChartArea, minInBottomOfChartArea,
                        PerfixValue, PostfixValue, 0, false, ref nAddSpaceOfLeft, dataMain.Name);
                    if (SecondDataMember != null)
                    {
                        double ratio = SecondDataMember.DataMember.Scale;
                        double gridHeightInRoundSecond = gridHeightInRound;
                        if (ratio > 0)
                            gridHeightInRoundSecond /= ratio;

                        CalculateYAxileTextPosition(
                            grChart, !bR2L, constSpeceEndOfYTextAndAxis,
                            (float)gridHeightInRoundSecond,
                            yTextPositiveSecond, yTextNegativeSecond,
                            SecondDataMember.MaxInTopOfChart, SecondDataMember.MinInBottomOfChart,
                            SecondDataMember.PerfixValue, SecondDataMember.PostfixValue,
                            SecondDataMember.DataMember.InverseMap(0), true, ref nAddSpaceOfRight, SecondDataMember.DataMember.Name);
                    }
                    #endregion

                    #region Set space of X,Y Axis
                    if (this.Parent.Chart.DrawManager != null)
                    {
                        ((AxileDrawManager)this.Parent.Chart.DrawManager)
                            .CalculateToXAxileSpace(this.Parent.Chart, ref nAddSpaceOfBottom, ref nAddSpaceOfLeft, ref nAddSpaceOfRight);
                    }
                    SetSpaceOfAxile(bR2L, nAddSpaceOfBottom, nAddSpaceOfLeft, nAddSpaceOfRight);
                    #endregion

                    if ((int)rcChartDrawArea.Height > 0 && (int)rcChartDrawArea.Width > 0)
                    {
                        double maxminHeight = (double)(rcChartDrawArea.Height / (maxInTopOfChartArea - minInBottomOfChartArea));

                        AxisFromTop = (int)(
                            (maxminHeight * maxInTopOfChartArea)
                            + rcChartDrawArea.Top);

                        int xAxisLocationFromTop = AxisFromTop;
                        if (xAxileLocation == XAxileLocation.OnZero)
                            xAxisLocationFromTop = AxisFromTop;
                        else if (xAxileLocation == XAxileLocation.Bottom)
                            xAxisLocationFromTop = (int)rcChartDrawArea.Bottom;
                        int heightXTex = rcArea.Bottom - xAxisLocationFromTop;

                        if (horizontalGrid == HorizontalGridMode.BackOfData)
                            if (sizingModeValue == SizingModeValue.Round)
                                DarwDash(grChart, rcChartDrawArea, AxisFromTop, gridHeightInRound);
                            else
                                DarwDash(grChart, rcChartDrawArea, AxisFromTop);

                        double xAxisBetweenTextSpace = 0;
                        double xAxisTextWidth = 0;
                        InternalPaintChart(grChart, data, rcArea,
                            ref xAxisBetweenTextSpace, ref xAxisTextWidth);

                        #region Draw X Axis text
                        StringFormat stringFormat2 = (StringFormat)stringFormat.Clone();
                        DrawXAxisText(grChart,
                            data, bR2L,
                            brAxis,
                            xAxisLocationFromTop, heightXTex, xAxisBetweenTextSpace, xAxisTextWidth,
                            stringFormat2);
                        stringFormat2.Dispose();
                        #endregion

                        #region Draw Y Axis text
                        stringFormat2 = (StringFormat)stringFormat.Clone();
                        DrawYAxisText(
                           grChart, rcArea, gridHeightInRound, bR2L, brAxis, stringFormat2,
                           constSpeceEndOfYTextAndAxis, yTextPositive, yTextNegative,
                           maxInTopOfChartArea, minInBottomOfChartArea);
                        if (SecondDataMember != null)
                        {
                            DrawYAxisText(
                                grChart, rcArea, gridHeightInRound, !bR2L, brAxis, stringFormat2,
                                constSpeceEndOfYTextAndAxis, yTextPositiveSecond, yTextNegativeSecond,
                                maxInTopOfChartArea, minInBottomOfChartArea);
                        }
                        stringFormat2.Dispose();
                        #endregion
                    }
                }
                else
                {
                    #region Set space of X,Y Axis
                    if (this.Parent.Chart.DrawManager != null)
                    {
                        ((AxileDrawManager)this.Parent.Chart.DrawManager)
                            .CalculateToXAxileSpace(this.Parent.Chart, ref nAddSpaceOfBottom, ref nAddSpaceOfLeft, ref nAddSpaceOfRight);
                    }
                    SetSpaceOfAxile(bR2L, nAddSpaceOfBottom, nAddSpaceOfLeft, nAddSpaceOfRight);
                    #endregion
                }
            }
            else
            {//if nedd draw any thing withot calculate data
                if (horizontalGrid == HorizontalGridMode.BackOfData)
                    if (sizingModeValue == SizingModeValue.Round)
                        DarwDash(grChart, rcChartDrawArea, AxisFromTop, gridHeightInRound);
                    else
                        DarwDash(grChart, rcChartDrawArea, AxisFromTop);
            }

            if (horizontalGrid == HorizontalGridMode.FrontOfData)
                if (sizingModeValue == SizingModeValue.Round)
                    DarwDash(grChart, rcChartDrawArea, AxisFromTop, gridHeightInRound);
                else
                    DarwDash(grChart, rcChartDrawArea, AxisFromTop);

            DrawAxis(grChart, rcArea, bR2L, penAxis, brAxis, dataMain);

            stringFormat.Dispose();
            brAxis.Dispose();
            penAxis.Dispose();
        }

        #region Draw Axis Text
        private float CalculateYAxileTextPosition(
                    Graphics grChart, bool bR2L, int constSpeceEndOfYTextAndAxis,
                    float gridHeightInRound,
                    List<string> yTextPositive, List<string> yTextNegative,
                    double max, double min, string perfixValue, string postfixValue,
                    double baseGrid, bool bSecond, ref int nAddSpaceToLeftOrRight, string axileName)
        {
            double fRetGridHeightInRound = gridHeightInRound;

            if ((max == 0 || min == 0) && !bSecond)
            {
                if (sizingModeValue != SizingModeValue.Round)
                {
                    double maxOfmaxmin = max;
                    maxOfmaxmin = Math.Max(maxOfmaxmin, Math.Abs(min));
                    maxOfmaxmin -= Math.Abs(baseGrid);
                    fRetGridHeightInRound = maxOfmaxmin / gridCount;

                    int degitCount = -1 + (int)Math.Log10(maxOfmaxmin / gridCount);
                    int degitCount2 = Math.Abs(degitCount);
                    string sFormat = "{0:F" + degitCount2 + "}";

                    for (int i = 0; i <= gridCount; i++)
                    {
                        double f = fRetGridHeightInRound * i;
                        if (degitCount > 0)
                            yTextPositive.Add(perfixValue + ((int)f) + postfixValue);
                        else
                            yTextPositive.Add(perfixValue + String.Format(sFormat, f) + postfixValue);
                    }
                }
                else
                {
                    int degitCount = -1 + (int)Math.Log10(gridHeightInRound);
                    int degitCount2 = Math.Abs(degitCount);
                    string sFormat = "{0:F" + degitCount2 + "}";

                    for (double f = baseGrid; f < max; f += gridHeightInRound)
                        if (degitCount > 0)
                            yTextPositive.Add(perfixValue + ((int)f) + postfixValue);
                        else
                            yTextPositive.Add(perfixValue + String.Format(sFormat, f) + postfixValue);
                }
            }
            else
            {
                double step = 0;
                if (bSecond)
                {
                    step = gridHeightInRound;
                }
                else
                {
                    if (sizingModeValue != SizingModeValue.Round)
                    {
                        double maxOfmaxmin = max;
                        maxOfmaxmin = Math.Max(maxOfmaxmin, Math.Abs(min));
                        step = (maxOfmaxmin - Math.Abs(baseGrid)) / gridCount;
                    }
                    else
                    {
                        step = gridHeightInRound;
                    }
                }
                fRetGridHeightInRound = step;

                int degitCount = -1 + (int)Math.Log10(step);
                int degitCount2 = Math.Abs(degitCount);
                string sFormat = "{0:F" + degitCount2 + "}";
                double d = baseGrid;
                for (; d <= max; d += step)
                {
                    if (degitCount > 0)
                        yTextPositive.Add(perfixValue + ((int)d) + postfixValue);
                    else
                        yTextPositive.Add(perfixValue + String.Format(sFormat, d) + postfixValue);
                }
                d = baseGrid;
                for (bool bFirst = true; d >= min; d -= step, bFirst = false)
                {
                    if (bFirst)
                    {
                        yTextNegative.Add("");
                    }
                    else
                    {
                        if (degitCount > 0)
                            yTextNegative.Add(perfixValue + ((int)d) + postfixValue);
                        else
                            yTextNegative.Add(perfixValue + String.Format(sFormat, d) + postfixValue);
                    }
                }
            }

            nAddSpaceToLeftOrRight = 0;

            if (showTextOfAxis == ShowTextAxisMode.Value ||
                            showTextOfAxis == ShowTextAxisMode.Both)
            {
                float szColumnTextWidth = 0;
                foreach (string val in yTextPositive)
                {
                    SizeF szColumnTextTmp = new SizeF(0, 0);
                    szColumnTextTmp = grChart.MeasureString(
                        val, Parent.Chart.Font);
                    float tmpWidth = szColumnTextTmp.Width;
                    if (szColumnTextWidth < tmpWidth)
                        szColumnTextWidth = tmpWidth;
                }
                foreach (string val in yTextNegative)
                {
                    SizeF szColumnTextTmp = new SizeF(0, 0);
                    szColumnTextTmp = grChart.MeasureString(
                        val, Parent.Chart.Font);
                    float tmpWidth = szColumnTextTmp.Width;
                    if (szColumnTextWidth < tmpWidth)
                        szColumnTextWidth = tmpWidth;
                }
                nAddSpaceToLeftOrRight = (int)szColumnTextWidth + constSpeceEndOfYTextAndAxis;
            }

            if (axileNameVisible == AxileName.BackAxileTop | axileNameVisible == AxileName.BackAxileCenter
                | axileNameVisible == AxileName.BackAxileBottom)
            {
                Font fnt = fFontAxileName;
                if (fnt == null)
                    fnt = this.Parent.Chart.Font;
                SizeF sz = grChart.MeasureString(axileName, fnt);

                nAddSpaceToLeftOrRight += (int)Math.Ceiling(sz.Height);
            }

            return (float)fRetGridHeightInRound;
        }

        private void SetSpaceOfAxile(bool bR2L, int nAddSpaceOfBottom, int nAddSpaceOfLeft, int nAddSpaceOfRight)
        {
            //if nAddSpaceOfBottom change,so recalculate rcChartDrawArea
            rcChartDrawArea.Height -= nAddSpaceOfBottom;
            AxisFromTop = (int)rcChartDrawArea.Bottom;

            //if nAddSpaceOfLeft change,so recalculate rcChartDrawArea
            rcChartDrawArea = new RectangleF(
                (bR2L ? rcChartDrawArea.Left : rcChartDrawArea.Left + nAddSpaceOfLeft),
                rcChartDrawArea.Top,
                rcChartDrawArea.Width - nAddSpaceOfLeft,
                rcChartDrawArea.Height
                );

            //if nAddSpaceOfRight change,so recalculate rcChartDrawArea
            rcChartDrawArea = new RectangleF(
                (!bR2L ? rcChartDrawArea.Left : rcChartDrawArea.Left + nAddSpaceOfRight),
                rcChartDrawArea.Top,
                rcChartDrawArea.Width - nAddSpaceOfRight,
                rcChartDrawArea.Height
                );
        }

        private void DrawYAxisText(Graphics grChart, Rectangle rcArea, float gridHeightInRound, bool bR2L, Brush brAxis, StringFormat stringFormat2,
                int constSpeceEndOfYTextAndAxis, List<string> yTextPositive, List<string> yTextNegative,
                double max, double min)
        {
            if (showTextOfAxis == ShowTextAxisMode.Value ||
                    showTextOfAxis == ShowTextAxisMode.Both)
            {
                stringFormat2.FormatFlags &= ~StringFormatFlags.DirectionVertical;

                StringFormat sf = (StringFormat)stringFormat2.Clone();

                float fHeight = 0;
                double maxOfmaxmin = max;
                maxOfmaxmin = Math.Max(maxOfmaxmin, Math.Abs(min));

                if (sizingModeValue != SizingModeValue.Round)
                {
                    if (maxOfmaxmin == max)
                        fHeight = ((AxisFromTop - rcChartDrawArea.Top) / gridCount);
                    else
                        fHeight = ((rcChartDrawArea.Bottom - AxisFromTop) / gridCount);
                }
                else
                {
                    if (maxOfmaxmin == max)
                        fHeight = (float)((AxisFromTop - rcChartDrawArea.Top) / (max / gridHeightInRound));
                    else
                        fHeight = (float)((rcChartDrawArea.Bottom - AxisFromTop) / (Math.Abs(min) / gridHeightInRound));
                }

                int xYtext = rcArea.Left;
                int xYwidth = (int)rcChartDrawArea.Left - rcArea.Left - constSpeceEndOfYTextAndAxis;
                sf.Alignment = StringAlignment.Far;
                if (bR2L)
                {
                    xYtext = (int)rcChartDrawArea.Right + constSpeceEndOfYTextAndAxis;
                    xYwidth = rcArea.Right - (int)rcChartDrawArea.Right - constSpeceEndOfYTextAndAxis;
                    sf.Alignment = StringAlignment.Near;
                }

                if (fHeight != 0)
                {
                    int gridNumCount = 1;
                    for (gridNumCount = 1; (gridNumCount * fHeight) < Parent.Chart.Font.Height; gridNumCount++) ;

                    int j = 0;
                    fHeight *= gridNumCount;
                    float fDraw = AxisFromTop;

                    int rowIndex = yTextNegative.Count - 1;
                    foreach (string val in yTextPositive)
                    {
                        rowIndex++;
                        if ((j % gridNumCount) == 0)
                        {
                            RectangleF rcf = new RectangleF(xYtext, fDraw - fHeight / 2,
                                 xYwidth, fHeight);

                            grChart.DrawString(val,
                                Parent.Chart.Font, brAxis,
                                rcf, sf);
                            fDraw -= fHeight;

                            LabelsY.Add(new AxileLabelText(rowIndex, rcf,
                                val, sf.Alignment));
                        }
                        j++;
                    }
                    j = 0;
                    fDraw = AxisFromTop;
                    rowIndex = -1;
                    foreach (string val in yTextNegative)
                    {
                        rowIndex++;
                        if ((j % gridNumCount) == 0)
                        {
                            RectangleF rcf = new RectangleF(xYtext, fDraw - fHeight / 2,
                                 xYwidth, fHeight);
                            grChart.DrawString(val,
                                Parent.Chart.Font, brAxis,
                                rcf, sf);
                            fDraw += fHeight;

                            LabelsY.Add(new AxileLabelText(rowIndex, rcf,
                                val, sf.Alignment));
                        }
                        j++;
                    }
                }

                sf.Dispose();
            }
        }

        private void DrawXAxisText(Graphics grChart, IBindingData data,
            bool bR2L, Brush brAxis, int xAxisLocationFromTop,
            int heightXTex, double xAxisBetweenTextSpace,
            double xAxisTextWidth, StringFormat stringFormat2)
        {
            if (!(showTextOfAxis == ShowTextAxisMode.Label ||
                    showTextOfAxis == ShowTextAxisMode.Both))
                return;

            Dictionary<int, RectangleF> lablesOfXLocation = new Dictionary<int, RectangleF>();
            double mid;
            double drawWidth = Math.Max(xAxisTextWidth, Parent.Chart.Font.Height);
            for (int colIndex = 0; colIndex < data.ColumnCount; colIndex++)
            {
                if (columnScaling)
                    mid = xAxisBetweenTextSpace + (xAxisBetweenTextSpace + xAxisTextWidth) * data.ColumnValue(colIndex);
                else
                    mid = xAxisBetweenTextSpace + (xAxisBetweenTextSpace + xAxisTextWidth) * colIndex;

                if (!ignoreEmptyColumnName || !string.IsNullOrEmpty(data.ColumnName(colIndex)))
                {
                    lablesOfXLocation.Add(colIndex, new RectangleF(
                        (float)(mid),
                        (float)(xAxisLocationFromTop + 5),
                        (float)(drawWidth),
                        (float)(heightXTex)));
                }
            }

            RectangleF clipDraw = new RectangleF();
            RectangleF rcAccept = new RectangleF(DrawArea.Left,
                Parent.Chart.ClientRectangle.Top,
                DrawArea.Width,
                Parent.Chart.ClientRectangle.Height);

            double drawTo = (bR2L ? DrawArea.Right : DrawArea.Left);
            foreach (var i in lablesOfXLocation.Keys)
            {
                var r = lablesOfXLocation[i];

                float w = DrawArea.Right - r.Left;
                w = Math.Min(w, r.Width);
                if (bR2L)
                {
                    clipDraw = new RectangleF(
                        DrawArea.Right - r.Left - w,
                        r.Top,
                        w,
                        r.Height);
                }
                else
                {
                    clipDraw = new RectangleF(
                        DrawArea.Left + r.Left,
                        r.Top, w, r.Height);
                }

                clipDraw = RectangleF.Intersect(clipDraw, rcAccept);

                if (clipDraw.Width >= Parent.Chart.Font.Height)
                {
                    string strXTextDraw = perfixLabel + data.ColumnName(i) + postfixLabel;

                    if (bR2L)
                    {
                        if (clipDraw.Right - drawTo <= 0.001)
                        {
                            LabelsX.Add(new AxileLabelText(i, clipDraw,
                                strXTextDraw, labelAlign));

                            drawTo = clipDraw.Left;
                        }
                    }
                    else
                    {
                        if (drawTo - clipDraw.Left <= 00.001)
                        {
                            LabelsX.Add(new AxileLabelText(i, clipDraw,
                                strXTextDraw, labelAlign));
                            drawTo = clipDraw.Right;
                        }
                    }
                }
            }

            AxileLabelTextEventArgs e = new AxileLabelTextEventArgs(LabelsX);
            OnAxileLabelTextFormatting(e);

            foreach (AxileLabelText dt in LabelsX)
            {
                stringFormat2.LineAlignment = dt.Alignment;

                grChart.DrawString(dt.Text,
                        Parent.Chart.Font, brAxis,
                        dt.Rectangle, stringFormat2);

            }
        }
        #endregion

        #region SetupSecondDataMember
        private IBindingData SetupSecondDataMember(IBindingData data)
        {
            if (SecondDataMember != null)
            {
                SecondDataMember.DataMember.Scale = 1;
                SecondDataMember.DataMember.Offset = 0;
                double maxSecond = 0;
                double minSecond = 0;
                InternalFindMaxMinOfData(SecondDataMember.DataMember, ref maxSecond, ref minSecond);
                if (maxSecond == minSecond)
                    maxSecond = minSecond + 1;

                if (SecondDataMember.SizingModeValue == SizingModeValue.Auto)
                {
                    maxSecond *= SecondDataMember.VerticalScale;
                    minSecond *= SecondDataMember.VerticalScale;
                }
                else if (SecondDataMember.SizingModeValue == SizingModeValue.Fix)
                {
                    maxSecond = SecondDataMember.ValueMax;
                    minSecond = SecondDataMember.ValueMin;
                }
                else //SecondDataMember.SizingModeValue == SizingModeValue.Round
                {
                    double diff = maxSecond - minSecond;
                    diff /= 10;
                    float gridHeightInRound = (float)diff.RoundNumber();

                    int n = 5;

                    if (maxSecond != 0)
                    {
                        n = (int)(maxSecond / gridHeightInRound);
                        n++;
                        maxSecond = n * gridHeightInRound;
                    }

                    if (minSecond != 0)
                    {
                        n = (int)(minSecond / gridHeightInRound);
                        n--;
                        minSecond = n * gridHeightInRound;
                    }
                }

                SecondDataMember.MaxInTopOfChart = maxSecond;
                SecondDataMember.MinInBottomOfChart = minSecond;

                if (SecondDataMember.MaxInTopOfChart != SecondDataMember.MinInBottomOfChart)
                {
                    data = Bind.FromIBindingDatas(data, SecondDataMember.DataMember);
                    if (this.SecondDataMemberIndependentZero)
                    {
                        //SecondDataMember.MaxInTopOfChart map to maxInTopOfChartArea
                        //SecondDataMember.MinInBottomOfChart map to minInBottomOfChartArea
                        //Note : SecondDataMember.MaxInTopOfChart != SecondDataMember.MinInBottomOfChart
                        double a = (maxInTopOfChartArea - minInBottomOfChartArea)
                                    /
                                    (SecondDataMember.MaxInTopOfChart - SecondDataMember.MinInBottomOfChart);
                        double b = maxInTopOfChartArea - a * SecondDataMember.MaxInTopOfChart;

                        SecondDataMember.DataMember.Scale = a;
                        SecondDataMember.DataMember.Offset = b;
                    }
                    else
                    {
                        if (minInBottomOfChartArea == 0 && SecondDataMember.MinInBottomOfChart == 0)
                        {
                            SecondDataMember.DataMember.Scale = maxInTopOfChartArea / SecondDataMember.MaxInTopOfChart;
                        }
                        else if (maxInTopOfChartArea == 0 && SecondDataMember.MaxInTopOfChart == 0)
                        {
                            SecondDataMember.DataMember.Scale = minInBottomOfChartArea / SecondDataMember.MinInBottomOfChart;
                        }
                        else
                        {
                            //We have >0 and <0 in main or second DataMember
                            //      So we devide graph to 2 areas (positive and negative)
                            double max1 = Math.Max(
                                Math.Abs(maxInTopOfChartArea),
                                Math.Abs(minInBottomOfChartArea));
                            maxInTopOfChartArea = max1;
                            minInBottomOfChartArea = -max1;

                            double max2 = Math.Max(
                                Math.Abs(SecondDataMember.MaxInTopOfChart),
                                Math.Abs(SecondDataMember.MinInBottomOfChart));
                            SecondDataMember.MaxInTopOfChart = max2;
                            SecondDataMember.MinInBottomOfChart = -max2;

                            max1 = max1 / max2;

                            SecondDataMember.DataMember.Scale = max1;
                        }
                    }
                }
            }
            return data;
        }
        #endregion

        #region Draw Axis
        private void DrawAxis(Graphics grChart, Rectangle rcArea, bool bR2L, Pen penAxis, Brush brAxis, IBindingData dataMain)
        {
            if (nWidthAxisLine > 0 && (int)rcChartDrawArea.Height > 0 && (int)rcChartDrawArea.Width > 0)
            {
                //vertical line
                DrawVerticalAxile(grChart, rcArea, penAxis, brAxis, bR2L, dataMain.Name, Parent.Chart.Colors[0]);
                if (SecondDataMember != null)
                    DrawVerticalAxile(grChart, rcArea, penAxis, brAxis, !bR2L, SecondDataMember.DataMember.Name, Parent.Chart.Colors[dataMain.RowCount]);


                const int deepOfExtended = SPACE_NEED;

                //horizontal line
                int deep = (drawAllDataField ? 0 : deepOfExtended);
                int y = AxisFromTop;
                if (xAxileLocation == Component.Axile.XAxileLocation.Bottom)
                    y = (int)rcChartDrawArea.Bottom;
                grChart.DrawLine(penAxis,
                    rcChartDrawArea.Left + (bR2L ? deep : 0), y,
                    rcChartDrawArea.Right - (bR2L ? 0 : deep), y);

                //Draw '>' sign if may be not draw all data in end of horizontal line
                if (!drawAllDataField)
                {
                    int location = (bR2L
                        ? (int)rcChartDrawArea.Left + deep
                        : (int)rcChartDrawArea.Right - deep);
                    deep = (bR2L ? -deepOfExtended : deepOfExtended);

                    GraphicsPath path = new GraphicsPath();
                    path.StartFigure(); // Start the first figure.
                    Point[] points = {
                           new Point(location, y),
                           new Point(location, y + deepOfExtended),
                           new Point(location + deep, y),
                           new Point(location, y - deepOfExtended)
                        };
                    path.AddLines(points);
                    path.CloseFigure(); // Second figure is closed.
                    grChart.FillPath(brAxis, path);
                }
            }
        }

        private void DrawVerticalAxile(Graphics grChart, Rectangle rcArea, Pen penAxis, Brush brAxis, bool bR2L, string axileName, Color axileNameColor)
        {
            PointF ptEnd;
            if (bR2L)
            {
                grChart.DrawLine(penAxis,
                    rcChartDrawArea.Right, rcChartDrawArea.Top,
                    rcChartDrawArea.Right, rcChartDrawArea.Bottom);
                ptEnd = new PointF(rcChartDrawArea.Right, rcChartDrawArea.Top);
            }
            else
            {
                grChart.DrawLine(penAxis,
                    rcChartDrawArea.Left, rcChartDrawArea.Top,
                    rcChartDrawArea.Left, rcChartDrawArea.Bottom);
                ptEnd = new PointF(rcChartDrawArea.Left, rcChartDrawArea.Top);
            }

            //Draw axile name
            if (axileNameVisible != AxileName.None)
            {
                if (axileNameVisible == AxileName.BackAxileTop | axileNameVisible == AxileName.BackAxileCenter
                        | axileNameVisible == AxileName.BackAxileBottom)
                {
                    int constSpeceEndOfYTextAndAxis = SPACE_NEED;

                    StringFormat sf = new StringFormat();
                    sf.FormatFlags |= StringFormatFlags.DirectionVertical | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;

                    int xYtext = rcArea.Left;
                    int xYwidth = (int)rcChartDrawArea.Left - rcArea.Left - constSpeceEndOfYTextAndAxis;
                    sf.LineAlignment = StringAlignment.Near;
                    switch (axileNameVisible)
                    {
                        case AxileName.BackAxileTop: sf.Alignment = StringAlignment.Near; break;
                        case AxileName.BackAxileCenter: sf.Alignment = StringAlignment.Center; break;
                        case AxileName.BackAxileBottom: sf.Alignment = StringAlignment.Far; break;
                    }
                    if (bR2L)
                    {
                        xYtext = (int)rcChartDrawArea.Right + constSpeceEndOfYTextAndAxis;
                        xYwidth = rcArea.Right - (int)rcChartDrawArea.Right - constSpeceEndOfYTextAndAxis;
                        sf.LineAlignment = StringAlignment.Far;
                    }

                    RectangleF rcfMain = new RectangleF(xYtext, rcChartDrawArea.Top,
                         xYwidth, rcChartDrawArea.Height);

                    Font fnt = fFontAxileName;
                    if (fnt == null)
                        fnt = this.Parent.Chart.Font;

                    if (axileNameColorEnable)
                    {
                        Brush br = new SolidBrush(axileNameColor);
                        grChart.DrawString(axileName, fnt, br, rcfMain, sf);
                        br.Dispose();
                    }
                    else
                        grChart.DrawString(axileName, fnt, brAxis, rcfMain, sf);

                    sf.Dispose();
                }
                else
                {
                    SingleLineText slt = new SingleLineText();
                    slt.Add(axileName, SingleLineText.TextFromBaseLine.Normal, true);

                    Font fnt = fFontAxileName;
                    if (fnt == null)
                        fnt = this.Parent.Chart.Font;
                    SizeF sz = slt.MeasureString(grChart, fnt);
                    if (axileNameVisible == AxileName.EndAxile)
                    {
                        ptEnd.Y -= SPACE_NEED;
                        ptEnd.X -= sz.Width / 2;
                        ptEnd.Y -= sz.Height;
                    }
                    else if (axileNameVisible == AxileName.InArea)
                    {
                        if (bR2L)
                        {
                            ptEnd.X -= SPACE_NEED;
                            ptEnd.X -= sz.Width;
                        }
                        else
                            ptEnd.X += SPACE_NEED;
                    }

                    if (axileNameColorEnable)
                    {
                        Brush br = new SolidBrush(axileNameColor);
                        slt.DrawString(grChart, fnt, br, ptEnd.X, ptEnd.Y);
                        br.Dispose();
                    }
                    else
                        slt.DrawString(grChart, fnt, brAxis, ptEnd.X, ptEnd.Y);
                }
            }
        }
        #endregion

        #region Darw Dash
        private void DarwDash(Graphics grChart, RectangleF rcChartArea, int AxisFromTop)
        {
            if ((int)rcChartArea.Height > 0 && (int)rcChartArea.Width > 0)
            {
                Pen penGrid = new Pen(GridColor, 1);
                SetDashStyle(penGrid, this.GridDashStyle);

                double maxOfmaxmin = maxInTopOfChartArea;
                maxOfmaxmin = Math.Max(maxOfmaxmin, Math.Abs(minInBottomOfChartArea));

                float fHeight = 0;
                if (maxOfmaxmin == maxInTopOfChartArea)
                    fHeight = ((AxisFromTop - rcChartDrawArea.Top) / gridCount);
                else
                    fHeight = ((rcChartDrawArea.Bottom - AxisFromTop) / gridCount);

                if (fHeight != 0)
                {
                    int wBegin = (int)rcChartArea.Left;
                    int wEnd = (int)rcChartArea.Right;
                    for (float fDraw = AxisFromTop; fDraw >= rcChartDrawArea.Top; fDraw -= fHeight)
                    {
                        int j = (int)fDraw;
                        grChart.DrawLine(penGrid, wBegin, j, wEnd, j);
                    }
                    for (float fDraw = AxisFromTop; fDraw <= rcChartDrawArea.Bottom; fDraw += fHeight)
                    {
                        int j = (int)fDraw;
                        grChart.DrawLine(penGrid, wBegin, j, wEnd, j);
                    }
                }

                penGrid.Dispose();
            }
        }

        //For sizeModeValue is round
        private void DarwDash(Graphics grChart, RectangleF rcChartArea,
                int AxisFromTop, float gridHeightInRound)
        {
            if ((int)rcChartArea.Height > 0 && (int)rcChartArea.Width > 0)
            {
                Pen penGrid = new Pen(GridColor, 1);
                SetDashStyle(penGrid, this.GridDashStyle);

                double maxOfmaxmin = maxInTopOfChartArea;
                maxOfmaxmin = Math.Max(maxOfmaxmin, Math.Abs(minInBottomOfChartArea));

                float fHeight = 0;
                if (maxOfmaxmin == maxInTopOfChartArea)
                    fHeight = (float)((AxisFromTop - rcChartDrawArea.Top) / (maxInTopOfChartArea / gridHeightInRound));
                else
                    fHeight = (float)((rcChartDrawArea.Bottom - AxisFromTop) / (Math.Abs(minInBottomOfChartArea) / gridHeightInRound));

                if (fHeight != 0)
                {
                    int wBegin = (int)rcChartArea.Left;
                    int wEnd = (int)rcChartArea.Right;
                    for (float fDraw = AxisFromTop; fDraw >= rcChartDrawArea.Top; fDraw -= fHeight)
                    {
                        int j = (int)fDraw;
                        grChart.DrawLine(penGrid, wBegin, j, wEnd, j);
                    }
                    for (float fDraw = AxisFromTop; fDraw <= rcChartDrawArea.Bottom; fDraw += fHeight)
                    {
                        int j = (int)fDraw;
                        grChart.DrawLine(penGrid, wBegin, j, wEnd, j);
                    }
                }

                penGrid.Dispose();
            }
        }
        #endregion
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

        #region Mouse Enter Axis Area
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Chart")]
        [Description("Mouse enter the chart area (place draw axis).")]
        public event System.EventHandler MouseEnterAxisArea;

        private void OnMouseEnterAxisArea()
        {
            MouseEnterAxisArea?.Invoke(this, new EventArgs());
        }
        #endregion

        #region Mouse Leave Axis Area
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Chart")]
        [Description("Mouse exit the chart area (place draw axis).")]
        public event System.EventHandler MouseLeaveAxisArea;

        private void OnMouseLeaveAxisArea()
        {
            MouseLeaveAxisArea?.Invoke(this, new EventArgs());
        }
        #endregion

        #region Mouse Location Value
        public delegate void MouseLocationValueEventHandler(object sender, MouseLocationValueEventArgs e);

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Chart")]
        [Description("Mouse location - in chart area - has a value.When mouse move,calculate this value and fire this event.")]
        public event MouseLocationValueEventHandler MouseLocationValueChange;

        private void OnMouseLocationValueChange(float val)
        {
            MouseLocationValueChange?.Invoke(this, new MouseLocationValueEventArgs(val));
        }

        #endregion

        #region Mouse Location Value
        public delegate void AxileLabelTextEventHandler(object sender, AxileLabelTextEventArgs e);

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Chart")]
        [Description("Fire when draw X axil label for laber formatting ")]
        public event AxileLabelTextEventHandler AxileLabelTextFormatting;

        private void OnAxileLabelTextFormatting(AxileLabelTextEventArgs e)
        {
            AxileLabelTextFormatting?.Invoke(this, e);
        }

        #endregion

        #endregion

        #region Get Events are Fired by chart
        private void Chart_MouseLeave(object sender, EventArgs e)
        {
            if (bMouseEnterDrawChart)
            {
                bMouseEnterDrawChart = false;
                OnMouseLeaveAxisArea();
            }
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (rcChartDrawArea.Contains(e.Location))
            {
                if (!bMouseEnterDrawChart)
                {
                    bMouseEnterDrawChart = true;
                    OnMouseEnterAxisArea();
                }

                PointF pt = new PointF
                {
                    X = e.Location.X - rcChartDrawArea.Location.X,
                    Y = e.Location.Y - rcChartDrawArea.Location.Y
                };
                OnMouseLocationValueChange((float)
                    (maxInTopOfChartArea -
                    (pt.Y * (maxInTopOfChartArea - minInBottomOfChartArea) / rcChartDrawArea.Height)));
            }
            else
            {
                if (bMouseEnterDrawChart)
                {
                    bMouseEnterDrawChart = false;
                    OnMouseLeaveAxisArea();
                }
            }
        }
        #endregion

    }
}
