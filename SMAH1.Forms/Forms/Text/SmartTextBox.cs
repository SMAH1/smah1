using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SMAH1.Forms.Text
{
    public partial class SmartTextBox : TextBox
    {
        public SmartTextBox()
        {
            this.Validating += new CancelEventHandler(SmartTextBox_Validating);

            Regex = string.Empty;
        }

        [Browsable(true)]
        [Category("Appearance")]
        public string Regex { get; set; }

        private bool Validator(string value, bool acceptWhenTextBoxIsempty)
        {
            bool ret = false;
            if (Regex != string.Empty)
            {
                if (acceptWhenTextBoxIsempty)
                {
                    if (!string.IsNullOrEmpty(this.Text))
                    {
                        Regex regex = new Regex("^" + Regex + "$");
                        if (regex.IsMatch(value))
                            ret = true;
                        else
                            ret = false;
                    }
                    else
                        ret = true;
                }
                else
                {
                    Regex regex = new Regex("^" + Regex + "$");
                    if (regex.IsMatch(value))
                        ret = true;
                    else
                        ret = false;
                }
            }
            else
                ret = true;
            return ret;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (Validator(this.Text, true))
                base.OnLostFocus(e);
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (Validator(value, false))
                    base.Text = value;
            }
        }

        private void SmartTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !Validator(this.Text, true);
        }
    }
}
