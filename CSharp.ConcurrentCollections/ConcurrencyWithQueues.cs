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
            WriteLine(item);
            
        
        WriteLine("====================================");
        WriteLine("Enqueue Method:");
        
        concurrentIntQueue.Enqueue(3);
        concurrentIntQueue.Enqueue(4);
        concurrentIntQueue.Enqueue(5);
        
        foreach (var item in concurrentIntQueue.ToArray())
            WriteLine(item);
        
        WriteLine($"TryPeek: {concurrentIntQueue.TryPeek(out var peekedValue)}");
        WriteLine(peekedValue);
        
        WriteLine("====================================");
        WriteLine($"TryDequeue: {concurrentIntQueue.TryDequeue(out var dequeuedValue)}");
        WriteLine(dequeuedValue);
        
        WriteLine("====================================");
        WriteLine("Another iteration style");
        
        foreach (var concurrentIntQueueItem in concurrentIntQueue) 
            WriteLine(concurrentIntQueueItem);
        
        WriteLine("====================================");
        WriteLine("Concurrency");
        
        var t1 = Task.Factory.StartNew(() =>
        {
            for (var i = 0; i < 10; i++)
            {
                concurrentIntQueue.TryDequeue(out var dequeuedItem);
                Thread.Sleep(100);
            }
        });
        
        var t2 = Task.Factory.StartNew(() =>
        {
            Thread.Sleep(300);
            foreach (var item in concurrentIntQueue)
            {
                WriteLine(item);
                Thread.Sleep(100);
            }
        });

        try
        {
            Task.WaitAll(t1, t2);
        }
        catch (AggregateException e)
        {
            WriteLine(e.Message);
            throw;
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