using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SMAH1.BindingData
{
    public class BindingDataTable : BindingDataBase
    {
        private DataTable dt = null;

        internal protected BindingDataTable(DataTable dataTable)
        {
            dt = dataTable;
            Name = dataTable.TableName;
        }

        #region BindingDataBase Members
        public override int ColumnCount
        {
            get { return dt.Columns.Count; }
        }

        public override int RowCount
        {
            get { return dt.Rows.Count; }
        }

        public override string ColumnName(int index)
        {
            if (index < dt.Columns.Count)
                return dt.Columns[index].ColumnName;
            return "";
        }

        public override object ValueObject(int indexRow, int indexColumn)
        {
            try
            {
                return dt.Rows[indexRow][indexColumn];
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
