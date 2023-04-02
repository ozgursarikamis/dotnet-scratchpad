using System.Text;

namespace Globalization;

public static class WorkingWithNumbers
{
    public static void Run()
    {
        ConvertStringsToDifferentCultures();
        DisplayingNumbersAsStrings();
        
        StandardNumericFormatStrings();
        DisplayNumbersAsStrings();
        
        // Round the number before calling ToString:
        var rounded = Math.Round(1500.8).ToString("C0", new CultureInfo("en-US")); // $1,501
        WriteLine($"Rounded: {rounded}");
    }

    private static void ConvertStringsToDifferentCultures()
    {
        Console.OutputEncoding = Encoding.Unicode;
        
        var culture = new CultureInfo("en-US");
        decimal number = 1_000_000.50m;
        string numberAsString = number.ToString("C0", culture);
        WriteLine($"Number As String: {numberAsString}");
        
        string numberAsSwedishKronors =
            (number * 8.70m)
            .ToString("C", CultureInfo.CreateSpecificCulture("sv-SE"));
        WriteLine($"Number in Swedish Kron: {numberAsSwedishKronors}");
        
        WriteLine("========================================");
    }

    private static void DisplayingNumbersAsStrings()
    {
        int number = 1;
        decimal number2 = 150.5m;
        decimal number3 = 1_500_000.1337m;
        
        // Calling ToString on a numeric type will use the current culture:
        WriteLine(number.ToString());
        WriteLine(number2.ToString());
        WriteLine(number3.ToString());
        
        WriteLine("======================================== With Culture Specified");
        
        // You can specify the culture to use:
        WriteLine(number.ToString(new CultureInfo("en-US")));
        WriteLine(number.ToString(new CultureInfo("tr-US")));
        WriteLine(number2.ToString(new CultureInfo("en-US")));
        WriteLine(number3.ToString(new CultureInfo("en-US")));
        WriteLine(number3.ToString(new CultureInfo("tr-TR")));
        
        WriteLine("========================================");
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
        WriteLine("========================================");
    }

    private static void DisplayNumbersAsStrings()
    {
        var culture = CultureInfo.CreateSpecificCulture("sv-SE");
        decimal number = 1_000_000.50m;
        string numberAsString = number.ToString(culture);
        
        WriteLine($"Number As String: {numberAsString}");
        WriteLine("========================================");
    }
}