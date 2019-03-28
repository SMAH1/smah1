using System;
using System.Collections.Generic;
using System.Text;
using SMAH1.Attributes;
using System.ComponentModel;

namespace HowToWork.EnumInfo
{
    [FlagsAttribute]
    public enum WeekDay
    {
        /// <summary>
        /// Saturday.
        /// </summary>
        [Description("Saturday")]//Note: use Description (Not Descriptions!)
        Sat = 1,
        /// <summary>
        /// Sun.
        /// </summary>
        Sun = 2,
        /// <summary>
        /// Mon.
        /// </summary>
        [Descriptions("Monday")]
        Mon = 4,
        /// <summary>
        /// Tues.
        /// </summary>
        [Descriptions("Tuesday", "Tues is four")]
        Tues = 8,
        /// <summary>
        /// Wed.
        /// </summary>
        [Descriptions("Wednesday")]
        Wed = 16,
        /// <summary>
        /// Thu.
        /// </summary>
        Thu = 32,
        /// <summary>
        /// Fri.
        /// </summary>
        [Description("Friday")]//Note: use Description (Not Descriptions!)
        Fri = 64
    }

    public enum WeekDay2
    {
        /// <summary>
        /// Saturday.
        /// </summary>
        [Description("Saturday")]//Note: use Description (Not Descriptions!)
        Sat = 1,
        /// <summary>
        /// Sun.
        /// </summary>
        [Description("Sunday")]//Note: use Description (Not Descriptions!)
        Sun = 2
    }
}
