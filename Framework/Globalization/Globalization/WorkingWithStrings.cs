namespace Globalization;

public static class WorkingWithStrings
{
    public static void Run()
    {
        Introduction();
    }

    private static void Introduction()
    {
        var s1 = string.Equals("first", "second");
        
        // Defaults to ordinal case-sensitive ordinal comparison
        // Ignores culture
        var s2 = string.Equals("first", "second", StringComparison.Ordinal); // fastest, Culture-agnostic comparison
        
        var s3 = string.Equals("first", "second", StringComparison.OrdinalIgnoreCase);
        
        WriteLine($"s1: {s1}");
        WriteLine($"s2: {s2}");
        WriteLine($"s3: {s3}");
        WriteLine("========================================");

        bool result = string.Equals("first", "second");
        int order = string.Compare("first", "second"); // takes CultureInfo.CurrentCulture into account
        WriteLine($"string.Equals: {result}");
        WriteLine($"string.Compare: {order}");
        WriteLine("========================================");

        string first = "\u00e5"; // a with a ring
        string second = "\u0061\u030a"; // a with a ring
        
        WriteLine($"first: {first}");
        WriteLine($"second: {second}");
        bool comparisonResult = string.Equals(first, second);
        
        WriteLine($"string.Equals: {comparisonResult}");
        WriteLine($"string.Equals: {comparisonResult}");
        WriteLine("========================================");
        
        // string.Equals is culture-aware
        int sortOrderOrdinal = string.Compare("first", "second", StringComparison.Ordinal); // OR USE OrdinalIgnoreCase
        int sortOrderInvariantCase = string.Compare("first", "second", StringComparison.InvariantCulture); // AVOID THIS 
        
        WriteLine($"sortOrderOrdinal: {sortOrderOrdinal}");
        WriteLine($"sortOrderOrdinalIgnoreCase: {sortOrderInvariantCase}");
        WriteLine("========================================");
    }
}