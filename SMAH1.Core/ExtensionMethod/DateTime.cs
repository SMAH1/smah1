using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMAH1.ExtensionMethod
{
    public static class DateTimeExtensionMethod
    {
        static DateTime dtBase = new DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

        public static DateTime ResetClock(this DateTime dt)
        {
            return dt
                .AddMilliseconds(-1 * dt.Millisecond)
                .AddSeconds(-1 * dt.Second)
                .AddMinutes(-1 * dt.Minute)
                .AddHours(-1 * dt.Hour)
                ;
        }

        public static DayOfWeek? WeekDayDetect(this string name)
        {
            int ret = -1;

            name = name.ToUpper();

            string[] sa = new string[] { "SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT" };
            int j = sa.Length;
            for (ret = 0; ret < j; ret++)
                if (string.Compare(name, sa[ret]) == 0)
                {
                    DayOfWeek d;
                    d = (DayOfWeek)ret;
                    return d;
                }

            sa = new string[] {
                DayOfWeek.Sunday.ToString().ToUpper(),
                DayOfWeek.Monday.ToString().ToUpper(),
                DayOfWeek.Tuesday.ToString().ToUpper(),
                DayOfWeek.Wednesday.ToString().ToUpper(),
                DayOfWeek.Thursday.ToString().ToUpper(),
                DayOfWeek.Friday.ToString().ToUpper(),
                DayOfWeek.Saturday.ToString().ToUpper()
            };

            j = sa.Length;
            for (ret = 0; ret < j; ret++)
                if (string.Compare(name, sa[ret]) == 0)
                {
                    DayOfWeek d;
                    d = (DayOfWeek)ret;
                    return d;
                }

            return null;
        }

        /// <summary>
        /// Convert DateTime (Local or UTC) to UnixTimestamp
        /// </summary>
        /// <param name="dt">DateTime (Local or UTC)</param>
        /// <returns></returns>
        public static long ToUnixTimestamp(DateTime dt)
        {
            if (dt.Kind != DateTimeKind.Utc)
                dt = dt.ToUniversalTime();

            return (long)(dt - dtBase).TotalSeconds;
        }

        /// <summary>
        /// Convert UnixTimestamp to DateTime (Local)
        /// </summary>
        /// <param name="ut">UnixTimestamp value</param>
        /// <returns></returns>
        public static DateTime FromUnixTimestamp(long unixTimestamp, bool isUTC = false)
        {
            var dt = dtBase.AddSeconds(unixTimestamp);

            if (isUTC)
                return dt;

            return dt.ToLocalTime();
        }
    }
}
