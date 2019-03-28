using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms.Design;
using SMAH1.Attributes;
using System.Windows.Forms;

namespace SMAH1.Forms.PropertyGridComponent
{
    public class NumericFloatUpDownEditor : UITypeEditor
    {
        ITypeDescriptorContext contextSelected;

        public NumericFloatUpDownEditor()
        {
            contextSelected = null;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(
                ITypeDescriptorContext context,
                IServiceProvider provider,
                object value
            )
        {
            IWindowsFormsEditorService wfes = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (wfes == null)
                return null;

            MaxMinForFloatAttribute attr = new MaxMinForFloatAttribute(1, 100, 0, 1F);
            foreach (System.Attribute attr2 in context.PropertyDescriptor.Attributes)
            {
                if (attr2 is MaxMinForFloatAttribute)
                {
                    attr = (MaxMinForFloatAttribute)attr2;
                    break;
                }
            }

            NumericUpDown numericUpDown = new NumericUpDown
            {
                DecimalPlaces = attr.DecimalPlaces
            };
            try
            {
                numericUpDown.Minimum = (decimal)attr.Min;
            }
            catch { }
            try
            {
                numericUpDown.Maximum = (decimal)attr.Max;
            }
            catch { }

            numericUpDown.Size = new System.Drawing.Size(50, 30);
            numericUpDown.Increment = decimal.Parse(attr.Increment.ToString());
            numericUpDown.Value = decimal.Parse(value.ToString());
            contextSelected = context;
            numericUpDown.ValueChanged += new EventHandler(Nmr_ValueChanged);
            wfes.DropDownControl(numericUpDown);
            context.PropertyDescriptor.SetValue(context.Instance, Convert.ChangeType(numericUpDown.Value, context.PropertyDescriptor.PropertyType));
            numericUpDown.Value = (decimal)Convert.ChangeType(context.PropertyDescriptor.GetValue(context.Instance), typeof(decimal));
            return (float)Convert.ToDouble(numericUpDown.Value);
        }

        void Nmr_ValueChanged(object sender, EventArgs e)
        {
            if (contextSelected != null)
            {
                NumericUpDown numericUpDown = (NumericUpDown)sender;
                //Change Real Time
                contextSelected.PropertyDescriptor.SetValue(
                    contextSelected.Instance, (float)Convert.ToDouble(numericUpDown.Value));
            }
        }
    }
}
