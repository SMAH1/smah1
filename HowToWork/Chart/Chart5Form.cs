using SMAH1.Forms.Chart.Component.LineComponent;
using SMAH1.Forms.Chart.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class Chart5Form : Form
    {
        DataTable dt = null;

        #region IBindingData
        class BdtCol : SMAH1.BindingData.BindingDataTable
        {
            bool showSecondOnly = false;
            bool scalling = false;

            public BdtCol(DataTable dataTable, bool showSecondOnly, bool scalling)
                : base(dataTable)
            {
                this.showSecondOnly = showSecondOnly;
                this.scalling = scalling;
            }

            public override string ColumnName(int index)
            {
                string s = base.ColumnName(index);
                var sa = s.Split('-');
                int i = int.Parse(sa[0]);
                float d = i/1000F;
                if (showSecondOnly)
                {
                    if ((i % 1000) == 0)
                        return d.ToString("F1");
                    return string.Empty;
                }

                return d.ToString("F1");
            }

            public override double ColumnValue(int index)
            {
                if (scalling)
                {
                    string s = base.ColumnName(index);
                    return int.Parse(s.Split('-')[1]);
                }
                return index;
            }
        }
        #endregion

        public Chart5Form()
        {
            InitializeComponent();

            chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            line1.Layout = LayoutMode.Line;
            chart1.Colors = new Color[] { Color.Green, Color.Red };

            CreateDataBig();

            UpdateState();
        }

        private void CreateDataBig()
        {
            dt = new DataTable("31");
            List<object> values = new List<object>();
            Random rnd = new Random();
            int n = 0;
            for (int i = 0; i < 34; i++)
            {
                dt.Columns.Add(string.Format("{0}-{1}", i * 100, n), typeof(Int32));
                n += rnd.Next(10);
                values.Add(100 + rnd.Next(100));
            }

            dt.Rows.Add(values.ToArray());
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            NewChartConfigurationForm();
        }

        ChartConfigurationForm configForm = null;
        private void NewChartConfigurationForm()
        {
            panelConfigurationForm.Controls.Clear();

            if (configForm != null)
            {
                configForm.Close();
                configForm = null;
            }
            configForm = new ChartConfigurationForm(chart1);

            configForm.FormBorderStyle = FormBorderStyle.None;
            configForm.TopLevel = false;
            configForm.Dock = DockStyle.Fill;
            panelConfigurationForm.Controls.Add(configForm);
            configForm.Show();
        }

        private void UpdateState()
        {
            Redrawable(false);

            chart1.DataMember = null;
            chart1.DataMember = new BdtCol(dt, chbxSecond.Checked, chbxColScal.Checked);
            line1.IgnoreEmptyColumnName = chbxSecond.Checked;
            line1.ColumnScaling = chbxColScal.Checked;

            Redrawable(true);
        }

        private void Redrawable(bool state)
        {
            chart1.Redrawable = state;
        }

        private void chbxSecond_CheckedChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void chbxColScal_CheckedChanged(object sender, EventArgs e)
        {
            UpdateState();
        }
    }
}
