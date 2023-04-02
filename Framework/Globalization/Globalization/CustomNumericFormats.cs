using System.Text;

namespace Globalization;

public static class CustomNumericFormats
{
    public static void Run()
    {
        CultureAgnosticRepresentation();
        DecimalTryParseMethod();
        CurrencyNumberStyles();
        NumberStylesFloat();
        DecimalsWithWhiteSpaces();
        ParsingAndPersistingNumbers();
        CustomNumericFormatStrings();
    }

    private static void CultureAgnosticRepresentation()
    {
        // prepare data to be stored
        string data = 1_500_000.50.ToString(CultureInfo.InvariantCulture);
        
        // restore data:
        var number = decimal.Parse(data, CultureInfo.InvariantCulture);
        
        // NOTE: Use InvariantCulture to work with the data in a culture insensitive manner
        // NOTE: JSON.NET uses InvariantCulture by default
        WriteLine("========================================");
    }

    private static void DecimalTryParseMethod()
    {
        var numberAsString = "1 000 000,5 kr";
        if (
            decimal.TryParse(
                numberAsString, 
                NumberStyles.Currency, 
                new CultureInfo("sv-SE"), out var number))
        {
            WriteLine(number);
        }
        else
        {
            WriteLine("Could not parse the number");
        }
        WriteLine("========================================");
    }

    private static void CurrencyNumberStyles()
    {
        WriteLine(decimal.Parse("100,50 kr", NumberStyles.Currency, new CultureInfo("sv-SE")));
        WriteLine(decimal.Parse("$100.50", NumberStyles.Currency, new CultureInfo("en-US")));
        WriteLine(decimal.Parse("£100.50", NumberStyles.Currency, new CultureInfo("en-GB")));
        WriteLine(decimal.Parse("100,50€", NumberStyles.Currency, new CultureInfo("fr-FR")));
        WriteLine("========================================");
    }

    private static void NumberStylesFloat()
    {
        var floatNumber = decimal.Parse("       150,5       ",
            NumberStyles.Float, new CultureInfo("sv-SE"));
        // NumberStyles.Float automatically clears white spaces
        WriteLine($"Float Number: {floatNumber}");
        WriteLine("========================================");
    }

    private static void DecimalsWithWhiteSpaces()
    {
        var decimalWithWhiteSpaces = decimal.Parse("  150  ", NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
            new CultureInfo("sv-SE"));
        WriteLine($"Decimals With White Space: {decimalWithWhiteSpaces}");
        
        WriteLine("========================================");
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

        // var numberInUsFormat = 1.50.ToString(new CultureInfo("en-US"));
        // var thisWillThrowException =
        //     decimal.Parse(numberInUsFormat, new CultureInfo("sv-SE"));
        // WriteLine(thisWillThrowException);
        
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