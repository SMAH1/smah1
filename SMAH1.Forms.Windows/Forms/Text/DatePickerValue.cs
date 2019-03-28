using SMAH1.ExtensionMethod.Persian;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Text.Persian
{
    public struct DatePickerValue
    {
        public const char SEMI_SPACE = '‌';
        public const char SPACE = ' ';

        #region Variable

        #endregion

        #region Properties

        //Because default constructor in struct is not allowed => default value NotEmpty is FALSE => IsEmpty is TRUE
        public bool NotEmpty { get; set; }

        public bool IsConcept { get; private set; }
        public SMAH1.Persian.Date DateSelection { get; private set; }
        public bool IsEmpty { get { return !NotEmpty; } }
        internal DateConcept Concept { get; private set; }

        public static DatePickerValue Empty { get { return new DatePickerValue(); } }

        public static DatePickerValue FutureYear { get { DatePickerValue dv = SetConcept(DateConcept.FutureYear); return dv; } }
        public static DatePickerValue FutureMonth { get { DatePickerValue dv = SetConcept(DateConcept.FutureMonth); return dv; } }
        public static DatePickerValue FutureWeek { get { DatePickerValue dv = SetConcept(DateConcept.FutureWeek); return dv; } }
        public static DatePickerValue Tomorrow { get { DatePickerValue dv = SetConcept(DateConcept.Tomorrow); return dv; } }
        public static DatePickerValue Today { get { DatePickerValue dv = SetConcept(DateConcept.Today); return dv; } }
        public static DatePickerValue Yesterday { get { DatePickerValue dv = SetConcept(DateConcept.Yesterday); return dv; } }
        public static DatePickerValue LastWeek { get { DatePickerValue dv = SetConcept(DateConcept.LastWeek); return dv; } }
        public static DatePickerValue LastMonth { get { DatePickerValue dv = SetConcept(DateConcept.LastMonth); return dv; } }
        public static DatePickerValue LastYear { get { DatePickerValue dv = SetConcept(DateConcept.LastYear); return dv; } }

        #endregion

        #region Method
        public static DatePickerValue FromDate(SMAH1.Persian.Date date)
        {
            DatePickerValue dv = new DatePickerValue
            {
                DateSelection = date,
                NotEmpty = true,
                IsConcept = false
            };
            return dv;

        }

        private static DatePickerValue SetConcept(DateConcept dc)
        {
            DatePickerValue dv = new DatePickerValue();

            if (dc != DateConcept.None)
            {
                dv.NotEmpty = true;
                dv.IsConcept = true;
                dv.Concept = dc;
                dv.DateSelection = SMAH1.Persian.Date.Empty;
            }
            else
            {
                dv.NotEmpty = false;
                dv.IsConcept = false;
                dv.Concept = dc;
                dv.DateSelection = SMAH1.Persian.Date.Empty;
            }

            return dv;
        }

        public override string ToString()
        {
            string ret = string.Empty;
            if (!IsEmpty)
            {
                if (!IsConcept)
                    ret = DateSelection.ToString();
                else
                {
                    ret = SMAH1.EnumInfoBase<DateConcept>.GetFieldDescription(Concept, 0);
                }
            }
            return ret;
        }

        public SMAH1.Persian.Date ToDate()
        {
            SMAH1.Persian.Date ret;
            if (!IsEmpty)
            {
                if (!IsConcept)
                    ret = DateSelection;
                else
                {
                    ret = SMAH1.Persian.Date.Now;
                    switch (Concept)
                    {
                        case DateConcept.FutureYear:
                            ret = ret.AddYears(1);
                            break;
                        case DateConcept.FutureMonth:
                            ret = ret.AddMonths(1);
                            break;
                        case DateConcept.FutureWeek:
                            ret = ret.AddWeeks(1);
                            break;
                        case DateConcept.Tomorrow:
                            ret = ret.AddDays(1);
                            break;
                        case DateConcept.Today:
                            break;
                        case DateConcept.Yesterday:
                            ret = ret.AddDays(-1);
                            break;
                        case DateConcept.LastWeek:
                            ret = ret.AddWeeks(-1);
                            break;
                        case DateConcept.LastMonth:
                            ret = ret.AddMonths(-1);
                            break;
                        case DateConcept.LastYear:
                            ret = ret.AddYears(-1);
                            break;
                    }
                }
            }
            else
            {
                ret = SMAH1.Persian.Date.Empty;
            }
            return ret;
        }
        #endregion

        #region object method
        public override bool Equals(object obj)
        {
            if (obj == null)
                return true;
            if (obj is DatePickerValue)
                return this.Equals((DatePickerValue)obj);
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(DatePickerValue left, DatePickerValue right)
        {
            if (right != null)
            {
                return right.Equals(left);
            }
            return left.Equals(right);
        }

        public static bool operator !=(DatePickerValue left, DatePickerValue right)
        {
            return !(left == right);
        }

        public bool Equals(DatePickerValue p)
        {
            if (p == null)
            {
                return false;
            }

            if (ReferenceEquals(this, p))
            {
                return true;
            }

            if (this.GetType() != p.GetType())
                return false;

            if (this.IsEmpty == p.IsEmpty && this.IsEmpty)
                return true;

            if (this.IsConcept == p.IsConcept)
            {
                if (this.IsConcept)
                {
                    if (this.Concept == p.Concept)
                        return true;
                }
                else
                {
                    return (this.DateSelection == p.DateSelection);
                }
            }

            return false;
        }
        #endregion

        #region Parse
        public static DatePickerValue Parse(string s)
        {
            s = s.ToPersianStandardAlphabet();
            DatePickerValue dv = new DatePickerValue();
            if (!string.IsNullOrEmpty(s))
            {
                foreach (DateConcept dc in SMAH1.EnumInfoBase<DateConcept>.GetFields())
                    if (string.Compare(
                        s.RemoveDiacritics().Replace("" + SPACE, "").Replace("" + SEMI_SPACE, ""), 
                        SMAH1.EnumInfoBase<DateConcept>.GetFieldDescription(dc, 0).RemoveDiacritics().Replace("" + SPACE, "").Replace("" + SEMI_SPACE, "")
                        ) == 0)
                    {
                        dv = SetConcept(dc);
                        break;
                    }

                if (dv.IsEmpty)
                {
                    SMAH1.Persian.Date dt = new SMAH1.Persian.Date(s);
                    if (dt.DayOfMonth == 0)
                        throw new Exception("Format Invalid");
                    dv = DatePickerValue.FromDate(dt);
                }
            }

            return dv;
        }

        public static bool TryParse(string s, out DatePickerValue dv)
        {
            bool ret = false;
            s = s.ToPersianStandardAlphabet();
            dv = new DatePickerValue();
            if (string.IsNullOrEmpty(s))
            {
                ret = true;
            }
            else
            {
                foreach (DateConcept dc in SMAH1.EnumInfoBase<DateConcept>.GetFields())
                    if (string.Compare(
                        s.RemoveDiacritics().Replace("" + SPACE, "").Replace("" + SEMI_SPACE, ""),
                        SMAH1.EnumInfoBase<DateConcept>.GetFieldDescription(dc, 0).RemoveDiacritics().Replace("" + SPACE, "").Replace("" + SEMI_SPACE, "")
                        ) == 0)
                    {
                        dv = SetConcept(dc);
                        ret = true;
                        break;
                    }

                if (dv.IsEmpty)
                {
                    SMAH1.Persian.Date dt = new SMAH1.Persian.Date(s);
                    if (dt.DayOfMonth == 0)
                        ret = false;
                    else
                    {
                        ret = true;
                        dv = DatePickerValue.FromDate(dt);
                    }
                }
            }

            return ret;
        }
        #endregion
    }
}
