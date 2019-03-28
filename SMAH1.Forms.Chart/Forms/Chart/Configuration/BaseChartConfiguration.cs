using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using SMAH1.Attributes;
using SMAH1.Forms.PropertyGridComponent;

namespace SMAH1.Forms.Chart.Configuration
{
    [TypeConverter(typeof(ChartConfigurationTypeConverter))]
    public abstract class BaseChartConfiguration : IColorArrayEditorCaller
    {

        #region Fields and their access points
        private bool defaultVisibleConfigurationItems;

        private List<PropertyNameDescription> chartAndComponentConfigurationItems;

        [Browsable(false)]
        public Chart Chart { get; }

        [Browsable(false)]
        public ChartConfigurationForm ParentForm { get; }

        [Browsable(false)]
        internal protected bool DefaultVisibleConfigurationItems { get { return defaultVisibleConfigurationItems; } }
        #endregion

        #region Property

        [Browsable(true)]
        [Description("Title of chart.Show top-center chart")]
        [Category("Cation and Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [NotBrowsableIf("ShowText", ShowTextMode.None)]
        public virtual string Text
        {
            get { return Chart.Text; }
            set { Chart.Text = value; }
        }

        [Browsable(true)]
        [Description("Show/Hide Title of chart")]
        [Category("Cation and Text")]
        public virtual ShowTextMode ShowText
        {
            get { return Chart.ShowText; }
            set { Chart.ShowText = value; ParentForm.RebindChartConfiguration(); }
        }

        [Browsable(true)]
        [Description("Font of draw text")]
        [Category("Font")]
        public virtual Font FontText
        {
            get { return Chart.Font; }
            set { Chart.Font = value; }
        }

        [Browsable(true)]
        [Description("Font of draw Title")]
        [Category("Font")]
        [NotBrowsableIf("ShowText", ShowTextMode.None)]
        public virtual Font FontTitle
        {
            get { return Chart.FontTitle; }
            set { Chart.FontTitle = value; }
        }

        [Browsable(true)]
        [Description("Font of legend")]
        [Category("Font")]
        [NotBrowsableIf("LegendShow", false)]
        public virtual Font FontLegend
        {
            get { return Chart.FontLegend; }
            set { Chart.FontLegend = value; }
        }

        [Browsable(true)]
        [Description("Space between Bottom and Axis")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(5, int.MaxValue)]
        public virtual int SpaceBottom
        {
            get { return Chart.SpaceBottom; }
            set { Chart.SpaceBottom = value; }
        }

        [Browsable(true)]
        [Description("Space between Top and top of text or Graph area")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(5, int.MaxValue)]
        public virtual int SpaceTop
        {
            get { return Chart.SpaceTop; }
            set { Chart.SpaceTop = value; }
        }

        [Browsable(true)]
        [Description("Space between Text and Chart area.Use if Text is drawn Top")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(3, int.MaxValue)]
        [NotBrowsableIf("ShowText", ShowTextMode.None)]
        public virtual int SpaceAfterText
        {
            get { return Chart.SpaceAfterText; }
            set { Chart.SpaceAfterText = value; }
        }

        [Browsable(true)]
        [Description("Space between Left and Axis")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(5, int.MaxValue)]
        public virtual int SpaceLeft
        {
            get { return Chart.SpaceLeft; }
            set { Chart.SpaceLeft = value; }
        }

        [Browsable(true)]
        [Description("Space between right and end of Axis")]
        [Category("Width and Space")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(5, int.MaxValue)]
        public virtual int SpaceRight
        {
            get { return Chart.SpaceRight; }
            set { Chart.SpaceRight = value; }
        }

        [Browsable(true)]
        [Description("Color of data drawn")]
        [Category("Color")]
        [Editor(typeof(ColorArrayEditor),
                typeof(System.Drawing.Design.UITypeEditor))]
        public virtual Color[] Colors
        {
            get { return Chart.Colors; }
            set { Chart.Colors = value; }
        }

        [Browsable(true)]
        [Description("Color of text")]
        [Category("Color")]
        public virtual Color ForeColor
        {
            get { return Chart.ForeColor; }
            set { Chart.ForeColor = value; }
        }

        [Browsable(true)]
        [Description("Color of background color chart")]
        [Category("Color")]
        public virtual Color BackColor
        {
            get { return Chart.BackColor; }
            set { Chart.BackColor = value; }
        }

        [Browsable(true)]
        [Category("Legend")]
        [Description("Legend Alignment from AllArea or ChartArea")]
        [NotBrowsableIf("LegendShow", false)]
        public virtual ContentAlignment LegendAlignment
        {
            get { return Chart.LegendAlignment; }
            set { Chart.LegendAlignment = value; }
        }

        [Browsable(true)]
        [Category("Legend")]
        [Description("Show/Hode legend of graph")]
        public virtual bool LegendShow
        {
            get { return Chart.LegendShow; }
            set { Chart.LegendShow = value; ParentForm.RebindChartConfiguration(); }
        }

        [Browsable(true)]
        [Description("Positive for calculate form control area,Negative for calculate form Draw Chart area")]
        [Category("Legend")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(int.MinValue, int.MaxValue)]
        [NotBrowsableIf("LegendShow", false)]
        public virtual int LegendHorizontalSpace
        {
            get { return Chart.LegendHorizontalSpace; }
            set { Chart.LegendHorizontalSpace = value; }
        }

        [Browsable(true)]
        [Description("Positive for calculate form control area,Negative for calculate form Draw Chart area")]
        [Category("Legend")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(int.MinValue, int.MaxValue)]
        [NotBrowsableIf("LegendShow", false)]
        public virtual int LegendVerticalSpace
        {
            get { return Chart.LegendVerticalSpace; }
            set { Chart.LegendVerticalSpace = value; }
        }

        [Browsable(true)]
        [Description("Draw transparency of background when draw legend")]
        [Category("Legend")]
        public bool LegendDrawBackground
        {
            get { return Chart.LegendDrawBackground; }
            set { Chart.LegendDrawBackground = value; }
        }

        [Browsable(true)]
        [Description("Reserve space from edge")]
        [Category("Legend")]
        public virtual LegendSpaceReserve LegendSpaceReserve
        {
            get { return Chart.LegendSpaceReserve; }
            set { Chart.LegendSpaceReserve = value; }
        }

        [Browsable(true)]
        [Description("Draw chart from left or right")]
        [Category("Layout")]
        public virtual RightToLeft RightToLeft
        {
            get { return Chart.RightToLeft; }
            set { Chart.RightToLeft = value; }
        }
        #endregion

        #region Chart and Component Configuration Items

        public bool LoadChartAndComponentConfigurationItemsFromStream(TextReader reader)
        {
            bool bRet = false;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(reader);
                LoadChartConfigurationFormItemsFromXml(xmlDoc);
                bRet = true;
            }
            catch (XmlException exp)
            {
                System.Diagnostics.Trace.WriteLine("Load xml faild : " + exp.Message);
                bRet = false;
            }
            catch /*(Exception exc)*/ { bRet = false; }

            return bRet;
        }

        public bool LoadChartAndComponentConfigurationItemsFromFile(string filename)
        {
            bool bRet = false;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filename);
                LoadChartConfigurationFormItemsFromXml(xmlDoc);
                bRet = true;
            }
            catch (XmlException exp)
            {
                System.Diagnostics.Trace.WriteLine("Load xml faild : " + exp.Message);
                bRet = false;
            }
            catch /*(Exception exc)*/ { bRet = false; }

