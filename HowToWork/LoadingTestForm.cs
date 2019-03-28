using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SMAH1.Forms.Loading;

namespace HowToWork
{
    public partial class LoadingTestForm : Form
    {
        List<ILoadingComponent> list;

        public LoadingTestForm()
        {
            InitializeComponent();

            list = new List<ILoadingComponent>();
            list.Add(fan1);
            list.Add(cageOfBird1);
            list.Add(protest1);
            list.Add(plus1);
            list.Add(textNose1);
            list.Add(circularRibbons1);
            list.Add(circleInterrupted1);
            list.Add(circularminimalist1);
            list.Add(clock1);
            list.Add(fillPoint1);
            list.Add(hourglass1);
            list.Add(hartPqrst1);
            list.Add(hartPqrst2);
            list.Add(messageSend1);
            list.Add(lineSlide1);
            list.Add(piscina1);
            list.Add(circleWalker1);
            list.Add(yingYang);
        }

        private void LoadingTestForm_Load(object sender, EventArgs e)
        {
            foreach (ILoadingComponent com in list)
                cbxLoading.Items.Add(com.GetType().Name);
            cbxLoading.SelectedIndex = 0;

            btnStartStop.Text = loading1.Enabled ? "Stop" : "Start";
            numInterval.Maximum = int.MaxValue;
            numInterval.Value = loading1.Interval;
        }

        private void cbxLoading_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLoading.SelectedIndex >= 0 && cbxLoading.SelectedIndex < list.Count)
            {
                loading1.Component = list[cbxLoading.SelectedIndex];
                propertyGrid1.SelectedObject = list[cbxLoading.SelectedIndex];
            }
        }

        private void numInterval_ValueChanged(object sender, EventArgs e)
        {
            loading1.Interval = (int)numInterval.Value;
            numInterval.Value = loading1.Interval;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            loading1.Enabled = !loading1.Enabled;
            btnStartStop.Text = loading1.Enabled ? "Stop" : "Start";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = loading1.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                loading1.BackColor = dlg.Color;
        }
    }
}
