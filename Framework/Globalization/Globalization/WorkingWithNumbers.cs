namespace Globalization;

public static class WorkingWithNumbers
{
    public static void Run()
    {
        StandardNumericFormatStrings();
        DisplayNumbersAsStrings();
        
        // Round the number before calling ToString:
        var rounded = Math.Round(1500.8).ToString("C0", new CultureInfo("en-US")); // $1,501
        WriteLine($"Rounded: {rounded}");
    }

    /// <summary>
    ///     Standard Numeric Format Strings
    /// </summary>
    private static void StandardNumericFormatStrings()
    {
        var culture = new CultureInfo("en-US");
        const double amount = 1500.5;
        WriteLine($"Currency: {amount.ToString("C", culture)}"); // $1,500.50
        WriteLine($"Exponential: {amount.ToString("E", culture)}"); // 1.500500E+003
        WriteLine($"Fixed point: {amount.ToString("F", culture)}"); // 1500.50
        WriteLine($"General: {amount.ToString("G", culture)}"); // 1500.5
        WriteLine($"Number: {amount.ToString("N", culture)}"); // 1,500.50
        WriteLine($"Percent: {amount.ToString("P", culture)}"); // 150,050.00 %
        WriteLine($"Round-trip: {amount.ToString("R", culture)}"); // 1500.5
        WriteLine($"Hexadecimal: {255.ToString("X", culture)}"); // 5DC.8000000000003
        WriteLine($"Decimal: {1500.ToString("D", culture)}"); // 150050
        WriteLine();
    }

    private static void DisplayNumbersAsStrings()
    {
        var culture = CultureInfo.CreateSpecificCulture("sv-SE");
        decimal number = 1_000_000.50m;
        string numberAsString = number.ToString(culture);
        
        WriteLine($"Number As String: {numberAsString}");
        WriteLine();
    }
}