using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart.Component.Axile
{
    internal class Coordinated
    {
        internal Axile Axile { get; }
        internal List<Chart> Charts { get; }

        internal Coordinated(Axile axile) { this.Axile = axile; Charts = new List<Chart>(); }
        internal bool Contains(Chart chart) { return Charts.Contains(chart); }
        internal void AddRange(Chart[] charts) { Charts.AddRange(charts); }
        internal bool Remove(Chart chart) { return Charts.Remove(chart); }
    }
}
