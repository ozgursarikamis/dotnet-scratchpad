using System.Collections.Concurrent;

namespace ConcurrentCollections;

public static class ConcurrencyWithQueues
{
    public static void Run()
    {
        // StandardQueues();
        ConcurrentQueues();
    }

    private static void ConcurrentQueues()
    {
        List<int> ints = new()
        {
            1,
            2
        };
        ConcurrentQueue<int> concurrentIntQueue = new(ints);
        foreach (var item in concurrentIntQueue.ToArray())
        {
            WriteLine(item);
        }
    }

    private static void StandardQueues()
    {
        // Standard Queue:
        var calledIds = new Queue<int>();
        calledIds.Enqueue(1);
        calledIds.Enqueue(2);
        calledIds.Enqueue(3);
        calledIds.Enqueue(4);

        foreach (var id in calledIds)
            WriteLine(id);
        
        calledIds.Dequeue();
        WriteLine("After Dequeue:");
        
        foreach (var id in calledIds)
            WriteLine(id);
        
        // The Peek() method always returns the first item from a queue
        // collection without removing it from the queue
        WriteLine($"Peek: {calledIds.Peek()}");
        
        WriteLine("Contains Method:");
        WriteLine(calledIds.Contains(2));
        
        WriteLine("Using LINQ Methods");
        WriteLine(calledIds.Min());
        WriteLine(calledIds.Max());
    }
}