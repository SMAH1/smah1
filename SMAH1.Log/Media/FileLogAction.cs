using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SMAH1.Log.Media
{
    public enum FileLogAction
    {
        NoAction,
        DeleteIfLarge,
        ArchiveIfLarge
    }
}
