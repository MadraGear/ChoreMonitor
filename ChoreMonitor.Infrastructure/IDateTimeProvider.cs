namespace ChoreMonitor.Infrastructure
{
    using System;
    using System.Globalization;

    public interface IDateTimeProvider
    {
        DateTime Now();
        DateTime UtcNow();
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime FirstDayOfWeek(this DateTime dt, CultureInfo cultureInfo)
        {
            int diff = dt.DayOfWeek - cultureInfo.DateTimeFormat.FirstDayOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-diff).Date;
        }

        public static DateTime LastDayOfWeek(this DateTime dt, CultureInfo cultureInfo)
        {
            return dt.FirstDayOfWeek(cultureInfo).AddDays(6);
        }
    }
}