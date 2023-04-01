using System.Collections.Concurrent;

namespace ConcurrentCollections;

public static class ConcurrentBags
{
    public static void Run()
    {
        var concurrentBag = GetConcurrentBag();
        concurrentBag.TryTake(out var nextTrade);
        WriteLine($"Removed value is : \t {nextTrade}");
        
        WriteLine("====================================");
        WriteLine("PEEK:");

        Parallel.For(0, 7, i =>
        {
            if (concurrentBag.TryPeek(out var number))
            {
                WriteLine($"Peeked Items: {Environment.CurrentManagedThreadId} - {number}");
            }
        });
    }
    
    private static ConcurrentBag<int> GetConcurrentBag()
    {
        var myConcurrentBag = new ConcurrentBag<int>();
        Parallel.For(1, 6, (i) =>
        {
            myConcurrentBag.Add(i);
            WriteLine($"Item added to the bag: {i}");
        });


        return myConcurrentBag;
    }
}