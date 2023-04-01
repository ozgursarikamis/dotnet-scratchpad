using System.Collections.Concurrent;

namespace ConcurrentCollections;

public static class BlockingCollections
{
    public static void Run()
    {
        var collection = GenerateABlockingCollection();
        RemovingItemsFromABlockingCollection();
    }

    private static void RemovingItemsFromABlockingCollection()
    {
        var collection = new BlockingCollection<int>
        {
            10, 20
        };
        foreach (var i in collection)
            WriteLine($"Item: {i}");

        WriteLine("==================================== TAKE METHOD:");
        var result1 = collection.Take();
        WriteLine("Item: {0}", result1);
        
        WriteLine("==================================== TryTake METHOD WITH TIMEOUT:");
        var tryTake = collection.TryTake(out var result2, TimeSpan.FromSeconds(1));
        WriteLine("Item: {0}", tryTake ? result2.ToString() : "No item was available to be removed");
    }

    private static BlockingCollection<int> GenerateABlockingCollection()
    {
        BlockingCollection<int> collection = new(4);
        collection.Add(10);
        collection.Add(20);
        
        collection.Add(40);
        collection.Add(50);

        if (collection.TryAdd(30, TimeSpan.FromSeconds(1)))
        {
            WriteLine("Item 30 Added");
        }
        else
        {
            WriteLine("Item 30 could not be added");
        }

        foreach (var item in collection)
        {
            WriteLine(item);
        }

        return collection;
    }
}