using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using SMAH1.Attributes;
using SMAH1.Forms.Chart.Component.Axile;
using SMAH1.Forms.Chart.Configuration;
using SMAH1.Forms.PropertyGridComponent;

namespace SMAH1.Forms.Chart.Component.Configuration
{
    public abstract class AxileChartConfiguration : BaseChartConfiguration
    {
        [Browsable(false)]
        public AxileBase AxileBase { get; }

        #region Property

        [Browsable(true)]
        [Description("String to add begin of Value Text")]
        [Category("Cation and Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual string PerfixValue
        {
            get { return AxileBase.PerfixValue; }
            set { AxileBase.PerfixValue = value; }
        }

        [Browsable(true)]
        [Description("String to add end of Value Text")]
        [Category("Cation and Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual string PostfixValue
        {
            get { return AxileBase.PostfixValue; }
            set { AxileBase.PostfixValue = value; }
        }

        [Browsable(true)]
        [Description("String to add begin of Label Text")]
        [Category("Cation and Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual string PerfixLabel
        {
            get { return AxileBase.PerfixLabel; }
            set { AxileBase.PerfixLabel = value; }
        }

        [Browsable(true)]
        [Description("String to add end of Label Text")]
        [Category("Cation and Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual string PostfixLabel
        {
            get { return AxileBase.PostfixLabel; }
            set { AxileBase.PostfixLabel = value; }
        }

        [Browsable(true)]
        [Description("Show/Hide text of axis labels and values")]
        [Category("Cation and Text")]
        public virtual ShowTextAxisMode ShowTextOfAxis
        {
            get { return AxileBase.ShowTextOfAxis; }
            set { AxileBase.ShowTextOfAxis = value; ParentForm.RebindChartConfiguration(); }
        }

        [Browsable(true)]
        [Description("Alignment of X-Axis label text")]
        [Category("Cation and Text")]
        public virtual StringAlignment LabelAlign
        {
            get { return AxileBase.LabelAlign; }
            set { AxileBase.LabelAlign = value; }
        }

        [Browsable(true)]
        [Description("Axis width")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(0, int.MaxValue)]
        public virtual int WidthAxisLine
        {
            get { return AxileBase.WidthAxisLine; }
            set { AxileBase.WidthAxisLine = value; }
        }

        [Browsable(true)]
        [Description("Draw normal mode or fit width graph to drawn control")]
        [Category("Sizing mode")]
        public virtual SizingModeLabel SizingModeLabel
        {
            get { return AxileBase.SizingModeLabel; }
            set { AxileBase.SizingModeLabel = value; ParentForm.RebindChartConfiguration(); }
        }

        [Browsable(true)]
        [Description("Scale for use in value axis in graph")]
        [Category("Sizing mode")]
        [RefreshProperties(RefreshProperties.All)]
        public virtual SizingModeValue SizingModeValue
        {
            get { return AxileBase.SizingModeValue; }
            set { AxileBase.SizingModeValue = value; ParentForm.RebindChartConfiguration(); }
        }

        [Browsable(true)]
        [Description("Scale of height (use when SizingModeValue is Auto)")]
        [Category("Sizing mode")]
        [Editor(typeof(NumericFloatUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForFloat(1, 10, 2, 0.01F)]
        [NotBrowsableIf("SizingModeValue", "SizingModeValue", SizingModeValue.Fix, SizingModeValue.Round)]
        public virtual float VerticalScale
        {
            get { return AxileBase.VerticalScale; }
            set { AxileBase.VerticalScale = value; }
        }

        [Browsable(true)]
        [Description("Maximum value of height (use when SizingModeValue is Fix)")]
        [Category("Sizing mode")]
        [Editor(typeof(NumericFloatUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForFloat(0, (float)(decimal.MaxValue / 2), 0, 1F)]
        [NotBrowsableIf("SizingModeValue", "SizingModeValue", SizingModeValue.Auto, SizingModeValue.Round)]
        public virtual float ValueMax
        {
            get { return AxileBase.ValueMax; }
            set { AxileBase.ValueMax = value; }
        }

        [Browsable(true)]
        [Description("Minimum value of height (use when SizingModeValue is Fix)")]
        [Category("Sizing mode")]
        [Editor(typeof(NumericFloatUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForFloat((float)(decimal.MinValue / 2), 0, 0, 1F)]
        [NotBrowsableIf("SizingModeValue", "SizingModeValue", SizingModeValue.Auto, SizingModeValue.Round)]
        public virtual float ValueMin
        {
            get { return AxileBase.ValueMin; }
            set { AxileBase.ValueMin = value; }
        }

        [Browsable(true)]
        [Description("Draw horizontal grid on chart")]
        [Category("Grid")]
        public virtual HorizontalGridMode HorizontalGrid
        {
            get { return AxileBase.HorizontalGrid; }
            set { AxileBase.HorizontalGrid = value; ParentForm.RebindChartConfiguration(); }
        }

        [Browsable(true)]
        [Description("Count of horizontal grid on chart")]
        [Category("Grid")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(2, 20)]
        [NotBrowsableIf("SizingModeValue", "HorizontalGrid", SizingModeValue.Round, HorizontalGridMode.None)]
        public virtual int CountOfGrid
        {
            get { return AxileBase.CountOfGrid; }
            set { AxileBase.CountOfGrid = value; }
        }

        [Browsable(true)]
        [Category("Grid")]
        [Description("Style of horizontal grid on chart")]
        [NotBrowsableIf("HorizontalGrid", HorizontalGridMode.None)]
        public virtual GridDashStyle GridDashStyle
        {
            get { return AxileBase.GridDashStyle; }
            set { AxileBase.GridDashStyle = value; }
        }

        [Browsable(true)]
        [Description("Color of grid")]
        [Category("Color")]
        public virtual Color GridColor
        {
            get { return AxileBase.GridColor; }
            set { AxileBase.GridColor = value; }
        }

        [Browsable(true)]
        [Description("Color of axis and text")]
        [Category("Color")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        [Browsable(true)]
        [Description("Font of draw axis text")]
        [Category("Font")]
        [NotBrowsableIf("ShowTextOfAxis", ShowTextAxisMode.None)]
        public override Font FontText
        {
            get { return base.FontText; }
            set { base.FontText = value; }
        }

        [Browsable(true)]
        [Description("Horizontal Axile Location")]
        [Category("Layout")]
        public virtual XAxileLocation XAxileLocation
        {
            get { return AxileBase.XAxileLocation; }
            set { AxileBase.XAxileLocation = value; }
        }

        [Browsable(true)]
        [Description("Show and location of axile name")]
        [Category("Layout")]
        public virtual AxileName AxileNameVisible
        {
            get { return AxileBase.AxileNameVisible; }
            set { AxileBase.AxileNameVisible = value; ParentForm.RebindChartConfiguration(); }
        }

        [Browsable(true)]
        [Description("Font of Axile Name")]
        [Category("Font")]
        [NotBrowsableIf("AxileNameVisible", AxileName.None)]
        public virtual Font FontAxileName
        {
            get { return AxileBase.FontAxileName; }
            set { AxileBase.FontAxileName = value; }
        }

        [Browsable(true)]
        [Description("Set color compatible with legend for axile name,If axile name is Shown")]
        [Category("Layout")]
        [NotBrowsableIf("AxileNameVisible", AxileName.None)]
        public virtual bool AxileNameColorEnable
        {
            get { return AxileBase.AxileNameColorEnable; }
            set { AxileBase.AxileNameColorEnable = value; }
        }

        #endregion

        public AxileChartConfiguration(Chart chart, ChartConfigurationForm parentForm)
            : base(chart, parentForm)
        {
            AxileBase = Chart.Component as AxileBase;
            if (AxileBase == null)
                throw new ArgumentException("Chart.Component is not AxileBase!");
        }
    }
}
