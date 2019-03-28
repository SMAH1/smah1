using System;
using System.Data;
using System.Windows.Forms;
using SMAH1.Forms.Wait;

namespace SMAH1.Export.Component
{
    public class BaseExportComponentFrom : Form
    {
        protected BaseExportComponentFrom()
        {
            CancelWork = false;
            DoWorkCorrectly = false;
            ExportWithColumnName = true;
            Data = null;
        }

        internal protected bool CancelWork { get; set; }
        internal protected bool DoWorkCorrectly { get; set; }
        internal protected bool ExportWithColumnName { get; set; }
        internal protected DataTable Data { get; set; }

        public virtual bool ValidData() { return true; }

        internal protected virtual void StartExport() { }   //use in current thread
        internal protected virtual void Export(WaitProgressForm wait) { }   //use in multi-thread
        internal protected virtual void EndExport(bool successfull) { }     //use in current thread

        protected void BrowseFile(TextBox txt, string format, string fileFilter)
        {
            SaveFileDialog sf = new SaveFileDialog
            {
                Title = "Save for " + format + " export",
                Filter = fileFilter,
                FilterIndex = 1,
                FileName = txt.Text
            };
            if (sf.ShowDialog() == DialogResult.OK)
            {
                txt.Text = sf.FileName;
                OnValidDataChanged();
            }
        }

        #region Event
        public event EventHandler ValidDataChanged;
        protected virtual void OnValidDataChanged()
        {
            ValidDataChanged?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
