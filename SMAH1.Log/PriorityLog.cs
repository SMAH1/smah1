using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Log
{
    [Flags]
    public enum Priority : byte
    {
        None = 0,
        INFO = 1,
        DEBUG = 2,
        WARNING = 4,
        ERROR = 8,
        VERBOSE = 64,
        CRITICAL = 128,
        INFO_WARNING_ERROR = INFO | WARNING | ERROR,
        INFO_DEBUG_WARNING_ERROR = INFO | DEBUG | WARNING | ERROR
    }
}
