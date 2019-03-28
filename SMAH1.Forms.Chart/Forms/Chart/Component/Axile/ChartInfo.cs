using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SMAH1.Forms.Chart.Component.Axile
{
    internal class ChartInfo
    {
        internal ChartInfo(Chart chart)
        {
            Chart = chart;
            XAxileSpace = 0;
            YAxileSpace1 = 0;
            YAxileSpace2 = 0;
            Bitmap = null;
        }

        internal ChartInfo(Chart chart, Size sz)
        {
            this.Chart = chart;
            this.Bitmap = new Bitmap(sz.Width, sz.Height);
        }

        internal Chart Chart { get; }
        internal int XAxileSpace { get; set; }
        internal int YAxileSpace1 { get; set; }
        internal int YAxileSpace2 { get; set; }
        internal Bitmap Bitmap { get; }
    }
}
