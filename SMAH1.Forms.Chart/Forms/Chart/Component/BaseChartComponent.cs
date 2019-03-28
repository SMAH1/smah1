using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using SMAH1.Attributes;
using SMAH1.Forms.Chart.Configuration;
using SMAH1.Serialize;
using SMAH1.BindingData;

namespace SMAH1.Forms.Chart.Component
{
    [DesignerCategory("SMAH1")]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public abstract class BaseChartComponent : System.ComponentModel.Component
    {
        private ChartController parent;
        protected bool drawAllDataField;
        protected RectangleF rcChartDrawArea;

        protected const int SPACE_NEED = 5;

        public BaseChartComponent()
        {
            parent = null;
            drawAllDataField = true;
            rcChartDrawArea = RectangleF.Empty;
        }

        #region Object method
        public override bool Equals(System.Object obj)
        {
            if (obj == null) return false;
            if (!ReferenceEquals(this, obj)) return false;

            return Equals(obj as BaseChartComponent);
        }

        public bool Equals(BaseChartComponent bcc)
        {
            if (bcc == null) return false;
            if (!ReferenceEquals(this, bcc)) return false;

            if (!base.Equals(bcc)) return false;
            if (bcc.parent == null && parent != null) return false;
            if (bcc.parent != null && parent == null) return false;
            if (bcc.parent != null)
                if (!bcc.parent.Equals(parent)) return false;
            if (bcc.drawAllDataField != drawAllDataField) return false;
            if (bcc.rcChartDrawArea != rcChartDrawArea) return false;

            return true;
        }

        public static bool operator ==(BaseChartComponent a, BaseChartComponent b)
        {
            bool ab = a is null;
            bool bb = b is null;
            if (ab && bb)
                return true;
            if (ab && !bb)
                return false;
            return a.Equals(b); //No we have object of a (a is not null)
        }

        public static bool operator !=(BaseChartComponent a, BaseChartComponent b) { return !(a == b); }

        public override int GetHashCode()
        {
            int hash = 0;
            hash += base.GetHashCode();
            hash += parent == null ? 0 : parent.GetHashCode();
            hash += drawAllDataField.GetHashCode();
            hash += rcChartDrawArea.GetHashCode();

            return hash;
        }
        #endregion

        #region Property
        [Browsable(false)]
        public abstract string Guid { get; }

        [Browsable(false)]
        public RectangleF CurrentChartDrawArea { get { return rcChartDrawArea; } }

        [Browsable(false)]
        [DefaultValue(null)]
        internal protected ChartController Parent
        {
            get { return parent; }
            set
            {
                if (parent != value)
                {
                    if (parent != null)
                    {
                        Terminate();
                        parent.Chart.Component = null;
                    }
                    parent = value;
                    if (parent != null)
                    {
                        parent.Chart.Component = this;
                        Initialize();
                    }
                }
            }
        }

        [Browsable(false)]
        internal protected bool DrawAllData
        {
            get { return drawAllDataField; }
        }

        [Browsable(false)]
        internal protected RectangleF DrawArea
        {
            get { return rcChartDrawArea; }
            set { rcChartDrawArea = value; }
        }
        #endregion

        #region Load & Save Configuration of Component
        public bool SaveConfigurationOfComponent(TextWriter writer)
        {
            bool bRet = false;
            try
            {
                XmlElement rootNode = Chart.CreateRootXmlForSave();
                Chart.CreateComponentXmlForSave(rootNode, this);

                rootNode.OwnerDocument.Save(writer);
                bRet = true;
            }
            catch { bRet = false; }

            return bRet;
        }
        public bool SaveConfigurationOfComponent(string filename)
        {
            bool bRet = false;
            try
            {
                XmlElement rootNode = Chart.CreateRootXmlForSave();
                Chart.CreateComponentXmlForSave(rootNode, this);

                rootNode.OwnerDocument.Save(filename);
                bRet = true;
            }
            catch { bRet = false; }

            return bRet;
        }
        public bool SaveConfigurationOfChart(out string xmlOfConfiguration)
        {
            xmlOfConfiguration = "";
            bool bRet = false;
            using (MemoryStream ms = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(ms);
                bRet = SaveConfigurationOfComponent(sw);
                sw.Flush();

                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                xmlOfConfiguration = sr.ReadToEnd();
            }
            return bRet;
        }
        public bool LoadConfigurationOfComponentFromStream(TextReader reader)
        {
            bool bRet = false;

            bool oldRedrawable = true;
            if (Parent != null)
            {
                oldRedrawable = Parent.Chart.Redrawable;
                Parent.Chart.Redrawable = false;
            }
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(reader);
                foreach (XmlNode node in xmlDoc.GetElementsByTagName(ChartConst.CHART_TAG)[0].ChildNodes)
                {
                    if (node.Name == ChartConst.COMPONENT_TAG)
                    {
                        this.LoadFromXml(node);
                        // not use 'continue',because we can multi component in one config file
                    }
                }

                bRet = true;
            }
            catch (XmlException exp)
            {
                System.Diagnostics.Trace.WriteLine("Load xml faild : " + exp.Message);
                bRet = false;
            }
            catch /*(Exception exc)*/ { bRet = false; }

            if (Parent != null)
                Parent.Chart.Redrawable = oldRedrawable;

            return bRet;
        }
        public bool LoadConfigurationOfComponentFromFile(string filename)
        {
            bool bRet = false;

            bool oldRedrawable = true;
            if (Parent != null)
            {
                oldRedrawable = Parent.Chart.Redrawable;
                Parent.Chart.Redrawable = false;
            }
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filename);
                foreach (XmlNode node in xmlDoc.GetElementsByTagName(ChartConst.CHART_TAG)[0].ChildNodes)
                {
                    if (node.Name == ChartConst.COMPONENT_TAG)
                    {
                        this.LoadFromXml(node);
                        // not use 'continue',because we can multi component in one config file
                    }
                }

