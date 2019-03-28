using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SMAH1.Forms.Text.Persian
{
    [DefaultEvent("ChangeDate")]
    public partial class DatePickerComplete : UserControl
    {
        #region Variable
        List<DatePickerHelperLabel> lstYear = new List<DatePickerHelperLabel>();
        List<DatePickerHelperLabel> lstMonth = new List<DatePickerHelperLabel>();
        List<DatePickerHelperLabel> lstDay = new List<DatePickerHelperLabel>();
        SMAH1.Persian.Date nowDate;
        SMAH1.Persian.Date dt;
        SMAH1.Persian.Date dtDefaultDate = SMAH1.Persian.Date.Now;
        DateConcept dpdc = DateConcept.None;
        bool isEmpty = false;
        DatePickerValue dv;
        bool allowEmpty = true;
        #endregion

        #region Event

        public event System.EventHandler ChangeDate;

        protected void OnChangeDate()
        {
            ChangeDate?.Invoke(this, new EventArgs());
        }

        #endregion

        // نتیجه انتخاب تاریخ
        [Browsable(false)]
        internal SMAH1.Persian.Date Result
        {
            get { return dt; }
        }

        // نتیجه انتخاب تاریخ مفهومی
        [Browsable(false)]
        internal DateConcept DateConceptStatus
        {
            get { return dpdc; }
            set
            {
                dpdc = value;
                SetDefaultLayout(DateConceptStatus != DateConcept.None);
            }
        }

        // تعیین تاریخ پیشفرض
        [Browsable(false)]
        internal SMAH1.Persian.Date DefaultDate
        {
            set
            {
                dtDefaultDate = value;
                SetYears(dtDefaultDate.Year);
                SetMonth(dtDefaultDate.Month);
                SetDay(dtDefaultDate.DayOfMonth);
                dt = dtDefaultDate;
                OnChangeDate();
            }
        }

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
                if (dv.IsEmpty)
                {
                    Empty();
                }
                else if (dv.IsConcept)
                {
                    SetEmpty(false);
                    DateConceptStatus = dv.Concept;
                    DefaultDate = dv.ToDate();
                }
                else
                {
                    SetEmpty(false);
                    DateConceptStatus = DateConcept.None;
                    DefaultDate = dv.ToDate();
                }

            }
        }

        [DefaultValue(true)]
        public bool AllowEmpty
        {
            get { return allowEmpty; }
            set { allowEmpty = value; lblEmpty.Visible = allowEmpty; }
        }


        internal void SetEmpty(bool value)
        {
            isEmpty = value;
        }

        internal bool IsEmpty()
        {
            return isEmpty;
        }

        // هماهنگ کننده سالها
        private void SetYears(int selYears)
        {
            lblToYear.Selected = true;
            lblToYear.Text = lblToYear.Value = selYears.ToString();
            lblYearGo.Text = lblYearGo.Value = selYears.ToString();
            lbl7Y.Text = lbl7Y.Value = (selYears - 7).ToString();
            lbl6Y.Text = lbl6Y.Value = (selYears - 6).ToString();
            lbl5Y.Text = lbl5Y.Value = (selYears - 5).ToString();
            lbl4Y.Text = lbl4Y.Value = (selYears - 4).ToString();
            lbl3Y.Text = lbl3Y.Value = (selYears - 3).ToString();
            lbl2Y.Text = lbl2Y.Value = (selYears - 2).ToString();
            lbl1Y.Text = lbl1Y.Value = (selYears - 1).ToString();
            lblY1.Text = lblY1.Value = (selYears + 1).ToString();
            lblY2.Text = lblY2.Value = (selYears + 2).ToString();
            lblY3.Text = lblY3.Value = (selYears + 3).ToString();
            lblY4.Text = lblY4.Value = (selYears + 4).ToString();
            lblY5.Text = lblY5.Value = (selYears + 5).ToString();
            lblY6.Text = lblY6.Value = (selYears + 6).ToString();
            lblY7.Text = lblY7.Value = (selYears + 7).ToString();
        }

        // سازنده لیست های روز و ماه و سال
        private void ListCreator()
        {
            lstYear.Add(lbl1Y);
            lstYear.Add(lbl2Y);
            lstYear.Add(lbl3Y);
            lstYear.Add(lbl4Y);
            lstYear.Add(lbl5Y);
            lstYear.Add(lbl6Y);
            lstYear.Add(lbl7Y);
            lstYear.Add(lblToYear);
            lstYear.Add(lblY1);
            lstYear.Add(lblY2);
            lstYear.Add(lblY3);
            lstYear.Add(lblY4);
            lstYear.Add(lblY5);
            lstYear.Add(lblY6);
            lstYear.Add(lblY7);

            lstMonth.Add(lblM01);
            lstMonth.Add(lblM02);
            lstMonth.Add(lblM03);
            lstMonth.Add(lblM04);
            lstMonth.Add(lblM05);
            lstMonth.Add(lblM06);
            lstMonth.Add(lblM07);
            lstMonth.Add(lblM08);
            lstMonth.Add(lblM09);
            lstMonth.Add(lblM10);
            lstMonth.Add(lblM11);
            lstMonth.Add(lblM12);

            lstDay.Add(lblD01);
            lstDay.Add(lblD02);
            lstDay.Add(lblD03);
            lstDay.Add(lblD04);
            lstDay.Add(lblD05);
            lstDay.Add(lblD06);
            lstDay.Add(lblD07);
            lstDay.Add(lblD08);
            lstDay.Add(lblD09);
            lstDay.Add(lblD10);
            lstDay.Add(lblD11);
            lstDay.Add(lblD12);
            lstDay.Add(lblD13);
            lstDay.Add(lblD14);
            lstDay.Add(lblD15);
            lstDay.Add(lblD16);
            lstDay.Add(lblD17);
            lstDay.Add(lblD18);
            lstDay.Add(lblD19);
            lstDay.Add(lblD20);
            lstDay.Add(lblD21);
            lstDay.Add(lblD22);
            lstDay.Add(lblD23);
            lstDay.Add(lblD24);
            lstDay.Add(lblD25);
            lstDay.Add(lblD26);
            lstDay.Add(lblD27);
            lstDay.Add(lblD28);
            lstDay.Add(lblD29);
            lstDay.Add(lblD30);
            lstDay.Add(lblD31);
            lstDay.Add(lblD32);
            lstDay.Add(lblD33);
            lstDay.Add(lblD34);
            lstDay.Add(lblD35);
            lstDay.Add(lblD36);
            lstDay.Add(lblD37);
        }

        // هماهنگ کننده ماهها 
        private void SetMonth(int selMonth)
        {
            for (int i = 0; i < lstMonth.Count; i++)
                lstMonth[i].Selected = false;
            string selectedMonth = string.Format("{0:D2}", selMonth);
            for (int i = 0; i < lstMonth.Count; i++)
                if (lstMonth[i].Value == selectedMonth)
                {
                    lstMonth[i].Selected = true;
                    lblMonthGO.Text = lstMonth[i].Text + " " + dtDefaultDate.Year.ToString();
                    lblMonthGO.Value = lstMonth[i].Value;
                }
        }

        // هماهنگ کننده روزها
        private void SetDay(int selDay)
        {
            int dayNumber = 1;
            SMAH1.Persian.Date dtFirstDay = new SMAH1.Persian.Date(dtDefaultDate.Year.ToString() + "/" + dtDefaultDate.Month.ToString() + "/1");
            int numFirstDay = (int)dtFirstDay.DayOfWeek;
            numFirstDay++;
            numFirstDay %= 7;
            int allDay = dtFirstDay.AddMonths(1).ToInteger(dtFirstDay);
            for (int j = 0; j < lstDay.Count; j++)
            {
                lstDay[j].Text = lstDay[j].Value = string.Empty;
                lstDay[j].Selected = lstDay[j].Visible = false;
            }
            for (int i = numFirstDay; i < (allDay + numFirstDay); i++)
            {
                lstDay[i].Text = lstDay[i].Value = string.Format("{0:D2}", dayNumber);
                lstDay[i].Visible = true;
                if (selDay == dayNumber)
                    lstDay[i].Selected = true;
                dayNumber++;
            }
        }

        // تنظیم تاریخ های مفهومی
        private void SetDinamicValue()
        {
            lblPYear.Value = nowDate.AddYears(-1).ToString();
            lblPMonth.Value = nowDate.AddMonths(-1).ToString();
            lblPWeek.Value = nowDate.AddWeeks(-1).ToString();
            lblPDay.Value = nowDate.AddDays(-1).ToString();
            lblToDay.Value = nowDate.ToString();
            lblFDay.Value = nowDate.AddDays(1).ToString();
            lblFWeek.Value = nowDate.AddWeeks(1).ToString();
            lblFMonth.Value = nowDate.AddMonths(1).ToString();
            lblFYear.Value = nowDate.AddYears(1).ToString();
        }

        // ماه بعد
        private void NextMonth()
        {
            dtDefaultDate = dtDefaultDate.AddMonths(1);
            SetYears(dtDefaultDate.Year);
            SetMonth(dtDefaultDate.Month);
            SetDay(dtDefaultDate.DayOfMonth);
            dpdc = DateConcept.None;
            dt = dtDefaultDate;
            DatePickerCompleteChangeDate();
            OnChangeDate();
        }

        // ماه قبل
        private void PreviousMonth()
        {
            dtDefaultDate = dtDefaultDate.AddMonths(-1);
            SetYears(dtDefaultDate.Year);
            SetMonth(dtDefaultDate.Month);
            SetDay(dtDefaultDate.DayOfMonth);
            dpdc = DateConcept.None;
            dt = dtDefaultDate;
            DatePickerCompleteChangeDate();
            OnChangeDate();
        }

        // سازنده
        public DatePickerComplete()
        {
            InitializeComponent();
            this.Size = new Size(150, 150);
            YearPanel.Location = new Point(0, -150);
            nowDate = SMAH1.Persian.Date.Now;
            ListCreator();
            SetDinamicValue();
            SetDefaultLayout(false);
            SetYears(dtDefaultDate.Year);
            SetMonth(dtDefaultDate.Month);
            SetDay(dtDefaultDate.DayOfMonth);
            this.LostFocus += new EventHandler(DatePickerComplete_LostFocus);
        }

        void DatePickerComplete_LostFocus(object sender, EventArgs e)
        {
            SetDefaultLayout(DateConceptStatus != DateConcept.None);
        }

        // نمایش پنل ماه
        private void ShowMonthTimer_Tick(object sender, EventArgs e)
        {
            if (MonthPanel.Location.X > 0)
                MonthPanel.Location = new Point(MonthPanel.Location.X - 30, MonthPanel.Location.Y);
            else
                ShowMonthTimer.Stop();
        }

        // نمایش پنل سال
        private void ShowYearTimer_Tick(object sender, EventArgs e)
        {
            if (YearPanel.Location.Y < 0)
                YearPanel.Location = new Point(YearPanel.Location.X, YearPanel.Location.Y + 30);
            else
                ShowYearTimer.Stop();
        }

        // نمایش پنل تاریخ مفهومی
        private void ShowConceptTimer_Tick(object sender, EventArgs e)
        {
            if (ConceptPanel.Location.Y > 0)
                ConceptPanel.Location = new Point(ConceptPanel.Location.X, ConceptPanel.Location.Y - 30);
            else
                ShowConceptTimer.Stop();
        }

        // مخفی کردن پنل ماه
        private void HideMonthTimer_Tick(object sender, EventArgs e)
        {
            if (MonthPanel.Location.X < 150)
                MonthPanel.Location = new Point(MonthPanel.Location.X + 30, MonthPanel.Location.Y);
            else
                HideMonthTimer.Stop();
        }

        // مخفی کردن پنل سال
        private void HideYearTimer_Tick(object sender, EventArgs e)
        {
            if (YearPanel.Location.Y > -150)
                YearPanel.Location = new Point(YearPanel.Location.X, YearPanel.Location.Y - 30);
            else
                HideYearTimer.Stop();
        }

        // مخفی کردن پنل تاریخ مفهومی
        private void HideConceptTimer_Tick(object sender, EventArgs e)
        {
            if (ConceptPanel.Location.Y < 150)
                ConceptPanel.Location = new Point(ConceptPanel.Location.X, ConceptPanel.Location.Y + 30);
            else
                HideConceptTimer.Stop();
        }

        // درخواست دهنده پنل ماه
        private void MonthsView(object sender, MouseEventArgs e)
        {
            isEmpty = false;
            ShowMonthTimer.Start();
        }

        // درخواست دهنده پنل سال
        private void YearsView(object sender, MouseEventArgs e)
        {
            isEmpty = false;
            ShowYearTimer.Start();
        }

        // انتخاب ماه
        private void SelectMonth(object sender, MouseEventArgs e)
        {
            HideMonthTimer.Start();
            DatePickerHelperLabel sl = (DatePickerHelperLabel)sender;
            lblMonthGO.Text = sl.Text + " " + dtDefaultDate.Year.ToString();
            lblMonthGO.Value = sl.Value;
            int iDef = Convert.ToInt32(sl.Value) - dtDefaultDate.Month;
            dtDefaultDate = dtDefaultDate.AddMonths(iDef);
            SMAH1.Persian.Date dResult = dtDefaultDate;
            dpdc = DateConcept.None;
            dt = dResult;
            SetMonth(dtDefaultDate.Month);
            SetDay(dtDefaultDate.DayOfMonth);
            OnChangeDate();
        }

        // انتخاب سال
        private void SelectYear(object sender, MouseEventArgs e)
        {
            HideYearTimer.Start();
            DatePickerHelperLabel sl = (DatePickerHelperLabel)sender;
            lblYearGo.Text = sl.Text;
            lblYearGo.Value = sl.Value;
            int iDef = Convert.ToInt32(sl.Value) - dtDefaultDate.Year;
            dtDefaultDate = dtDefaultDate.AddYears(iDef);
            SMAH1.Persian.Date dResult = dtDefaultDate;
            dpdc = DateConcept.None;
            dt = dResult;
            SetYears(dtDefaultDate.Year);
            SetMonth(dtDefaultDate.Month);
            OnChangeDate();
        }

        // انتخاب تاریخ مفهومی
        private void SetDinamicValue(object sender)
        {
            DatePickerHelperLabel sl = (DatePickerHelperLabel)sender;
            dt = new SMAH1.Persian.Date(sl.Value);
            isEmpty = false;
            DatePickerCompleteChangeDate();
            OnChangeDate();

        }

        // درخواست دهنده ماه بعد
        private void LblNextMonth_MouseDown(object sender, MouseEventArgs e)
        {
            isEmpty = false;
            NextMonth();
        }

        // درخواست دهنده سال بعد
        private void LblPreviousMonth_MouseDown(object sender, MouseEventArgs e)
        {
            isEmpty = false;
            PreviousMonth();
        }

        // ؟!؟!؟!؟!؟!؟!؟!؟!؟!؟!
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 8) // WM_KILLFOCUS
                SetDefaultLayout(DateConceptStatus != DateConcept.None);
            base.WndProc(ref m);
        }

        // انتخاب روز
        private void SelectDay(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < lstDay.Count; i++)
                lstDay[i].Selected = false;
            DatePickerHelperLabel sl = (DatePickerHelperLabel)sender;
            int def = (Convert.ToInt32(sl.Value) - dtDefaultDate.DayOfMonth);
            sl.Selected = true;
            dtDefaultDate = dtDefaultDate.AddDays(def);
            SMAH1.Persian.Date dResult = dtDefaultDate;
            dpdc = DateConcept.None;
            dt = dResult;
            isEmpty = false;
            DatePickerCompleteChangeDate();
            OnChangeDate();

        }

        // درخواست دهنده نمایش پنل تاریخ مفهومی
        private void LblShowConcept_MouseDown(object sender, MouseEventArgs e)
        {
            ShowConceptTimer.Start();
            //bDefualtConceptLayout = true;
        }

        // درخواست دهنده مخفی کردن پنل تاریخ مفهومی
        private void HideConceptPanel_Click(object sender, EventArgs e)
        {
            HideConceptTimer.Start();
            //bDefualtConceptLayout = false;
        }

        // تاریخ های مفهومی
        private void LblFYear_MouseDown(object sender, MouseEventArgs e)
        {
            dpdc = DateConcept.FutureYear;
            SetDinamicValue(sender);
        }
        private void LblFMonth_MouseDown(object sender, MouseEventArgs e)
        {
            dpdc = DateConcept.FutureMonth;
            SetDinamicValue(sender);
        }
        private void LblFWeek_MouseDown(object sender, MouseEventArgs e)
        {
            dpdc = DateConcept.FutureWeek;
            SetDinamicValue(sender);
        }
        private void LblFDay_MouseDown(object sender, MouseEventArgs e)
        {
            dpdc = DateConcept.Tomorrow;
            SetDinamicValue(sender);
        }
        private void LblToDay_MouseDown(object sender, MouseEventArgs e)
        {
            dpdc = DateConcept.Today;
            SetDinamicValue(sender);
        }
        private void LblPDay_MouseDown(object sender, MouseEventArgs e)
        {
            dpdc = DateConcept.Yesterday;
            SetDinamicValue(sender);
        }
        private void LblPWeek_MouseDown(object sender, MouseEventArgs e)
        {
            dpdc = DateConcept.LastWeek;
            SetDinamicValue(sender);
        }
        private void LblPMonth_MouseDown(object sender, MouseEventArgs e)
        {
            dpdc = DateConcept.LastMonth;
            SetDinamicValue(sender);
        }
        private void LblPYear_MouseDown(object sender, MouseEventArgs e)
        {
            dpdc = DateConcept.LastYear;
            SetDinamicValue(sender);
        }

        // بازگرداندن پنل ها به حالت اول
        private void SetDefaultLayout(bool concept)
        {
            HideYearTimer.Start();
            HideMonthTimer.Start();
            if (concept)
                ConceptPanel.Location = new Point(0, 0);
            else
                HideConceptTimer.Start();

        }

        public void Empty()
        {
            dpdc = DateConcept.None;
            dtDefaultDate = SMAH1.Persian.Date.Now;
            SetYears(dtDefaultDate.Year);
            SetMonth(dtDefaultDate.Month);
            SetDay(dtDefaultDate.DayOfMonth);
            dt = SMAH1.Persian.Date.Empty;
            isEmpty = true;
            OnChangeDate();
        }

        private void LblEmpty_MouseDown(object sender, MouseEventArgs e)
        {
            Empty();
            DatePickerCompleteChangeDate();
            OnChangeDate();

        }

        private void DatePickerCompleteChangeDate()
        {
            if (IsEmpty())
            {
                dv = DatePickerValue.Empty;
            }
            else if (DateConceptStatus == DateConcept.None)
            {
                dv = DatePickerValue.FromDate(Result);
            }
            else
            {
                switch (DateConceptStatus)
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
        }
    }
}
