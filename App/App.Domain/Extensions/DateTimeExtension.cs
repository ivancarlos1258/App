namespace App.Domain.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime NowBr => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
    }
}
