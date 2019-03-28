using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart.Component.Axile
{
    public enum AxileName
    {
        None,               // Don't show any axile name
        InArea,             // Show axile name in end of axile in chart area
        EndAxile,           // Show axile name in top of end of axile
        BackAxileTop,       // Show axile name in back of axile (between axile and edge),Draw Top of axile
        BackAxileCenter,    // Show axile name in back of axile (between axile and edge),Draw Center of axile
        BackAxileBottom     // Show axile name in back of axile (between axile and edge),Draw Bottom of axile
    }
}
