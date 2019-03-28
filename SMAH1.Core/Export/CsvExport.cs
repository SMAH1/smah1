using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace SMAH1.Export
{
    public class CsvExport
    {
        private const string STRING_SIGN = "\"";
        private const string CRLF = "\r\n";

        public string Delimiter { get; }
        public DataTable Table { get; }
        public bool ExportWithColumnName { get; }
        public bool CancelWork { get; set;  }

        private List<bool> lstColIsString;

        public CsvExport(string delimiter, DataTable table, bool exportWithColumnName)
        {
            Delimiter = delimiter;
            Table = table;
            ExportWithColumnName = exportWithColumnName;

            lstColIsString = new List<bool>();

            CancelWork = false;
        }

        public string Convert()
        {
            string ret = string.Empty;

            using (MemoryStream ms = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(ms, Encoding.UTF8);
                Convert(sw);
                sw.Flush();

                ms.Position = 0;

                StreamReader sr = new StreamReader(ms, Encoding.UTF8);
                ret = sr.ReadToEnd();

                sr.Close();
                sw.Close();
            }

            return ret;
        }

        public void Convert(StreamWriter writer)
        {
            OnStarted();
            CheckCanceled();

            ColumnAnalyzeAndExport(writer);
            CheckCanceled();
            ExportRows(writer);

            CheckCanceled();
            OnFinished();
        }

        private void ColumnAnalyzeAndExport(StreamWriter writer)
        {
            StringBuilder data = new StringBuilder();
            List<string> lstNames = new List<string>();

            var numericTypes = new Type[] {
                typeof(Byte), typeof(Decimal), typeof(Double),
                typeof(Int16), typeof(Int32), typeof(Int64), typeof(SByte),
                typeof(Single), typeof(UInt16), typeof(UInt32), typeof(UInt64)
            };

            foreach (DataColumn col in Table.Columns)
            {
                lstColIsString.Add(!numericTypes.Contains(col.DataType));
                lstNames.Add(col.ColumnName);
            }

            if (ExportWithColumnName)
            {
                if (lstNames.Count > 0)
                    writer.Write(STRING_SIGN + string.Join(STRING_SIGN + Delimiter + STRING_SIGN, lstNames.ToArray()) + STRING_SIGN + CRLF);
            }
        }

        private void ExportRows(StreamWriter writer)
        {
            ExportProgressEventArgs args = new ExportProgressEventArgs(Table.Rows.Count);

            for (int i = 0; i < Table.Rows.Count; i++)
            {
                CheckCanceled();

                var objs = Table.Rows[i].ItemArray;
                args.CurrentIndex = i;
                OnProgress(args);

                for (int j = 0; j < objs.Length; j++)
                {
                    var obj = objs[j];

                    if (j != 0)
                        writer.Write(Delimiter);

                    if (lstColIsString[j])
                    {
                        if (obj != null && obj != System.DBNull.Value)
                        {
                            writer.Write(STRING_SIGN);
                            writer.Write(obj.ToString());
                            writer.Write(STRING_SIGN);
                        }
                    }
                    else
                    {
                        writer.Write(obj.ToString());
                    }
                }

                writer.Write(CRLF);
            }
        }

        private void CheckCanceled()
        {
            if (CancelWork)
                throw new Exception("Export Canceled");
        }

        #region Event
        public event EventHandler Started;
        protected virtual void OnStarted()
        {
            Started?.Invoke(this, new EventArgs());
        }

        public event EventHandler Finished;
        protected virtual void OnFinished()
        {
            Finished?.Invoke(this, new EventArgs());
        }

        public event EventHandler<ExportProgressEventArgs> Progress;
        protected virtual void OnProgress(ExportProgressEventArgs arg)
        {
            Progress?.Invoke(this, arg);
        }
        #endregion
    }
}
