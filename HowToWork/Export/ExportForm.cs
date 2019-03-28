using SMAH1.Export;
using SMAH1.Export.Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class ExportForm : Form
    {
        private Random rnd = new Random();
        private DataTable table = null;

        public ExportForm()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            table = CreateTable();

            dgv.DataSource = table;
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable("Test");
            dt.Columns.Add("Number", typeof(Int32));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Family", typeof(String));
            dt.Columns.Add("DateTime", typeof(DateTime));
            dt.Columns.Add("Value", typeof(Double));

            dt.Rows.Add(1, "علی", "Mohamadi", GetRandomDateTime(), GetRandomValue());
            dt.Rows.Add(5, "Sara", "Sarvi", GetRandomDateTime(), GetRandomValue());
            dt.Rows.Add(4, "محسن", "Saba", GetRandomDateTime(), GetRandomValue());
            dt.Rows.Add(10, "Rahim", "vahed", GetRandomDateTime(), GetRandomValue());
            dt.Rows.Add(10, "Behzad", "Khaki", GetRandomDateTime(), GetRandomValue());
            dt.Rows.Add(9, "Mina", "mashhadi", GetRandomDateTime(), GetRandomValue());
            dt.Rows.Add(6, "Zahra", "Tavassoly", GetRandomDateTime(), GetRandomValue());
            dt.Rows.Add(20, "گلی", "Torki", GetRandomDateTime(), GetRandomValue());
            return dt;
        }

        private double GetRandomValue()
        {
            var ret = rnd.NextDouble() * 100;
            ret *= 1000;
            ret = (int)ret;
            ret /= 1000;
            return ret;
        }

        private DateTime GetRandomDateTime()
        {
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(rnd.NextDouble() * 100);
            dt = dt.AddMinutes(rnd.NextDouble() * 100);
            dt = dt.AddHours(rnd.NextDouble() * 100);
            dt = dt.AddDays(rnd.Next(1, 15000));
            return dt;
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog
            {
                Title = "Save for CSV export",
                Filter = "CSV file|*.csv|All files|*.*",
                FilterIndex = 0
            };
            if (sv.ShowDialog() == DialogResult.OK)
            {
                CsvExport export = new CsvExport("\t", table, chbxWithColName.Checked);
                string content = export.Convert();
                File.WriteAllText(sv.FileName, content, Encoding.UTF8); //Use Encoding for Add BOM
            }
        }

        private void BtnExportSimple_Click(object sender, EventArgs e)
        {
            ExportDataForm export = new ExportDataForm(ExportDataForm.DefaultList(), (DataTable)dgv.DataSource);
            export.ExportWithColumnName = chbxWithColName.Checked;
            export.ShowDialog();
        }

        private void btnExportCustom_Click(object sender, EventArgs e)
        {
            List<BaseExportComponentFrom> components = new List<BaseExportComponentFrom>();
            components.AddRange(ExportDataForm.DefaultList());
            components.Add(new Export.XlsExportFrom());

            ExportDataForm export = new ExportDataForm(components.AsReadOnly(), (DataTable)dgv.DataSource);
            export.ExportWithColumnName = chbxWithColName.Checked;
            export.ShowDialog();
        }
    }
}
