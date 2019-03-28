using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using SMAH1.ExtensionMethod;

namespace SMAH1.Persian
{
    public struct Date
    {
        #region variable
        private static Calendar persianCalendar = null;
        private static Calendar gregorianCalendar = null;
        private readonly DateTime dateGregorian;
        #endregion

        #region constructor
        public Date(DateTime dtGregorian)
            : this()
        {
            Year = PersianCalendar.GetYear(dtGregorian);
            Month = PersianCalendar.GetMonth(dtGregorian);
            DayOfMonth = PersianCalendar.GetDayOfMonth(dtGregorian);
            DayOfWeek = PersianCalendar.GetDayOfWeek(dtGregorian);
            DayOfYear = PersianCalendar.GetDayOfYear(dtGregorian);
            dateGregorian = dtGregorian.ResetClock();
        }

        public Date(string persianDate)
            : this()
        {
            Date date = new Date();
            if (TryParse(persianDate, ref date))
                this = date;
        }

        #endregion

        #region operation and methods
        public Date AddDays(int days)
        {
            if (IsEmpty(this))
                throw new ArgumentException("Date is empty!");

            return new Date(PersianCalendar.AddDays(dateGregorian, days));
        }

        public Date AddMonths(int months)
        {
            if (IsEmpty(this))
                throw new ArgumentException("Date is empty!");

            return new Date(PersianCalendar.AddMonths(dateGregorian, months));
        }

        public Date AddYears(int years)
        {
            if (IsEmpty(this))
                throw new ArgumentException("Date is empty!");

            return new Date(PersianCalendar.AddYears(dateGregorian, years));
        }

        public Date AddWeeks(int weeks)
        {
            if (IsEmpty(this))
                throw new ArgumentException("Date is empty!");

            return new Date(PersianCalendar.AddWeeks(dateGregorian, weeks));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return true;

            if (obj is Date)
                return this.Equals((Date)obj);

            return false;
        }

        public bool Equals(Date p)
        {
            if (ReferenceEquals(this, p))
                return true;

            // If run-time types are not exactly the same, return false.
            if (GetType() != p.GetType())
                return false;

            if (IsEmpty(this) && IsEmpty(p))
                return true;

            if (IsEmpty(this) ^ IsEmpty(p)) //a Empty and other is not empty
                return false;

            return (GetInternalHashCode() == p.GetInternalHashCode());
        }

        public override int GetHashCode()
        {
            return GetInternalHashCode().GetHashCode();
        }

        public int GetInternalHashCode()
        {
            return (Year * 400 + DayOfYear);
        }

        #endregion

        #region properties
        public int Year { get; }
        public int Month { get; }
        public int DayOfMonth { get; }
        public int DayOfYear { get; }
        public DayOfWeek DayOfWeek { get; }
        public DateTime GregorianDate
        {
            get
            {
                if (IsEmpty(this))
                    throw new ArgumentException("Date is empty!");

                return dateGregorian;
            }
        }
        #endregion

        #region Static
        public static Date Empty { get { return new Date(); } }
        public static Date Now { get { return new Date(DateTime.Now); } }

        private static Calendar PersianCalendar
        {
            get
            {
                if (persianCalendar == null)
                    persianCalendar = new System.Globalization.PersianCalendar();
                return persianCalendar;
            }
        }

        private static Calendar GregorianCalendar
        {
            get
            {
                if (gregorianCalendar == null)
                    gregorianCalendar = new System.Globalization.GregorianCalendar();
                return gregorianCalendar;
            }
        }

        public static bool IsEmpty(Date date)
        {
            if (date.Month == 0 || date.DayOfMonth == 0)
                return true;
            return false;
        }

        public static string[] GetMonthPersianName()
        {
            return new string[]
                {
                    "فروردین","اردیبهشت","خرداد",
                    "تیر","مرداد","شهریور",
                    "مهر","آبان","آذر",
                    "دی","بهمن","اسفند"
                };
        }

        public static string[] GetMonthEnglishName()
        {
            return new string[]
                {
                    "Farvardin","Ordibehesht","Khordad",
                    "Tir","Mordad","Shahrivar",
                    "Mehr","Aban","Azar",
                    "Dey","Bahman","Esfand"
                };
        }

        public static string[] GetDayPersianName()
        {
            return new string[]
                {
                    "شنبه",
                    "یکشنبه",
                    "دوشنبه",
                    "سه شنبه",
                    "چهارشنبه",
                    "پنجشنبه",
                    "چمعه"
                };
        }

        public static string[] GetDayEnglishName()
        {
            return new string[]
                {
                    "Shanbe",
                    "Yek-Shanbe",
                    "Do-Shanbe",
                    "Se-Shanbe",
                    "Char-Shanbe",
                    "Panj-Shanbe",
                    "Jomee"
                };
        }

