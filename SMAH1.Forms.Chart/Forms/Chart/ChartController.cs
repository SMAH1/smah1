using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart
{
    public class ChartController
    {
        public Chart Chart { get; }

        internal ChartController(Chart chart)
        {
            Chart = chart;
            if (chart == null)
                throw new ArgumentException("'chart' is null");
        }
    }
}
