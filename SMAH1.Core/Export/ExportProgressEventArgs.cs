using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMAH1.Export
{
    public class ExportProgressEventArgs : EventArgs
    {
        public int CurrentIndex { get; internal protected set; }
        public int Count { get; }

        public ExportProgressEventArgs(int count)
        {
            CurrentIndex = 0;
            Count = count;
        }
    }
}
