using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Log
{
    public class Format
    {
        private string itemSeparator = Environment.NewLine;
        public string ItemSeparator
        {
            get { return itemSeparator; }
            protected set { itemSeparator = value; }
        }

        private string segmentSeparator = Environment.NewLine;
        public string SegmentSeparator
        {
            get { return segmentSeparator; }
            protected set { segmentSeparator = value; }
        }

        public virtual string BeginCreationItem(int logID, Priority p) { return "Begin"; }
        public virtual string EndCreationItem(int logID, Priority p) { return "End"; }

        public virtual string CreateSubItem(int logID, Priority p, string name, string value)
        {
            if (string.IsNullOrEmpty(value))
                return "\t" + name.Replace(":", @"\:") + ": {}";
            return "\t" + name.Replace(":", @"\:") + ": {" + value.Replace("{", @"\{").Replace("}", @"\}") + "}";
        }
    }
}