                bRet = true;
            }
            catch (XmlException exp)
            {
                System.Diagnostics.Trace.WriteLine("Load xml faild : " + exp.Message);
                bRet = false;
            }
            catch /*(Exception exc)*/ { bRet = false; }

            if (Parent != null)
                Parent.Chart.Redrawable = oldRedrawable;

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
                bRet = LoadConfigurationOfComponentFromStream(sr);
            }
            return bRet;
        }
        #endregion

        #region Load & Save Xml
        internal protected XmlElement CreateXmlForSave(XmlDocument xmlDoc, string subRootName)
        {
            XmlElement node;

            XmlElement rootNode = xmlDoc.CreateElement(subRootName);
            XmlAttribute guid = xmlDoc.CreateAttribute("GUID");
            guid.Value = Guid;
            rootNode.SetAttributeNode(guid);

            Dictionary<String, PropertyInfo> propSaveLoad = new Dictionary<String, PropertyInfo>();
            foreach (PropertyInfo prop in (this.GetType()).GetProperties())
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
                    if (SerializeData.Serialize(thisProp.PropertyType, value, out string valueText))
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

            InternalCreateXmlForSave(rootNode);

            return rootNode;
        }

        internal protected void LoadFromXml(XmlNode subRootNode)
        {
            XmlAttribute xmlAttribute = subRootNode.Attributes["GUID"];
            if (xmlAttribute == null)
                return;
            if (!IdentifyGuid(xmlAttribute.Value))
                return;

            Dictionary<string, PropertyInfo> propSaveLoad = new System.Collections.Generic.Dictionary<String, PropertyInfo>();
            foreach (PropertyInfo prop in (this.GetType()).GetProperties())
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

            foreach (XmlNode node in subRootNode.ChildNodes)
            {
                String s = node.InnerText;
                if (propSaveLoad.ContainsKey(node.Name))
                {
                    PropertyInfo thisProp = propSaveLoad[node.Name];
                    if (thisProp != null)
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
                    continue;
                }
                else
                    InternalLoadFromXml(node);
            }
        }

        //Use for child,when it has data that can be saved (like struct,class,list,...)
        protected virtual void InternalCreateXmlForSave(XmlElement rootNode) { }

        //Can component load current data?
        protected virtual bool IdentifyGuid(string guid)
        {
            if (string.Compare(this.Guid, guid, true) == 0)
                return true;
            return false;
        }
        //Use for load node that created by CreatePrivateXmlForSave
        protected virtual void InternalLoadFromXml(XmlNode node) { }
        #endregion

        #region Default configuration of chart and component
        private static Dictionary<string, string> defaultConfigurationOfChartAndComponent = new Dictionary<string, string>();

        public static void ClearDefaultConfiguration(Type typeSubclassOfBaseChartComponent)
        {
            if (!typeSubclassOfBaseChartComponent.IsSubclassOf(typeof(BaseChartComponent)))
                return;

            string t = typeSubclassOfBaseChartComponent.ToString();
            if (defaultConfigurationOfChartAndComponent.ContainsKey(t))
                defaultConfigurationOfChartAndComponent.Remove(t);
        }

        public static void SetDefaultConfiguration(Type typeSubclassOfBaseChartComponent, string xmlConfiguration)
        {
            if (!typeSubclassOfBaseChartComponent.
                        IsSubclassOf(typeof(BaseChartComponent)))
                return;

            if (string.IsNullOrEmpty(xmlConfiguration))
            {
                ClearDefaultConfiguration(typeSubclassOfBaseChartComponent);
                return;
            }

            string t = typeSubclassOfBaseChartComponent.ToString();
            if (defaultConfigurationOfChartAndComponent.ContainsKey(t))
                defaultConfigurationOfChartAndComponent[t] = xmlConfiguration;
            else
                defaultConfigurationOfChartAndComponent.Add(t, xmlConfiguration);
        }

        public bool RestoreDefaultConfiguration(Chart chart)
        {
            string t = this.GetType().ToString();
            if (!defaultConfigurationOfChartAndComponent.ContainsKey(t))
                return true;

            return chart.LoadConfigurationOfChartFromString(
                defaultConfigurationOfChartAndComponent[t]);
        }
        #endregion

        public abstract BaseChartConfiguration CreateChartConfiguration(ChartConfigurationForm form);

        #region Initialize & Terminate
        protected virtual void Initialize()
        {
            if (Parent == null)
                throw new NullReferenceException("'Parent' is null!");
        }
        protected virtual void Terminate()
        {
            if (Parent == null)
                throw new NullReferenceException("'Parent' is null!");
        }
        #endregion

        #region Paint
        internal protected virtual void PaintStart(Graphics gr, IBindingData data) { }
        internal protected virtual void Paint(Graphics gr, IBindingData data, Rectangle rcArea) { }
        internal protected virtual void PaintFinish(Graphics gr, IBindingData data) { }
        #endregion
    }
}
