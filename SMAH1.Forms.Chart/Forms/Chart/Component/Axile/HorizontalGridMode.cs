using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart.Component.Axile
{
    public enum HorizontalGridMode
    {
        None,        // Don't show any horizontal grid on graph
        BackOfData,  // Show horizontal grid on graph,bar/line/chunk/... is front of grid
        FrontOfData  // Show horizontal grid on graph,grid is back of bar/line/chunk/...
    }
}
