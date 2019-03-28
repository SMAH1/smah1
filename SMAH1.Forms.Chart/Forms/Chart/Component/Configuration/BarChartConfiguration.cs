using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using SMAH1.Attributes;
using SMAH1.Forms.Chart.Component.BarComponent;
using SMAH1.Forms.Chart.Configuration;
using SMAH1.Forms.PropertyGridComponent;

namespace SMAH1.Forms.Chart.Component.Configuration
{
    public class BarChartConfiguration : AxileChartConfiguration
    {
        [Browsable(false)]
        public Bar Bar { get; }

        #region Property

        [Browsable(true)]
        [Description("Width of each bar")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(4, int.MaxValue)]
        public virtual int WidthBar
        {
            get { return Bar.WidthBar; }
            set { Bar.WidthBar = value; }
        }

        [Browsable(true)]
        [Description("Width of border line of bar")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(0, int.MaxValue)]
        public virtual int WidthBorderOfBarLine
        {
            get { return Bar.WidthBorderOfBarLine; }
            set { Bar.WidthBorderOfBarLine = value; }
        }

        [Browsable(true)]
        [Description("Gap between of bars of same column")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(0, int.MaxValue)]
        public virtual int GapBarOfColumn
        {
            get { return Bar.GapBarOfColumn; }
            set { Bar.GapBarOfColumn = value; }
        }

        [Browsable(true)]
        [Description("Gap between of group bars of columns")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(1, int.MaxValue)]
        public virtual int GapColumns
        {
            get { return Bar.GapColumns; }
            set { Bar.GapColumns = value; }
        }

        [Browsable(true)]
        [Description("Color of border of bar")]
        [Category("Color")]
        public virtual Color BorderOfBarColor
        {
            get { return Bar.BorderOfBarColor; }
            set { Bar.BorderOfBarColor = value; }
        }

        #endregion

        public BarChartConfiguration(Chart chart, ChartConfigurationForm parentForm)
            : base(chart, parentForm)
        {
            Bar = Chart.Component as Bar;
            if (Bar == null)
                throw new ArgumentException("Chart.Component is not Bar!");
        }
    }
}
