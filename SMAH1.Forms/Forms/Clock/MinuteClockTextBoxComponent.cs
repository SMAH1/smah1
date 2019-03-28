using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Clock
{
    internal class MinuteClockTextBoxComponent : BaseClockTextBoxComponent
    {
        public MinuteClockTextBoxComponent() : base(0, 59, 2, "{0:D2}") { }
    }
}
