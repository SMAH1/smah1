using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart
{
    public enum LegendSpaceReserve
    {
        None,       // Don't reserve space for legend
        Horizontal, // Reserve horizontal space (width) add left/right space
        Vertical,   // Reserve vertical space (height) add top/bottom space
        Both        // Reserve horizontal space (width) and vertical space (height) add left/right and top/bottom space
    }
}
