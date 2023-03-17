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

public static class NewLinqMethods
{
    public static void Run()
    {
        IEnumerable<string> strings = new List<string>
        {
            "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Item 10", "Item 11", "Item 12"
        };
        foreach (var item in strings.Chunk(3))
        {
            Console.WriteLine(item[0]);
        }
    }
}