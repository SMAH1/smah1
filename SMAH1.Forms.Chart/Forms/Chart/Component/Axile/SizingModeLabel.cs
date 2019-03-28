using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart.Component.Axile
{
    public enum SizingModeLabel
    {
        Normal,         // Use variable values for width of the bar
        Fit,            // Automatically calculate the bounding rectangle and fit all data inside the control
        FitIfLarge      // Automatically calculate the bounding rectangle and fit all data inside the control if can not draw all data
    }
}
