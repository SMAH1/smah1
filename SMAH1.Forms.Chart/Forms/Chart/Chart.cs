using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using SMAH1.Attributes;
using SMAH1.Forms.Chart.Component;
using SMAH1.Collections;
using SMAH1.Forms.PropertyGridComponent;
using SMAH1.Serialize;
using SMAH1.BindingData;
using SMAH1.ExtensionMethod;

namespace SMAH1.Forms.Chart
{
    [DesignerCategory("SMAH1")]
    [ToolboxBitmap(typeof(Chart), "Chart.bmp")]
    [DefaultProperty("Component")]
    [DefaultEvent("ComponentChanged")]
    public class Chart : Control
    {
        #region Fields
        private BaseChartComponent component = null;

        private Color[] colors;

        private int nSpaceAfterText;

        private ShowTextMode showTitle;
        private Font fFontTitle;
        private Font fFontLegend;
        private ContentAlignment legendAlignment;
        private bool legendShow;
        private int legendHorizontalSpace;    //Positive for calculate form control area,Negative for calculate form Draw area
        private int legendVerticalSpace;      //Positive for calculate form control area,Negative for calculate form Draw area
        private LegendSpaceReserve legendSpaceReserve;
        private bool legendDrawBackground;

        private IBindingData dataMember;

        //Use for save draw information
        private Bitmap bmpChart;

        private bool redrawable = true; //if true then RedrawChart active

        //For not shadow text (in print , ..)
        private bool antiAlias = false;

        //Use for DesignMode
        private readonly IBindingData dataSample;
        private List<SingleLineText> legendRowNameSample;

        //This chart send component that changed parent!
        private bool bNotChangeComponentMessage = false;

        protected const int SpaceNeed = 5;

        #endregion

        #region Property

        [Browsable(true)]
        [Description("Title of chart.Show top-center chart")]
        [Category("Chart")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (SingleLineText slt in TextByFormat)
                    sb.Append(slt.ToString());
                return sb.ToString();
            }
            set
            {
                TextByFormat.Clear();
                TextByFormat.Add(new SingleLineText());
                TextByFormat[0].Add(value,
                    SingleLineText.TextFromBaseLine.Normal,
                    true);
                //RedrawChart() : Automatically call RedrawChart
            }
        }

