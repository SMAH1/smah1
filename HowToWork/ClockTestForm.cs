using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class ClockTestForm : Form
    {
        public ClockTestForm()
        {
            InitializeComponent();
        }

        private void ClockForm_Load(object sender, EventArgs e)
        {
            var dt = DateTime.Now;

            ctbHour.Text = dt.Hour.ToString();
            ctbMinute.Text = dt.Minute.ToString();
            ctbHM.Text = dt.Hour.ToString() + ":" + dt.Minute.ToString();
            ctbHMS.Text = dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString();
            ctbHMSM.Text = dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString() + ":" + dt.Millisecond.ToString();
            ctbHMSM2.Text = dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString() + ":" + dt.Millisecond.ToString();
        }
    }
}
