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

    public static void RunPythonObjects()
    {
        ScriptEngine engine = Python.CreateEngine();
        string tupleStatement = "customer = ('John', 42, 200)";
        
        ScriptScope scope = engine.CreateScope();
        ScriptSource source = engine.CreateScriptSourceFromString(tupleStatement, SourceCodeKind.SingleStatement);
        source.Execute(scope);
        
        dynamic pythonTuple = scope.GetVariable("customer");
        WriteLine($"Name = {pythonTuple[0]} Age = {pythonTuple[1]} Salary = {pythonTuple[2]}");
    }

    public static void RunPassingCustomDynamicObject()
    {
        ScriptEngine engine = Python.CreateEngine();
        HtmlElement image = new HtmlElement("img");

        ScriptScope scope = engine.CreateScope();
        scope.SetVariable("image", image);
        
        ScriptSource source = engine.CreateScriptSourceFromFile("SetImageAttributes.py");
        
        WriteLine($"image before python execution: {image}");
        source.Execute(scope);
        
        WriteLine($"image after python execution: {image}");
    }
}












