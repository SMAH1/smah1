using SMAH1.Persian;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Log.Persian
{
    public class SegmentItem : SMAH1.Log.SegmentItem
    {
        public override SMAH1.Log.Items GetItems(int logID, SMAH1.Log.Priority p)
        {
            SMAH1.Log.Items items = base.GetItems(logID, p);
            if (items.Contains("Date"))
                items["Date"] = Date.Now.ToString('/');
            return items;
        }
    }
}
