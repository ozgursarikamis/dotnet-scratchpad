namespace ConsoleApp;

public static class ExplicitlyImplementedInterfaceMembers
{
    internal static void Run()
    {
        IHelloable p = new Person { FirstName = "Gentry" };
        
        dynamic pd = p;
        
        WriteLine(pd.PrependHello()); // RuntimeBinderException
        // Person does not contain a definition for 'PrependHello'
    }
}


public interface IHelloable
{
    string PrependHello();
}

internal class Person : IHelloable
{
    public string FirstName { get; set; }

    string IHelloable.PrependHello()
    {
        return $"Hello {FirstName}";
    }

    public void DoStuff()
    {
        WriteLine("DoStuff() was called");
    }
}