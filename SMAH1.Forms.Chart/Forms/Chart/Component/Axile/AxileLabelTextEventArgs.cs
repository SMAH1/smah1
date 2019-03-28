using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart.Component.Axile
{
    public class AxileLabelTextEventArgs : EventArgs
    {
        System.Collections.Generic.List<AxileLabelText> axileLabels = null;

        internal AxileLabelTextEventArgs(System.Collections.Generic.List<AxileLabelText> axileLabels)
        {
            this.axileLabels = axileLabels ?? throw new ArgumentNullException("axileLabels");
        }

        public int CountAxileLabel { get { return axileLabels.Count; } }
        public AxileLabelText GetAxileLabel(int index)
        {
            if (index < axileLabels.Count && index >= 0)
                return axileLabels[index];
            return null;
        }
        public AxileLabelText this[int index] { get { return GetAxileLabel(index); } }
    }
}
