using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SMAH1.Log
{
    public sealed class Logger
    {
        private Priority priority;
        private bool nowLog = false;
        private IMedia media = null;
        private IMedia mediaDefault = null;
        private SegmentItem segmentItem = new SegmentItem();
        private Format format = new Format();

        private Logger()
        {
            priority = ~Priority.VERBOSE;

            nowLog = false;

            mediaDefault = new SMAH1.Log.Media.MemoryLog();
            media = mediaDefault;
        }

        private Logger(IMedia media)
            : this()
        {
            if (media != null)
                this.media = media;
        }

        #region Properties
        public Priority LogPriority
        {
            get { return priority; }
            set { priority = value; }
        }

        public IMedia Media
        {
            get { return media; }
            set
            {
                var media2 = value ?? throw new Exception("Set 'Media' for logging");
                if (media != mediaDefault)
                    media.Free();
                media = media2;
                media.Init();
            }
        }

        public SegmentItem SegmentItem
        {
            get { return segmentItem; }
            set
            {
                segmentItem = value ?? throw new Exception("Set 'SegmentItem' for logging");
            }
        }

        public Format Format
        {
            get { return format; }
            set
            {
                if (value == null)
                    throw new Exception("Set 'Format' for logging");
                format = value;
            }
        }
        #endregion

        #region static
        private static Logger instance = null;
        public static Logger Default
        {
            get
            {
                if (instance == null)
                    instance = new Logger();
                return instance;
            }
        }

        public static Logger CreateSpecialLogger(IMedia media)
        {
            return new Logger(media);
        }

        public static Logger CreateSpecialLogger()
        {
            return new Logger();
        }
        #endregion

        private bool MustBeLog(Priority p)
        {
            return ((p & priority) > 0);
        }

        #region Log functions
        private void SendToMedia(int logID, Priority p, Items items)
        {
            if (!MustBeLog(p))
                return;

            StringBuilder sb = new StringBuilder();
            sb.Append(format.BeginCreationItem(logID, p));
            sb.Append(format.ItemSeparator);
            foreach (Item item in items)
            {
                sb.Append(format.CreateSubItem(logID, p, item.Name, item.Value));
                sb.Append(format.ItemSeparator);
            }
            sb.Append(format.EndCreationItem(logID, p));
            sb.Append(format.ItemSeparator);
            sb.Append(format.SegmentSeparator);

            try
            {
                if (media == null)
                    mediaDefault.LogString(sb.ToString(), p);
                else
                {
                    if (nowLog)
                        throw new Exception("");    //Log in EventLog in catch

                    nowLog = true;
                    media.LogString(sb.ToString(), p);
                    nowLog = false;
                }
            }
            catch
            {
                mediaDefault.LogString(sb.ToString(), p);
            }
        }

        public void LogMessage(int logID, Priority p, string msg)
        {
            if (!MustBeLog(p))
                return;

            Items items = segmentItem.GetItems(logID, p);
            items.Add(segmentItem.MessageTitle, msg);

            SendToMedia(logID, p, items);
        }

        public void LogException(int logID, Priority p, Exception exp)
        {
            if (exp == null)
                throw new ArgumentNullException("exp");

            if (!MustBeLog(p))
                return;

            Items items = segmentItem.GetItems(logID, p);

            Exception e = exp;
            while (e != null)
            {
                items.Add(segmentItem.ExceptionTitle, e.Message);
                items.Add(segmentItem.StackTraceTitle, e.StackTrace);

                e = e.InnerException;
            }

            SendToMedia(logID, p, items);
        }

        public void LogException(int logID, Priority p, Exception exp, string description)
        {
            if (exp == null)
                throw new ArgumentNullException("exp");

            if (!MustBeLog(p))
                return;

            Items item = segmentItem.GetItems(logID, p);
            item.Add(segmentItem.DescriptionTitle, description);

            Exception e = exp;
            while (e != null)
            {
                item.Add(segmentItem.ExceptionTitle, e.Message);
                item.Add(segmentItem.StackTraceTitle, e.StackTrace);

                e = e.InnerException;
            }

            SendToMedia(logID, p, item);
        }

        public void LogBindingData(int logID, Priority p, DataTable table)
        {
            if (!MustBeLog(p))
                return;

            Items item = segmentItem.GetItems(logID, p);

            StringBuilder sb = new StringBuilder();
            sb.Append(table.TableName);
            sb.Append(format.ItemSeparator);
            for (int i = 0; i < table.Columns.Count; i++)
                sb.Append(table.Columns[i].ColumnName + "\t");
            sb.Append(format.ItemSeparator);
            for (int j = 0; j < table.Rows.Count; j++)
            {
                var objs = table.Rows[j].ItemArray;

                for (int i = 0; i < objs.Length; i++)
                {
                    var obj = objs[i];
                    if (obj != null && obj != System.DBNull.Value)
                        sb.Append(obj.ToString() + "\t");
                    else
                        sb.Append("NULL\t");
                }
                sb.Append(format.ItemSeparator);
            }

            item.Add(segmentItem.BindingDataTitle, sb.ToString());

            SendToMedia(logID, p, item);
        }

        public void LogBindingData(int logID, Priority p, DataTable table, string description)
        {
            if (!MustBeLog(p))
                return;

            Items item = segmentItem.GetItems(logID, p);
            item.Add(segmentItem.DescriptionTitle, description);

            StringBuilder sb = new StringBuilder();
            sb.Append(table.TableName);
            sb.Append(format.ItemSeparator);
            for (int i = 0; i < table.Columns.Count; i++)
                sb.Append(table.Columns[i].ColumnName + "\t");
            sb.Append(format.ItemSeparator);
            for (int j = 0; j < table.Rows.Count; j++)
            {
                var objs = table.Rows[j].ItemArray;

                for (int i = 0; i < objs.Length; i++)
                {
                    var obj = objs[i];
                    if (obj != null && obj != System.DBNull.Value)
                        sb.Append(obj.ToString() + "\t");
                    else
                        sb.Append("NULL\t");
                }
                sb.Append(format.ItemSeparator);
            }

            item.Add(segmentItem.BindingDataTitle, sb.ToString());

            SendToMedia(logID, p, item);
        }
        #endregion
    }
}
