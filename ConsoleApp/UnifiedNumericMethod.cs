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
        
        WriteLine("==================================== Dynamic & GENERIC VERSION ====================================");
        WriteLine(CommonMathDynamicWithGenerics.Add(int1, double1));
        WriteLine(CommonMathDynamicWithGenerics.Add(double1, double1));

        WriteLine("==================================== Dynamic & GENERIC VERSION WITH EXPLICIT CAST ====================================");
        short short1 = 1;
        short short2 = 2;
        // WriteLine(CommonMathDynamicWithGenerics.Add(short1, short2)); // RuntimeBinderException: 
        
        WriteLine(CommonMathDynamicWithGenericsExplicitCast.Add(short1, short2));
        
        // Performance tip:
        CommonMathDynamicWithGenericsExplicitCast.Add(double1, double2);
    }
}

public static class CommonMathDynamicWithGenericsExplicitCast
{
    public static T Add<T>(T a, T b)
    {
        dynamic result = (dynamic)a + b;
        return (T)result; // Casting
    }
    
    // to increase performance, if required for specific types:
    public static double Add(double a, double b)
    {
        double result = a + b;
        return result;
    }
}

public static class CommonMathDynamicWithGenerics
{
    public static T Add<T>(T a, T b)
    {
        dynamic result = (dynamic)a + b;
        return result;
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