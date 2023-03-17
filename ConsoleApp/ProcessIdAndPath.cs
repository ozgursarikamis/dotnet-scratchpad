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
        
        Console.WriteLine();
        
        var people = new List<Person>
        {
            new() { FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1980, 1, 1) },
            new() { FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateOnly(1985, 1, 1) },
            new() { FirstName = "John", LastName = "Smith", DateOfBirth = new DateOnly(1970, 1, 1) },
            new() { FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1975, 1, 1) },
        };
        var oldest = people.MaxBy(p => p.DateOfBirth);
        var youngest = people.MinBy(p => p.DateOfBirth);

        Console.WriteLine($"Oldest: {oldest!.FirstName} {oldest.LastName}");
        Console.WriteLine($"Youngest: {youngest!.FirstName} {youngest.LastName}");
        Console.WriteLine();
    }
}

public class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
}