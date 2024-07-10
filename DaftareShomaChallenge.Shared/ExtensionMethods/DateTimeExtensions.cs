using System.Globalization;

namespace DaftareShomaChallenge.Shared.ExtensionMethods;

public static class DateTimeExtensions
{
    private static readonly PersianCalendar persianCalendar = new PersianCalendar();

    public static string ToPersianDateString(this DateTime dateTime)
    {
        int year = persianCalendar.GetYear(dateTime);
        int month = persianCalendar.GetMonth(dateTime);
        int day = persianCalendar.GetDayOfMonth(dateTime);

        return string.Concat(year.ToString("0000"), "/", month.ToString("00"), "/", day.ToString("00"));
    }

    public static string ToPersianMonthDayString(this DateTime dateTime)
    {
        int month = persianCalendar.GetMonth(dateTime);
        int day = persianCalendar.GetDayOfMonth(dateTime);

        return string.Concat(month.ToString("00"), "/", day.ToString("00"));
    }
}
