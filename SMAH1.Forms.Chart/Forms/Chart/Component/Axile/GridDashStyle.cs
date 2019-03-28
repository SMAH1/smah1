using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SMAH1.Forms.Chart.Component.Axile
{
    public enum GridDashStyle
    {
        [Description("solid style")]
        Solid = 0,      //Specifies a solid line.

        [Description("dash style")]
        Dash = 1,       //Specifies a line consisting of dashes.

        [Description("dot style")]
        Dot = 2,        //Specifies a line consisting of dots.

        [Description("dash-dot style")]
        DashDot = 3,    //Specifies a line consisting of a repeating pattern of dash-dot.

        [Description("dash-dot-dot style")]
        DashDotDot = 4, //Specifies a line consisting of a repeating pattern of dash-dot-dot.

        [Description("dot-space style")]
        DotSpace = 5,   //Specifies a line consisting of a repeating pattern of dot-space.

        [Description("dot-space-space style")]
        DotSpaceSpace = 6,  //Specifies a line consisting of a repeating pattern of dot-space-space.

        [Description("dot-space-space-space style")]
        DotSpace3 = 7,  //Specifies a line consisting of a repeating pattern of dot-space-space-space.

        [Description("dot-space-space-space-space style")]
        DotSpace4 = 8,  //Specifies a line consisting of a repeating pattern of dot-space-space-space-space.

        [Description("dash-space style")]
        DashSpace = 9,  //Specifies a line consisting of a repeating pattern of dash-space.

        [Description("dash-space-space style")]
        DashSpaceSpace = 10,  //Specifies a line consisting of a repeating pattern of dash-space-space.
    }
}
