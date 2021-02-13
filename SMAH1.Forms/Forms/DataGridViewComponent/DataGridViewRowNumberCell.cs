using SMAH1.Character;
using System;
using System.Windows.Forms;
using SMAH1.ExtensionMethod;

namespace SMAH1.Forms.DataGridViewComponent
{
    public class DataGridViewRowNumberCell : DataGridViewTextBoxCell
    {
        public DataGridViewRowNumberCell() { }

        protected override object GetValue(int rowIndex)
        {
            return (rowIndex + Start).ToString().NumeralSystemReplacer(NumeralSign, NumeralSystemSign.Default);
        }

        public override Type ValueType
        {
            get { return typeof(string); }
        }

        public override object DefaultNewRowValue
        {
            get { return 0; }
        }

        //Important for deserialize with VS designer
        public override object Clone()
        {
            DataGridViewRowNumberCell dataGridViewCell = base.Clone() as DataGridViewRowNumberCell;
            if (dataGridViewCell != null)
            {
                dataGridViewCell.Start = this.Start;
                dataGridViewCell.NumeralSign = this.NumeralSign;
            }
            return dataGridViewCell;
        }

        public int Start { get; set; } = 1;
        public NumeralSystemSign NumeralSign { get; set; } = NumeralSystemSign.Default;

        internal void SetStart(int rowIndex, int value) { Start = value; }
        internal void SetNumeralSign(int rowIndex, NumeralSystemSign value) { NumeralSign = value; }
    }
}
