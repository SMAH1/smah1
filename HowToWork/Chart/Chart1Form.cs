﻿using SMAH1.BindingData;
using SMAH1.Forms;
using SMAH1.Forms.Chart.Component;
using SMAH1.Forms.Chart.Component.Axile;
using SMAH1.Forms.Chart.Component.BarComponent;
using SMAH1.Forms.Chart.Component.LineComponent;
using SMAH1.Forms.Chart.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class Chart1Form : Form
    {
        List<BaseChartComponent> list;
        DataTable dtSample = null;
        bool bAddCustomIcon = false;

        const string customPropertyOfChart =
                "<?xml version='1.0' encoding='utf-8'?>" +
                "<ChartProperty default='false' save='ذخيره' load='بازيابي' " +
                "title='عنوان فرم' Alphabetical='الفبایی' Categorized='گروهی' " +
                "Add='افزودن' Remove='حذف' Cancle='لغو' OK='تایید' " +
                "rtl='true'>" +
                "  <PostfixLabel visible='false' />" +
                //"  <PerfixLabel visible='false' />" +
                //"  <PerfixValue visible='false' />" +
                "  <PostfixValue visible='false' />" +
                "  <ShowText name='Show Text'>نحوه ي نمايش عنوان</ShowText>" +
                "  <ShowTextOfAxis name='Show Text Of Axis'>Show Text Of Axis Description</ShowTextOfAxis>" +
                "  <FontText visible='false' />" +
                "  <FontTitle visible='false' />" +
                "  <FontLegend visible='false' />" +
                "  <WidthBar name='Width Bar'>Width Bar Description</WidthBar>" +
                "  <WidthBorderOfBarLine name='Width Border Of Bar'>Width Border Of Bar Description</WidthBorderOfBarLine>" +
                "  <GapBarOfColumn name='Gap Bar Of Column'>Gap Bar Of Column Description</GapBarOfColumn>" +
                "  <GapColumns name='Gap Columns'>Gap Columns Description</GapColumns>" +
                "  <WidthLine name='Width Line'>Width Line Description</WidthLine>" +
                "  <SpaceBottom name='Space Bottom'>Space Bottom Description</SpaceBottom>" +
                "  <SpaceTop name='Space Top'>Space Top Description</SpaceTop>" +
                "  <SpaceBelowText name='Space Below Text'>Space Below Text Description</SpaceBelowText>" +
                "  <SpaceLeft name='Space Left'>Space Left Description</SpaceLeft>" +
                "  <SpaceRight name='Space Right'>Space Right Description</SpaceRight>" +
                "  <VerticalScale name='Vertical Scale'>Vertical Scale Description</VerticalScale>" +
                "  <SizingModeLabel name='Sizing Mode Label' />" +
                "  <BorderOfBarColor name='Border Of Bar Color'>Border Of Bar Color Description</BorderOfBarColor>" +
                "  <ForeColor name='Fore Color'>Fore Color Description</ForeColor>" +
                "  <BackColor name='Back Color'>Back Color Description</BackColor>" +
                "  <HorizontalGrid name='Horizontal Grid'>Horizontal Grid Description</HorizontalGrid>" +
                "  <CountOfGrid name='Count Of Grid'>Count Of Grid Description</CountOfGrid>" +
                "  <LegendAlignment name='Legend Alignment'>Legend Alignment Description</LegendAlignment>" +
                "  <LegendShow name='Legend Show'>Legend Show Description</LegendShow>" +
                "  <LegendHorizontalSpace name='Legend Horizontal Space'>Legend Horizontal Space Description</LegendHorizontalSpace>" +
                "  <LegendVerticalSpace name='Legend Vertical Space'>Legend Vertical Space Description</LegendVerticalSpace>" +
                "  <Colors name='Color(s)'>Color(s) Description</Colors>" +
                "  <Text name='عنوان'>اين عنوان با توجه به نحوه ي نمايش در بالا يا وسط نمايش داده خواهد شد</Text>" +
                "</ChartProperty>";

        public Chart1Form()
        {
            InitializeComponent();

            dtSample = new DataTable("Test");
            dtSample.Columns.Add("X", typeof(Int32));
            dtSample.Columns.Add("12.3", typeof(Double));
            dtSample.Columns.Add("Test", typeof(Int32));

            dtSample.Rows.Add(19, -0.1, 22);
            dtSample.Rows.Add(12, 21.5, 0);
            dtSample.Rows.Add(0, 31.5, 25);
            dtSample.Rows.Add(10, 20, -15);

            dgv.DataSource = dtSample;

            //Events
            lblValue.Text = lblItem.Text = "";
            bar1.MouseLeaveAxisArea += new System.EventHandler(axisComponent_MouseLeaveAxisArea);
            bar1.MouseLocationValueChange += new AxileBase.MouseLocationValueEventHandler(axisComponent_MouseLocationValueChange);
            bar1.MouseEnterBar += new Bar.MouseAndItemEventHandler(component_MouseEnterItem);
            bar1.MouseLeaveBar += new Bar.MouseAndItemEventHandler(component_MouseLeaveItem);
            line1.MouseLeaveAxisArea += new System.EventHandler(axisComponent_MouseLeaveAxisArea);
            line1.MouseLocationValueChange += new AxileBase.MouseLocationValueEventHandler(axisComponent_MouseLocationValueChange);
            line1.MouseEnterPoint += new Line.MouseAndItemEventHandler(component_MouseEnterItem);
            line1.MouseLeavePoint += new Line.MouseAndItemEventHandler(component_MouseLeaveItem);


            chart1.DataMember = Bind.FromDataTable(dtSample);

            chart1.LegendItems.Clear();
            chart1.LegendItems.Add(new SingleLineText("Legend"));
            SingleLineText slt = new SingleLineText();
            slt.Add("E=X_1!Y^2!Z", '!', '_', '^');
            chart1.LegendItems.Add(slt);
            chart1.LegendItems.Add(new SingleLineText("123"));
            slt = new SingleLineText();
            slt.Add("فارسی", SingleLineText.TextFromBaseLine.Normal, true);
            chart1.LegendItems.Add(slt);

            list = new List<BaseChartComponent>();
            list.Add(bar1);
            list.Add(line1);

            lblNearset.Text = "";
        }

        void component_MouseEnterItem(object sender, MouseAndItemEventArgs e)
        {
            lblItem.Text = chart1.DataMember.ValueDouble(e.RowIndex, e.ColumnIndex).ToString();
        }

        void component_MouseLeaveItem(object sender, MouseAndItemEventArgs e)
        {
            lblItem.Text = "Leave";
        }

        void axisComponent_MouseLocationValueChange(object sender, MouseLocationValueEventArgs e)
        {
            lblValue.Text = e.Value.ToString();
        }

        void axisComponent_MouseLeaveAxisArea(object sender, EventArgs e)
        {
            lblValue.Text = "Leave";
            lblItem.Text = "Leave";
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {

            foreach (BaseChartComponent com in list)
                cbxChart.Items.Add(com.GetType().Name);
            cbxChart.SelectedIndex = 0;

            NewChartConfigurationForm();

            chartEnableToolStripMenuItem.Checked = chart1.Enabled;
        }

        private void cbxChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChart.SelectedIndex >= 0 && cbxChart.SelectedIndex < list.Count)
            {
                chart1.Component = list[cbxChart.SelectedIndex];
            }
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
            setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem.Checked = false;
            configForm = new ChartConfigurationForm(chart1);

            if (bAddCustomIcon)
            {
                configForm.LoadIcon = global::HowToWork.Properties.Resources.Open16X16;
                configForm.SaveIcon = global::HowToWork.Properties.Resources.Save16X16;
            }

            configForm.FormBorderStyle = FormBorderStyle.None;
            configForm.TopLevel = false;
            configForm.Dock = DockStyle.Fill;
            panelConfigurationForm.Controls.Add(configForm);
            configForm.Show();
        }

        /********************** Menu ******************************/

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Title = "Save Chart Image";
            sv.Filter = "Bitmap|*.bmp|Gif|*.gif|Jpeg|*.jpg|PNG|*.png";
            sv.FilterIndex = 0;
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
                chart1.SaveImageOfChart(sv.FileName, imgform);
            }
        }

        private void save1000x1000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Title = "Save Chart Image";
            sv.Filter = "Bitmap|*.bmp|Gif|*.gif|Jpeg|*.jpg|PNG|*.png";
            sv.FilterIndex = 0;
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
                chart1.SaveImageOfChart(sv.FileName, imgform, new Size(1000, 1000));
            }
        }

        private void printDirectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Print(true, "PrintBarChart");
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Title = "Save Chart Config";
            sv.Filter = "All file|*.*";
            sv.FilterIndex = 0;
            if (sv.ShowDialog() == DialogResult.OK)
                chart1.SaveConfigurationOfChart(sv.FileName);
        }

        private void saveWithoutComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Title = "Save Chart Config";
            sv.Filter = "All file|*.*";
            sv.FilterIndex = 0;
            if (sv.ShowDialog() == DialogResult.OK)
                chart1.SaveConfigurationOfChart(sv.FileName, false);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Load Chart Config";
            op.Filter = "All file|*.*";
            op.FilterIndex = 0;
            if (op.ShowDialog() == DialogResult.OK)
                chart1.LoadConfigurationOfChartFromFile(op.FileName);
        }

        private void showConfigXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = "";
            using (MemoryStream ms = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(ms);
                chart1.SaveConfigurationOfChart(sw);
                sw.Flush();

                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                data = sr.ReadToEnd();
            }

            MessageBox.Show(data);

            /*using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(data)))
            {
                StreamReader sr = new StreamReader(ms);
                chart1.LoadConfigurationOfChart(sr);
            }*/
        }

        private void saveCurrentComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbxChart.SelectedIndex >= 0 && cbxChart.SelectedIndex < list.Count)
            {
                BaseChartComponent c = list[cbxChart.SelectedIndex];

                SaveFileDialog sv = new SaveFileDialog();
                sv.Title = "Save Component Config";
                sv.Filter = "All file|*.*";
                sv.FilterIndex = 0;
                if (sv.ShowDialog() == DialogResult.OK)
                    c.SaveConfigurationOfComponent(sv.FileName);
            }
        }

        private void loadCurrentComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbxChart.SelectedIndex >= 0 && cbxChart.SelectedIndex < list.Count)
            {
                BaseChartComponent c = list[cbxChart.SelectedIndex];

                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Load Component Config";
                op.Filter = "All file|*.*";
                op.FilterIndex = 0;
                if (op.ShowDialog() == DialogResult.OK)
                    c.LoadConfigurationOfComponentFromFile(op.FileName);
            }
        }

        private void setCurrentComponentConfigurationToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbxChart.SelectedIndex >= 0 && cbxChart.SelectedIndex < list.Count)
            {
                BaseChartComponent c = list[cbxChart.SelectedIndex];
                string sXml = chart1.SaveConfigurationOfChartToString();
                BaseChartComponent.SetDefaultConfiguration(c.GetType(), sXml);
            }
        }

        private void clearDefaultCurrentComponentConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbxChart.SelectedIndex >= 0 && cbxChart.SelectedIndex < list.Count)
            {
                BaseChartComponent c = list[cbxChart.SelectedIndex];
                BaseChartComponent.ClearDefaultConfiguration(c.GetType());
            }
        }

        private void setCostumConfigurationPropertyForBarComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseChartConfiguration.SetDefaultItemsConfiguration(typeof(SMAH1.Forms.Chart.Component.Configuration.BarChartConfiguration), customPropertyOfChart);
            cbxChart.SelectedIndex = -1;
            cbxChart.SelectedIndex = 0;//Bar Component
        }

        private void setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem.Checked)
                configForm.CurrentChartConfigurationChanged -= new EventHandler(configForm_CurrentChartConfigurationChanged);
            else
                configForm.CurrentChartConfigurationChanged += new EventHandler(configForm_CurrentChartConfigurationChanged);
            setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem.Checked =
                !setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem.Checked;
            if (cbxChart.SelectedIndex != 0)
                cbxChart.SelectedIndex = 0;
            else
            {
                //configForm.RebindChartConfiguration();
                chart1.Component = bar1;
            }
        }

        void configForm_CurrentChartConfigurationChanged(object sender, EventArgs e)
        {
            if (cbxChart.SelectedIndex == 0)
            {
                ChartConfigurationForm frm = (ChartConfigurationForm)sender;
                frm.CurrentChartConfiguration.LoadChartAndComponentConfigurationItemsFromString(customPropertyOfChart);
            }
        }

        private void setTitleMultiLineWithFormatedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.TextByFormat.Clear();
            SingleLineText slt = new SingleLineText();
            slt.Add("E_f$ = mc^2", '$', '_', '^');
            chart1.TextByFormat.Add(slt);
            slt = new SingleLineText();
            slt.Add("فرمول", SingleLineText.TextFromBaseLine.Normal, true);
            chart1.TextByFormat.Add(slt);
            configForm.RebindChartConfiguration();
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            chart1.RedrawChart();
        }

        private void setLoadSaveIconToPRopertyGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bAddCustomIcon = !bAddCustomIcon;
            setLoadSaveIconToPRopertyGridToolStripMenuItem.Checked = bAddCustomIcon;
            NewChartConfigurationForm();
        }

        private void chartEnableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool b = chartEnableToolStripMenuItem.Checked;
            b = !b;
            chartEnableToolStripMenuItem.Checked = b;
            chart1.Enabled = b;
            chartEnableToolStripMenuItem.Checked = chart1.Enabled;
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Bar bar = chart1.Component as Bar;
            if (bar != null)
            {
                int r, c;
                bar.NearestBar(e.Location, out r, out c);
                lblNearset.Text = e.Location.ToString() + " : " + r + "," + c;
            }
            else
            {
                Line line = chart1.Component as Line;
                if (line != null)
                {
                    int c = line.NearestColumnIndex(e.Location);
                    lblNearset.Text = e.Location.ToString() + " : Column " + c;
                }
                else
                    lblNearset.Text = "";
            }
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            lblNearset.Text = "Leave";
        }
    }
}