        [Browsable(false)]
        [Description("Title (formated text) of chart.Show top-center chart")]
        [Category("Chart")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public List<SingleLineText> TextByFormat { get; }

        [Browsable(true)]
        [Description("Show/Hide Title of chart")]
        [Category("Chart")]
        [DefaultValue(ShowTextMode.None)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public ShowTextMode ShowText
        {
            get { return showTitle; }
            set { showTitle = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Font of draw Title")]
        [Category("Chart")]
        [SaveLoad]
        public Font FontTitle
        {
            get { return fFontTitle; }
            set { fFontTitle = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Color of content of bar/line/chunk/...")]
        [Category("Chart")]
        [Editor(typeof(ColorArrayEditor),
                typeof(System.Drawing.Design.UITypeEditor))]
        [SaveLoad]
        public Color[] Colors
        {
            get { return colors; }
            set { colors = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Space between Text and Chart area.Use if Text is drawn Top")]
        [Category("Chart")]
        [DefaultValue(10)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(3, int.MaxValue)]
        public int SpaceAfterText
        {
            get { return nSpaceAfterText; }
            set { nSpaceAfterText = (value > 3 ? value : 3); RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Space between Bottom and Axis")]
        [Category("Chart")]
        [DefaultValue(10)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(5, int.MaxValue)]
        public int SpaceBottom
        {
            get { return base.Padding.Bottom; }
            set
            {
                base.Padding = new Padding(
                    base.Padding.Left,
                    base.Padding.Top,
                    base.Padding.Right,
                    (value > 5 ? value : 5)
                    );
                RedrawChart();
            }
        }

        [Browsable(true)]
        [Description("Space between Top and top of text or Graph area")]
        [Category("Chart")]
        [DefaultValue(10)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(5, int.MaxValue)]
        public int SpaceTop
        {
            get { return base.Padding.Top; }
            set
            {
                base.Padding = new Padding(
                    base.Padding.Left,
                    (value > 5 ? value : 5),
                    base.Padding.Right,
                    base.Padding.Bottom
                    );
                RedrawChart();
            }
        }

        [Browsable(true)]
        [Description("Space between Left and Axis")]
        [Category("Chart")]
        [DefaultValue(10)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(5, int.MaxValue)]
        public int SpaceLeft
        {
            get { return base.Padding.Left; }
            set
            {
                base.Padding = new Padding(
                    (value > 5 ? value : 5),
                    base.Padding.Top,
                    base.Padding.Right,
                    base.Padding.Bottom
                    );
                RedrawChart();
            }
        }

        [Browsable(true)]
        [Description("Space between right and end of Axis")]
        [Category("Chart")]
        [DefaultValue(10)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(5, int.MaxValue)]
        public int SpaceRight
        {
            get { return base.Padding.Right; }
            set
            {
                base.Padding = new Padding(
                    base.Padding.Left,
                    base.Padding.Top,
                    (value > 5 ? value : 5),
                    base.Padding.Bottom
                    );
                RedrawChart();
            }
        }

        [Browsable(true)]
        [Category("Chart")]
        [Description("Legend Alignment from AllArea or ChartArea")]
        [DefaultValue(ContentAlignment.TopRight)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public ContentAlignment LegendAlignment
        {
            get { return legendAlignment; }
            set { legendAlignment = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Category("Chart")]
        [Description("Show/Hode legend of graph")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public bool LegendShow
        {
            get { return legendShow; }
            set { legendShow = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Positive for calculate form control area,Negative for calculate form Draw Chart area")]
        [Category("Chart")]
        [DefaultValue(-1)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(int.MinValue, int.MaxValue)]
        public int LegendHorizontalSpace
        {
            get { return legendHorizontalSpace; }
            set { legendHorizontalSpace = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Reserve space from edge")]
        [Category("Chart")]
        [DefaultValue(LegendSpaceReserve.None)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public LegendSpaceReserve LegendSpaceReserve
        {
            get { return legendSpaceReserve; }
            set { legendSpaceReserve = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Positive for calculate form control area,Negative for calculate form Draw Chart area")]
        [Category("Chart")]
        [DefaultValue(-1)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(int.MinValue, int.MaxValue)]
        public int LegendVerticalSpace
        {
            get { return legendVerticalSpace; }
            set { legendVerticalSpace = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Draw transparency of background when draw legend")]
        [Category("Chart")]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [SaveLoad]
        public bool LegendDrawBackground
        {
            get { return legendDrawBackground; }
            set { legendDrawBackground = value; RedrawChart(); }
        }

        [Browsable(true)]
        [Description("Font of legend")]
        [Category("Chart")]
        [SaveLoad]
        public Font FontLegend
        {
            get { return fFontLegend; }
            set { fFontLegend = value; RedrawChart(); }
        }

        [Browsable(false)]
        [Description("Legend Items or Row Names")]
        [Category("Chart")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<SingleLineText> LegendItems { get; }

        [Browsable(false)]
        [Description("Define custom data for saev and get it in load")]
        [Category("Chart")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IChartCustomData CustomData { get; set; }

        /// <summary>
        /// get or set data member of the connected data source. Chart reads data of this data member.
        /// </summary>
        [
         DefaultValue(null),
         Category("Chart"),
         Browsable(false),
         Description("Defines data member of the connected data source. Chart reads data of this data member.")
        ]
        public IBindingData DataMember
        {
            get
            {
                return dataMember;
            }
            set
            {
                dataMember = value;
                if (!DesignMode)
                    RedrawChart();
            }
        }

        [Browsable(false)]
        [Category("Chart")]
        [DefaultValue(true)]
        //if true then RedrawChart act
        public bool Redrawable
        {
            get { return redrawable; }
            set { redrawable = value; RedrawChart(); }
        }
        [Browsable(false)]
        [Category("Chart")]
        [DefaultValue(false)]
        //true for not shadow (color shadow) in text
        public bool AntiAlias
        {
            get { return antiAlias; }
            set { antiAlias = value; RedrawChart(); }
        }

        [Category("Chart")]
        [DefaultValue(null)]
        public BaseChartComponent Component
        {
            get { return component; }
            set
            {
                if (bNotChangeComponentMessage)
                    return;
                bNotChangeComponentMessage = true;
                if (component != value)
                {
                    if (component != null)
                    {
                        BaseChartComponent old = component;

                        //Sequence of two commands below is important
                        component = null;
                        old.Parent = null;
                    }
                    component = value;
                    if (component != null)
                    {
                        component.Parent = new ChartController(this);
                        if (!DesignMode)
                        {
                            component.RestoreDefaultConfiguration(this);
                        }
                    }
                    OnComponentChanged();
                    RedrawChart();
                }
                else
                {
                    if (component != null)
                        component.RestoreDefaultConfiguration(this);
                    OnComponentChanged();
                }
                bNotChangeComponentMessage = false;
            }
        }
        #endregion

        #region Override
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Size.Width > 0 && this.Size.Height > 0)
            {
                ChartPaint(e);
            }
            base.OnPaint(e);
        }

        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            RedrawChart();
            base.OnSizeChanged(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        //protected override void OnInvalidated(InvalidateEventArgs e)
        //{
        //    RedrawChart(false);
        //}

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            RedrawChart();
        }

        [SaveLoad]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; RedrawChart(); }
        }

        [SaveLoad]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; RedrawChart(); }
        }

        [SaveLoad("FontText")]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; RedrawChart(); }
        }

        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; RedrawChart(); }
        }

        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; RedrawChart(); }
        }

        [SaveLoad]
        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; RedrawChart(); }
        }


        [DefaultValue(false)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            get { return false; }
            set { base.TabStop = false; }
        }


        [Browsable(false)]
        internal IDrawManager DrawManager { get; set; /*Only use in IDrawManager class*/ }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Point AutoScrollOffset { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoSize { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AllowDrop { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override BindingContext BindingContext { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool CausesValidation { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Margin { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }
        #endregion

        #region Method main
        public Chart()
        {
            DataTable dtSample = new DataTable("Test");
            dtSample.Columns.Add("X", typeof(Int32));
            dtSample.Columns.Add("12.3", typeof(Double));
            dtSample.Columns.Add("Test", typeof(Int32));

            dtSample.Rows.Add(19, 0, 22);
            dtSample.Rows.Add(12, 21.5, 0);
            dtSample.Rows.Add(0, 31.5, 25);

            dataSample = Bind.FromDataTable(dtSample);

            legendRowNameSample = new List<SingleLineText> { new SingleLineText("Legend") };
            SingleLineText slt = new SingleLineText();
            slt.Add("E=X_1!Y^2!Z", '!', '_', '^');
            legendRowNameSample.Add(slt);
            legendRowNameSample.Add(new SingleLineText("123"));

            //Initalize variables
            bmpChart = null;
            CustomData = null;
            TextByFormat = new List<SingleLineText>();
            showTitle = ShowTextMode.None;
            fFontTitle = new Font("Arial", 20);
            fFontLegend = this.Font;
            colors = new Color[] {
                Color.Green,
                Color.GhostWhite,
                Color.Red,
                Color.Blue,
                Color.SeaGreen,
                Color.Gray,
                Color.Pink,
                Color.RoyalBlue,
                Color.LightGreen,
                Color.Gold,
                Color.LightPink,
                Color.LightBlue,
                Color.Lime,
                Color.Yellow,
                Color.Magenta,
                Color.Khaki
            };
            redrawable = true;
            base.Padding = new Padding(10);
            nSpaceAfterText = 10;
            legendAlignment = ContentAlignment.TopRight;
            legendShow = false;
            legendHorizontalSpace = -1;
            legendVerticalSpace = -1;
            legendSpaceReserve = SMAH1.Forms.Chart.LegendSpaceReserve.None;
            LegendItems = new List<SingleLineText>();
            dataMember = null;
            antiAlias = false;
            DrawManager = null;
            legendDrawBackground = true;

            LegendItems.CountChanged += new EventHandler(LegendItems_CountChanged);
            TextByFormat.CountChanged += new EventHandler(TextByFormat_CountChanged);
        }

        public void RedrawChart()
        {
            RedrawChart(true);
        }

        protected void RedrawChart(bool withRefresh)
        {
            if (DrawManager != null)
                DrawManager.Redraw(this);
            else
                RedrawChartFinal(withRefresh);
        }

        internal void RedrawChartCallFromIDrawManager()    //Only use in IDrawManager
        {
            if (!redrawable)
                return;

            if (bmpChart != null)
            {
                bmpChart.Dispose();
                bmpChart = null;
            }

            if (this.ClientSize.Width > 0 && this.ClientSize.Height > 0)
            {
                bmpChart = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                DrawChart(ref bmpChart);
            }
        }

        internal void RedrawChartFinalCallFromIDrawManager()    //Only use in IDrawManager
        {
            this.Refresh();
        }

        protected void RedrawChartFinal(bool withRefresh)
        {
            if (!redrawable)
                return;

            if (bmpChart != null)
            {
                bmpChart.Dispose();
                bmpChart = null;
            }

            if (withRefresh)
                Refresh();
        }

        private void ChartPaint(PaintEventArgs e)
        {
            if (bmpChart == null)
            {
                bmpChart = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                DrawChart(ref bmpChart);
            }

            if (bmpChart != null)
            {
                if (this.Enabled)
                {
                    e.Graphics.DrawImage(
                        bmpChart, e.ClipRectangle,
                        e.ClipRectangle, GraphicsUnit.Pixel);
                }
                else
                {
                    e.Graphics.DrawImage(
                        bmpChart.Grayscale(), e.ClipRectangle,
                        e.ClipRectangle, GraphicsUnit.Pixel);
                }
            }
        }

        public void DrawChart(ref Bitmap bmp)
        {
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                Rectangle rc = new Rectangle(ClientRectangle.Location, bmp.Size);
                Pen penBorder = new Pen(ForeColor);

                //Draw background
                SolidBrush brushErase = new SolidBrush(BackColor);
                gr.FillRectangle(brushErase, rc);

                rc.Inflate(-1, -1);

                brushErase.Dispose();

                System.Drawing.Text.TextRenderingHint saveGraphics =
                    gr.TextRenderingHint;

                if (DesignMode)
                    ChartPaintWithTable(gr, dataSample, rc);
                else
                    ChartPaintWithTable(gr, dataMember, rc);

                gr.TextRenderingHint = saveGraphics;

                gr.DrawRectangle(penBorder, rc);
                penBorder.Dispose();
            }
        }
        #endregion

        #region Paint of chart
        private void ChartPaintWithTable(Graphics grChart, IBindingData data, Rectangle rcClientRect)
        {
            if (data == null)
                data = Bind.FromDataTable(new DataTable());

            if (AntiAlias)
                grChart.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            if (component != null)
                component.PaintStart(grChart, data);

            bool bShowText = (ShowText == ShowTextMode.Top);

            Brush brTitle = new SolidBrush(ForeColor);

            StringFormat stringFormat = StringFormat.GenericDefault;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.Trimming = StringTrimming.None;
            stringFormat.FormatFlags =
                StringFormatFlags.NoWrap |
                StringFormatFlags.LineLimit |
                StringFormatFlags.DirectionVertical;

            int nFinalSpaceOfTop = SpaceTop;
            int nFinalSpaceOfBottom = SpaceBottom;
            int nFinalSpaceOfLeft = SpaceLeft;
            int nFinalSpaceOfRight = SpaceRight;

            if (bShowText)
            {
                foreach (SingleLineText slt in TextByFormat)
                {
                    SizeF szText = new SizeF(0, 0);
                    szText = slt.MeasureString(grChart, FontTitle, false);

                    float x = (rcClientRect.Width - 2 - szText.Width) / 2;
                    slt.DrawString(grChart, FontTitle, brTitle,
                        x, nFinalSpaceOfTop, false);

                    nFinalSpaceOfTop += (int)szText.Height;
                }

                nFinalSpaceOfTop += nSpaceAfterText;
            }

            Rectangle rcClient = new Rectangle(
                nFinalSpaceOfLeft,
                nFinalSpaceOfTop,
                //Width
                rcClientRect.Width - (nFinalSpaceOfLeft + nFinalSpaceOfRight),
                //Height
                rcClientRect.Height - (nFinalSpaceOfBottom + nFinalSpaceOfTop)
                );

            SetupLegendSpaceReserve(grChart, brTitle, stringFormat, ref rcClient);

            RectangleF rcChartDrawArea = new RectangleF(rcClient.Location, rcClient.Size);

            //Column text space need
            if (this.component != null)
            {
                component.Paint(grChart, data, rcClient);
                rcChartDrawArea = this.component.DrawArea;
            }

            #region Draw Legend
            if (LegendShow)
            {
                DrawLegend(grChart, rcClientRect, brTitle, stringFormat, rcChartDrawArea, false);
            }
            #endregion

            #region Draw Title if cneter
            if (ShowText == ShowTextMode.Center && (int)rcChartDrawArea.Height > 0 && (int)rcChartDrawArea.Width > 0)
            {
                stringFormat.FormatFlags &= ~StringFormatFlags.DirectionVertical;
                stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                stringFormat.Alignment = StringAlignment.Center;
                using (Bitmap bmpTitle = new Bitmap((int)rcChartDrawArea.Width, (int)rcChartDrawArea.Height))
                {
                    using (Graphics grTitle = Graphics.FromImage(bmpTitle))
                    {
                        // Drow by Rotate
                        float angleRotate = 90F;
                        if (rcChartDrawArea.Width != 0)
                            angleRotate = (float)(
                                Math.Atan(rcChartDrawArea.Height / rcChartDrawArea.Width)
                                * (180 / Math.PI));
                        //const float radinRotate = (float)(Math.PI * degRotate / 180);

                        Matrix mx = new Matrix(1, 0, 0, 1, 0, 0);
                        mx.Rotate(-angleRotate, MatrixOrder.Append);
                        mx.Translate(rcChartDrawArea.Width / 2,
                            rcChartDrawArea.Height / 2, MatrixOrder.Append);
                        grTitle.Transform = mx;
                        grTitle.DrawString(
                            this.Text, this.FontTitle,
                            brTitle, 0, 0,
                            stringFormat);
                    }
                    grChart.DrawImage(bmpTitle,
                        rcChartDrawArea.Left,
                        rcChartDrawArea.Top
                        );
                }
            }
            #endregion

            stringFormat.Dispose();
            brTitle.Dispose();

            if (this.component != null)
                this.component.PaintFinish(grChart, data);
        }

        private void SetupLegendSpaceReserve(Graphics grChart, Brush brTitle, StringFormat stringFormat, ref Rectangle rcClient)
        {
            //Legend space need
            if (LegendSpaceReserve != SMAH1.Forms.Chart.LegendSpaceReserve.None)
            {
                int l, r, t, b; //left, right, top, bottom
                l = r = t = b = 0;

                Size szLegendSpaceReserve = DrawLegend(grChart, new Rectangle(),
                    brTitle, stringFormat, new RectangleF(), true);
                switch (LegendSpaceReserve)
                {
                    case SMAH1.Forms.Chart.LegendSpaceReserve.Horizontal:
                        szLegendSpaceReserve = new Size(szLegendSpaceReserve.Width, 0);
                        break;
                    case SMAH1.Forms.Chart.LegendSpaceReserve.Vertical:
                        szLegendSpaceReserve = new Size(0, szLegendSpaceReserve.Height);
                        break;
                }

                switch (legendAlignment)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.TopRight:
                        t = szLegendSpaceReserve.Height + SpaceNeed * 2;
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomRight:
                        b = szLegendSpaceReserve.Height + SpaceNeed * 2;
                        break;
                }
                switch (legendAlignment)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.MiddleLeft:
                        l = szLegendSpaceReserve.Width + SpaceNeed * 2;
                        break;
                    case ContentAlignment.TopRight:
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.MiddleRight:
                        r = szLegendSpaceReserve.Width + SpaceNeed * 2;
                        break;
                }

                rcClient = new Rectangle(
                        rcClient.X + l, rcClient.Y + t,
                        rcClient.Width - (l + r), rcClient.Height - (t + b));
            }
        }

        private Size DrawLegend(Graphics grChart,
                    Rectangle rcClientRect, Brush brTitle,
                    StringFormat stringFormat, RectangleF rcChartDrawArea,
                    bool onlyCalculateSize)
        {
            Size szRet = new Size(0, 0);

            List<SingleLineText> list = LegendItems;
            if (DesignMode)
                list = legendRowNameSample;
            if (list.Count != 0)
            {
                stringFormat.FormatFlags &= ~StringFormatFlags.DirectionVertical;
                stringFormat.Alignment = StringAlignment.Near;

                float w, h;
                w = h = float.MinValue;
                foreach (SingleLineText slt in list)
                {
                    SizeF sz = slt.MeasureString(grChart, FontLegend);
                    if (w < sz.Width)
                        w = sz.Width;
                    if (h < sz.Height)
                        h = sz.Height;
                }

                int itemHorSpace = 1;
                int itemVerSpace = 10;
                int maxItemTextWidth = (int)Math.Ceiling(w);
                int maxItemTextHeight = (int)Math.Ceiling(h);
                int itemColorWidth = maxItemTextHeight;
                int widthLegend = maxItemTextWidth + 3 * itemVerSpace + itemColorWidth;
                int heightLegend = maxItemTextHeight * list.Count + itemHorSpace * (list.Count + 1);

                szRet = new Size(widthLegend, heightLegend);

                if (!onlyCalculateSize)
                {
                    Point ptOffset = new Point(0, 0);
                    //For ptOffset.Y
                    switch (legendAlignment)
                    {
                        case ContentAlignment.TopLeft:
                        case ContentAlignment.TopCenter:
                        case ContentAlignment.TopRight:
                            if (legendVerticalSpace >= 0)
                                ptOffset.Y = rcClientRect.Top + legendVerticalSpace;
                            else
                                ptOffset.Y = (int)rcChartDrawArea.Top - legendVerticalSpace;
                            break;
                        case ContentAlignment.BottomLeft:
                        case ContentAlignment.BottomCenter:
                        case ContentAlignment.BottomRight:
                            if (legendVerticalSpace >= 0)
                                ptOffset.Y = rcClientRect.Bottom - legendVerticalSpace - heightLegend;
                            else
                                ptOffset.Y = (int)rcChartDrawArea.Bottom + legendVerticalSpace - heightLegend;
                            break;
                        case ContentAlignment.MiddleLeft:
                        case ContentAlignment.MiddleCenter:
                        case ContentAlignment.MiddleRight:
                            if (legendVerticalSpace >= 0)
                                ptOffset.Y = rcClientRect.Top + (rcClientRect.Height - heightLegend) / 2;
                            else
                                ptOffset.Y = (int)rcChartDrawArea.Top + (int)(rcChartDrawArea.Height - heightLegend) / 2;
                            break;
                    }
                    //For ptOffset.X
                    switch (legendAlignment)
                    {
                        case ContentAlignment.TopLeft:
                        case ContentAlignment.BottomLeft:
                        case ContentAlignment.MiddleLeft:
                            if (legendHorizontalSpace >= 0)
                                ptOffset.X = rcClientRect.Left + legendHorizontalSpace;
                            else
                                ptOffset.X = (int)rcChartDrawArea.Left - legendHorizontalSpace;
                            break;
                        case ContentAlignment.TopRight:
                        case ContentAlignment.BottomRight:
                        case ContentAlignment.MiddleRight:
                            if (legendHorizontalSpace >= 0)
                                ptOffset.X = rcClientRect.Right - legendHorizontalSpace - widthLegend;
                            else
                                ptOffset.X = (int)rcChartDrawArea.Right + legendHorizontalSpace - widthLegend;
                            break;
                        case ContentAlignment.TopCenter:
                        case ContentAlignment.BottomCenter:
                        case ContentAlignment.MiddleCenter:
                            if (legendHorizontalSpace >= 0)
                                ptOffset.X = rcClientRect.Left + (rcClientRect.Width - widthLegend) / 2;
                            else
                                ptOffset.X = (int)rcChartDrawArea.Left + (int)(rcChartDrawArea.Width - widthLegend) / 2;
                            break;
                    }

                    Brush br = new SolidBrush(Color.FromArgb(64,
                        (BackColor.R < 192 ? BackColor.R + 64 : BackColor.R - 192),
                        (BackColor.G < 192 ? BackColor.G + 64 : BackColor.G - 192),
                        (BackColor.B < 192 ? BackColor.B + 64 : BackColor.B - 192)
                        ));
                    if (LegendDrawBackground)
                        grChart.FillRectangle(br, ptOffset.X, ptOffset.Y, widthLegend, heightLegend);
                    br.Dispose();

                    //Draw Colors and legend string
                    int x1 = itemVerSpace + ptOffset.X;
                    int x2 = itemVerSpace * 2 + itemColorWidth + ptOffset.X;
                    int y = itemHorSpace + ptOffset.Y;
                    Pen pen = new Pen(ForeColor, 1F);
                    for (int i = 0; i < list.Count; i++)
                    {
                        br = new SolidBrush(colors[i % colors.Length]);
                        Rectangle rc = new Rectangle(x1, y, itemColorWidth, maxItemTextHeight);
                        rc.Inflate(-2, -3);
                        grChart.FillRectangle(br, rc);
                        grChart.DrawRectangle(pen, rc);
                        rc = new Rectangle(x2, y, maxItemTextWidth, maxItemTextHeight);
                        SingleLineText slt = list[i];
                        slt.DrawString(grChart, this.FontLegend, brTitle, rc.X, rc.Y);
                        y += (itemHorSpace + maxItemTextHeight);
                        br.Dispose();
                    }
                    pen.Dispose();
                }
            }

            return szRet;
        }
        #endregion

        #region Print & Save Image Of Chart
        public bool Print(bool bFitToPaper, string strDocName)
        {
            bool bRet = false;
            SMAH1.Print.SimplePrinterBitmap printer = new SMAH1.Print.SimplePrinterBitmap();

            // Customize the document and sizing mode
            printer.Document.DocumentName = strDocName;
            printer.FitToArea = bFitToPaper;
            OnBeginPrint(printer.Document);

            // Ask user to select a printer and set options for it
            if (!printer.ShowOptions())
                return false;

            // Create and prepare a bitmap to be printed into printer DC
            Bitmap bmp = null;
            if (bFitToPaper)
            {
                // Full screen
                bmp = new Bitmap(
                    printer.Document.DefaultPageSettings.Bounds.Width,
                    printer.Document.DefaultPageSettings.Bounds.Height);
            }
            else
            {
                // WYSIWYG
                bmp = (Bitmap)bmpChart.Clone();
            }
            // Draw On the bitmap
            DrawChart(ref bmp);

            // Set bitmap for printing
            printer.Image = bmp;

            // Ask printer class to print its bitmap.
            bRet = printer.Print();

            // Remove bitmap from memory
            bmp.Dispose();
            bmp = null;

            return bRet;
        }

        protected Image DrawAdvanceHelper(Size sz)
        {
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            DrawChart(ref bmp);
            return bmp;
        }

        public void SaveImageOfChart(string fileName, ImageFormat format)
        {
            SaveImageOfChart(fileName, format, new Size(0, 0));
        }

        public void SaveImageOfChart(string fileName, ImageFormat format, Size size)
        {
            // Create and prepare a bitmap to be printed into printer DC
            Bitmap bmp;

            if (size.Width <= 0 || size.Height <= 0)
            {
                if (bmpChart != null)
                {
                    bmp = (Bitmap)bmpChart.Clone();
                }
                else if (this.Size.Width <= 0 || this.Size.Height <= 0)
                    bmp = new Bitmap(
                        Screen.PrimaryScreen.Bounds.Width,
                        Screen.PrimaryScreen.Bounds.Height);
                else
                    bmp = new Bitmap(this.Size.Width, this.Size.Height);
                DrawChart(ref bmp);
            }
            else
                bmp = (Bitmap)DrawAdvanceHelper(size);

            bmp.Save(fileName, format);

            // Remove bitmap from memory
            bmp.Dispose();
            bmp = null;
        }

        public void SaveImageOfChart(Stream stream, ImageFormat format)
        {
            SaveImageOfChart(stream, format, new Size(0, 0));
        }

        public void SaveImageOfChart(Stream stream, ImageFormat format, Size size)
        {
            //TODO : If IDrawManager,Throw exception

            // Create and prepare a bitmap to be printed into printer DC
            Bitmap bmp;

            if (size.Width <= 0 || size.Height <= 0)
            {
                if (bmpChart != null)
                {
                    bmp = (Bitmap)bmpChart.Clone();
                }
                else if (this.Size.Width <= 0 || this.Size.Height <= 0)
                    bmp = new Bitmap(
                        Screen.PrimaryScreen.Bounds.Width,
                        Screen.PrimaryScreen.Bounds.Height);
                else
                    bmp = new Bitmap(this.Size.Width, this.Size.Height);
                DrawChart(ref bmp);
            }
            else
                bmp = (Bitmap)DrawAdvanceHelper(size);

            bmp.Save(stream, format);

            // Remove bitmap from memory
            bmp.Dispose();
            bmp = null;
        }

        internal void SaveImageOfChartByDrawManager(Bitmap bmp)    //Only use in IDrawManager
        {
            DrawChart(ref bmp);
        }
        #endregion

        #region Save & Load Configuration Of Chart

        public bool SaveConfigurationOfChart(TextWriter writer)
        {
            return SaveConfigurationOfChart(writer, true);
        }

        public bool SaveConfigurationOfChart(TextWriter writer, bool withComponent)
        {
            bool bRet = false;
            try
            {
                XmlDocument xmlDoc = CreateXmlForSave(withComponent);

                xmlDoc.Save(writer);
                bRet = true;
            }
            catch { bRet = false; }

            return bRet;
        }

        public bool SaveConfigurationOfChart(string filename)
        {
            return SaveConfigurationOfChart(filename, true);
        }

        public bool SaveConfigurationOfChart(string filename, bool withComponent)
        {
            bool bRet = false;
            try
            {
                XmlDocument xmlDoc = CreateXmlForSave(withComponent);

                xmlDoc.Save(filename);
                bRet = true;
            }
            catch { bRet = false; }

            return bRet;
        }

        public string SaveConfigurationOfChartToString()
        {
            return SaveConfigurationOfChartToString(true);
        }

        public string SaveConfigurationOfChartToString(bool withComponent)
        {
            string xmlOfConfiguration = "";
            bool bRet = false;
            using (MemoryStream ms = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(ms);
                bRet = SaveConfigurationOfChart(sw, withComponent);
                sw.Flush();

                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                xmlOfConfiguration = sr.ReadToEnd();
            }
            return bRet ? xmlOfConfiguration : null;
        }

        public bool LoadConfigurationOfChartFromStream(TextReader reader)
        {
            bool bRet = false;

            bool oldRedrawable = Redrawable;
            Redrawable = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(reader);
                LoadFromXml(xmlDoc);
                bRet = true;
            }
            catch (XmlException exp)
            {
                System.Diagnostics.Trace.WriteLine("Load xml faild : " + exp.Message);
                bRet = false;
            }
            catch /*(Exception exc)*/ { bRet = false; }
            Redrawable = oldRedrawable;

            return bRet;
        }

        public bool LoadConfigurationOfChartFromFile(string filename)
        {
            bool bRet = false;

            bool oldRedrawable = Redrawable;
            Redrawable = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filename);
                LoadFromXml(xmlDoc);
                bRet = true;
            }
            catch (XmlException exp)
            {
                System.Diagnostics.Trace.WriteLine("Load xml faild : " + exp.Message);
                bRet = false;
            }
            catch /*(Exception exc)*/ { bRet = false; }
            Redrawable = oldRedrawable;

            return bRet;
        }

        public bool LoadConfigurationOfChartFromString(string xmlOfConfiguration)
        {
            if (string.IsNullOrEmpty(xmlOfConfiguration))
                return false;

            bool bRet = false;
            using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(xmlOfConfiguration)))
            {
                StreamReader sr = new StreamReader(ms);
                bRet = LoadConfigurationOfChartFromStream(sr);
            }
            return bRet;
        }

        #region Load & Save - internal static functions
        internal static XmlElement CreateRootXmlForSave()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);

            // Create the root element
            XmlElement rootNode = xmlDoc.CreateElement(ChartConst.CHART_TAG);
            xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);
            xmlDoc.AppendChild(rootNode);

            return rootNode;
        }
        internal static void CreateComponentXmlForSave(XmlElement rootNode, BaseChartComponent component)
        {
            if (component != null)
            {
                XmlElement node = component.CreateXmlForSave(
                    rootNode.OwnerDocument, ChartConst.COMPONENT_TAG);
                rootNode.AppendChild(node);
            }
        }
        #endregion

        #region Load & Save From XML

        private XmlDocument CreateXmlForSave(bool withComponent)
        {
            XmlElement node;
            XmlElement rootNode = CreateRootXmlForSave();
            XmlDocument xmlDoc = rootNode.OwnerDocument;

            System.Collections.Generic.Dictionary<String, PropertyInfo> propSaveLoad = new System.Collections.Generic.Dictionary<String, PropertyInfo>();
            foreach (PropertyInfo prop in (typeof(Chart)).GetProperties())
            {
                foreach (object attribute in prop.GetCustomAttributes(true))
                {
                    if (attribute is SaveLoadAttribute)
                    {
                        if (string.IsNullOrEmpty(attribute.ToString()))
                            propSaveLoad.Add(prop.Name, prop);
                        else
                            propSaveLoad.Add(attribute.ToString(), prop);
                    }
                }
            }

            foreach (string nodeName in propSaveLoad.Keys)
            {
                PropertyInfo thisProp = propSaveLoad[nodeName];
                if (thisProp != null)
                {
                    object value = thisProp.GetValue(this, null);
                    string valueText;
                    if (thisProp.PropertyType.IsArray)
                    {
                        XmlNode nodeArray = xmlDoc.CreateElement(thisProp.Name);
                        Array arr = value as Array;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            valueText = "";
                            object v = arr.GetValue(i);
                            if (SerializeData.Serialize(v.GetType(), v, out valueText))
                            {
                                node = xmlDoc.CreateElement("Item");
                                node.AppendChild(xmlDoc.CreateTextNode(valueText));
                                nodeArray.AppendChild(node);
                            }
                        }
                        rootNode.AppendChild(nodeArray);
                    }
                    else
                    {
                        valueText = "";
                        if (SerializeData.Serialize(thisProp.PropertyType, value, out valueText))
                        {
                            node = xmlDoc.CreateElement(nodeName);
                            node.AppendChild(xmlDoc.CreateTextNode(valueText));
                            rootNode.AppendChild(node);
                        }
                        else
                        {
                            if (valueText != null)
                                throw new Exception(valueText);
                            else
                                throw new Exception("in '" + thisProp.Name + "' ,Can not determine type ");
                        }
                    }
                }
            }

            //CustomData
            if (CustomData != null)
            {
                XmlNode nodeData = xmlDoc.CreateElement(ChartConst.CUSTOM_TAG);

                node = xmlDoc.CreateElement(ChartConst.CUSTOM_SIGNATURE_TAG);
                node.AppendChild(xmlDoc.CreateTextNode(CustomData.CustomDataSignature));
                nodeData.AppendChild(node);

                node = xmlDoc.CreateElement(ChartConst.CUSTOM_VALUE_TAG);
                node.AppendChild(xmlDoc.CreateTextNode(CustomData.GetChartCustomData(this)));
                nodeData.AppendChild(node);

                rootNode.AppendChild(nodeData);
            }

            //Create component root element
            if (withComponent)
                CreateComponentXmlForSave(rootNode, Component);

            return xmlDoc;
        }

        private void LoadFromXml(XmlDocument xmlDoc)
        {
            bool saveRedrawable = this.Redrawable;
            this.Redrawable = false;

            System.Collections.Generic.Dictionary<String, PropertyInfo> propSaveLoad = new System.Collections.Generic.Dictionary<String, PropertyInfo>();
            foreach (PropertyInfo prop in (typeof(Chart)).GetProperties())
            {
                foreach (object attribute in prop.GetCustomAttributes(true))
                {
                    if (attribute is SaveLoadAttribute)
                    {
                        if (attribute.ToString() == "")
                            propSaveLoad.Add(prop.Name, prop);
                        else
                            propSaveLoad.Add(attribute.ToString(), prop);
                    }
                }
            }

            foreach (XmlNode node in xmlDoc.GetElementsByTagName(ChartConst.CHART_TAG)[0].ChildNodes)
            {
                if (node.Name == ChartConst.COMPONENT_TAG && Component != null)
                {
                    Component.LoadFromXml(node);
                    continue;
                }

                String s = node.InnerText;
                if (propSaveLoad.ContainsKey(node.Name))
                {
                    PropertyInfo thisProp = propSaveLoad[node.Name];
                    if (thisProp != null)
                    {
                        if (thisProp.PropertyType.IsArray)
                        {
                            //Find type of items
                            Object v = thisProp.GetValue(this, null);
                            Type arrayType = v.GetType().GetElementType();

                            Array arr = Array.CreateInstance(arrayType, node.ChildNodes.Count);

                            for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
                            {
                                XmlNode nodeItem = node.ChildNodes[i];
                                string valueText = nodeItem.InnerText;
                                if (SerializeData.Deserialize(arrayType, valueText, out object value))
                                {
                                    if (value != null)
                                        arr.SetValue(value, i);
                                    else
                                        arr.SetValue(Activator.CreateInstance(arrayType), i);
                                }
                                else
                                    arr.SetValue(Activator.CreateInstance(arrayType), i);
                            }
                            thisProp.SetValue(this, arr, null);
                        }
                        else
                        {
                            string valueText = s;
                            if (SerializeData.Deserialize(thisProp.PropertyType, valueText, out object value))
                            {
                                if (value != null)
                                    thisProp.SetValue(this, value, null);
                            }
                            else
                            {
                                if (value != null)
                                    throw new Exception(value.ToString());
                                else
                                    throw new Exception("in '" + thisProp.Name + "' ,Can not determine type ");
                            }
                        }
                    }
                    continue;
                }

                if (node.Name == ChartConst.CUSTOM_TAG && CustomData != null)
                {
                    string signature = "";
                    string data = "";
                    foreach (XmlNode nodeArray in node.ChildNodes)
                    {
                        if (nodeArray.Name == ChartConst.CUSTOM_SIGNATURE_TAG)
                        {
                            signature = nodeArray.InnerText;
                        }
                        else if (nodeArray.Name == ChartConst.CUSTOM_VALUE_TAG)
                        {
                            data = nodeArray.InnerText;
                        }
                    }

                    if (signature == CustomData.CustomDataSignature)
                        CustomData.SetChartCustomData(this, data);

                    continue;
                }
            }

            Redrawable = saveRedrawable;
        }
        #endregion

        #endregion

        #region Chart Custom Events

        #region Begin Print
        public delegate void BeginPrintEventHandler(object sender, BeginPrintEventArgs e);

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Chart")]
        [Description("Custom print doctument.")]
        public event BeginPrintEventHandler BeginPrint;

        private void OnBeginPrint(PrintDocument doc)
        {
            BeginPrint?.Invoke(this, new BeginPrintEventArgs(doc));
        }
        #endregion

        #region Change Component
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Chart")]
        [Description("Component of chart was changed.")]
        public event EventHandler ComponentChanged;

        private void OnComponentChanged()
        {
            ComponentChanged?.Invoke(this, new EventArgs());
        }
        #endregion

        #endregion

        #region Get Events of variabels
        void LegendItems_CountChanged(object sender, EventArgs e)
        {
            RedrawChart();
            foreach (SingleLineText slt in LegendItems)
                slt.TextChanged += new EventHandler(LegendItem_TextChanged);
        }

        void LegendItem_TextChanged(object sender, EventArgs e)
        {
            RedrawChart();
        }

        void TextByFormat_CountChanged(object sender, EventArgs e)
        {
            RedrawChart();
            foreach (SingleLineText slt in TextByFormat)
                slt.TextChanged += new EventHandler(TextByFormatItem_TextChanged);
        }

        void TextByFormatItem_TextChanged(object sender, EventArgs e)
        {
            RedrawChart();
        }
        #endregion
    }
}
