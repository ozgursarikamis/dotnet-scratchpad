namespace WhatsNewInDotnet6;

public static class DateOnlyAndTimeOnlyClasses
{
    public static void Run()
    {
        var myDate = new DateOnly(2023, 12, 1);
        Console.WriteLine(myDate);
        Console.WriteLine(myDate.ToLongDateString());

        Console.WriteLine();

        var today = DateOnly.FromDateTime(DateTime.Now);
        Console.WriteLine(today);

        Console.WriteLine();

        var oneYearFromToday = today.AddYears(1);
        Console.WriteLine(oneYearFromToday);

        Console.WriteLine();

        var myTime = new TimeOnly(9, 0);
        Console.WriteLine(myTime);

        Console.WriteLine();

        var startTime = new TimeOnly(10, 0);
        var endTime = new TimeOnly(10, 30, 25);

        var duration = endTime - startTime;
        Console.WriteLine(duration);
        Console.WriteLine(endTime > startTime);
    }
}