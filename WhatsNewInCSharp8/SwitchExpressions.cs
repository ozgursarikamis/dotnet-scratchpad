namespace WhatsNewInCSharp8;

public static class SwitchExpressions
{
    public static void Run()
    {
        DisplayMeasurement(-0.4);
        DisplayMeasurement2(-0.4);
        DisplayMeasurement_CaseGuards(2, 3);
        DisplayMeasurement_CaseGuards(2, -3);
        
        var shape = new Rectangle { Width = 10, Height = 5 };
        var area = DetermineShapeArea(shape);
        
        WriteLine($"Area is {area}");
    }

    private static double DetermineShapeArea(object shape)
    {
        var area = shape switch
        {
            Rectangle r => r.Width * r.Height,
            Circle c => c.Radius * c.Radius * Math.PI,
            Triangle t => t.Base * t.Height / 2,
            _ => throw new ArgumentException(message: "invalid shape", paramName: nameof(shape))
        };
        return area;
    }

    private static void DisplayMeasurement_CaseGuards(int a, int b)
    {
        switch (a, b)
        {
            case (> 0, > 0) when a == b:
                WriteLine("Both are positive");
                break;
            case (> 0, > 0):
                WriteLine("Both are positive, but not equal");
                break;
            default:
                WriteLine("one or both measurements are not valid");
                break;
        }
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

    private class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }

    private class Circle
    {
        public double Radius { get; set; }
    }

    private class Triangle
    {
        public double Base { get; set; }
        public double Height { get; set; }
    }
}