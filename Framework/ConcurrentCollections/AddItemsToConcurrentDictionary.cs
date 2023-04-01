using System.Collections.Concurrent;

namespace ConcurrentCollections;

public static class AddItemsToConcurrentDictionary
{
    public static void Run()
    {
        var dict = new ConcurrentDictionary<string, string>();

        var tasks = new List<Task>();
        for (var i = 0; i < 10; i++)
        {
            var i1 = i;
            var task = Task.Run(() => {
                dict.TryAdd($"Item_{i1.ToString()}", i1.ToString());
            });
            tasks.Add(task);
        }

        Task.WaitAll(tasks.ToArray());

        foreach (var item in dict)
        {
            WriteLine(item);
        }
        
        WriteLine("====================================");
        
        // TryGetValue:
        
        var doesItemExist = dict.TryGetValue("Item_1", out string? value);
        WriteLine(doesItemExist ? $"Item_1 Exists: {value}" : "No such item");
    }
}