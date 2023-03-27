using System.Collections.Concurrent;

namespace ConcurrentCollections;

public static class AddItemsToConcurrentDictionary
{
    public static void Run()
    {
        var dict = new ConcurrentDictionary<string, string>();

        var task1 = Task.Run(() =>
        { 
            dict.TryAdd("1", "One");
            dict.TryAdd("2", "Two");
        });
        var task2 = Task.Run(() =>
        {
            dict.TryAdd("3", "Three");
            dict.TryAdd("4", "Four");
        });

        Task.WaitAll(task1, task2);

        foreach (var item in dict)
        {
            WriteLine(item);
        }
    }
}