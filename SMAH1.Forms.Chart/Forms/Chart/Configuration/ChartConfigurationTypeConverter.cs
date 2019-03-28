using System.Collections.Generic;
using System.ComponentModel;
using SMAH1.Attributes;
using System.Reflection;

namespace SMAH1.Forms.Chart.Configuration
{
    class ChartConfigurationTypeConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context,
            object value,
            System.Attribute[] attributes)
        {
            PropertyDescriptorCollection props = base.GetProperties(context, value, attributes);
            BaseChartConfiguration bcc = (BaseChartConfiguration)value;
            List<PropertyNameDescription> pnd = bcc.GetChartConfigurationFormItems();
            List<PropertyDescriptor> list = new List<PropertyDescriptor>(props.Count);
            foreach (PropertyDescriptor prop in props)
            {
                PropertyDescriptor addCandid = null;
                if (bcc.DefaultVisibleConfigurationItems)
                    addCandid = prop;
                foreach (PropertyNameDescription p in pnd)
                {
                    if (string.Compare(p.Property, prop.Name, true) == 0)
                    {
                        if (p.Visible)
                        {
                            addCandid = new ChartConfigurationTypeConverterNameDescriptorProperty(
                                prop,
                                p.Name,
                                (!string.IsNullOrEmpty(p.Description) ? p.Description : prop.Description)
                            );
                            break;
                        }
                        else
                        {
                            addCandid = null;
                            break;
                        }
                    }
                }
                if (addCandid != null)
                {
                    if (Browsable(bcc, prop))
                        list.Add(addCandid);
                }
            }
            PropertyDescriptorCollection pdc =
                new PropertyDescriptorCollection(list.ToArray(), true);
            return pdc;
        }

        private bool Browsable(BaseChartConfiguration bcc, PropertyDescriptor prop)
        {
            PropertyInfo pi1 = bcc.GetType().GetProperty(prop.Name);
            if (pi1 != null)
            {
                if (pi1.IsDefined(typeof(NotBrowsableIfAttribute), true))
                {
                    object[] os = pi1.GetCustomAttributes(typeof(NotBrowsableIfAttribute), true);
                    foreach (object o in os)
                    {
                        if (o is NotBrowsableIfAttribute a)
                        {
                            for (int i = 0; i < a.Properties.Count; i++)
                            {
                                PropertyInfo pi2 = bcc.GetType().GetProperty(a.Properties[i]);
                                if (pi2 != null)
                                {
                                    object oCur = pi2.GetValue(bcc, null);
                                    if (oCur.Equals(a.Values[i]))
                                        return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}
