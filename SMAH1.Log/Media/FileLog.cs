using System;
using System.Text;
using System.IO;

namespace SMAH1.Log.Media
{
    public class FileLog : IMedia
    {
        private static object OBJECT = new object();

        FileLogAction action = FileLogAction.NoAction;
        int maxFileLength = 1024 * 1024 * 2;    //byte
        int countArchiveFile = 10;
        string filePath = string.Empty;

        public FileLog(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Invalid file path");
            this.filePath = filePath;
        }

        public FileLog(string filePath,
                FileLogAction action,
                int maxFileLength,
                int countArchiveFile)
            : this(filePath)
        {
            this.action = action;

            if (action == FileLogAction.DeleteIfLarge || action == FileLogAction.ArchiveIfLarge)
                if (maxFileLength < 0)
                    throw new ArgumentException("maxFileLength must be positive");
            if (action == FileLogAction.ArchiveIfLarge)
                if (countArchiveFile < 1)
                    throw new ArgumentException("countArchiveFile must be positive");

            this.maxFileLength = maxFileLength;
            this.countArchiveFile = countArchiveFile;

            DoAction();
        }

        private void DoAction()
        {
            if (action != FileLogAction.NoAction)
            {
                try
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Length > maxFileLength)
                    {
                        if (action == FileLogAction.ArchiveIfLarge)
                        {
                            int inx = filePath.LastIndexOf(".");
                            int indexNew = 0;
                            for (indexNew = 0; indexNew < countArchiveFile; indexNew++)
                            {
                                string fn = CombineName(filePath, inx, indexNew);
                                if (!File.Exists(fn))
                                    break;
                            }
                            if (indexNew == countArchiveFile)
                                File.Delete(CombineName(filePath, inx, countArchiveFile));
                            int i = indexNew;
                            while (i > 1)
                            {
                                string fnOld = CombineName(filePath, inx, i - 1);
                                string fnNew = CombineName(filePath, inx, i);
                                File.Move(fnOld, fnNew);
                                i--;
                            }

                            Compress(CombineName(filePath, inx, 1));
                        }
                    }
                }
                catch { }

                try
                {
                    if (!File.Exists(filePath))
                        File.Delete(filePath);
                }
                catch { }
            }
        }

        protected virtual string CombineName(string filePath, int inx, int i)
        {
            string postfix = ".gz";
            if (inx < 0)
                return filePath + i + postfix;
            StringBuilder sb = new StringBuilder();
            sb.Append(filePath);
            sb.Insert(inx, i);
            sb.Append(postfix);
            return sb.ToString();
        }

        protected virtual void Compress(string archiveFileName)
        {
            string message;
            SMAH1.Zip.CompressDecompressZip
               (new byte[] { },    //GZip only (Withot signature)
               filePath, archiveFileName,
               true, out message);
        }

        #region IMedia Members
        public virtual void Init() { }
        public virtual void Free() { }

        public virtual void LogString(string msg, Priority priority)
        {
            lock (OBJECT)
            {
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.Write(msg);
                sw.Flush();
                sw.Close();
            }
        }
        #endregion
    }
}
