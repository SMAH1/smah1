using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMAH1.ExtensionMethod
{
    public static class ControlExtensionMethod
    {
        public static bool IsRTL(this Control control)
        {
            bool result;

            if (control.RightToLeft == RightToLeft.Yes)
                result = true;
            else if (control.RightToLeft == RightToLeft.Inherit && control.Parent != null)
                result = IsRTL(control.Parent);
            else
                result = false;

            return result;
        }

        public static ToolTip CreateToolTip(this Control control, string text)
        {
            ToolTip tt = new ToolTip();

            tt.AutoPopDelay = 3000;
            tt.InitialDelay = 100;
            tt.ReshowDelay = 100;
            tt.ShowAlways = true;

            tt.SetToolTip(control, text);

            return tt;
        }
    }
}
