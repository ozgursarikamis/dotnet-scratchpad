using System.Collections.Concurrent;

namespace ConcurrentCollections;

public static class BlockingCollections
{
    public static void Run()
    {
        GenerateABlockingCollection();
    }

    private static void GenerateABlockingCollection()
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
    }
}