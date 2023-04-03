namespace Globalization;

public static class UsingDateTimeOffset
{
    public static void Run()
    {
        ConvertToLocalDateFromUtc();
    }

    private static void ConvertToLocalDateFromUtc()
    {
        // Convert this to the CORRECT local time:
        DateTime date = new DateTime(2020, 01, 01, 13, 30, 0, DateTimeKind.Utc);
        var localDate = TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"));
        WriteLine(localDate.ToString("f"));
        WriteLine("========================================");
    }
}