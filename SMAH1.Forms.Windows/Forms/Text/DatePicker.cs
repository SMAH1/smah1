using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SMAH1.Forms.Popup;

namespace SMAH1.Forms.Text.Persian
{
    [DefaultEvent("SelectDate")]
    public partial class DatePicker : UserControl
    {
        PopupComponent popup;
        DatePickerPopup datePickerPopup;
        DatePickerValue dv = DatePickerValue.Empty;

        #region Event

        public event System.EventHandler SelectDate;

        protected void OnSelectDate()
        {
            SelectDate?.Invoke(this, new EventArgs());
        }

        #endregion

        [Browsable(false)]
        [DefaultValue(DateConcept.None)]
        public DatePickerValue Value
        {
            get
            {
                return dv;
            }
            set
            {
                dv = value;
                txtShowDate.Text = dv.ToString();
                if (dv.IsEmpty)
                {
                    datePickerPopup.Empty();
                }
                else if (dv.IsConcept)
                {
                    datePickerPopup.SetEmpty(false);
                    datePickerPopup.DateConceptStatus = dv.Concept;
                    datePickerPopup.DefaultDate = dv.ToDate();
                }
                else
                {
                    datePickerPopup.SetEmpty(false);
                    datePickerPopup.DateConceptStatus = DateConcept.None;
                    datePickerPopup.DefaultDate = dv.ToDate();
                }

            }
        }

        [DefaultValue(true)]
        public bool AllowEmpty
        {
            get { return datePickerPopup.AllowEmpty; }
            set { datePickerPopup.AllowEmpty = value; }
        }

        public DatePicker()
        {
            InitializeComponent();
            popup = new PopupComponent(datePickerPopup = new DatePickerPopup());
            if (SystemInformation.IsComboBoxAnimationEnabled)
            {
                popup.ShowingAnimation = PopupAnimations.Slide | PopupAnimations.TopToBottom;
                popup.HidingAnimation = PopupAnimations.Slide | PopupAnimations.BottomToTop;
            }
            else
            {
                popup.ShowingAnimation = popup.HidingAnimation = PopupAnimations.None;
            }
            popup.Resizable = false;
            datePickerPopup.ChangeDate += new EventHandler(DatePickerPopup_ChangeDate);
        }

        void DatePickerPopup_ChangeDate(object sender, EventArgs e)
        {
            if (datePickerPopup.IsEmpty())
            {
                txtShowDate.Text = string.Empty;
                dv = DatePickerValue.Empty;
            }
            else if (datePickerPopup.DateConceptStatus == DateConcept.None)
            {
                txtShowDate.Text = datePickerPopup.Result.ToString();
                dv = DatePickerValue.FromDate(datePickerPopup.Result);
            }
            else
            {
                txtShowDate.Text = SMAH1.EnumInfoBase<DateConcept>.GetFieldDescription(datePickerPopup.DateConceptStatus, 0);
                switch (datePickerPopup.DateConceptStatus)
                {
                    case DateConcept.FutureYear:
                        dv = DatePickerValue.FutureYear;
                        break;
                    case DateConcept.FutureMonth:
                        dv = DatePickerValue.FutureMonth;
                        break;
                    case DateConcept.FutureWeek:
                        dv = DatePickerValue.FutureWeek;
                        break;
                    case DateConcept.Tomorrow:
                        dv = DatePickerValue.Tomorrow;
                        break;
                    case DateConcept.Today:
                        dv = DatePickerValue.Today;
                        break;
                    case DateConcept.Yesterday:
                        dv = DatePickerValue.Yesterday;
                        break;
                    case DateConcept.LastWeek:
                        dv = DatePickerValue.LastWeek;
                        break;
                    case DateConcept.LastMonth:
                        dv = DatePickerValue.LastMonth;
                        break;
                    case DateConcept.LastYear:
                        dv = DatePickerValue.LastYear;
                        break;
                }
            }
            OnSelectDate();
        }

        private void BtnShowDate_Click(object sender, EventArgs e)
        {
            if (!popup.Visible)
                popup.Show(this);
        }

        private void TxtShowDate_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                if (Clipboard.ContainsText())
                    if (DatePickerValue.TryParse(Clipboard.GetText(), out DatePickerValue dv))
                    {
                        this.Value = dv;
                    }
            }
            else if (e.KeyData == (Keys.Control | Keys.C) && txtShowDate.SelectionLength > 0)
                Clipboard.SetText(txtShowDate.Text);
            else if (e.KeyCode == Keys.Delete)
            {
                this.Value = new DatePickerValue();
            }
        }

        private void TsmCopy_Click(object sender, EventArgs e)
        {
            if (txtShowDate.SelectionLength > 0)
                Clipboard.SetText(txtShowDate.Text);
        }

        private void TsmPaste_Click(object sender, EventArgs e)
        {
            if (DatePickerValue.TryParse(Clipboard.GetText(), out DatePickerValue dv))
            {
                this.Value = dv;
            }
        }

        private void TsmEmpty_Click(object sender, EventArgs e)
        {
            this.Value = new DatePickerValue();
        }

        private void TxtShowDate_MouseUp(object sender, MouseEventArgs e)
        {
            txtShowDate.SelectAll();
        }

        private void Cms_Opening(object sender, CancelEventArgs e)
        {
            tsmEmpty.Enabled = tsmCopy.Enabled = !this.Value.IsEmpty;
            tsmPaste.Enabled = false;
            if (Clipboard.ContainsText())
                if (DatePickerValue.TryParse(Clipboard.GetText(), out DatePickerValue dv))
                    tsmPaste.Enabled = true;
        }
    }
}
