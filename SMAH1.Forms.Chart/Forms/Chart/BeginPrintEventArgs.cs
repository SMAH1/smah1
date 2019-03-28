using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;

namespace SMAH1.Forms.Chart
{
    public class BeginPrintEventArgs : EventArgs
    {
        public PrintDocument PrintDocument { get; }

        public BeginPrintEventArgs(PrintDocument doc)
        {
            PrintDocument = doc;
        }
    }
}
