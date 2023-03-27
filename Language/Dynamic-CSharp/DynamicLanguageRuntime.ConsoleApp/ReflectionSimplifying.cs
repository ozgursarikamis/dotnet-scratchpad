using System.Reflection;
using System.Text;

namespace DynamicLanguageRuntime.ConsoleApp;

public static class ReflectionSimplifying
{
    public static void Run()
    {
        InvokeMethodUsingReflection();
        InvokeMethodUsingDynamic();
    }

    private static void InvokeMethodUsingReflection()
    {
        StringBuilder sb = new StringBuilder();
        sb.GetType().InvokeMember(
            "AppendLine", 
            BindingFlags.InvokeMethod, 
            null, 
            sb, 
            new object?[] { "Hello Reflection" });
        WriteLine(sb);
    }
    private static void InvokeMethodUsingDynamic()
    {
        StringBuilder sb = new StringBuilder();
        ((dynamic)sb).AppendLine("Hello Dynamic Reflection");
        WriteLine(sb);  
    }

}