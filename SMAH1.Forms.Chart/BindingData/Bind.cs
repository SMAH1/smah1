using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace SMAH1.BindingData
{
    public static class Bind
    {
        public static BindingDataBase FromDataTable(DataTable dataTable)
        {
            if (dataTable == null)
                throw new ArgumentException("'dataTable' is null");
            return new BindingDataTable(dataTable);
        }
        public static BindingDataBase FromDataSet(DataSet dataSet, string tableName)
        {
            if (dataSet == null)
                throw new ArgumentException("'dataSet' is null");
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentException("'tableName' is null");

            BindingDataBase ret = null;

            try
            {
                DataTable dt = dataSet.Tables[tableName];

                if (dt == null)
                    throw new ArgumentException("Table not found!");

                ret = new BindingDataTable(dt);
            }
            catch
            {
                throw new ArgumentException("Table not found!");
            }

            return ret;    //Dont excute this!
        }
        public static BindingDataBase FromDataGridView(DataGridView dataGridView)
        {
            return FromDataGridView(dataGridView, false);
        }
        public static BindingDataBase FromDataGridView(DataGridView dataGridView, bool onlyVisibleColumn)
        {
            if (dataGridView == null)
                throw new ArgumentException("'dataGridView' is null");

            return new BindingDataGridView(dataGridView, onlyVisibleColumn);
        }
        public static BindingDataBase FromList(System.Collections.IList lst)
        {
            if (lst == null)
                throw new ArgumentException("'lst' is null");
            return new BindingList(lst);
        }
        public static BindingDataBase FromListList(IList<System.Collections.IList> lstList)
        {
            if (lstList == null)
                throw new ArgumentException("'lstList' is null");
            return new BindingListList(lstList);
        }
        public static BindingDataBase FromEmptyRows(int rowCount)
        {
            return new EmptyRowsBindingData(rowCount);
        }
        public static BindingMultiIBindingData FromIBindingDatas(params IBindingData[] bds)
        {
            if (bds.Length < 1)
                throw new ArgumentException("Enter IBindingData(s)!");

            return new BindingMultiIBindingData(bds);
        }
        public static BindingDataLinearMap FromBindingDataLinearMap(IBindingData bd)
        {
            if (bd == null)
                throw new ArgumentException("'bs' is null");

            return new BindingDataLinearMap(bd);
        }
        public static BindingDataLinearMap FromBindingDataLinearMap(IBindingData bd, double scale)
        {
            if (bd == null)
                throw new ArgumentException("'bs' is null");

            return new BindingDataLinearMap(bd, scale, 0);
        }
        public static BindingDataLinearMap FromBindingDataLinearMap(IBindingData bd,
                    double scale, double offset
                    )
        {
            if (bd == null)
                throw new ArgumentException("'bs' is null");

            return new BindingDataLinearMap(bd, scale, offset);
        }
    }
}
