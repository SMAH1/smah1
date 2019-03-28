using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;
using SMAH1.Attributes;

namespace SMAH1.Forms.PropertyGridComponent
{
    public interface IColorArrayEditorCaller
    {
        Color ForeColorForColorArrayEditor { get; }
        Color BackColorForColorArrayEditor { get; }
        string GetButtonText(string currentText);
    }
}
