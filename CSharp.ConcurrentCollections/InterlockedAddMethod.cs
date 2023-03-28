using System.Collections.Concurrent;

namespace ConcurrentCollections;

public static class InterlockedAddMethod
{
    public static void Run()
    {
        var result = 0;
        var tasks = new List<Task>();
        
        for (var i = 0; i < 100000; i++)
        {
            var task = Task.Run(() => {
                Interlocked.Add(ref result, 1);
            });
            tasks.Add(task);
        }
        
        Task.WaitAll(tasks.ToArray());
        
        WriteLine(result);
    }
}