using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;
using SMAH1.Attributes;

namespace SMAH1.Forms.PropertyGridComponent
{
    //Implementation for same interface in .NET and mono
    public class ColorArrayEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(
         ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(
         ITypeDescriptorContext context,
         IServiceProvider provider,
         object value)
        {
            IColorArrayEditorCaller caller = null;
            if (context.Instance is IColorArrayEditorCaller)
                caller = (IColorArrayEditorCaller)context.Instance;
            ColorArrayForm f = new ColorArrayForm((Color[])value, "",
                caller);
            if (f.ShowDialog() == DialogResult.OK)
            {
                return f.GetColorArray();
            }
            return base.EditValue(context, provider, value);
        }
    }
}
