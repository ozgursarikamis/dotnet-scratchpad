namespace ConsoleApp;

public static class ExtensionMethodCalls
{
    public static void Run()
    {
        dynamic gentry = "Gentry";
        WriteLine(gentry.PrependHello()); 
        // Microsoft.CSharp.RuntimeBinder.RuntimeBinderException:
        // 'string' does not contain a definition for 'PrependHello'
    }
}

static class ExtensionMethods
{
    public static string PrependHello(this string s) => $"Hello {s}";
}