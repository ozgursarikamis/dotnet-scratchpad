namespace ConsoleApp;

public static class UnifiedNumericMethod
{
    public static void Run()
    {
        int int1 = 5;
        int int2 = 2;
        
        WriteLine($"Int overload {CommonMath.Add(int1, int2)}");

        double double1 = 20;
        double double2 = 5;
        
        WriteLine($"Double overload {CommonMath.Add(double1, double2)}");

        WriteLine("==================================== DYNAMIC VERSION ====================================");
        WriteLine($"Dynamic overload {CommonMathDynamic.Add(int1, double1)}");
        WriteLine($"Dynamic overload {CommonMathDynamic.Add(double2, int2)}");

        // string result = CommonMathDynamic.Add(1, 4); // RuntimeBinderException: cannot implicitly convert type 'int' to 'string'
    }
}

public static class CommonMath
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }
}

public static class CommonMathDynamic
{
    public static dynamic Add(dynamic a, dynamic b)
    {
        dynamic result = a + b;
        return result;
    }
}

// // Can't do this because no unified numeric types in C#
// public static class CommonMathGeneric
// {
//     public static T Add<T>(T a, T b) // can't say "where T is a numeric type"
//     {
//         return a + b;
//     }
// }