using System.Text.Json;

namespace ConsoleApp.Json;

public abstract class JsonReader
{
    public static void Run()
    {
        RunSample();
    }

    private static void RunSample()
    {
        using var stream = File.OpenRead("./Json/sample.json");
        using var document = JsonDocument.Parse(stream);
        
        var root = document.RootElement;
        var firstName = root
            .GetProperty("author")
            .GetProperty("firstName")
            .GetString();
        
        WriteLine($"Name is {firstName}");
        
        EnumerateElement(root);
    }

    private static void EnumerateElement(JsonElement root)
    {
        foreach (var prop in root.EnumerateObject())
        {
            if (prop.Value.ValueKind == JsonValueKind.Object)
            {
                WriteLine($"{prop.Name}");
                WriteLine("----- BEGIN OBJECT -----");
                EnumerateElement(prop.Value);
                WriteLine("----- END OBJECT -----");
            }
            else
            {
                WriteLine($"{prop.Value}:{prop.Value.GetRawText()}");
            }
        }
    }
}