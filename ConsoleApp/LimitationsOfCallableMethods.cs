namespace ConsoleApp;

public static class LimitationsOfCallableMethods
{
    public static void Run()
    {
        dynamic gentry = "Gentry";
        WriteLine(gentry.PrependHello()); 
        // Microsoft.CSharp.RuntimeBinder.RuntimeBinderException:
        // 'string' does not contain a definition for 'PrependHello'
        
        string gentry2 = "Gentry";
        WriteLine(gentry2.PrependHello()); // Hello Gentry
    }
}

static class ExtensionMethods
{
    public static string PrependHello(this string s) => $"Hello {s}";
}