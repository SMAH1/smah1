using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SMAH1.Forms.DataGridViewComponent
{
    public class DataGridViewProgressCellPaintStateEventArgs : EventArgs
    {
        public DataGridViewCellStyle CellStyle { get; }
        public DataGridViewElementStates CellState { get; internal set; }
        public int Value { get; set; }

        private float percent;
        public float Percent
        {
            get { return percent; }
            set
            {
                percent = value;
                if (percent < 0f)
                    percent = 0f;
                else if (percent > 1f)
                    percent = 1f;
            }
        }
        public string Text { get; set; }
        public Color ForeColorDefault { get; set; }
        public Color BackColorDefault { get; set; }
        public Color ForeColorProgress { get; set; }
        public Color BackColorProgress { get; set; }
        public DataGridViewProgressCell ProgressCell { get; }

        public DataGridViewProgressCellPaintStateEventArgs
            (
                DataGridViewProgressCell cell,
                DataGridViewCellStyle cellStyle
            )
        {
            this.ProgressCell = cell;
            this.CellStyle = cellStyle;
            this.CellState = DataGridViewElementStates.None;
            Value = 0;
            Percent = 0f;
            Text = string.Empty;
            ForeColorDefault = BackColorDefault = ForeColorProgress = BackColorProgress = Color.Empty;
        }
    }
}
