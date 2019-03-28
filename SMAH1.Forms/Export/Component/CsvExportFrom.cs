using SMAH1.Forms.Wait;
using System;
using System.IO;
using System.Windows.Forms;

namespace SMAH1.Export.Component
{
    public partial class CsvExportFrom : BaseExportComponentFrom
    {
        string fileName = "";
        string delimiter;

        public CsvExportFrom() : base()
        {
            InitializeComponent();

            foreach (var item in SMAH1.EnumInfoBase<CsvExportDelimiter>.GetFields())
                cbxDelimiter.Items.Add(item.ToString());

            string ls = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
            int index = -1;
            foreach (var item in SMAH1.EnumInfoBase<CsvExportDelimiter>.GetFieldsDescription(0))
            {
                index++;
                if (string.Compare(item, ls) == 0)
                    break;
            }
            if (index == cbxDelimiter.Items.Count)
                index = 0;

            cbxDelimiter.SelectedIndex = index;
        }

        public override bool ValidData()
        {
            bool bRet = true;

            string s = txtCsvFile.Text.Trim();
            if (cbxDelimiter.Text.Trim().Length == 0)
                bRet = false;
            else
            {
                if (s.Length > 0)
                {
                    FileInfo fi = new FileInfo(s);
                    DirectoryInfo di = fi.Directory;
                    if (di != null)
                        bRet = di.Exists;
                }
                else
                    bRet = false;
            }

            if (bRet)
            {
                if (cbxDelimiter.SelectedIndex == -1)
                    if (cbxDelimiter.Text.Length == 0)
                        bRet = false;
            }

            return bRet;
        }

        internal protected override void StartExport()
        {
            fileName = txtCsvFile.Text.Trim();
            if (cbxDelimiter.SelectedIndex != -1)
            {
                var d = SMAH1.EnumInfoBase<CsvExportDelimiter>.GetFields()[cbxDelimiter.SelectedIndex];
                delimiter = SMAH1.EnumInfoBase<CsvExportDelimiter>.GetFieldDescription(d, 0);
            }
            else
            {
                delimiter = cbxDelimiter.Text;
                if (string.IsNullOrEmpty(delimiter))
                    MessageBox.Show("Enter Delimiter string!");

            }
        }

        internal protected override void Export(WaitProgressForm wait)
        {
            wait.Message = "Initalize";

            DoWorkCorrectly = true;
            StreamWriter streamWriter = null;
            FileStream fs = null;
            CsvExport exporter = new CsvExport(delimiter, Data, ExportWithColumnName);

            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                if (File.Exists(fileName))
                    File.Delete(fileName);

                wait.Message = "Create CSV Format";

                fs = new FileStream(fileName, FileMode.CreateNew);
                streamWriter = new StreamWriter(fs, System.Text.Encoding.UTF8);

                exporter.Progress += (s, e) =>
                {
                    wait.Value = e.CurrentIndex;
                    if (CancelWork)
                        exporter.CancelWork = true;
                };

                exporter.Convert(streamWriter);

                streamWriter.Flush();
                fs.Flush();
                streamWriter.Close();
                fs.Close();
            }
            catch
            {
                DoWorkCorrectly = false;
                if (fs != null)
                {
                    if (streamWriter != null)
                        streamWriter.Close();
                    fs.Close();
                }
            }
        }

        private void BtnCsvBrowse_Click(object sender, EventArgs e)
        {
            BrowseFile(txtCsvFile, "CSV", "*.csv|*.csv|All file|*.*");
        }

        private void TxtCsvFile_TextChanged(object sender, EventArgs e)
        {
            OnValidDataChanged();
        }

        private void CbxDelimiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnValidDataChanged();
        }

        private void CbxDelimiter_TextChanged(object sender, EventArgs e)
        {
            OnValidDataChanged();
        }
    }
}
