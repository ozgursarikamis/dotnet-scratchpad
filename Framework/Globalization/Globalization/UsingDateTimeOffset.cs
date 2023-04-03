namespace Globalization;

public static class UsingDateTimeOffset
{
    public static void Run()
    {
        ParsingDatesFromStrings();
        ConvertToLocalDateFromUtc();
    }

    private static void ParsingDatesFromStrings()
    {
        DateTimeOffset date = new DateTimeOffset(2021, 05, 10, 18, 30, 59, TimeSpan.FromHours(8));
        string dateAsString = date.ToString("F", new CultureInfo("sv-SE"));
        string dateAsString2 = date.ToString("F", new CultureInfo("in-IN"));
        string dateAsString3 = date.ToString("F", new CultureInfo("ar-SA"));
        WriteLine($"SE: {dateAsString} ");
        WriteLine($"IN: {dateAsString2} ");
        WriteLine($"AR: {dateAsString3} ");
        WriteLine("========================================");
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