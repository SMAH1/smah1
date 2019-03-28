using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SMAH1.Forms.Text.Persian
{
    internal partial class DatePickerHelperLabel : Label
    {
        bool _selected;

        public DatePickerHelperLabel()
        {
            InitializeComponent();

            Value = string.Empty;
            _selected = false;
        }

        [Browsable(true)]
        [Category("Appearance")]
        public string Value { get; set; }

        [Browsable(true)]
        [Category("Appearance")]
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if (_selected)
                {
                    this.BackColor = SystemColors.Highlight;
                    this.ForeColor = SystemColors.HighlightText;
                }
                else
                {
                    this.BackColor = SystemColors.Window;
                    this.ForeColor = SystemColors.ControlText;
                }
            }
        }
    }
}
