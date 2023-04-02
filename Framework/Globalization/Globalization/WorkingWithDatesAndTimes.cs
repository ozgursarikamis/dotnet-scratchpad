namespace Globalization;

public static class WorkingWithDatesAndTimes
{
    public static void Run()
    {
        Introduction();
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
    }
}