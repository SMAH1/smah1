using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SMAH1.BindingData
{
    public class BindingList : BindingDataBase
    {
        private System.Collections.IList lst = null;

        internal protected BindingList(System.Collections.IList list)
        {
            lst = list;
        }

        #region BindingDataBase Members
        public override int ColumnCount
        {
            get { return lst.Count; }
        }

        public override int RowCount
        {
            get { return 1; }
        }

        public override string ColumnName(int index)
        {
            if (index < lst.Count)
                return (index+1).ToString();
            return "";
        }

        public override object ValueObject(int indexRow, int indexColumn)
        {
            try
            {
                return lst[indexColumn];
            }
            catch { }
            return null;
        }

        public override bool Valid(int indexRow, int indexColumn)
        {
            return true;
        }
        #endregion
    }
}
