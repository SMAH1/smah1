using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart.Component.Axile
{
    public class MouseAndItemEventArgs : EventArgs
    {
        public int ColumnIndex { get; }
        public int RowIndex { get; }

        public MouseAndItemEventArgs(int col, int row)
        {
            ColumnIndex = col;
            RowIndex = row;
        }
    }
}
