using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Clock
{
    internal class MillisecondClockTextBoxComponent : BaseClockTextBoxComponent
    {
        public MillisecondClockTextBoxComponent() : base(0, 999, 3, "{0:D3}") { }
    }
}
