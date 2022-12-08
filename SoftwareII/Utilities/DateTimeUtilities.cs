using System;

namespace SoftwareII.Utilities
{
    class DateTimeUtilities
    {
        public static DateTime GetFirstDayOfWeek(DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;

            var days = dayOfWeek - DayOfWeek.Monday;

            var start = date.AddDays(-days);
            return start;
        }

        public static DateTime GetLastDayOfWeek(DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;

            var days = dayOfWeek - DayOfWeek.Monday;

            var start = date.AddDays(-days);
            var end = start.AddDays(6);
            return end;
        }

        public static DateTime GetFirstDayOfMonth(DateTime date)
        {
            var start = new DateTime(date.Year, date.Month, 1);
            return start;
        }

        public static DateTime GetLastDayOfMonth(DateTime date)
        {
            var start = new DateTime(date.Year, date.Month, 1);
            var end = start.AddMonths(1).AddDays(-1);
            return end;
        }

        public static DateTime GetFirstDayOfYear(DateTime date)
        {
            var start = new DateTime(date.Year, 1, 1);
            return start;
        }

        public static DateTime GetLastDayOfYear(DateTime date)
        {
            var start = new DateTime(date.Year, 1, 1);
            var end = start.AddYears(1).AddDays(-1);
            return end;
        }
    }
}
