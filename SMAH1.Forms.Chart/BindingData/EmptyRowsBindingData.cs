using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SMAH1.BindingData
{
    public class EmptyRowsBindingData : BindingDataBase
    {
        private readonly int rowCount = 1;

        internal protected EmptyRowsBindingData(int rowCount)
        {
            if (rowCount < 1)
                rowCount = 1;
            this.rowCount = rowCount;
        }

        #region BindingDataBase Members
        public override int ColumnCount
        {
            get { return 0; }
        }

        public override int RowCount
        {
            get { return rowCount; }
        }

        public override string ColumnName(int index)
        {
            return "";
        }

        public override object ValueObject(int indexRow, int indexColumn)
        {
            return null;
        }

        public override bool Valid(int indexRow, int indexColumn)
        {
            return true;
        }
        #endregion
    }
}
