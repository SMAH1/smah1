using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart
{
    public interface IChartCustomData
    {
        string CustomDataSignature { get; }
        string GetChartCustomData(Chart chart);
        void SetChartCustomData(Chart chart, string data); //Send for owner of signature
    }
}
