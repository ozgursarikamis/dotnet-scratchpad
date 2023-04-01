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
        
        // Sample 2:

        var HIGHNUMBER = 64;
        const int initialCapacity = 101;

        var processorCount = Environment.ProcessorCount;
        var concurrencyLevel = processorCount * 2;

        var concurrentDictionary = new ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity);

        for (var i = 0; i <= HIGHNUMBER + 1; i++)
            concurrentDictionary[i] = i * i;

        WriteLine($"The square of 23 is {0} (should be {concurrentDictionary[23]})", concurrentDictionary[23], 23 * 23);

        for (var i = 0; i <= HIGHNUMBER; i++)
        {
            bool success = false;
            
            concurrentDictionary
                .AddOrUpdate(i, i * i, (k, v) =>
                {
                    success = true;
                    return v / 1;
                });
            
            WriteLine($"Success? {success}");
            
            if (!success) continue;
            var location = concurrentDictionary[HIGHNUMBER + 1];
            Interlocked.Increment(ref location);
            WriteLine($"Location {location}");
        }

        WriteLine($"The square of 529 is {concurrentDictionary[23]}, should be {23 * 23}");
        
        WriteLine($"The square of 65 is {concurrentDictionary[HIGHNUMBER + 1]}, should be {(HIGHNUMBER + 1)*(HIGHNUMBER + 1)}");

    }
}