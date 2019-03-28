using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SMAH1.BindingData
{
    public class BindingListList : BindingDataBase
    {
        private IList<System.Collections.IList> lstList = null;
        private readonly int countColumn = 0;

        internal protected BindingListList(IList<System.Collections.IList> lstList)
        {
            this.lstList = lstList;

            countColumn = 0;
            foreach (System.Collections.IList lst in this.lstList)
            {
                if (countColumn < lst.Count)
                    countColumn = lst.Count;
            }
        }

        #region BindingDataBase Members
        public override int ColumnCount
        {
            get { return countColumn; }
        }

        public override int RowCount
        {
            get { return lstList.Count; }
        }

        public override string ColumnName(int index)
        {
            if (index < countColumn)
                return (index + 1).ToString();
            return "";
        }


        public override object ValueObject(int indexRow, int indexColumn)
        {
            try
            {
                if (indexRow < lstList.Count)
                {
                    System.Collections.IList lst = lstList[indexRow];
                    if (indexColumn < lst.Count)
                    {
                        return lst[indexColumn];
                    }
                }
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
