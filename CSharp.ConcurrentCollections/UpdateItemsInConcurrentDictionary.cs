using System.Collections.Concurrent;

namespace ConcurrentCollections;

public static class UpdateItemsInConcurrentDictionary
{
    public static void Run()
    {
        var dictionary 
            = new ConcurrentDictionary<string, string?>();
        
        dictionary.TryAdd("1", "First");
        dictionary.TryAdd("2", "Second");
        dictionary.TryAdd("3", "Third");
        dictionary.TryAdd("4", "Fourth");
        
        // Update an item:
 
        var returnsTrue = dictionary.TryUpdate("1", "First Updated", "First");
        dictionary.TryGetValue("1", out var newValue);
        WriteLine(newValue);

        var returnsFalse = dictionary.TryUpdate("2", "New Value 2", "No Value");
        dictionary.TryGetValue("2", out newValue);

        WriteLine(newValue);
    }
}