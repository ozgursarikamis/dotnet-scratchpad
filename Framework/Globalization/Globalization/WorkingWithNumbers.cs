namespace Globalization;

public static class WorkingWithNumbers
{
    public static void Run()
    {
        DisplayNumbersAsStrings();
    }

    private static void DisplayNumbersAsStrings()
    {
        
        var culture = CultureInfo.CreateSpecificCulture("sv-SE");
        decimal number = 1_000_000.50m;
        string numberAsString = number.ToString(culture);
        
        WriteLine(numberAsString);
    }
}