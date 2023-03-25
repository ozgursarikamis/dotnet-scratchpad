namespace ConcurrentCollections;

public static class CollectionsAndAtomicOperations
{
    public static void Run()
    {
        var ordersQueue = new Queue<string>();
        var task1 = Task.Run(() =>
        {
            PlaceOrders(ordersQueue, "Xavier", 5);
        });
        var task2 = Task.Run(() =>
        {
            PlaceOrders(ordersQueue, "Ramdevi", 3);
        });
        Task.WaitAll(task1, task2);
        
        foreach (string order in ordersQueue)
            WriteLine($"ORDER: {order}");
    }

    private static void PlaceOrders(Queue<string> orders, string customerName, int nOrders)
    {
        for (var i = 0; i < nOrders; i++)
        {
            Thread.Sleep(1);
            var orderName = $"{customerName} wants t-shirts {i}";
            orders.Enqueue(orderName);
        }
    }
}