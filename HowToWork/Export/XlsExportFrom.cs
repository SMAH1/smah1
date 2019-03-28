using SMAH1.Export.Component;
using SMAH1.Forms.Wait;
using System;
using System.IO;

namespace HowToWork.Export
{
    public partial class XlsExportFrom : BaseExportComponentFrom
    {
        string fileName = "";
        bool bOpenAfterCreate = false;

        public XlsExportFrom()
        {
            InitializeComponent();
            Codepage = XlsExportBIFF2.Codepage.ASCII;
        }

        public XlsExportBIFF2.Codepage Codepage { get; set; }

        public override bool ValidData()
        {
            bool bRet = true;

            string s = txtXlsFile.Text.Trim();
            bRet = false;
            if (s.Length > 0)
            {
                FileInfo fi = new FileInfo(s);
                DirectoryInfo di = fi.Directory;
                if (di != null)
                    bRet = di.Exists;
            }

            return bRet;
        }

        protected override void StartExport()
        {
            fileName = txtXlsFile.Text.Trim();
            bOpenAfterCreate = chbOpen.Checked;
        }

        protected override void Export(WaitProgressForm wait)
        {
            wait.Message = "Initalize";

            DoWorkCorrectly = true;
            FileStream stream = null;
            XlsExportBIFF2 writer = null;

            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                wait.Message = "Open file";
                stream = new FileStream(fileName, FileMode.OpenOrCreate);
                writer = new XlsExportBIFF2(stream, Codepage);

                wait.Message = "Move data";
                writer.WriteBegin();

                int row = 0;
                if (ExportWithColumnName)
                {
                    for (int j = 0; j < Data.Columns.Count; j++)
                        writer.WriteCell(row, j, Data.Columns[j].ColumnName);
                    row++;
                }

                for (int i = 0; i < Data.Rows.Count; i++)
                {
                    wait.Value = i;
                    if (CancelWork)
                        throw new Exception("Cancel!");
                    for (int j = 0; j < Data.Columns.Count; j++)
                    {
                        object o = Data.Rows[i].ItemArray[j];
                        if (o == null)
                            o = string.Empty;
                        writer.WriteCell(row, j, o.ToString());
                    }
                    row++;
                }

                wait.Message = "Close file";

                writer.WriteEnd();
                stream.Close();

                if (bOpenAfterCreate)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(fileName);
                    }
                    catch (Exception exc)
                    {
                        throw new Exception("Can not open '" + fileName + "'!", exc);
                    }
                }
            }
            catch
            {
                DoWorkCorrectly = false;
                if (stream != null)
                {
                    if (writer != null)
                        writer.WriteEnd();
                    stream.Close();
                }
            }
        }

        private void BtnXlsBrowse_Click(object sender, EventArgs e)
        {
            BrowseFile(txtXlsFile, "XLS", "*.xls|*.xls|All file|*.*");
        }

        private void TxtXlsFile_TextChanged(object sender, EventArgs e)
        {
            OnValidDataChanged();
        }
    }
}
