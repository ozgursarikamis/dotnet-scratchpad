namespace ConsoleApp;

public static class ConsumingVoidMethods
{
    public static void Run()
    {
        dynamic p = new Person();
        var x = p.DoStuff(); // RuntimeBinderException
        // Cannot implicitly convert type 'void' to 'object'
    }
} 