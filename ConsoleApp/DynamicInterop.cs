using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace ConsoleApp;

public static class DynamicInterop
{
    public static void Run()
    {
        // create a python engine:
        ScriptEngine engine = Python.CreateEngine();
        
        int customerAge = 42;
        WriteLine("Enter an expression");
        string expression = ReadLine();
        
        ScriptScope scope = engine.CreateScope();
        scope.SetVariable("a", customerAge);
        
        ScriptSource source = engine.CreateScriptSourceFromString(expression, SourceCodeKind.SingleStatement);
        source.Execute(scope);

        var dynamicResult = scope.GetVariable("result");
        WriteLine($"Expression Result: {dynamicResult}");
        
        WriteLine("Press any key to continue...");
        ReadKey();
    }
}