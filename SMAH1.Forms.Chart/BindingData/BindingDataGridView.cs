using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace SMAH1.BindingData
{
    public class BindingDataGridView : BindingDataBase
    {
        private DataGridView dgv = null;

        List<int> columnIndex = null;

        internal protected BindingDataGridView(DataGridView dataGridView,bool onlyVisibleColumn)
        {
            dgv = dataGridView;
            Name = dgv.Name;

            columnIndex = new List<int>();
            for (int index = 0; index < dgv.Columns.Count; index++)
                if (dgv.Columns[index].Visible || !onlyVisibleColumn)
                    columnIndex.Add(index);
        }

        #region BindingDataBase Members
        public override int ColumnCount
        {
            get { return columnIndex.Count; }
        }

        public override int RowCount
        {
            get { return dgv.Rows.Count; }
        }

        public override string ColumnName(int index)
        {
            if (index < columnIndex.Count)
                return dgv.Columns[columnIndex[index]].HeaderText;
            return "";
        }

        public override object ValueObject(int indexRow, int indexColumn)
        {
            try
            {
                return dgv.Rows[indexRow].Cells[columnIndex[indexColumn]].FormattedValue;
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
