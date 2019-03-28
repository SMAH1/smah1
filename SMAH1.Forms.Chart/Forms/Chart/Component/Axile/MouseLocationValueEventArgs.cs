using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart.Component.Axile
{
    public class MouseLocationValueEventArgs : EventArgs
    {
        public float Value { get; }

        public MouseLocationValueEventArgs(float val)
        {
            Value = val;
        }
    }
}
