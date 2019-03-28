using System;
using System.Drawing;
using System.Windows.Forms;

namespace SMAH1.Forms.DataGridViewComponent
{
    public class DataGridViewRowNumberCell : DataGridViewTextBoxCell
    {
        public DataGridViewRowNumberCell() { }

        protected override object GetValue(int rowIndex)
        {
            return rowIndex + 1;
        }

        public override Type ValueType
        {
            get { return typeof(int); }
        }

        public override object DefaultNewRowValue
        {
            get { return 0; }
        }
    }
}
