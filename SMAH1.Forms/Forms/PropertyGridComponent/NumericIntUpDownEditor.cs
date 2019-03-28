using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using SMAH1.Attributes;

namespace SMAH1.Forms.PropertyGridComponent
{
    public class NumericIntUpDownEditor : UITypeEditor
    {
        ITypeDescriptorContext contextSelected;
        Type type;

        public NumericIntUpDownEditor()
        {
            contextSelected = null;
            type = null;
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

            NumericUpDown numericUpDown = new NumericUpDown
            {
                Minimum = 0,
                Maximum = (decimal)int.MaxValue
            };
            foreach (System.Attribute attr in context.PropertyDescriptor.Attributes)
            {
                if (attr is MaxMinForIntAttribute attr2)
                {
                    numericUpDown.Minimum = (decimal)attr2.Min;
                    numericUpDown.Maximum = (decimal)attr2.Max;
                    break;
                }
            }
            contextSelected = context;
            type = contextSelected.PropertyDescriptor.PropertyType;
            numericUpDown.Size = new System.Drawing.Size(50, 30);
            numericUpDown.Increment = 1;
            numericUpDown.DecimalPlaces = 0;
            numericUpDown.Value = (decimal)Convert.ChangeType(value, typeof(decimal));
            numericUpDown.ValueChanged += new EventHandler(Nmr_ValueChanged);
            wfes.DropDownControl(numericUpDown);
            numericUpDown.Value = (decimal)Convert.ChangeType(context.PropertyDescriptor.GetValue(context.Instance), typeof(decimal));
            return Convert.ChangeType(numericUpDown.Value, type);
        }

        void Nmr_ValueChanged(object sender, EventArgs e)
        {
            if (contextSelected != null)
            {
                NumericUpDown numericUpDown = (NumericUpDown)sender;
                //Change Real Time
                contextSelected.PropertyDescriptor.SetValue(
                    contextSelected.Instance,
                    Convert.ChangeType(numericUpDown.Value, type));
            }
        }
    }
}
