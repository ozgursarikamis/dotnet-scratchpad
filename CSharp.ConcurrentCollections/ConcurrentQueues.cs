namespace ConcurrentCollections;

public static class ConcurrentQueues
{
    public static void Run()
    {
        StandardQueues();
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