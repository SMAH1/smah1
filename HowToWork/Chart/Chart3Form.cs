using SMAH1.BindingData;
using SMAH1.Forms.Chart.Component.Axile;
using SMAH1.Forms.Chart.Configuration;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class Chart3Form : Form
    {
        DataTable dt11 = null;
        DataTable dt12 = null;
        DataTable dt13 = null;
        DataTable dt21 = null;
        DataTable dt22 = null;
        DataTable dt23 = null;
        DataTable dt31 = null;
        DataTable dt32 = null;
        DataTable dt33 = null;
        AxileDrawManager man;

        bool enterAxil = false;

        #region IBindingData
        class BDT_Date : SMAH1.BindingData.BindingDataTable
        {
            int baseColumnValue = -1;

            public BDT_Date(DataTable dataTable) : base(dataTable) { }

            public override double ColumnValue(int indexColumn)
            {
                if (baseColumnValue == -1)
                {
                    SMAH1.Persian.Date d1 = new SMAH1.Persian.Date(this.ColumnName(0));
                    baseColumnValue = d1.ToIntegerOf1300();
                }
                SMAH1.Persian.Date d3 = new SMAH1.Persian.Date(this.ColumnName(indexColumn));
                return d3.ToIntegerOf1300() - baseColumnValue;
            }

            public override object CalculateColumnValue(double value)
            {
                int v = (int)value;
                v += baseColumnValue;
                SMAH1.Persian.Date d = SMAH1.Persian.Date.FromIntegerOf1300(v);
                return d.ToString();
            }
        }
        class BDT_Int : SMAH1.BindingData.BindingDataTable
        {
            int baseColumnValue = -1;

            public BDT_Int(DataTable dataTable) : base(dataTable) { }

            public override double ColumnValue(int indexColumn)
            {
                if (baseColumnValue == -1)
                {
                    baseColumnValue = int.Parse(this.ColumnName(0));
                }
                return int.Parse(this.ColumnName(indexColumn)) - baseColumnValue;
            }

            //public override object CalculateColumnValue(double value)
            //{
            //    int v = (int)value;
            //    v += baseColumnValue;
            //    SMAH1.Persian.Date d = SMAH1.Persian.Date.FromInteger(v);
            //    return d.ToString();
            //}
        }
        #endregion

        public Chart3Form()
        {
            InitializeComponent();
            lblNearest.Text = string.Empty;

            chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            chart2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            chart3.RightToLeft = System.Windows.Forms.RightToLeft.No;

            chart1.Colors = new Color[] { Color.Green, Color.Red };
            chart2.Colors = chart1.Colors;
            chart3.Colors = chart1.Colors;

            CreateData1();
            CreateData2();
            CreateData3();

            man = new AxileDrawManager();
            UpdateState();
        }

        private void CreateData1()
        {
            dt11 = new DataTable("11");
            dt11.Columns.Add("1390/01/01", typeof(Int32));
            dt11.Columns.Add("1390/01/02", typeof(Double));
            dt11.Columns.Add("1390/01/05", typeof(Int32));

            dt11.Rows.Add(12, 21.5, 22);


            dt12 = new DataTable("12");
            dt12.Columns.Add("10", typeof(Int32));
            dt12.Columns.Add("20", typeof(Double));
            dt12.Columns.Add("100", typeof(Int32));

            dt12.Rows.Add(12, 21.5, 22);


            dt13 = new DataTable("13");
            dt13.Columns.Add("1390/01/01", typeof(Int32));
            dt13.Columns.Add("1390/01/02", typeof(Int32));
            dt13.Columns.Add("1390/01/05", typeof(Int32));

            dt13.Rows.Add(12000, 21500, 22000);
        }

        private void CreateData2()
        {
            dt21 = new DataTable("21");
            dt21.Columns.Add("1390/01/01", typeof(Int32));
            dt21.Columns.Add("1390/01/02", typeof(Double));
            dt21.Columns.Add("1390/01/05", typeof(Int32));

            dt21.Rows.Add(12, 10, 5);


            dt22 = new DataTable("22");
            dt22.Columns.Add("10", typeof(Int32));
            dt22.Columns.Add("20", typeof(Double));
            dt22.Columns.Add("100", typeof(Int32));

            dt22.Rows.Add(12, 10, 5);


            dt23 = new DataTable("23");
            dt23.Columns.Add("1390/01/01", typeof(Int32));
            dt23.Columns.Add("1390/01/02", typeof(Int32));
            dt23.Columns.Add("1390/01/05", typeof(Int32));

            dt23.Rows.Add(1200, 1000, 500);
        }

        private void CreateData3()
        {
            dt31 = new DataTable("31");
            dt31.Columns.Add("1390/01/01", typeof(Int32));
            dt31.Columns.Add("1390/01/02", typeof(Int32));
            dt31.Columns.Add("1390/01/05", typeof(Int32));
            dt31.Columns.Add("1390/01/11", typeof(Int32));
            dt31.Columns.Add("1390/01/17", typeof(Int32));
            dt31.Columns.Add("1390/01/20", typeof(Int32));
            dt31.Columns.Add("1390/01/25", typeof(Int32));
            dt31.Columns.Add("1390/02/02", typeof(Int32));
            dt31.Columns.Add("1390/02/04", typeof(Int32));
            dt31.Columns.Add("1390/02/08", typeof(Int32));
            dt31.Columns.Add("1390/02/09", typeof(Int32));
            dt31.Columns.Add("1390/02/20", typeof(Int32));
            dt31.Columns.Add("1390/02/21", typeof(Int32));
            dt31.Columns.Add("1390/02/25", typeof(Int32));
            dt31.Columns.Add("1390/02/31", typeof(Int32));
            dt31.Columns.Add("1390/03/01", typeof(Int32));
            dt31.Columns.Add("1390/03/03", typeof(Int32));
            dt31.Columns.Add("1390/03/04", typeof(Int32));
            dt31.Columns.Add("1390/03/05", typeof(Int32));
            dt31.Columns.Add("1390/03/06", typeof(Int32));
            dt31.Columns.Add("1390/03/10", typeof(Int32));

            dt31.Rows.Add(12, 21, 22, 12, 21, 22, 12, 21, 22, 12, 21, 22, 12, 21, 22, 12, 21, 22, 12, 21, 22);


            dt32 = new DataTable("32");
            dt32.Columns.Add("10", typeof(Int32));
            dt32.Columns.Add("20", typeof(Int32));
            dt32.Columns.Add("100", typeof(Int32));
            dt32.Columns.Add("130", typeof(Int32));
            dt32.Columns.Add("140", typeof(Int32));
            dt32.Columns.Add("200", typeof(Int32));
            dt32.Columns.Add("210", typeof(Int32));
            dt32.Columns.Add("240", typeof(Int32));
            dt32.Columns.Add("300", typeof(Int32));
            dt32.Columns.Add("310", typeof(Int32));
            dt32.Columns.Add("380", typeof(Int32));
            dt32.Columns.Add("400", typeof(Int32));
            dt32.Columns.Add("450", typeof(Int32));
            dt32.Columns.Add("470", typeof(Int32));
            dt32.Columns.Add("500", typeof(Int32));
            dt32.Columns.Add("505", typeof(Int32));
            dt32.Columns.Add("550", typeof(Int32));
            dt32.Columns.Add("600", typeof(Int32));
            dt32.Columns.Add("690", typeof(Int32));
            dt32.Columns.Add("693", typeof(Int32));
            dt32.Columns.Add("700", typeof(Int32));

            dt32.Rows.Add(12, 21, 22, 12, 21, 22, 12, 21, 22, 12, 21, 22, 12, 21, 22, 12, 21, 22, 12, 21, 22);


            dt33 = new DataTable("33");
            dt33.Columns.Add("1390/01/01", typeof(Int32));
            dt33.Columns.Add("1390/01/02", typeof(Int32));
            dt33.Columns.Add("1390/01/05", typeof(Int32));
            dt33.Columns.Add("1390/01/11", typeof(Int32));
            dt33.Columns.Add("1390/01/17", typeof(Int32));
            dt33.Columns.Add("1390/01/20", typeof(Int32));
            dt33.Columns.Add("1390/01/25", typeof(Int32));
            dt33.Columns.Add("1390/02/02", typeof(Int32));
            dt33.Columns.Add("1390/02/04", typeof(Int32));
            dt33.Columns.Add("1390/02/08", typeof(Int32));
            dt33.Columns.Add("1390/02/09", typeof(Int32));
            dt33.Columns.Add("1390/02/20", typeof(Int32));
            dt33.Columns.Add("1390/02/21", typeof(Int32));
            dt33.Columns.Add("1390/02/25", typeof(Int32));
            dt33.Columns.Add("1390/02/31", typeof(Int32));
            dt33.Columns.Add("1390/03/01", typeof(Int32));
            dt33.Columns.Add("1390/03/03", typeof(Int32));
            dt33.Columns.Add("1390/03/04", typeof(Int32));
            dt33.Columns.Add("1390/03/05", typeof(Int32));
            dt33.Columns.Add("1390/03/06", typeof(Int32));
            dt33.Columns.Add("1390/03/10", typeof(Int32));

            dt33.Rows.Add(12000, 21500, 22000, 12000, 21500, 22000, 12000, 21500, 22000, 12000, 21500, 22000
                , 12000, 21500, 22000, 12000, 21500, 22000, 12000, 21500, 22000);
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
            bool manger = chbxManager.Checked;
            bool second = chbxSecond.Checked & (!chbxManyCol.Checked);
            bool many = chbxManyCol.Checked;
            bool scale = chbxColScal.Checked;

            Redrawable(false);

            man.Remove(chart1);
            man.Remove(chart2);
            man.Remove(chart3);

            if (manger)
            {
                man.AddCoordinatorGroup(Axile.X, chart1, chart2);
                man.AddCoordinatorGroup(Axile.Y, chart1, chart3);
            }

            if (second)
            {
                line1.SecondDataMember = new DataDefine(Bind.FromDataTable(dt21));
                line2.SecondDataMember = new DataDefine(Bind.FromDataTable(dt22));
                line3.SecondDataMember = new DataDefine(Bind.FromDataTable(dt23));
            }
            else
            {
                line1.SecondDataMember = null;
                line2.SecondDataMember = null;
                line3.SecondDataMember = null;
            }

            if (scale)
            {
                if (many)
                {
                    chbxSecond.Checked = false;
                    chart1.DataMember = new BDT_Date(dt31);
                    chart2.DataMember = new BDT_Int(dt32);
                    chart3.DataMember = new BDT_Date(dt33);
                }
                else
                {
                    chart1.DataMember = new BDT_Date(dt11);
                    chart2.DataMember = new BDT_Int(dt12);
                    chart3.DataMember = new BDT_Date(dt13);
                }
            }
            else
            {
                if (chbxManyCol.Checked)
                {
                    chbxSecond.Checked = false;
                    chart1.DataMember = new BDT_Date(dt31);
                    chart2.DataMember = new BDT_Int(dt32);
                    chart3.DataMember = new BDT_Date(dt33);
                }
                else
                {
                    chart1.DataMember = Bind.FromDataTable(dt11);
                    chart2.DataMember = Bind.FromDataTable(dt12);
                    chart3.DataMember = Bind.FromDataTable(dt13);
                }
            }

            line1.ColumnScaling = scale;
            line2.ColumnScaling = scale;
            line3.ColumnScaling = scale;

            Redrawable(true);
        }

        private void Redrawable(bool state)
        {
            chart1.Redrawable = state;
            chart2.Redrawable = state;
            chart3.Redrawable = state;
        }

        private void chbxManager_CheckedChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void chbxSecond_CheckedChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void chbxColScal_CheckedChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void chbxManyCol_CheckedChanged(object sender, EventArgs e)
        {
            chbxSecond.Enabled = !chbxManyCol.Checked;

            UpdateState();
        }

        private void chbxRTL_CheckedChanged(object sender, EventArgs e)
        {
            RightToLeft rtl = System.Windows.Forms.RightToLeft.No;
            if (chbxRTL.Checked)
                rtl = System.Windows.Forms.RightToLeft.Yes;
            Redrawable(false);
            chart1.RightToLeft = rtl;
            chart2.RightToLeft = rtl;
            chart3.RightToLeft = rtl;
            Redrawable(true);
        }

        private void line1_MouseEnterAxisArea(object sender, EventArgs e)
        {
            enterAxil = true;
        }

        private void line1_MouseLeaveAxisArea(object sender, EventArgs e)
        {
            enterAxil = false;
            lblNearest.Text = string.Empty;
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            enterAxil = false;
            lblNearest.Text = string.Empty;
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (enterAxil)
            {
                int inx = line1.NearestColumnIndex(e.Location);
                if (inx >= 0 && inx < chart1.DataMember.ColumnCount)
                    lblNearest.Text = string.Format("Column : {0} ({1})", inx, chart1.DataMember.ColumnName(inx));
                else
                    lblNearest.Text = string.Format("Column : {0}", inx);

                lblNearest.Text += Environment.NewLine;

                int i, j;
                line1.NearestColumnsIndex(e.Location, out i, out j);
                if (i >= 0 && i < chart1.DataMember.ColumnCount)
                    lblNearest.Text += string.Format("Column : {0} ({1})", i, chart1.DataMember.ColumnName(i));
                else
                    lblNearest.Text += string.Format("Column : {0}", i);
                lblNearest.Text += " , ";
                if (j >= 0 && j < chart1.DataMember.ColumnCount)
                    lblNearest.Text += string.Format("Column : {0} ({1})", j, chart1.DataMember.ColumnName(j));
                else
                    lblNearest.Text += string.Format("Column : {0}", j);

                lblNearest.Text += Environment.NewLine;

                object obj = line1.EstimateByNearestColumnsInDataMember(e.Location);
                lblNearest.Text += string.Format("Estimate : {0}", obj.ToString());
            }
            else
                lblNearest.Text = string.Empty;
        }
    }
}
