namespace Globalization;

public static class RegionInfoClass
{
    public static void Run()
    {
        CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
        WriteLine($"LCID: {cultureInfo.LCID}");
        WriteLine($"Name: {cultureInfo.Name}");
        
        RegionInfo region = new RegionInfo(cultureInfo.LCID);
        
        WriteLine($"Currency: {region.CurrencySymbol}");
        
        WriteLine("========================================");

        decimal distance = 10m;
        if (region.IsMetric)
        {
            WriteLine($"It's metric: {distance}");
        }
        else
        {
            decimal distanceInFeet = distance * 3.281m;
            WriteLine($"Not metric: {distanceInFeet}");
        }
        WriteLine("========================================");
        
        // NOTE: Don't rely on approximate conversions
        // Store region specific data and use the LCID to look it up.
    }
}