using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using SMAH1.Persian;

namespace SMAH1.Forms.Text.Persian
{
    public class TextBoxPersianDate : TextBox
    {
        Color colorTextBK;

        public TextBoxPersianDate()
        {
            this.Validating += new CancelEventHandler(ValidatingEvent);
            this.LostFocus += new EventHandler(TextBoxPersianDate_LostFocus);
            colorTextBK = Color.Transparent;
        }

        public bool ValidDate()
        {
            if (ValidPersianDate(this.Text.Trim()).Length > 0)
                return true;
            return false;
        }

        public bool ValidDateOrEmpty()
        {
            if (string.IsNullOrEmpty(this.Text))
                return true;
            return ValidDate();
        }

        private void TextBoxPersianDate_LostFocus(object sender, EventArgs e)
        {
            string s = ValidPersianDate(this.Text);
            if (s.Length == 0 && this.Text.Length > 0)
            {
                this.Focus();
                if (colorTextBK == Color.Transparent)
                    colorTextBK = this.BackColor;
                this.BackColor = SystemColors.Info;
                System.Media.SystemSounds.Beep.Play();
                this.SelectAll();
            }
            else
            {
                this.Text = s;
                if (colorTextBK != Color.Transparent)
                    this.BackColor = colorTextBK;
                colorTextBK = Color.Transparent;
            }
        }

        private void ValidatingEvent(object sender, CancelEventArgs e)
        {
            string s = ValidPersianDate(this.Text);
            if (s.Length == 0 && this.Text.Length > 0)
            {
                e.Cancel = true;
                if (colorTextBK == Color.Transparent)
                    colorTextBK = this.BackColor;
                this.BackColor = SystemColors.Info;
                System.Media.SystemSounds.Beep.Play();
                this.SelectAll();
            }
            else
            {
                this.Text = s;
                if (colorTextBK != Color.Transparent)
                    this.BackColor = colorTextBK;
            }
        }

        private string ValidPersianDate(string strDate)
        {
            Date date = new Date(strDate);
            if (!Date.IsEmpty(date))
                return date.ToString();
            return "";
        }
    }
}
