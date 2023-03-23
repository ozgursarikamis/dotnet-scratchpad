using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace ConsoleApp;

public static class DynamicInterop
{
    public static void Run()
    {
        // create a python engine:
        ScriptEngine engine = Python.CreateEngine();
        string simpleExpression = "1 + 2";
        dynamic dynamicResult = engine.Execute(simpleExpression);
        
        // int typedResult = engine.Execute<int>(simpleExpression);
        // WriteLine(typedResult);
        
        WriteLine($"Expression Result: {dynamicResult}");
        
        WriteLine("Press any key to continue...");
        ReadKey();
    }
}