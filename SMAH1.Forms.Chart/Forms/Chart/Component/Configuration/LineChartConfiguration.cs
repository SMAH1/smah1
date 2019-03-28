using System;
using System.ComponentModel;
using System.Drawing.Design;
using SMAH1.Attributes;
using SMAH1.Forms.Chart.Component.Axile;
using SMAH1.Forms.Chart.Component.LineComponent;
using SMAH1.Forms.Chart.Configuration;
using SMAH1.Forms.PropertyGridComponent;

namespace SMAH1.Forms.Chart.Component.Configuration
{
    public class LineChartConfiguration : AxileChartConfiguration
    {
        [Browsable(false)]
        public Line Line { get; }

        #region Property

        [Browsable(true)]
        [Description("Width of each Column")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(4, int.MaxValue)]
        [NotBrowsableIf("SizingModeLabel", SizingModeLabel.Fit)]
        public virtual int WidthColumns
        {
            get { return Line.WidthColumns; }
            set { Line.WidthColumns = value; }
        }

        [Browsable(true)]
        [Description("Width of line")]
        [Category("Width and Space")]
        [Editor(typeof(NumericFloatUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForFloat(0.5F, 100F, 1, 0.1F)]
        [NotBrowsableIf("Layout", LayoutMode.Point)]
        public virtual float WidthLine
        {
            get { return Line.WidthLine; }
            set { Line.WidthLine = value; }
        }

        [Browsable(true)]
        [Description("Diagonal of point of each column")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(1, int.MaxValue)]
        [NotBrowsableIf("Layout", LayoutMode.Line)]
        public virtual int DiagonalPoint
        {
            get { return Line.DiagonalPoint; }
            set { Line.DiagonalPoint = value; }
        }

        [Browsable(true)]
        [Description("Show line,point or both in chart")]
        [Category("Layout")]
        public virtual LayoutMode Layout
        {
            get { return Line.Layout; }
            set { Line.Layout = value; ParentForm.RebindChartConfiguration(); }
        }

        [Browsable(true)]
        [Description("Point is circle or square")]
        [Category("Layout")]
        [NotBrowsableIf("Layout", LayoutMode.Line)]
        public virtual PointType PointKind
        {
            get { return Line.PointKind; }
            set { Line.PointKind = value; }
        }

        [Browsable(true)]
        [Description("Color of line and point Transparency")]
        [Category("Layout")]
        public virtual bool ColorOverTransparency
        {
            get { return Line.ColorOverTransparency; }
            set { Line.ColorOverTransparency = value; }
        }

        [Browsable(true)]
        [Category("Grid")]
        [Description("Draw vertical grid on chart")]
        public virtual HorizontalGridMode VerticalGrid
        {
            get { return Line.VerticalGrid; }
            set { Line.VerticalGrid = value; }
        }

        [Browsable(true)]
        [Category("Grid")]
        [Description("Style of horizontal and vertical grid on chart")]
        //TODO : If NotShow Horizontal AND Vertical grid,Not show this!
        public override GridDashStyle GridDashStyle
        {
            get { return base.GridDashStyle; }
            set { base.GridDashStyle = value; }
        }

        #endregion

        public LineChartConfiguration(Chart chart, ChartConfigurationForm parentForm)
            : base(chart, parentForm)
        {
            Line = Chart.Component as Line;
            if (Line == null)
                throw new ArgumentException("Chart.Component is not Line!");
        }
    }
}
