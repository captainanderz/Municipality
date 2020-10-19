using System;

namespace DanskeBankMunicipality.Business.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
        public static DateTime FirstDayOfMonth(this DateTime current)
        {
            return new DateTime(current.Year, current.Month, 1);
        }
        public static DateTime FirstDayOfYear(this DateTime current)
        {
            return new DateTime(current.Year, 1, 1);
        }
    }
}