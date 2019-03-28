using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Log
{
    public interface IMedia
    {
        void Init();
        void LogString(string msg, Priority priority);
        void Free();
    }
}