            return bRet;
        }

        public bool LoadChartAndComponentConfigurationItemsFromString(string xmlOfItems)
        {
            if (string.IsNullOrEmpty(xmlOfItems))
                return false;

            bool bRet = false;
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlOfItems)))
            {
                StreamReader sr = new StreamReader(ms);
                bRet = LoadChartAndComponentConfigurationItemsFromStream(sr);
            }
            return bRet;
        }

        private void LoadChartConfigurationFormItemsFromXml(XmlDocument xmlDoc)
        {
            List<String> propSaveLoad = new List<String>();
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                foreach (object attribute in prop.GetCustomAttributes(true))
                {
                    if (attribute is BrowsableAttribute)
                        if (!((BrowsableAttribute)attribute).Browsable)
                            continue;
                    propSaveLoad.Add(prop.Name);
                    break;
                }
            }

            chartAndComponentConfigurationItems.Clear();

            XmlNode chartProperty = xmlDoc.GetElementsByTagName("ChartProperty")[0];
            foreach (XmlAttribute attr in chartProperty.Attributes)
            {
                if (String.Compare(attr.Name, "default", true) == 0)
                {
                    if (!bool.TryParse(attr.Value, out defaultVisibleConfigurationItems))
                        defaultVisibleConfigurationItems = true;
                }
                else
                    chartAndComponentConfigurationItems.Add(new PropertyNameDescription(
                        attr.Name, "", attr.Value, true, true));
            }
            foreach (XmlNode node in chartProperty.ChildNodes)
            {
                foreach (string prop in propSaveLoad)
                {
                    if (String.Compare(prop, node.Name, true) == 0)
                    {
                        string name = node.Name;
                        bool visible = true;
                        foreach (XmlAttribute attr in node.Attributes)
                        {
                            if (String.Compare(attr.Name, "name", true) == 0)
                                name = attr.Value;
                            else if (String.Compare(attr.Name, "visible", true) == 0)
                            {
                                if (!bool.TryParse(attr.Value, out visible))
                                    visible = true;
                            }
                        }
                        chartAndComponentConfigurationItems.Add(new PropertyNameDescription(
                            node.Name, name, node.InnerText, visible, false));
                        break;
                    }
                }
            }
        }

        public List<PropertyNameDescription> GetChartConfigurationFormItems()
        {
            return chartAndComponentConfigurationItems;
        }
        #endregion

        #region Default chart and component configuration items
        private static Dictionary<string, string>
                        defaultChartAndComponentConfigurationItems
                            = new Dictionary<string, string>();

        public static void ClearDefaultItemsConfiguration
                    (Type typeSubclassOfBaseChartConfiguration)
        {
            if (!typeSubclassOfBaseChartConfiguration.
                        IsSubclassOf(typeof(BaseChartConfiguration)))
                return;

            string t = typeSubclassOfBaseChartConfiguration.ToString();
            if (defaultChartAndComponentConfigurationItems.ContainsKey(t))
                defaultChartAndComponentConfigurationItems.Remove(t);
        }
        public static void SetDefaultItemsConfiguration
                (Type typeSubclassOfBaseChartConfiguration, string xmlConfiguration)
        {
            if (!typeSubclassOfBaseChartConfiguration.
                        IsSubclassOf(typeof(BaseChartConfiguration)))
                return;

            if (string.IsNullOrEmpty(xmlConfiguration))
            {
                ClearDefaultItemsConfiguration(typeSubclassOfBaseChartConfiguration);
                return;
            }

            string t = typeSubclassOfBaseChartConfiguration.ToString();
            if (defaultChartAndComponentConfigurationItems.ContainsKey(t))
                defaultChartAndComponentConfigurationItems[t] = xmlConfiguration;
            else
                defaultChartAndComponentConfigurationItems.Add(t, xmlConfiguration);
        }
        public bool RestoreDefaultItemsConfiguration()
        {
            string t = this.GetType().ToString();
            if (!defaultChartAndComponentConfigurationItems.ContainsKey(t))
                return true;

            return this.LoadChartAndComponentConfigurationItemsFromString(
                defaultChartAndComponentConfigurationItems[t]);
        }
        #endregion

        #region ColorArrayEditorCaller Members
        [Browsable(false)]
        public Color ForeColorForColorArrayEditor
        {
            get { return ForeColor; }
        }

        [Browsable(false)]
        public Color BackColorForColorArrayEditor
        {
            get { return BackColor; }
        }

        public string GetButtonText(string currentText)
        {
            if (chartAndComponentConfigurationItems.Count > 0)
            {
                foreach (PropertyNameDescription p in chartAndComponentConfigurationItems)
                {
                    if (p.IsAttribute)
                    {
                        if (String.Compare(p.Property, currentText, true) == 0)
                        {
                            return p.Description;
                        }
                    }
                }
            }
            return currentText;
        }
        #endregion

        public BaseChartConfiguration(Chart chart, ChartConfigurationForm parentForm)
        {
            Chart = chart;
            ParentForm = parentForm;
            if (chart == null)
                throw new ArgumentNullException("Chart can not null!");
            if (parentForm == null)
                throw new ArgumentNullException("ParentForm can not null!");
            defaultVisibleConfigurationItems = true;

            chartAndComponentConfigurationItems = new List<PropertyNameDescription>();
        }
    }
}
