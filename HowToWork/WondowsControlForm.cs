using SMAH1.ExtensionMethod;
using System;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class WondowsControlForm : Form
    {
        public WondowsControlForm()
        {
            InitializeComponent();
        }

        private void WondowsControlForm_Load(object sender, EventArgs e)
        {
            cbxNumberType.DataSource = SMAH1.EnumInfoBase<SMAH1.Forms.Text.TextBoxNumberType>.GetFields();
            cbxButtonArrowType.DataSource = SMAH1.EnumInfoBase<SMAH1.Forms.Clickable.ButtonDirection.ArrowType>.GetFields();
            chbxBtnArrow.Checked = true;
            Update3StateLabel();

            txtNumFormat.SelectTextIfFocus();
            txtNumFormat.CreateToolTip("Input number");
            hourSelector1.CreateToolTip("Select Hours");

            UpdateHourSelected();
            UpdateButtonDIrectionPadding();
        }

        private void cbxNumberType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumFormat.NumberType = (SMAH1.Forms.Text.TextBoxNumberType)cbxNumberType.SelectedItem;
        }

        private void chbxBtnArrow_CheckedChanged(object sender, EventArgs e)
        {
            buttonWithArrow1.Enabled = chbxBtnArrow.Checked;
            buttonWithArrow2.Enabled = chbxBtnArrow.Checked;
            buttonWithArrow3.Enabled = chbxBtnArrow.Checked;
            buttonWithArrow4.Enabled = chbxBtnArrow.Checked;
        }

        private void cbxButtonArrowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonWithArrow1.Type = (SMAH1.Forms.Clickable.ButtonDirection.ArrowType)cbxButtonArrowType.SelectedItem;
            buttonWithArrow2.Type = buttonWithArrow1.Type;
            buttonWithArrow3.Type = buttonWithArrow1.Type;
            buttonWithArrow4.Type = buttonWithArrow1.Type;
        }

        private void chbxText_CheckStateChanged(object sender, EventArgs e)
        {
            Update3StateLabel();
        }

        private void Update3StateLabel()
        {
            lbl3State.Text = chbxText.CheckState.ToString();
        }

        private void hourSelector1_StateClockChange(object sender, EventArgs e)
        {
            UpdateHourSelected();
        }

        private void UpdateHourSelected()
        {
            lblHourSelected.Text = string.Join(",", hourSelector1.GetClockCheckedString());
        }

        private void numButtonDIrectionPadding_ValueChanged(object sender, EventArgs e)
        {
            UpdateButtonDIrectionPadding();
        }

        private void UpdateButtonDIrectionPadding()
        {
            var p = new Padding((int)numButtonDIrectionPadding.Value);

            buttonWithArrow1.Padding = p;
            buttonWithArrow2.Padding = p;
            buttonWithArrow3.Padding = p;
            buttonWithArrow4.Padding = p;
        }
    }
}
