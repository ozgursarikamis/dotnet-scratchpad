namespace ConsoleApp;

public static class TuplePatterns
{
    public static void Run()
    {
        var c1 = GetColor(Color.Red, Color.Blue);
        WriteLine(c1);
        WriteLine();
        
        var c2 = GetColor(Color.Red, Color.Yellow);
        WriteLine(c2);
    }

    private static Color GetColor(Color c1, Color c2)
    {
        return (c1, c2) switch
        {
            (Color.Red, Color.Blue) => Color.Purple,
            (Color.Blue, Color.Red) => Color.Purple,
            
            (Color.Red, Color.Yellow) => Color.Orange,
            (Color.Yellow, Color.Red) => Color.Orange,

            (Color.Blue, Color.Yellow) => Color.Green,
            (Color.Yellow, Color.Blue) => Color.Green,
            
            (Color.Red, Color.Green) => Color.Brown,
            (Color.Green, Color.Red) => Color.Brown,
            
            // Default case with discard pattern
            // _ => throw new Exception("Unknown color combination")
            (_, _) when c1 == c2 => c1,
            
            // Default case
            _ => Color.Unknown
        };
    }
}

public enum Color
{
    Unknown,
    Red,
    Blue,
    Green,
    Purple,
    Orange,
    Brown,
    Yellow
}