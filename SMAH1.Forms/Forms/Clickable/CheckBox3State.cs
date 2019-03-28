using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace SMAH1.Forms.Clickable
{
    [DefaultEvent("CheckStateChanged")]
    [DefaultProperty("CheckState")]
    public class CheckBox3State : CheckBox
    {
        public CheckBox3State()
        {
            AutoCheck = false;
            this.Click += new EventHandler(Chbx_Click);
        }

        void Chbx_Click(object sender, EventArgs e)
        {
            CheckedChange();
        }

        private void CheckedChange()
        {
            if (AutoCheck)
                return;

            var st = this.CheckState;
            switch (st)
            {
                case CheckState.Checked: st = CheckState.Indeterminate; break;
                case CheckState.Indeterminate: st = CheckState.Unchecked; break;
                case CheckState.Unchecked: st = CheckState.Checked; break;
            }
            this.CheckState = st;
        }
    }
}
