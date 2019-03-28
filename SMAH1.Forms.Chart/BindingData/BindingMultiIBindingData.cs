using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SMAH1.BindingData
{
    public class BindingMultiIBindingData : BindingDataBase
    {
        private List<IBindingData> lst = null;
        private List<int> rowsCountF = null;
        private int countColumn = 0;
        private int countRow = 0;

        IBindingData columnName = null;

        internal protected BindingMultiIBindingData(params IBindingData[] bds)
        {
            if (bds.Length < 1)
                throw new Exception("Enter IBindingData(s)!");

            lst = new List<IBindingData>();
            lst.AddRange(bds);

            UpdateCount();

            columnName = lst[0];
        }

        private void UpdateCount()
        {
            rowsCountF = new List<int>();

            countColumn = 0;
            countRow = 0;
            foreach (IBindingData bd in lst)
            {
                if (countColumn < bd.ColumnCount)
                    countColumn = bd.ColumnCount;
                rowsCountF.Add(countRow);
                countRow += bd.RowCount;
            }
            rowsCountF.Add(countRow);
        }

        #region management
        public IBindingData ColumnNameBindingData
        {
            get { return columnName; }
            set { columnName = value; }
        }

        public int IBindingDataCount { get { return lst.Count; } }

        public IBindingData GetIBindingData(int index)
        {
            if (index < lst.Count)
                return lst[index];
            return null;
        }

        public System.Collections.IList GetIBindingDatas()
        {
            return lst;
        }

        public void Add(IBindingData bd)
        {
            lst.Add(bd);
            UpdateCount();
        }

        public void Insert(int index, IBindingData bd)
        {
            lst.Insert(index, bd);
            UpdateCount();
        }

        public void Remove(IBindingData bd)
        {
            lst.Remove(bd);
            UpdateCount();
        }

        public void RemoveAt(int index)
        {
            lst.RemoveAt(index);
            UpdateCount();
        }
        #endregion

        #region BindingDataBase Members
        public override int ColumnCount
        {
            get { return countColumn; }
        }

        public override int RowCount
        {
            get { return countRow; }
        }

        public override string ColumnName(int index)
        {
            if (index < columnName.ColumnCount)
                return columnName.ColumnName(index);
            return "";
        }

        public override double ColumnValue(int indexColumn)
        {
            return columnName.ColumnValue(indexColumn);
        }

        public override object ValueObject(int indexRow, int indexColumn)
        {
            try
            {
                if (indexRow < countRow)
                {
                    IBindingData bs = FindIBindingData(indexRow, out int inx);
                    if (bs != null && indexColumn < bs.ColumnCount)
                    {
                        return bs.ValueObject(indexRow - rowsCountF[inx], indexColumn);
                    }
                }
            }
            catch { }
            return null;
        }

        public override double ValueDouble(int indexRow, int indexColumn)
        {
            try
            {
                if (indexRow < countRow)
                {
                    IBindingData bs = FindIBindingData(indexRow, out int inx);
                    if (bs != null && indexColumn < bs.ColumnCount)
                    {
                        return bs.ValueDouble(indexRow - rowsCountF[inx], indexColumn);
                    }
                }
            }
            catch { }
            return 0;
        }

        private IBindingData FindIBindingData(int indexRow, out int i)
        {
            IBindingData bs = null;
            i = 0;
            while (indexRow >= rowsCountF[i])
                i++;
            i--;

            bs = lst[i];
            return bs;
        }

        public override bool Valid(int indexRow, int indexColumn)
        {
            try
            {
                if (indexRow < countRow)
                {
                    IBindingData bs = FindIBindingData(indexRow, out int inx);
                    if (bs != null && indexColumn < bs.ColumnCount)
                    {
                        return bs.Valid(indexRow - rowsCountF[inx], indexColumn);
                    }
                }
            }
            catch { }
            return false;
        }
        #endregion
    }
}
