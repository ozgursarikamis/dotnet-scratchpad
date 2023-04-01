namespace Globalization;

public static class Introduction
{
    public static void Run()
    {
        CultureInfo cultureInfo = CultureInfo.CurrentCulture;   
        DisplayInfo(cultureInfo);
        
        cultureInfo = new CultureInfo("tr-TR");
        DisplayInfo(cultureInfo);
    }

    private static void DisplayInfo(CultureInfo cultureInfo)
    {
        WriteLine($"Culture         : {cultureInfo.Name}");
        WriteLine($"Display Name    : {cultureInfo.DisplayName}");
        WriteLine($"English Name    : {cultureInfo.EnglishName}");
        WriteLine($"Native Name     : {cultureInfo.NativeName}");
        WriteLine($"Three-Letter ISO: {cultureInfo.ThreeLetterISOLanguageName}");
        WriteLine($"Three-Letter Win: {cultureInfo.ThreeLetterWindowsLanguageName}");
        WriteLine($"Two-Letter ISO  : {cultureInfo.TwoLetterISOLanguageName}");
        WriteLine($"Compare Info    : {cultureInfo.CompareInfo}");
        WriteLine($"Currency Symbol : {cultureInfo.NumberFormat.CurrencySymbol}");
        WriteLine();
    }
}