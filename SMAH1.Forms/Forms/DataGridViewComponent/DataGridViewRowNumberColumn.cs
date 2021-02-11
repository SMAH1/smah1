using SMAH1.Character;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SMAH1.Forms.DataGridViewComponent
{
    public class DataGridViewRowNumberColumn : DataGridViewColumn
    {
        public DataGridViewRowNumberColumn()
            : base(new DataGridViewRowNumberCell())
        {
            ReadOnly = true;
            Start = 1;
            NumeralSign = NumeralSystemSign.Default;
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (!(value is DataGridViewRowNumberCell))
                {
                    throw new InvalidCastException("");
                }
                base.CellTemplate = value;
            }
        }

        private DataGridViewRowNumberCell ValueCellTemplate { get { return (DataGridViewRowNumberCell)this.CellTemplate; } }

        public override bool ReadOnly { get { return base.ReadOnly; } set { base.ReadOnly = true; } }

        [Browsable(true)]
        [Category("Number")]
        public int Start
        {
            get
            {
                if (this.ValueCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.ValueCellTemplate.Start;
            }
            set
            {

                if (this.ValueCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.ValueCellTemplate.Start = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[this.Index] is DataGridViewRowNumberCell dataGridViewCell)
                        {
                            dataGridViewCell.SetStart(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }

        [Browsable(true)]
        [Category("Number")]
        public NumeralSystemSign NumeralSign
        {
            get
            {
                if (this.ValueCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.ValueCellTemplate.NumeralSign;
            }
            set
            {

                if (this.ValueCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.ValueCellTemplate.NumeralSign = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[this.Index] is DataGridViewRowNumberCell dataGridViewCell)
                        {
                            dataGridViewCell.SetNumeralSign(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }
    }
}
