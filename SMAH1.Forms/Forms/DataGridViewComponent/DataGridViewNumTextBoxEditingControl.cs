using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

//main from Chinese page

namespace SMAH1.Forms.DataGridViewComponent
{
    public class DataGridViewNumTextBoxEditingControl : NumericUpDown, IDataGridViewEditingControl
    {
        DataGridView dataGridView;

        public DataGridViewNumTextBoxEditingControl()
        {
            this.TabStop = false;
            this.Minimum = decimal.MinValue;
            this.Maximum = decimal.MaxValue;
            this.DecimalPlaces = 0;
            this.Increment = 1;
        }

        #region IDataGridViewEditingControl

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Value.ToString("F" + DecimalPlaces);
        }

        public int EditingControlRowIndex { get; set; }
        public bool EditingControlValueChanged { get; set; }

        public object EditingControlFormattedValue
        {
            get
            {
                return this.GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                SetValue(value);
            }
        }

        private void SetValue(object value)
        {
            if (value != null)
            {
                if (!decimal.TryParse(value.ToString(), out decimal d))
                    d = Minimum;
                if (d < Minimum)
                    d = Minimum;
                if (d > Maximum)
                    d = Maximum;
                //Fix bug of .NET
                //    If this.Value > Maximum then set this.Value = Maximum AND this.Value = d not work!
                while (this.Value != d)
                    this.Value = d;
            }
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
            switch (dataGridViewCellStyle.Alignment)
            {
                case DataGridViewContentAlignment.BottomCenter:
                case DataGridViewContentAlignment.MiddleCenter:
                case DataGridViewContentAlignment.TopCenter:
                    this.TextAlign = HorizontalAlignment.Center;
                    break;
                case DataGridViewContentAlignment.BottomRight:
                case DataGridViewContentAlignment.MiddleRight:
                case DataGridViewContentAlignment.TopRight:
                    this.TextAlign = HorizontalAlignment.Right;
                    break;
                default:
                    this.TextAlign = HorizontalAlignment.Left;
                    break;
            }
        }

        public DataGridView EditingControlDataGridView
        {
            get { return this.dataGridView; }
            set
            {
                this.dataGridView = value;
                Minimum = (((DataGridViewNumTextBoxCell)this.dataGridView.CurrentCell)).Minimum;
                Maximum = (((DataGridViewNumTextBoxCell)this.dataGridView.CurrentCell)).Maximum;
                DecimalPlaces = (((DataGridViewNumTextBoxCell)this.dataGridView.CurrentCell)).DecimalPlaces;
                Increment = (((DataGridViewNumTextBoxCell)this.dataGridView.CurrentCell)).Increment;
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Right:
                case Keys.End:
                case Keys.Left:
                case Keys.Home:
                case Keys.Up:
                case Keys.Down:
                case Keys.Escape:
                    return true;
                default:
                    return false;
            }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            SetValue(this.dataGridView.CurrentCell.Value);
            if (selectAll)
                this.Select(0, this.Text.Length);
            this.dataGridView.NotifyCurrentCellDirty(selectAll);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SetValue(this.dataGridView.CurrentCell.Value);
                dataGridView.EndEdit();
            }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        protected override void OnValidated(EventArgs e)
        {
            try
            {
                if (this.Text == "")
                {
                    (this.Parent.Parent as DataGridView).CurrentCell.Value = Minimum.ToString();
                }
                else
                {
                    (this.Parent.Parent as DataGridView).CurrentCell.Value = this.Text;
                }
            }
            catch
            {
                this.dataGridView.NotifyCurrentCellDirty(true);
            }
            base.OnValidated(e);
        }

        #endregion
    }
}
