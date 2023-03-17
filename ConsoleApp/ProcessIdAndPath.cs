namespace ConsoleApp;

public static class ProcessIdAndPath
{
    public static void Run()
    {
        var processId = Environment.ProcessId;
        var processPath = Environment.ProcessPath;

        Console.WriteLine();
        Console.WriteLine($"Process   Id: ${processId}");
        Console.WriteLine($"Process Path: {processPath}");
        Console.WriteLine();
    }
}