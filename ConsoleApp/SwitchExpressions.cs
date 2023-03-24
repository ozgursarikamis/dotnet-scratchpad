namespace ConsoleApp;

public static class SwitchExpressions
{
    public static void Run()
    {
        DisplayMeasurement(-0.4);
        DisplayMeasurement2(-0.4);
    }

    private static void DisplayMeasurement2(double measurement)
    {
        var result = measurement switch
        {
            < 0.0 => "Negative",
            > 15.0 => "Too high",
            double.NaN => "Not a number",
            _ => $"Value is {measurement}"
        };
        WriteLine(result);
    }
    private static void DisplayMeasurement(double measurement)
    {
        switch (measurement)
        {
            case < 0.0:
                WriteLine("Negative");
                break;
            case > 15.0:
                WriteLine("Too high");
                break;
            case double.NaN:
                WriteLine("Not a number");
                break;
            default:
                WriteLine($"Value is {measurement}");
                break;
        }
    }
}