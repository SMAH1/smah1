using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Clock
{
    internal class SecondClockTextBoxComponent : BaseClockTextBoxComponent
    {
        public SecondClockTextBoxComponent() : base(0, 59, 2, "{0:D2}") { }
    }
}
