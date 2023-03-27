using System.Collections.Concurrent;

namespace ConcurrentCollections;

public static class AddOrUpdateToAvoidRaceCondition
{
    public static void Run()
    {
        ConcurrentDictionary<int, int> dictionary = new();
        Parallel.For(0, 10000, i =>
        {
            dictionary
                .AddOrUpdate(1, 1, (key, oldValue) => oldValue + 1);
            WriteLine($"{i} in Parallel.For");
        });
        
        WriteLine("After 10000 AddOrUpdates, dictionary[1] = {0}, should be 10000", dictionary[1]);

        var value = dictionary.GetOrAdd(2, (key) => 100);
        WriteLine("After initial GetOrAdd, dictionary[2] = {0} (should be 100)", value);

        value = dictionary.GetOrAdd(2, 10000);
        WriteLine("After second GetOrAdd, dictionary[2] = {0} (should be 100)", value);
    }
}