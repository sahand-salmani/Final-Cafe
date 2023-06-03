using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common
{
    public static class AzTimeHandler
    {
        public static DateTime GetFirstDayOfCurrentMonthAz(this DateTime dateTime)
        {
            DateTime date = DateTime.Now.ToAzDateTime();
            return new DateTime(date.Year, date.Month, 1);
        }


        public static DateTime GetLastDayOfCurrentMonthAz(this DateTime dateTime)
        {
            var firstDayOfMonth = DateTime.Now.GetFirstDayOfCurrentMonthAz();
            return firstDayOfMonth.AddMonths(1).AddDays(-1);
        }

        public static string GetSqlDateTimeFormat(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        public static DateTime GetFirstDayOfCurrentYear(this DateTime _)
        {
            var now = DateTime.Now.ToAzDateTime();
            var year = now.Year;
            return new DateTime(year, 1, 1);
        }

        public static DateTime GetLastDayOfCurrentYear(this DateTime _)
        {
            var now = DateTime.Now.ToAzDateTime();
            var year = now.Year;
            return new DateTime(year, 1, 1).AddYears(1).AddDays(-1);
        }

        public static DateTime GetLastDayOfGivenYear(this DateTime dateTime)
        {
            var year = dateTime.Year;
            return new DateTime(year, 1, 1).AddYears(1).AddDays(-1);
        }
    }
}
