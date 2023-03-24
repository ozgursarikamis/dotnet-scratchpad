namespace ConsoleApp;

public static class SwitchExpressions
{
    public static void Run()
    {
        DisplayMeasurement(-0.4);
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