using SMAH1.Forms.Text.Persian;
using System;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class DatePickerTestForm : Form
    {
        public DatePickerTestForm()
        {
            InitializeComponent();

            lblDate11.Text = string.Empty;
            lblDate12.Text = string.Empty;
            lblDate21.Text = string.Empty;
            lblDate22.Text = string.Empty;
        }

        private void DatePickerTestForm_Load(object sender, EventArgs e)
        {
            ReloadAllowEmpty();
        }

        private void DatePicker1_SelectDate(object sender, EventArgs e)
        {
            lblDate11.Text = "String: " + datePicker1.Value.ToString();
            lblDate12.Text = "Date: " + datePicker1.Value.ToDate().ToString();
        }

        private void BtnSetUp_Click(object sender, EventArgs e)
        {
            datePicker1.Value = datePicker2.Value;
        }

        private void Button4btnChkOpt_Click(object sender, EventArgs e)
        {
            if (datePicker1.Value == datePicker2.Value)
                MessageBox.Show(string.Format("'{0}' and '{1}' is Equal", datePicker1.Value, datePicker2.Value));
            else if (datePicker1.Value != datePicker2.Value)
                MessageBox.Show(string.Format("'{0}' and '{1}' is not Equal", datePicker1.Value, datePicker2.Value));
            else
                MessageBox.Show("Error Operation");
        }

        private void DatePickerComplete1_ChangeDate(object sender, EventArgs e)
        {
            lblDate21.Text = "String: " + datePickerComplete1.Value.ToString();
            lblDate22.Text = "Date: " + datePickerComplete1.Value.ToDate().ToString();
        }

        private void BtnParse_Click(object sender, EventArgs e)
        {
            try { datePicker3.Value = DatePickerValue.Parse(txtDate.Text); }
            catch (Exception exp) { MessageBox.Show(exp.Message); }
        }

        private void BtnTryParse_Click(object sender, EventArgs e)
        {
            if (DatePickerValue.TryParse(txtDate.Text, out DatePickerValue dv))
                datePicker3.Value = dv;
            else
                datePicker3.Value = DatePickerValue.Empty;
        }

        private void ChbxAllowEmpty_CheckedChanged(object sender, EventArgs e)
        {
            ReloadAllowEmpty();
        }

        private void ReloadAllowEmpty()
        {
            datePicker1.AllowEmpty =
            datePicker2.AllowEmpty =
            datePicker3.AllowEmpty =
            datePickerComplete1.AllowEmpty = chbxAllowEmpty.Checked;
        }
    }
}
