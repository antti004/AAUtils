using System;
using System.Collections.Generic;
using System.Text;

namespace AAUtilities.DateTimeUtils
{
    public static class DateTimeInfo
    {
        public static bool IsWeekend(this DateTime source)
        {
            DayOfWeek day = (DayOfWeek)source.Day;
            return ((day == DayOfWeek.Saturday) || (day == DayOfWeek.Sunday));
        }
    }
}
