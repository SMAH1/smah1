using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

//main from Chinese page

namespace SMAH1.Forms.DataGridViewComponent
{
    public class DataGridViewNumTextBoxColumn : DataGridViewColumn
    {
        public DataGridViewNumTextBoxColumn()
            : base(new DataGridViewNumTextBoxCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (!(value is DataGridViewNumTextBoxCell))
                {
                    throw new InvalidCastException("");
                }
                base.CellTemplate = value;
            }
        }

        private DataGridViewNumTextBoxCell ValueCellTemplate { get { return (DataGridViewNumTextBoxCell)this.CellTemplate; } }


        [Browsable(true)]
        [Category("Range")]
        public decimal Minimum
        {
            get
            {
                if (this.ValueCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.ValueCellTemplate.Minimum;
            }
            set
            {

                if (this.ValueCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.ValueCellTemplate.Minimum = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[this.Index] is DataGridViewNumTextBoxCell dataGridViewCell)
                        {
                            dataGridViewCell.SetMinimum(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }

        [Browsable(true)]
        [Category("Range")]
        public decimal Maximum
        {
            get
            {
                if (this.ValueCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.ValueCellTemplate.Maximum;
            }
            set
            {

                if (this.ValueCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.ValueCellTemplate.Maximum = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[this.Index] is DataGridViewNumTextBoxCell dataGridViewCell)
                        {
                            dataGridViewCell.SetMaximum(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }

        [Browsable(true)]
        [Category("Range")]
        public int DecimalPlaces
        {
            get
            {
                if (this.ValueCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.ValueCellTemplate.DecimalPlaces;
            }
            set
            {

                if (this.ValueCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.ValueCellTemplate.DecimalPlaces = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[this.Index] is DataGridViewNumTextBoxCell dataGridViewCell)
                        {
                            dataGridViewCell.SetDecimalPlaces(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }
    }
}
