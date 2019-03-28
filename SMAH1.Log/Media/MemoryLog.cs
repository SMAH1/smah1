using System;
using System.IO;

namespace SMAH1.Log.Media
{
    public class MemoryLog : IMedia
    {
        private static object OBJECT = new object();
        MemoryStream ms = null;
        StreamWriter writer = null;

        public string ReadAllText()
        {
            writer.Flush();
            ms.Flush();
            ms.Position = 0;

            StreamReader reader = new StreamReader(ms, System.Text.Encoding.UTF8);
            string ret = reader.ReadToEnd();

            return ret;
        }

        #region IMedia
        public void Free()
        {
            lock (OBJECT)
            {
                writer.Flush();
                ms.Flush();
                writer.Close();
                ms.Close();
                ms.Dispose();
                ms = null;
                writer = null;
            }
        }

        public void Init()
        {
            lock (OBJECT)
            {
                if (ms != null)
                {
                    ms.Flush();
                    ms.Close();
                    ms.Dispose();
                }

                ms = new MemoryStream();
                writer = new StreamWriter(ms, System.Text.Encoding.UTF8);
            }
        }

        public void LogString(string msg, Priority priority)
        {
            lock (OBJECT)
            {
                if (writer == null) throw new Exception("No inittialize!");

                writer.Write(msg);
            }
        }
        #endregion
    }
}
