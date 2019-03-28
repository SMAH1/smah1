using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SMAH1.BindingData
{
    public interface IBindingData
    {
        int ColumnCount { get; }
        int RowCount { get; }
        string Name { get; }
        string ColumnName(int index);
        double ValueDouble(int indexRow, int indexColumn);
        object ValueObject(int indexRow, int indexColumn);
        bool Valid(int indexRow, int indexColumn);
        double ColumnValue(int indexColumn);
        object CalculateColumnValue(double value);
    }

    public abstract class BindingDataBase : IBindingData
    {
        protected string objName = string.Empty;

        public abstract int ColumnCount { get; }
        public abstract int RowCount { get; }
        public abstract string ColumnName(int index);
        public abstract object ValueObject(int indexRow, int indexColumn);
        public abstract bool Valid(int indexRow, int indexColumn);

        public virtual double ValueDouble(int indexRow, int indexColumn)
        {
            object obj = ValueObject(indexRow, indexColumn);
            if (obj == null)
                return 0;
            try
            {
                return Convert.ToDouble(obj);
            }
            catch { }
            return 0;
        }

        public virtual double ColumnValue(int indexColumn)
        {
            return (double)indexColumn;
        }

        public virtual object CalculateColumnValue(double value)
        {
            int index = (int)(value);
            return ColumnName(index);
        }

        public string Name { get { return objName; } set { objName = value; } }

        public override string ToString()
        {
            return Name;
        }

        public static void FindMaxMin(IBindingData data, ref double max, ref double min)
        {
            int rowIndex, colIndex;
            max = 0;
            min = 0;

            for (rowIndex = 0; rowIndex < data.RowCount; rowIndex++)
            {
                for (colIndex = 0; colIndex < data.ColumnCount; colIndex++)
                {
                    double d = data.ValueDouble(rowIndex, colIndex);
                    if (d > max)
                        max = d;
                    if (d < min)
                        min = d;
                }
            }
        }
    }
}
