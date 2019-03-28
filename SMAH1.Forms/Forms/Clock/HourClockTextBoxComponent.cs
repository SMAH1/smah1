using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Clock
{
    internal class HourClockTextBoxComponent : BaseClockTextBoxComponent
    {
        public HourClockTextBoxComponent() : base(0, 23, 2, "{0:D2}") { }
    }
}
