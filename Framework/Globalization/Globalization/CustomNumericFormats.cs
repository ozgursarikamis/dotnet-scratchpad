using System.Text;

namespace Globalization;

public static class CustomNumericFormats
{
    public static void Run()
    {
        ParsingAndPersistingNumbers();
        CustomNumericFormatStrings();
    }

    private static void ParsingAndPersistingNumbers()
    {
        Console.OutputEncoding = Encoding.Unicode;
        var numberAsString = "1 000 000,5";

        // System.FormatException: The input string '1 000 000,5' was not in a correct format.
        // decimal number = decimal.Parse(numberAsString);
        // WriteLine(number);
        
        decimal number = decimal.Parse(numberAsString, new CultureInfo("sv-SE"));
        WriteLine(number);
        
        WriteLine("========================================");
    }

    private static void CustomNumericFormatStrings()
    {
        CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
        const double onePointFive = 1.5;
        
        WriteLine(onePointFive.ToString("00.00"));    // 0 - Zero Placeholder
        WriteLine(onePointFive.ToString("##.##"));    // # - Digit Placeholder
        WriteLine(onePointFive.ToString("0000.000")); // . - Decimal Separator
        WriteLine(onePointFive.ToString(@"\#0"));     // \ - Escape Character
        WriteLine(onePointFive.ToString("0.00%"));    // % - Percent
        
        WriteLine("========================================");
        
        WriteLine(1550.55.ToString("#,#.000")); // , - Group Separator
        WriteLine(1.ToString("#%"));            // % - Percent placeholder
        WriteLine(1.ToString("#‰"));            // ‰ - Per mille placeholder
        WriteLine(150.ToString("#E0"));         // E - Scientific notation placeholder
        
        WriteLine("========================================");
    }
}