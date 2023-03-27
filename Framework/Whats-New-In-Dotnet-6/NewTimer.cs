namespace WhatsNewInDotnet6;

public static class NewTimer
{
    public static async Task Run()
    {
        var timer = new PeriodicTimer(TimeSpan.FromSeconds(3));
        while (await timer.WaitForNextTickAsync())
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss}");
        }
    }
}