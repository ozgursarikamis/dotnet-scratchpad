namespace Globalization;

public static class WorkingWithDatesAndTimes
{
    public static void Run()
    {
        TimeZoneInfoClass();
        DateTimeOffsetUsage();
        Introduction();
    }

    private static void TimeZoneInfoClass()
    {
        DateTime date = 
            new DateTime
                (2020, 01, 01, 13, 30, 0, DateTimeKind.Utc);
        
        WriteLine($"The date is {date:dd MMM yyyy HH:mm}");
        
        var localTimeZoneId = TimeZoneInfo.Local.Id;
        WriteLine($"Local time zone: {localTimeZoneId}");
        var displayName = TimeZoneInfo.Local.DisplayName;
        WriteLine($"Display name: {displayName}");
        
        var isDaylightSavingTime = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.Today);
        WriteLine($"Is daylight saving time: {isDaylightSavingTime}");
        
        WriteLine();
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(localTimeZoneId);
        TimeZoneInfo.ConvertTimeFromUtc(date, timeZoneInfo);
        
        WriteLine("========================================");
    }

    private static void DateTimeOffsetUsage()
    {
        DateTimeOffset now = DateTimeOffset.Now;
        WriteLine(now);

        DateTimeOffset otherDate = now.ToOffset(TimeSpan.FromHours(1));
        WriteLine(otherDate);

        DateTimeOffset utcDate = otherDate.ToUniversalTime();
        WriteLine(utcDate);
        WriteLine("========================================");
    }

    private static void Introduction()
    {
        var date1 = new DateTime(2021, 5, 10);
        var date2 = new DateTime(2021, 5, 10, 19, 30, 00);

        var date3 = DateTime.Now; // Local time
        var date4 = DateTime.UtcNow; // UTC time [NO TIME ZONE DATA AVAILABLE]
        
        // DateTime contains no time zone information
        var dateTime = DateTime.Now.ToString(new CultureInfo("sv-SE"));
        
        var specified1 = DateTime.SpecifyKind(date1, DateTimeKind.Local);
        WriteLine(specified1);
        
        WriteLine(dateTime);
        WriteLine("========================================");
    }
}