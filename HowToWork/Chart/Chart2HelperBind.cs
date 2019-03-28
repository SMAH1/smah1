using System;

namespace HowToWork
{
    internal class Chart2HelperBind : SMAH1.BindingData.IBindingData
    {
        SMAH1.BindingData.IBindingData master = null;
        internal Chart2HelperBind(SMAH1.BindingData.IBindingData master)
        {
            if (master == null)
                throw new ArgumentNullException("master");

            this.master = master;
            hideColumn3 = false;
        }

        bool hideColumn3 = false;
        public bool HideColumn3
        {
            get { return hideColumn3; }
            set { hideColumn3 = value; }
        }

        #region IBindingData Members

        public int ColumnCount
        {
            get { return master.ColumnCount; }
        }

        public int RowCount
        {
            get { return master.RowCount; }
        }

        public string Name
        {
            get { return master.Name; }
        }

        public string ColumnName(int index)
        {
            return master.ColumnName(index);
        }

        public double ValueDouble(int indexRow, int indexColumn)
        {
            return master.ValueDouble(indexRow, indexColumn);
        }

        public object ValueObject(int indexRow, int indexColumn)
        {
            return master.ValueObject(indexRow, indexColumn);
        }

        public bool Valid(int indexRow, int indexColumn)
        {
            if (hideColumn3 && indexColumn == 2)
                return false;
            return master.Valid(indexRow, indexColumn);
        }

        public virtual double ColumnValue(int indexColumn)
        {
            return (double)indexColumn;
        }

        public object CalculateColumnValue(double value)
        {
            int index = (int)(value);
            return ColumnName(index);
        }
        #endregion
    }
}
