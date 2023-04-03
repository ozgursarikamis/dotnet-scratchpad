namespace Globalization;

public static class UsingDateTimeOffset
{
    public static void Run()
    {
        UnixTimeStamp();
        AddAndSubtractDates();
        TryingToParseDate();
        ParsingDatesFromStrings();
        ConvertToLocalDateFromUtc();
    }

    private static void UnixTimeStamp()
    {
        // Unix TimeStamp always refers to UTC
        // Which means, it doesn't keep any time zone information

        long timestamp = 1616282420;
        DateTimeOffset date = DateTimeOffset.FromUnixTimeSeconds(timestamp);
        WriteLine(date.ToString("F", new CultureInfo("en-US")));
        WriteLine("========================================");
    }

    private static void AddAndSubtractDates()
    {
        DateTimeOffset date = new DateTimeOffset(2021, 01, 29, 23, 59, 00, TimeSpan.Zero);
        DateTimeOffset newDate = date.AddMonths(1);
        WriteLine(newDate.ToString("F", new CultureInfo("en-US")));

        DateTimeOffset now = DateTimeOffset.Now;
        DateTimeOffset future = now.Add(TimeSpan.FromHours(1));
        // TimeSpan difference = now.Subtract(future);
        TimeSpan difference = now - future;
        WriteLine($"Difference: {difference}");
        
        //NOTE: Time zone is ignored when calculating the difference
        WriteLine("========================================");
    }

    private static void TryingToParseDate()
    {
        var parsed = DateTimeOffset.TryParseExact(
            "5/10/2021 6:30:59 +08:00",
            "M/d/yyyy h:m:s", 
            null, 
            DateTimeStyles.None, out var date);
        
        if (parsed)
        {
            WriteLine($"Parsed: {date.ToString("g", new CultureInfo("en-US"))}");
        }
        else
        {
            WriteLine("Could not parse date");
        }
        
        WriteLine("========================================");
    }

    private static void ParsingDatesFromStrings()
    {
        DateTimeOffset date = new DateTimeOffset(2021, 05, 10, 18, 30, 59, TimeSpan.FromHours(8));
        string dateAsString = date.ToString("F", new CultureInfo("sv-SE"));
        string dateAsString2 = date.ToString("F", new CultureInfo("in-IN"));
        string dateAsString3 = date.ToString("F", new CultureInfo("ar-SA"));
        string dateAsString_cultureIgnored = date.ToString("O", new CultureInfo("ar-SA"));
        WriteLine($"SE: {dateAsString} ");
        WriteLine($"IN: {dateAsString2} ");
        WriteLine($"AR: {dateAsString3} ");
        WriteLine($"CULTURE IGNORED: {dateAsString_cultureIgnored} ");
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