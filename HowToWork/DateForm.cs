using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SMAH1.Persian;

namespace HowToWork
{
    public partial class DateForm : Form
    {
        public DateForm()
        {
            InitializeComponent();
        }

        private void DateForm_Load(object sender, EventArgs e)
        {
            cbxFY.SelectedIndex = 0;
            cbxFM.SelectedIndex = 0;
            cbxFD.SelectedIndex = 0;

            txtDate.Text = Date.Now.ToString();
            btnToInt.PerformClick();
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            bool bEnable = txtDate.ValidDate();
            btnToInt.Enabled = bEnable;
            btnAddWeek.Enabled = bEnable;
            btnAddDay.Enabled = bEnable;
            btnAddMonth.Enabled = bEnable;
            btnAddYear.Enabled = bEnable;
        }

        private void btnToInt_Click(object sender, EventArgs e)
        {
            Date date = new Date(txtDate.Text);
            if (!Date.IsEmpty(date))
            {
                txtNum.Text = date.ToIntegerOf1300().ToString();
            }
            UpdateByDateChange(date);
        }

        private void btnToDate_Click(object sender, EventArgs e)
        {
            Date date = Date.FromIntegerOf1300(int.Parse(txtNum.Text));
            txtDate.Text = date.ToString();
            UpdateByDateChange(date);
        }

        private void UpdateByDateChange(Date date)
        {
            txtDayNameEn.Text = date.DayOfWeek.ToString();
            txtDayNameFa.Text = Date.GetDayPersianName(date.DayOfWeek);

            string sf = "lblF";
            string sr = "lblR";
            for (int i = 1; i <= 5; i++)
            {
                Control cf = gbFormat.Controls[sf + i];
                Control cr = gbFormat.Controls[sr + i];

                cr.Text = date.ToString(cf.Text);
            }

            lblRR.Text = date.ToString(cbxFY.Text + " " + cbxFM.Text + " " + cbxFD.Text);
        }

        private void btnAddWeek_Click(object sender, EventArgs e)
        {
            Date date = new Date(txtDate.Text);
            if (!Date.IsEmpty(date))
            {
                date = date.AddWeeks(int.Parse(txtNumAdd.Text));
                txtDate.Text = date.ToString();
                btnToInt.PerformClick();
            }
        }

        private void btnAddYear_Click(object sender, EventArgs e)
        {
            Date date = new Date(txtDate.Text);
            if (!Date.IsEmpty(date))
            {
                date = date.AddYears(int.Parse(txtNumAdd.Text));
                txtDate.Text = date.ToString();
                btnToInt.PerformClick();
            }
        }

        private void btnAddMonth_Click(object sender, EventArgs e)
        {
            Date date = new Date(txtDate.Text);
            if (!Date.IsEmpty(date))
            {
                date = date.AddMonths(int.Parse(txtNumAdd.Text));
                txtDate.Text = date.ToString();
                btnToInt.PerformClick();
            }
        }

        private void btnAddDay_Click(object sender, EventArgs e)
        {
            Date date = new Date(txtDate.Text);
            if (!Date.IsEmpty(date))
            {
                date = date.AddDays(int.Parse(txtNumAdd.Text));
                txtDate.Text = date.ToString();
                btnToInt.PerformClick();
            }
        }

        private void cbxFY_SelectedIndexChanged(object sender, EventArgs e)
        {
            Date date = new Date(txtDate.Text);
            if (!Date.IsEmpty(date))
            {
                txtNum.Text = date.ToIntegerOf1300().ToString();
            }
            UpdateByDateChange(date);
        }

        private void cbxFM_SelectedIndexChanged(object sender, EventArgs e)
        {
            Date date = new Date(txtDate.Text);
            if (!Date.IsEmpty(date))
            {
                txtNum.Text = date.ToIntegerOf1300().ToString();
            }
            UpdateByDateChange(date);
        }

        private void cbxFD_SelectedIndexChanged(object sender, EventArgs e)
        {
            Date date = new Date(txtDate.Text);
            if (!Date.IsEmpty(date))
            {
                txtNum.Text = date.ToIntegerOf1300().ToString();
            }
            UpdateByDateChange(date);
        }
    }
}
