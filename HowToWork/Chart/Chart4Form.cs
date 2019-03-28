using SMAH1.Forms.Chart;
using SMAH1.Forms.Chart.Component.Axile;
using SMAH1.Forms.Chart.Component.LineComponent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class Chart4Form : Form
    {
        List<DataTable> dts1 = null;
        List<DataTable> dts2 = null;
        List<Chart> charts = null;
        AxileDrawManager man;

        const int tblCount = 5;
        const int rowCount = 100;

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
        #endregion

        public Chart4Form()
        {
            InitializeComponent();

            CreateData();
            CreateChart();
            UpdateCharts(chbxOtherData.Checked);

            btnExpImg.AddDropDownItemAndHandle("Default", ExportImageWithFill);
            btnExpImg.AddDropDownItemAndHandle("Fill Draw Area", ExportImageWithoutFill);
        }

        private void CreateData()
        {
            Random rnd = new Random();
            dts1 = new List<DataTable>();
            dts2 = new List<DataTable>();

            for (int i = 0; i < tblCount; i++)
            {
                DataTable dt = new DataTable("A" + dts1.Count);
                SMAH1.Persian.Date date = new SMAH1.Persian.Date("1390/01/01");

                List<object> lstInt = new List<object>();
                int max = (int)Math.Pow(7, i + 2);
                for (int j = 0; j < rowCount; j++)
                {
                    date = date.AddDays(rnd.Next(1, 10));
                    dt.Columns.Add(date.ToString(), typeof(Int32));
                    lstInt.Add(rnd.Next(max));
                }

                dt.Rows.Add(lstInt.ToArray());

                //string name = 123.xml";
                //dt.ReadXmlSchema(name.Replace(".xml", "_SCH.xml"));
                //dt.ReadXml(name);

                dts1.Add(dt);
            }
            for (int i = 0; i < tblCount; i++)
            {
                SMAH1.Persian.Date date = new SMAH1.Persian.Date("1391/01/01");
                DataTable dt = new DataTable("B" + dts2.Count);

                List<object> lstInt = new List<object>();
                for (int j = 0; j < rowCount; j++)
                {
                    date = date.AddDays(rnd.Next(1, 10));
                    dt.Columns.Add(date.ToString(), typeof(Int32));
                    lstInt.Add(rnd.Next(10));
                }

                dt.Rows.Add(lstInt.ToArray());

                dts2.Add(dt);
            }
        }

        private void CreateChart()
        {
            int y = 10;
            int h = 300;
            int dy = 5;

            ContextMenu cmsChart = new System.Windows.Forms.ContextMenu();
            cmsChart.MenuItems.Add("Save Data", chart_SaveData);
            cmsChart.MenuItems.Add("Save Image", chart_SaveImage1);
            cmsChart.MenuItems.Add("Save Image (1000X1000)", chart_SaveImage2);
            cmsChart.MenuItems.Add("Save Image Fill", chart_SaveImage3);

            charts = new List<Chart>();

            for (int i = 0; i < tblCount; i++)
            {
                Chart c = new Chart();
                c.Redrawable = false;
                Line l = new Line();
                c.Component = l;

                l.ShowTextOfAxis = ShowTextAxisMode.Both;

                c.Location = new Point(0, y);
                c.Size = new Size(pnl.Width, h);
                c.Name = "CHART" + charts.Count;
                y += h;
                y += dy;

                c.ContextMenu = cmsChart;

                charts.Add(c);

                pnl.Controls.Add(c);
            }
        }

        #region Chart Context Menu
        void chart_SaveImage1(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi == null)
                return;
            ContextMenu cm = mi.Parent as ContextMenu;
            if (cm == null)
                return;

            int h = 600;
            int w = 300;

            Chart c = (Chart)cm.SourceControl;
            using (MemoryStream ms = new MemoryStream())
            {
                c.SaveImageOfChart(ms, ImageFormat.Bmp, new Size(h, w));
                ms.Seek(0, SeekOrigin.Begin);
                Image img = Image.FromStream(ms);

                SaveFileDialog sv = new SaveFileDialog();
                sv.Title = "SaveImage of chart";
                sv.Filter = "Bitmap|*.bmp|Gif|*.gif|Jpeg|*.jpg|PNG|*.png";
                sv.FilterIndex = 4;
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat imgform = ImageFormat.Bmp;
                    switch (sv.FilterIndex)
                    {
                        case 1:
                            imgform = ImageFormat.Bmp;
                            break;
                        case 2:
                            imgform = ImageFormat.Gif;
                            break;
                        case 3:
                            imgform = ImageFormat.Jpeg;
                            break;
                        case 4:
                            imgform = ImageFormat.Png;
                            break;
                        default:
                            imgform = ImageFormat.Bmp;
                            break;
                    }

                    img.Save(sv.FileName, imgform);
                }
            }
        }
        void chart_SaveImage2(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi == null)
                return;
            ContextMenu cm = mi.Parent as ContextMenu;
            if (cm == null)
                return;

            int h = 1000;
            int w = 1000;

            Chart c = (Chart)cm.SourceControl;
            using (MemoryStream ms = new MemoryStream())
            {
                c.SaveImageOfChart(ms, ImageFormat.Bmp, new Size(h, w));
                ms.Seek(0, SeekOrigin.Begin);
                Image img = Image.FromStream(ms);

                SaveFileDialog sv = new SaveFileDialog();
                sv.Title = "SaveImage of chart";
                sv.Filter = "Bitmap|*.bmp|Gif|*.gif|Jpeg|*.jpg|PNG|*.png";
                sv.FilterIndex = 4;
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat imgform = ImageFormat.Bmp;
                    switch (sv.FilterIndex)
                    {
                        case 1:
                            imgform = ImageFormat.Bmp;
                            break;
                        case 2:
                            imgform = ImageFormat.Gif;
                            break;
                        case 3:
                            imgform = ImageFormat.Jpeg;
                            break;
                        case 4:
                            imgform = ImageFormat.Png;
                            break;
                        default:
                            imgform = ImageFormat.Bmp;
                            break;
                    }

                    img.Save(sv.FileName, imgform);
                }
            }
        }
        void chart_SaveImage3(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi == null)
                return;
            ContextMenu cm = mi.Parent as ContextMenu;
            if (cm == null)
                return;

            int h = 1000;
            int w = 1000;

            Chart c = (Chart)cm.SourceControl;
            using (MemoryStream ms = new MemoryStream())
            {
                c.SaveImageOfChart(ms, ImageFormat.Bmp, new Size(h, w));
                RectangleF rc = c.Component.CurrentChartDrawArea;
                ms.Seek(0, SeekOrigin.Begin);
                Image img = Image.FromStream(ms);

                SaveFileDialog sv = new SaveFileDialog();
                sv.Title = "SaveImage of chart";
                sv.Filter = "Bitmap|*.bmp|Gif|*.gif|Jpeg|*.jpg|PNG|*.png";
                sv.FilterIndex = 4;
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat imgform = ImageFormat.Bmp;
                    switch (sv.FilterIndex)
                    {
                        case 1:
                            imgform = ImageFormat.Bmp;
                            break;
                        case 2:
                            imgform = ImageFormat.Gif;
                            break;
                        case 3:
                            imgform = ImageFormat.Jpeg;
                            break;
                        case 4:
                            imgform = ImageFormat.Png;
                            break;
                        default:
                            imgform = ImageFormat.Bmp;
                            break;
                    }

                    using (Graphics gr = Graphics.FromImage(img))
                    {
                        Brush br = new SolidBrush(Color.FromArgb(32, Color.Red));
                        gr.FillRectangle(br, rc.X, rc.Y, rc.Width, rc.Height);
                        br.Dispose();
                    }

                    img.Save(sv.FileName, imgform);
                }
            }
        }

        void chart_SaveData(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi == null)
                return;
            ContextMenu cm = mi.Parent as ContextMenu;
            if (cm == null)
                return;

            Chart c = (Chart)cm.SourceControl;
            DataTable dt = (DataTable)c.Tag;

            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Save DataTable of chart";
            sf.Filter = "Xml file(*.xml)|*.xml";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                dt.WriteXml(sf.FileName);
                dt.WriteXmlSchema(sf.FileName.Replace(".xml", "_SCH.xml"));
            }
        }
        #endregion

        private void UpdateCharts(bool bOtherData)
        {
            Redrawable(false);
            if (bOtherData)
            {
                for (int i = 0; i < tblCount; i++)
                {
                    charts[i].DataMember = new BDT_Date(dts2[i]);
                    charts[i].Tag = dts2[i];
                }
            }
            else
            {
                for (int i = 0; i < tblCount; i++)
                {
                    charts[i].DataMember = new BDT_Date(dts1[i]);
                    charts[i].Tag = dts1[i];
                }
            }
            Redrawable(true);
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            Redrawable(false);
            man = new AxileDrawManager();
            man.AddCoordinatorGroup(Axile.Y, charts.ToArray());
            Redrawable(true);
        }

        private void Redrawable(bool state)
        {
            foreach (Chart c in charts)
                c.Redrawable = state;
        }

        private void chbxOtherData_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCharts(chbxOtherData.Checked);
        }

        private void chbxColScl_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Chart c in charts)
                c.Redrawable = false;
            foreach (Chart c in charts)
                ((Line)c.Component).ColumnScaling = chbxColScl.Checked;
            foreach (Chart c in charts)
                c.Redrawable = true;
        }

        private Image CreateChartsImage(bool filled = false)
        {
            int dy = 10;
            int dx = 10;
            int w = 500;
            int h = 200;

            int mw = w + 2 * dx;
            int mh = h * charts.Count + dy * (charts.Count + 1);
            Bitmap bmp = new Bitmap(mw, mh);

            if (filled)
            {
                Dictionary<Chart, RectangleF> dicArea = new Dictionary<Chart, RectangleF>();
                Dictionary<Chart, Bitmap> dic = man.SaveImageOfChart(new Size(w, h), dicArea);

                Brush br = new SolidBrush(Color.FromArgb(32, Color.Green));

                int y = dy;
                int x = dx;
                int cnt = 0;
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    foreach (Chart chart in dic.Keys)
                    {
                        Bitmap bmpChart = dic[chart];
                        RectangleF rc = dicArea[chart];

                        rc.Offset(dx, dy + cnt * (h + dy));

                        gr.DrawImage(bmpChart, x, y);
                        gr.FillRectangle(br, rc.X, rc.Y, rc.Width, rc.Height);
                        y += h;
                        y += dy;
                        cnt++;
                    }
                }

                br.Dispose();
            }
            else
            {
                Dictionary<Chart, Bitmap> dic = man.SaveImageOfChart(new Size(w, h));

                int y = dy;
                int x = dx;
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    foreach (Bitmap bmpChart in dic.Values)
                    {
                        gr.DrawImage(bmpChart, x, y);
                        y += h;
                        y += dy;
                    }
                }
            }

            return bmp;
        }

        private void ExportImageWithFill(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Title = "Save Charts Image in one file";
            sv.Filter = "Bitmap|*.bmp|Gif|*.gif|Jpeg|*.jpg|PNG|*.png";
            sv.FilterIndex = 4;
            if (sv.ShowDialog() == DialogResult.OK)
            {
                ImageFormat imgform = ImageFormat.Bmp;
                switch (sv.FilterIndex)
                {
                    case 1:
                        imgform = ImageFormat.Bmp;
                        break;
                    case 2:
                        imgform = ImageFormat.Gif;
                        break;
                    case 3:
                        imgform = ImageFormat.Jpeg;
                        break;
                    case 4:
                        imgform = ImageFormat.Png;
                        break;
                    default:
                        imgform = ImageFormat.Bmp;
                        break;
                }

                Image img = CreateChartsImage();
                img.Save(sv.FileName, imgform);
            }
        }

        private void ExportImageWithoutFill(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Title = "Save Charts Image in one file";
            sv.Filter = "Bitmap|*.bmp|Gif|*.gif|Jpeg|*.jpg|PNG|*.png";
            sv.FilterIndex = 4;
            if (sv.ShowDialog() == DialogResult.OK)
            {
                ImageFormat imgform = ImageFormat.Bmp;
                switch (sv.FilterIndex)
                {
                    case 1:
                        imgform = ImageFormat.Bmp;
                        break;
                    case 2:
                        imgform = ImageFormat.Gif;
                        break;
                    case 3:
                        imgform = ImageFormat.Jpeg;
                        break;
                    case 4:
                        imgform = ImageFormat.Png;
                        break;
                    default:
                        imgform = ImageFormat.Bmp;
                        break;
                }

                Image img = CreateChartsImage(true);
                img.Save(sv.FileName, imgform);
            }
        }

        private void btnExpImg_ButtonClick(object sender, EventArgs e)
        {
            ExportImageWithFill(this, new EventArgs());
        }
    }
}
