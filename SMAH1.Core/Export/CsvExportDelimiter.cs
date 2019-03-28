using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SMAH1.Export
{
    public enum CsvExportDelimiter
    {
        [Description(";")]
        Semicolon,

        [Description(",")]
        Comma,

        [Description("\t")]
        Tab,

        [Description(" ")]
        Space,
    }
}
