using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace SMAH1.Log
{
    public class SegmentItem
    {
        #region Properties
        private string dateFormat = "yyyy/MM/dd";
        public string DateFormat
        {
            get { return dateFormat; }
            set { dateFormat = value; }
        }

        private string timeFormat = "HH:mm:ss.fff";
        public string TimeFormat
        {
            get { return timeFormat; }
            set { timeFormat = value; }
        }

        private string descriptionTitle = "Description";
        public string DescriptionTitle
        {
            get { return descriptionTitle; }
            protected set { descriptionTitle = value; }
        }

        private string messageTitle = "Message";
        public string MessageTitle
        {
            get { return messageTitle; }
            protected set { messageTitle = value; }
        }

        private string stackTraceTitle = "\tLocation";
        public string StackTraceTitle
        {
            get { return stackTraceTitle; }
            protected set { stackTraceTitle = value; }
        }

        private string exceptionTitle = "Exception";
        public string ExceptionTitle
        {
            get { return exceptionTitle; }
            protected set { exceptionTitle = value; }
        }

        private string callerMethod = "Method";
        public string CallerMethod
        {
            get { return callerMethod; }
            protected set { callerMethod = value; }
        }

        private string bindingDataTitle = "Data";
        public string BindingDataTitle
        {
            get { return bindingDataTitle; }
            protected set { bindingDataTitle = value; }
        }
        #endregion

        public virtual Items GetItems(int logID, Priority p)
        {
            Items items = new Items();
            
            items.Add("LogID", logID.ToString());
            items.Add("Priority", p.ToString().Replace('_', ','));
            DateTime dt = DateTime.Now;
            items.Add("Date", string.Format(dt.ToString(dateFormat)));
            items.Add("Time", string.Format(dt.ToString(timeFormat)));

            StackTrace st = new StackTrace(true);
            StackFrame[] sfs = st.GetFrames();
            int j = sfs.Length;
            string typLogger = typeof(Logger).ToString();
            MethodBase mthCaller = null;
            for (int i = 1; i < j; i++)
            {
                StackFrame sf = sfs[i];

                MethodBase mth = sf.GetMethod();
                if (mth.DeclaringType.ToString() != typLogger)
                {
                    if (mthCaller == null)
                        mthCaller = mth;
                }
                else
                    mthCaller = null;   //We have caller in befor this!
            }

            if (mthCaller != null)
            {
                string strMth = mthCaller.DeclaringType.ToString() + "." + mthCaller.Name;
                string strAssmbly = mthCaller.DeclaringType.Assembly.Location;
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(strAssmbly);

                strAssmbly += " : " + assemblyName.Version;

                strMth += Environment.NewLine + "\t\t" + strAssmbly;

                items.Add(callerMethod, strMth);
            }

            return items;
        }
    }
}
