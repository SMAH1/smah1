using System;
using System.Windows.Forms;
using System.Drawing;
using SMAH1.Forms.Wait;
using SMAH1.Export.Component;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace SMAH1.Export
{
    public partial class ExportDataForm : Form
    {
        private DataTable[] tables;
        private string title = string.Empty;

        bool doWorkCorrectly = true;
        bool cancelWork = false;
        ReadOnlyCollection<BaseExportComponentFrom> lstExport = null;
        BaseExportComponentFrom curForm = null;

        public static ReadOnlyCollection<BaseExportComponentFrom> DefaultList()
        {
            return (new List<BaseExportComponentFrom>() {
                new CsvExportFrom()
            }).AsReadOnly();
        }

        public ExportDataForm(ReadOnlyCollection<BaseExportComponentFrom> list, params DataTable[] tables)
        {
            InitializeComponent();

            ExportWithColumnName = true;
            title = this.Text;

            this.tables = tables;
            if (tables == null)
                throw new ArgumentNullException("'tables' is null");
            if (tables.Length == 0)
                throw new ArgumentNullException("'tables' is empty");
            if (list == null)
                throw new ArgumentNullException("'list' is null");
            if (list.Count < 1)
                throw new ArgumentNullException("'list' is empty");

            curForm = null;

            lstExport = list;

            if (lstExport.Count < 1)
                throw new ArgumentNullException("All child form of list can not run!");

            foreach (var t in tables)
                cbxExportData.Items.Add(t.TableName);
            cbxExportData.SelectedIndex = 0;
            if (tables.Length == 1)
            {//Only one for export : Not show this combobox
                int dy = pnlExport.Location.Y - cbxExportData.Location.Y;
                cbxExportData.Visible = false;
                pnlExport.Location = new Point(pnlExport.Location.X, pnlExport.Location.Y - dy);
                pnlExport.Size = new Size(pnlExport.Size.Width, pnlExport.Size.Height + dy);
            }
        }

        #region Property
        /********************** Property ***************************/
        public Image ExportImage
        {
            get { return btnExport.Image; }
            set { btnExport.Image = value; }
        }

        public Image CancelImage
        {
            get { return btnCancel.Image; }
            set { btnCancel.Image = value; }
        }

        public bool ExportWithColumnName { get; set; }
        #endregion

        private void BtnExport_Load(object sender, EventArgs e)
        {
            if (tables.Length == 0)
            {
                MessageBox.Show("No data For Export!");
                Close();
            }

            int w, h;
            w = h = 0;

            foreach (BaseExportComponentFrom f in lstExport)
            {
                f.ValidDataChanged += new EventHandler(BaseExportComponentFrom_ValidDataChanged);
                f.FormBorderStyle = FormBorderStyle.None;
                f.TopLevel = false;

                //Sequence important
                if (w < f.Width)
                    w = f.Width;
                if (h < f.Height)
                    h = f.Height;
                f.Dock = DockStyle.Fill;

                pnlExport.Controls.Add(f);
                f.Show();
                f.Visible = false;

                lbxExport.Items.Add(f.Text);
            }

            w += 10;
            h += 10;
            w = Math.Max(w, pnlExport.Width) - pnlExport.Width;
            h = Math.Max(h, pnlExport.Height) - pnlExport.Height;

            if (w != 0 || h != 0)
                this.Size = new Size(w + this.Width, h + this.Height);
            this.MinimumSize = this.Size;

            lbxExport.SelectedIndex = 0;
        }

        private void CbxExportData_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = tables[cbxExportData.SelectedIndex];
            this.Text = title + " - Export " + t.Rows.Count.ToString() +
                (t.Rows.Count == 1 ? " row" : " rows");
        }

        void BaseExportComponentFrom_ValidDataChanged(object sender, EventArgs e)
        {
            BaseExportComponentFrom config = (BaseExportComponentFrom)sender;
            btnExport.Enabled = config.ValidData();
        }

        private void LbxExport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (curForm != null)
                curForm.Visible = false;
            int i = lbxExport.SelectedIndex;
            if (i != -1)
            {
                curForm = lstExport[i];
                curForm.Visible = true;
                btnExport.Enabled = curForm.ValidData();
            }
            else
            {
                curForm = null;
                btnExport.Enabled = false;
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (curForm == null)
                return;

            var table = tables[cbxExportData.SelectedIndex];

            curForm.Data = table;
            curForm.ExportWithColumnName = ExportWithColumnName;
            curForm.StartExport();

            curForm.DoWorkCorrectly = false;
            curForm.CancelWork = false;

            WaitProgressForm wait = new WaitProgressForm(this, curForm.Export, EndExport)
            {
                WidthDialog = this.Size.Width - 10,
                Maximum = table.Rows.Count,
                Value = 0
            };
            wait.CancelWork += new EventHandler(Wait_CancelWork);
            wait.CancelImage = this.CancelImage;
            wait.Message = "Configuration";
            wait.BeginOperation();
        }

        void Wait_CancelWork(object sender, EventArgs e)
        {
            curForm.CancelWork = true;
        }

        private void EndExport()
        {
            bool bSucessful = true;
            if (!doWorkCorrectly && !cancelWork)
                bSucessful = false;

            curForm.EndExport(bSucessful);

            if (!bSucessful)
                MessageBox.Show("Export faild!");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
