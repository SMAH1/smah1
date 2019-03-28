using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace SMAH1.Forms.Text
{
    public partial class TextBoxNumeric : TextBox
    {
        private bool proccessingText = false;
        private IStateFunctions support = new PositiveInteger();

        #region field
        private bool discreteNumeric = true;
        private string separator = ",";
        private TextBoxNumberType state = TextBoxNumberType.PositiveInteger;
        #endregion

        #region properties
        [DefaultValue("")]
        public string Separator
        {
            get { return separator; }
            set
            {
                string sRet = Text;
                separator = value;
                Text = sRet;
            }
        }
        protected string SeparatorDetected
        {
            get
            {
                if (string.IsNullOrEmpty(separator))
                    return separator;
                return System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
            }
        }
        [DefaultValue(TextBoxNumberType.PositiveInteger)]
        public TextBoxNumberType NumberType
        {
            get { return state; }
            set
            {
                if (state != value)
                {
                    string sRet = Text;
                    state = value;
                    support = null;
                    switch (state)
                    {
                        case TextBoxNumberType.PositiveInteger:
                            support = new PositiveInteger();
                            break;
                        case TextBoxNumberType.Integer:
                            support = new Integer();
                            break;
                        case TextBoxNumberType.PositiveDouble:
                            support = new PositiveDouble();
                            break;
                        case TextBoxNumberType.Double:
                            support = new Double();
                            break;
                    }
                    Text = sRet;
                }
            }
        }
        [DefaultValue(true)]
        public bool DiscreteNumeric { get { return discreteNumeric; } set { discreteNumeric = value; } }
        public override string Text
        {
            get
            {
                if (proccessingText)
                    return base.Text;

                string sRet = "";
                if (discreteNumeric)
                    sRet = base.Text.Replace(SeparatorDetected, "");
                else
                    sRet = base.Text;
                if (sRet.Length == 0)
                    sRet = "0";
                return sRet;
            }
            set { base.Text = value; }
        }
        public bool IsEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(TextBase))
                    return true;
                return false;
            }
        }
        protected string TextBase { get { return base.Text; } }
        #endregion

        #region override Method
        protected override void OnTextChanged(EventArgs e)
        {
            //For mono : in mono create LOOP
            if (proccessingText)
                return;

            proccessingText = true;
            string strText = base.Text;
            if (strText.Length > 0)
            {
                int selectionStart = this.SelectionStart;
                int selectionLength = this.SelectionLength;
                string ret = support.OnTextChanged(this, strText, ref selectionStart, ref selectionLength, discreteNumeric, SeparatorDetected);
                if (string.Compare(strText, ret) != 0)
                {
                    this.Text = ret;
                    this.SelectionStart = selectionStart;
                    this.SelectionLength = selectionLength;
                }
            }
            proccessingText = false;
            base.OnTextChanged(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            bool notProcees = false;

            notProcees |= (Control.ModifierKeys == Keys.Control);
            notProcees |= (Control.ModifierKeys == Keys.Alt);

            if (notProcees)
            {
                //No Action
                base.OnKeyPress(e);
                return;
            }
            support.OnKeyPress(this, e);
        }
        #endregion

    }
}
