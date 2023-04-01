using System.Collections.Immutable;

namespace ConcurrentCollections;

public static class ConcurrentDictionaries
{
    public static void Run()
    {
        StockController controller = new StockController(TShirtProvider.AllShirts);
        TimeSpan workDay = new TimeSpan(0, 0, 0, 0, 500);

        new SalesPerson("Kim").Work(workDay, controller);
        controller.DisplayStock();
    }
}

public class SalesPerson
{
    public string Name { get; set; }
    public SalesPerson(string name)
    {
        Name = name;
    }

    public void Work(TimeSpan workDay, StockController controller)
    {
        DateTime start = DateTime.Now;
        while (DateTime.Now - start < workDay)
        {
            var result = ServeCustomer(controller);
            if (result.Status != null) 
                WriteLine($"{Name}: {result.Status}");
            if (!result.ShirtsInStock)
                break;
        }
    }

    private static (bool ShirtsInStock, string Status) ServeCustomer(StockController controller)
    {
        
        TShirt shirt = controller.SelectRandomShirt();
        if (shirt == null)
            return (false, "No shirts in stock");
        Thread.Sleep(Rnd.NextInt(30));
        
        // customer chooses to buy with only 20% probability
        if (!Rnd.TrueWithProb(0.2)) 
            return (true, null);
        controller.Sell(shirt.Code);
        return (true, $"Sold {shirt}");
    }
}

public class TShirt
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int PricePence { get; set; }

    public TShirt(string code, string name, int pricePence)
    {
        Code = code;
        Name = name;
        PricePence = pricePence;
    }

    public override string ToString() => $"{Name} ({DisplayPrice(PricePence)})";
    private static string DisplayPrice(int pricePence) => $"${pricePence / 100}.{pricePence % 100:00}";
}

public static class TShirtProvider
{
    // Immutable collections are fixed, you cannot modify them.
    // They are thread-safe, and can be shared between threads.
    public static ImmutableArray<TShirt> AllShirts { get; } = ImmutableArray.Create(
        new TShirt("igeek", "IGeek", 500),
        new TShirt("bigData", "Big Data", 600),
        new TShirt("ilovenode", "I Love Node", 750),
        new TShirt("kcdc", "kcdc", 400),
        new TShirt("docker", "Docker", 350),
        new TShirt("qcon", "QCon", 300),
        new TShirt("ps", "Pluralsight", 60000),
        new TShirt("pslive", "Pluralsight Live", 60000)
    );
}

public class StockController
{
    private Dictionary<string, TShirt> _stock;

    public StockController(IEnumerable<TShirt> shirts)
    {
        _stock = shirts.ToDictionary(x => x.Code);
    }

    public void Sell(string code)
    {
        _stock.Remove(code);
    }

    public TShirt SelectRandomShirt()
    {
        var keys = _stock.Keys.ToList();
        if (keys.Count == 0)
            return null;
        
        Thread.Sleep(Rnd.NextInt(10));
        string selectedCode = keys[new Random().Next(keys.Count)];
        return _stock[selectedCode];
    }
    
    public void DisplayStock()
    {
        WriteLine($"Stock: {_stock.Count} items left in stock");
        foreach (var shirt in _stock.Values) 
            WriteLine(shirt);
    }
}

public class Rnd
{
    private static readonly Random Generator = new();
    public static int NextInt(int max) => Generator.Next(max);
    public static bool TrueWithProb(double probOfTrue) => Generator.NextDouble() < probOfTrue;
}