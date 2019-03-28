using System;
using System.Drawing;
using System.Windows.Forms;

namespace SMAH1.Forms.DataGridViewComponent
{
    public class DataGridViewRowNumberColumn : DataGridViewColumn
    {
        public DataGridViewRowNumberColumn()
            : base(new DataGridViewRowNumberCell())
        {
            ReadOnly = true;
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

        public override bool ReadOnly { get { return base.ReadOnly; } set { base.ReadOnly = true; } }
    }
}
