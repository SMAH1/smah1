using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SMAH1.Forms.Chart.Component.BarComponent
{
    internal struct ItemDrawInfo
    {
        internal Rectangle Rect { get; set; }
        internal bool IsOverflow { get; set; }
        internal int ColIndex { get; set; }
        internal int RowIndex { get; set; }
    }
}
