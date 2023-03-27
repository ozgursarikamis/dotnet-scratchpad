namespace WhatsNewInDotnet6;

public static class ParallelForEachAsync
{
    public static async Task Run()
    {
        var urls = new[]
        {
            "https://www.microsoft.com",
            "https://www.google.com",
            "https://www.yahoo.com",
        };
        var client = new HttpClient();

        await Parallel.ForEachAsync(urls, async (url, token) =>
        {
            var message = await client.GetAsync(url, token);
            Console.WriteLine($"{url} - {message.StatusCode}");
        });
    }
}