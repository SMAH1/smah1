using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;

namespace SMAH1.Forms.DataGridViewComponent
{
    public class DataGridViewProgressColumn : DataGridViewColumn
    {
        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DataGridViewProgressCell)))
                {
                    throw new InvalidCastException("Must be a DataGridViewProgressCell");
                }
                base.CellTemplate = value;
            }
        }

        #region colors
        [Browsable(true)]
        [Category("Progress Bar Color")]
        [DisplayName("Default")]
        public Color ProgressBarColorDefault
        {
            get
            {
                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.ProgressBarCellTemplate.ProgressBarColorDefault;
            }
            set
            {
                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.ProgressBarCellTemplate.ProgressBarColorDefault = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[this.Index] is DataGridViewProgressCell dataGridViewCell)
                        {
                            dataGridViewCell.SetProgressBarColorDefault(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }

        [Browsable(true)]
        [Category("Progress Bar Color")]
        [DisplayName("Progress")]
        public Color ProgressBarColorSelection
        {
            get
            {
                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.ProgressBarCellTemplate.ProgressBarColorSelection;
            }
            set
            {

                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.ProgressBarCellTemplate.ProgressBarColorSelection = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[this.Index] is DataGridViewProgressCell dataGridViewCell)
                        {
                            dataGridViewCell.SetProgressBarColorSelection(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }

        [Browsable(true)]
        [Category("Progress Bar Color")]
        [DisplayName("Queue")]
        public Color ProgressBarColorQueue
        {
            get
            {
                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.ProgressBarCellTemplate.ProgressBarColorQueue;
            }
            set
            {
                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.ProgressBarCellTemplate.ProgressBarColorQueue = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[this.Index] is DataGridViewProgressCell dataGridViewCell)
                        {
                            dataGridViewCell.SetProgressBarColorQueue(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }

        [Browsable(true)]
        [Category("Progress Bar Color")]
        [DisplayName("Process")]
        public Color ProgressBarColorProcess
        {
            get
            {
                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.ProgressBarCellTemplate.ProgressBarColorProcess;
            }
            set
            {
                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.ProgressBarCellTemplate.ProgressBarColorProcess = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[this.Index] is DataGridViewProgressCell dataGridViewCell)
                        {
                            dataGridViewCell.SetProgressBarColorProcess(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }

        [Browsable(true)]
        [Category("Progress Bar Color")]
        [DisplayName("Error")]
        public Color ProgressBarColorError
        {
            get
            {
                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.ProgressBarCellTemplate.ProgressBarColorError;
            }
            set
            {
                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.ProgressBarCellTemplate.ProgressBarColorError = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[this.Index] is DataGridViewProgressCell dataGridViewCell)
                        {
                            dataGridViewCell.SetProgressBarColorError(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }

        [Browsable(true)]
        [Category("Progress Bar Color")]
        [DisplayName("Finish")]
        public Color ProgressBarColorFinish
        {
            get
            {
                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.ProgressBarCellTemplate.ProgressBarColorFinish;
            }
            set
            {
                if (this.ProgressBarCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.ProgressBarCellTemplate.ProgressBarColorFinish = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[this.Index] is DataGridViewProgressCell dataGridViewCell)
                        {
                            dataGridViewCell.SetProgressBarColorFinish(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }
        #endregion

        #region Event
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Custom")]
        [Description("Fire when cell must be paint for custom color and text and progress value.")]

        public event DataGridViewProgressCellPaintStateEventHandler PaintState;

        private void OnPaintCellState(DataGridViewProgressCellPaintStateEventArgs arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg");

            PaintState?.Invoke(this, arg);
        }
        #endregion

        //Use for fire PaintState from DataGridViewProgressCell
        internal void FilePaintCellState(DataGridViewProgressCellPaintStateEventArgs arg)
        {
            OnPaintCellState(arg);
        }

        private DataGridViewProgressCell ProgressBarCellTemplate { get { return (DataGridViewProgressCell)this.CellTemplate; } }
    }
}
