using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace SMAH1.Forms.DataGridViewComponent
{
    public class DataGridViewProgressCell : DataGridViewCell
    {
        // Used to make custom cell consistent with a DataGridViewImageCell
        static int emptyValue;

        #region colors
        // Used to remember color of the progress bar
        private Color progressBarColorDefault;
        private Color progressBarColorSelection;
        private Color progressBarColorQueue;
        private Color progressBarColorProcess;
        private Color progressBarColorError;
        private Color progressBarColorFinish;

        public Color ProgressBarColorDefault
        {
            get { return progressBarColorDefault; }
            set { progressBarColorDefault = value; }
        }

        public Color ProgressBarColorSelection
        {
            get { return progressBarColorSelection; }
            set { progressBarColorSelection = value; }
        }

        public Color ProgressBarColorQueue
        {
            get { return progressBarColorQueue; }
            set { progressBarColorQueue = value; }
        }

        public Color ProgressBarColorProcess
        {
            get { return progressBarColorProcess; }
            set { progressBarColorProcess = value; }
        }

        public Color ProgressBarColorError
        {
            get { return progressBarColorError; }
            set { progressBarColorError = value; }
        }

        public Color ProgressBarColorFinish
        {
            get { return progressBarColorFinish; }
            set { progressBarColorFinish = value; }
        }

        internal void SetProgressBarColorDefault(int rowIndex, Color value)
        { this.ProgressBarColorDefault = value; }

        internal void SetProgressBarColorSelection(int rowIndex, Color value)
        { this.ProgressBarColorSelection = value; }

        internal void SetProgressBarColorQueue(int rowIndex, Color value)
        { this.ProgressBarColorQueue = value; }

        internal void SetProgressBarColorProcess(int rowIndex, Color value)
        { this.ProgressBarColorProcess = value; }

        internal void SetProgressBarColorError(int rowIndex, Color value)
        { this.ProgressBarColorError = value; }

        internal void SetProgressBarColorFinish(int rowIndex, Color value)
        { this.ProgressBarColorFinish = value; }
        #endregion

        #region Like Event
        private void OnPaintCellState(DataGridViewProgressCellPaintStateEventArgs arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg");

            if (this.OwningColumn is DataGridViewProgressColumn column)
                column.FilePaintCellState(arg);
        }
        #endregion

        static DataGridViewProgressCell()
        {
            emptyValue = 0;
        }
        public DataGridViewProgressCell()
        {
            this.ValueType = typeof(int);
            ProgressBarColorDefault = SystemColors.Window;
            ProgressBarColorSelection = SystemColors.Highlight;
            ProgressBarColorQueue = SystemColors.Info;
            ProgressBarColorProcess = SystemColors.ControlLight;
            ProgressBarColorError = Color.Red;
            ProgressBarColorFinish = Color.Green;
        }
        // Method required to make the Progress Cell consistent with the default Image Cell.
        // The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an int.
        protected override object GetFormattedValue(object value,
            int rowIndex, ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            DataGridViewProgressCellPaintStateEventArgs arg =
                new DataGridViewProgressCellPaintStateEventArgs(this, cellStyle)
                {
                    ForeColorDefault = cellStyle.ForeColor,
                    BackColorDefault = cellStyle.BackColor
                };

            try
            {
                int progressVal = Convert.ToInt32(value);
                if (progressVal < 0)
                {
                    switch (progressVal)
                    {
                        case (int)DataGridViewProgressCellState.Finish:
                            arg.Value = progressVal;
                            arg.Percent = 1f;
                            arg.Text = "Finish";
                            arg.ForeColorProgress = cellStyle.ForeColor;
                            arg.BackColorProgress = ProgressBarColorFinish;
                            break;
                        case (int)DataGridViewProgressCellState.Error:
                            arg.Value = progressVal;
                            arg.Percent = 1f;
                            arg.Text = "Error";
                            arg.ForeColorProgress = cellStyle.ForeColor;
                            arg.BackColorProgress = ProgressBarColorError;
                            break;
                        case (int)DataGridViewProgressCellState.Process:
                            arg.Value = progressVal;
                            arg.Percent = 0.5f;
                            arg.Text = "Process";
                            arg.ForeColorProgress = cellStyle.ForeColor;
                            arg.BackColorProgress = ProgressBarColorProcess;
                            break;
                        case (int)DataGridViewProgressCellState.Queue:
                            arg.Value = progressVal;
                            arg.Percent = 1f;
                            arg.Text = "Queue";
                            arg.ForeColorProgress = cellStyle.ForeColor;
                            arg.BackColorProgress = ProgressBarColorQueue;
                            break;
                        default:
                            arg.Value = progressVal;
                            arg.Percent = 0f;
                            arg.Text = progressVal.ToString();
                            arg.ForeColorProgress = cellStyle.ForeColor;
                            arg.BackColorProgress = ProgressBarColorQueue;
                            break;
                    }
                }
                else if (progressVal > 100)
                {
                    arg.Value = progressVal;
                    arg.Percent = 1f;
                    arg.Text = progressVal.ToString();
                    arg.ForeColorProgress = cellStyle.ForeColor;
                    arg.BackColorProgress = ProgressBarColorDefault;
                }
                else
                {
                    arg.Value = progressVal;
                    arg.Percent = ((float)progressVal / 100.0f);
                    arg.Text = progressVal.ToString() + "%";
                    arg.ForeColorProgress = cellStyle.ForeColor;
                    arg.BackColorProgress = ProgressBarColorDefault;
                }
            }
            catch
            {
                arg.Value = emptyValue;
                arg.Percent = 0f;
                if (value is DBNull)
                    arg.Text = emptyValue.ToString() + "%";
                else
                    arg.Text = emptyValue.ToString();
                arg.ForeColorProgress = cellStyle.ForeColor;
                arg.BackColorProgress = ProgressBarColorDefault;
            }
            return arg;
        }

        #region Paint
        protected override void Paint(System.Drawing.Graphics g,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object value, object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            DataGridViewProgressCellPaintStateEventArgs arg =
                formattedValue as DataGridViewProgressCellPaintStateEventArgs;

            bool selected = ((cellState & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected);

            arg.CellState = cellState;
            if (selected)
            {
                if (arg.Value >= 0 && arg.Value <= 100)
                {
                    arg.ForeColorProgress = cellStyle.SelectionForeColor;
                    arg.BackColorProgress = ProgressBarColorSelection;
                }
                else if (arg.BackColorProgress == ProgressBarColorDefault)
                {
                    arg.ForeColorProgress = cellStyle.SelectionForeColor;
                    arg.BackColorProgress = ProgressBarColorSelection;
                }
            }

            OnPaintCellState(arg);

            Rectangle rcProgress = new Rectangle(
                cellBounds.X + 2,
                cellBounds.Y + 2,
                Convert.ToInt32((1.0f * cellBounds.Width * 0.95)),
                cellBounds.Height - 5);

            //evaluating text position according to alignment
            PointF ptText = DrawTextPlace(arg.Text, cellStyle, cellStyle.Alignment, cellBounds);

            ptText.X -= rcProgress.X;
            ptText.Y -= rcProgress.Y;

            Bitmap bmpDefault = new Bitmap(rcProgress.Width, rcProgress.Height);
            Bitmap bmpProgress = new Bitmap(rcProgress.Width, rcProgress.Height);

            DrawCellShadow(rcProgress, cellStyle, arg, ptText, bmpDefault, false);
            DrawCellShadow(rcProgress, cellStyle, arg, ptText, bmpProgress, true);

            //Combine images
            if (arg.Percent > 0)
            {
                float w = arg.Percent * rcProgress.Width;
                using (Graphics gr = Graphics.FromImage(bmpDefault))
                {
                    RectangleF rcf = new RectangleF(0, 0, w, rcProgress.Height);
                    gr.DrawImage(bmpProgress, rcf, rcf, GraphicsUnit.Pixel);
                }
            }

            ptText.X += rcProgress.X;
            ptText.Y += rcProgress.Y;

            //Fill all area
            SolidBrush brBack = new SolidBrush(
                selected ? cellStyle.SelectionBackColor : cellStyle.BackColor
                );
            g.FillRectangle(brBack, cellBounds);
            brBack.Dispose();

            //Draw Grid
            Pen gridColorPen = new Pen(this.DataGridView.GridColor, 0.5F);
            int xw = cellBounds.X + cellBounds.Width;
            int yh = cellBounds.Y + cellBounds.Height;
            if (this.ColumnIndex != this.DataGridView.ColumnCount - 1)
                xw--;
            if (this.RowIndex != this.DataGridView.RowCount - 1)
                yh--;
            //g.DrawLine(gridColorPen, cellBounds.X, cellBounds.Y, xw, cellBounds.Y);   //Top
            if (this.ColumnIndex == 0)
                g.DrawLine(gridColorPen, cellBounds.X, cellBounds.Y, cellBounds.X, yh); //Left
            g.DrawLine(gridColorPen, xw, cellBounds.Y, xw, yh - 1);                     //Right
            g.DrawLine(gridColorPen, cellBounds.X, yh - 1, xw, yh - 1);                 //Bottom

            gridColorPen.Dispose();

            g.DrawImage(bmpDefault, rcProgress.Location);
        }

        private void DrawCellShadow(Rectangle rcProgress,
                    DataGridViewCellStyle cellStyle,
                    DataGridViewProgressCellPaintStateEventArgs arg,
                    PointF ptText, Bitmap bmp, bool progressed)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                SolidBrush brFore = new SolidBrush(progressed ? arg.ForeColorProgress : arg.ForeColorDefault);
                SolidBrush brBack = new SolidBrush(progressed ? arg.BackColorProgress : arg.BackColorDefault);

                g.FillRectangle(brBack, 0, 0, rcProgress.Width, rcProgress.Height);
                g.DrawString(arg.Text, cellStyle.Font, brFore, ptText.X, ptText.Y);

                brFore.Dispose();
                brBack.Dispose();
            }
        }

        private PointF DrawTextPlace(string text,
                DataGridViewCellStyle cellStyle,
                DataGridViewContentAlignment _Alignment,
                System.Drawing.Rectangle cellBounds
                )
        {
            PointF ptText = new PointF(cellBounds.X, cellBounds.Y);

            Size szDrawText = TextRenderer.MeasureText(text, cellStyle.Font);
            float textWidth = szDrawText.Width;
            float textHeight = szDrawText.Height;

            switch (_Alignment)
            {
                case DataGridViewContentAlignment.BottomCenter:
                    ptText.X = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2;
                    ptText.Y = cellBounds.Y + cellBounds.Height - textHeight;
                    break;
                case DataGridViewContentAlignment.BottomLeft:
                    ptText.X = cellBounds.X;
                    ptText.Y = cellBounds.Y + cellBounds.Height - textHeight;
                    break;
                case DataGridViewContentAlignment.BottomRight:
                    ptText.X = cellBounds.X + cellBounds.Width - textWidth;
                    ptText.Y = cellBounds.Y + cellBounds.Height - textHeight;
                    break;
                case DataGridViewContentAlignment.MiddleCenter:
                    ptText.X = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2;
                    ptText.Y = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2;
                    break;
                case DataGridViewContentAlignment.MiddleLeft:
                    ptText.X = cellBounds.X;
                    ptText.Y = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2;
                    break;
                case DataGridViewContentAlignment.MiddleRight:
                    ptText.X = cellBounds.X + cellBounds.Width - textWidth;
                    ptText.Y = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2;
                    break;
                case DataGridViewContentAlignment.TopCenter:
                    ptText.X = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2;
                    ptText.Y = cellBounds.Y;
                    break;
                case DataGridViewContentAlignment.TopLeft:
                    ptText.X = cellBounds.X;
                    ptText.Y = cellBounds.Y;
                    break;
                case DataGridViewContentAlignment.TopRight:
                    ptText.X = cellBounds.X + cellBounds.Width - textWidth;
                    ptText.Y = cellBounds.Y;
                    break;
            }

            return ptText;
        }
        #endregion

        //Important for deserialize with VS designer
        public override object Clone()
        {
            DataGridViewProgressCell dataGridViewCell = base.Clone() as DataGridViewProgressCell;
            if (dataGridViewCell != null)
            {
                dataGridViewCell.ProgressBarColorDefault = this.ProgressBarColorDefault;
                dataGridViewCell.ProgressBarColorSelection = this.ProgressBarColorSelection;
                dataGridViewCell.progressBarColorQueue = this.progressBarColorQueue;
                dataGridViewCell.progressBarColorProcess = this.progressBarColorProcess;
                dataGridViewCell.progressBarColorError = this.progressBarColorError;
                dataGridViewCell.progressBarColorFinish = this.progressBarColorFinish;
            }
            return dataGridViewCell;
        }

        public override Type FormattedValueType { get { return typeof(string); } }
    }
}
