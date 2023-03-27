namespace WhatsNewInDotnet6;

public static class ThrowIfNull
{
    public static void Run()
    {
        SomeVeryInterestingMethod(null);
    }

    private static void SomeVeryInterestingMethod(object? obj)
    {
        // Throws ArgumentNullException if obj is null
        ArgumentNullException.ThrowIfNull(obj);
    }
}