        public static string GetDayPersianName(DayOfWeek day)
        {
            int i = (int)day;
            i += 8;
            i %= 7;
            return GetDayPersianName()[i];
        }

        public static string GetDayEnglishName(DayOfWeek day)
        {
            int i = (int)day;
            i += 8;
            i %= 7;
            return GetDayEnglishName()[i];
        }

        public static bool TryParse(string persianDate, ref Date result)
        {
            bool ret = false;
            result = Empty;
            try
            {
                string[] numbers = persianDate.Split(new char[] { '/', '-', '\\' });
                numbers[0] = numbers[0].Trim();
                numbers[1] = numbers[1].Trim();
                numbers[2] = numbers[2].Trim();

                if (string.IsNullOrEmpty(numbers[0]) ||
                    string.IsNullOrEmpty(numbers[1]) ||
                    string.IsNullOrEmpty(numbers[2]))
                    return false;

                DateTime dt = new DateTime(
                    int.Parse(numbers[0]),
                    int.Parse(numbers[1]),
                    int.Parse(numbers[2]),
                    PersianCalendar);

                result = new Date(dt);

                ret = true;
            }
            catch (Exception)
            {
                result = Empty;
                ret = false;
            }

            return ret;
        }

        #region Operator override
        public static bool operator ==(Date lhs, Date rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Date lhs, Date rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator >(Date lhs, Date rhs)
        {
            return (lhs.GetInternalHashCode() > rhs.GetInternalHashCode());
        }

        public static bool operator <(Date lhs, Date rhs)
        {
            return (lhs.GetInternalHashCode() < rhs.GetInternalHashCode());
        }

        public static bool operator >=(Date lhs, Date rhs)
        {
            return (lhs.GetInternalHashCode() >= rhs.GetInternalHashCode());
        }

        public static bool operator <=(Date lhs, Date rhs)
        {
            return (lhs.GetInternalHashCode() <= rhs.GetInternalHashCode());
        }
        #endregion

        #endregion

        #region From/To Integer
        public int ToInteger(Date fromBase)
        {
            TimeSpan span = GregorianDate - fromBase.GregorianDate;
            return (int)span.TotalDays;
        }

        public int ToIntegerOf1300()
        {
            Date dtBase = new Date();
            TryParse("1300/1/1", ref dtBase);
            return ToInteger(dtBase);
        }

        public static Date FromInteger(int diff, Date fromBase)
        {
            return fromBase.AddDays(diff);
        }

        public static Date FromIntegerOf1300(int diff)
        {
            Date dt = new Date();
            TryParse("1300/1/1", ref dt);
            return FromInteger(diff, dt);
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return ToString('/');
        }

        public string ToString(char separator)
        {
            if (IsEmpty(this))
                return "";
            return string.Format("{0:D}{3}{1:D2}{3}{2:D2}", Year, Month, DayOfMonth, separator);
        }

        /// <summary>
        /// Convert Shamsi date to string with using the specified format
        /// </summary>
        /// <param name="format">A Date format string : 
        /// Y = default year,
        /// YY = 2 digits year,
        /// YYYY = 4 digits year,
        /// M = default month,
        /// MM = 2 digits month,
        /// N = month name persian by english alphabet,
        /// NN = month name persian by persian alphabet,
        /// D = default day,
        /// DD = 2 digits day,
        /// W = day of week persian by english alphabet,
        /// WW = day of week persian by persian alphabet,
        /// </param>
        /// <returns>A string representation of value with specified by format</returns>
        public string ToString(string format)
        {
            StringBuilder sb = new StringBuilder(format);
            sb.Replace("YYYY", string.Format("{0:D4}", Year));
            sb.Replace("YY", string.Format("{0:D2}", Year % 100));
            sb.Replace("Y", string.Format("{0}", Year));
            sb.Replace("MM", string.Format("{0:D2}", Month));
            sb.Replace("M", string.Format("{0}", Month));
            if (Month != 0)
            {
                sb.Replace("NN", string.Format("{0}", Date.GetMonthPersianName()[Month - 1]));
            }
            else
            {
                sb.Replace("NN", string.Empty);
            }
            sb.Replace("DD", string.Format("{0:D2}", DayOfMonth));
            sb.Replace("D", string.Format("{0}", DayOfMonth));
            sb.Replace("WW", string.Format("{0}", Date.GetDayPersianName(DayOfWeek)));

            //Replace English name in Final
            if (Month != 0)
                sb.Replace("N", string.Format("{0}", Date.GetMonthEnglishName()[Month - 1]));
            else
                sb.Replace("N", string.Empty);

            sb.Replace("W", string.Format("{0}", Date.GetDayEnglishName(DayOfWeek)));
            return sb.ToString();
        }
        #endregion
    }
}
