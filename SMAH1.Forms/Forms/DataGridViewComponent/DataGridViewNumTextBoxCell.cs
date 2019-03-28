using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

//main from Chinese page

namespace SMAH1.Forms.DataGridViewComponent
{
    public class DataGridViewNumTextBoxCell : DataGridViewTextBoxCell
    {
        int decimalPlaces = 0;

        public DataGridViewNumTextBoxCell()
        {
            Minimum = int.MinValue;
            Maximum = int.MaxValue;
            decimalPlaces = 0;
        }

        public override void InitializeEditingControl(
            int rowIndex, object initialFormattedValue,
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex,
                initialFormattedValue, dataGridViewCellStyle);

            if (this.DataGridView.EditingControl is DataGridViewNumTextBoxEditingControl NumBox)
            {
                if ((this.RowIndex < 0) || (this.ColumnIndex < 0))
                    return;

                NumBox.Text = this.Value != null ? this.Value.ToString() : "1";
            }
        }

        public decimal Minimum { get; set; } = int.MinValue;
        public decimal Maximum { get; set; } = int.MaxValue;

        public int DecimalPlaces
        {
            get { return decimalPlaces; }
            set
            {
                if (value < 0 || value > 99)
                {
                    throw new ArgumentOutOfRangeException("The DecimalPlaces property cannot be smaller than 0 or larger than 99.");
                }
                this.decimalPlaces = value;
            }
        }

        public override Type EditType
        {
            get { return typeof(DataGridViewNumTextBoxEditingControl); }
        }

        public override Type ValueType
        {
            get { return typeof(object); }
        }

        public override object DefaultNewRowValue
        {
            get { return base.DefaultNewRowValue; }
        }

        //Important for deserialize with VS designer
        public override object Clone()
        {
            DataGridViewNumTextBoxCell dataGridViewCell = base.Clone() as DataGridViewNumTextBoxCell;
            if (dataGridViewCell != null)
            {
                dataGridViewCell.Minimum = this.Minimum;
                dataGridViewCell.Maximum = this.Maximum;
            }
            return dataGridViewCell;
        }

        internal void SetMinimum(int rowIndex, decimal value) { this.Minimum = value; }

        internal void SetMaximum(int rowIndex, decimal value) { this.Maximum = value; }

        internal void SetDecimalPlaces(int rowIndex, int value) { this.DecimalPlaces = value; }
    }
}
