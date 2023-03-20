// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

for(var i = 0; i < 10; i++)
{
    var client = new HttpClient();
    var x = await client.GetAsync("http://localhost:5297/limited");
    Console.WriteLine(x.StatusCode);
    
    Thread.Sleep(2000);
    
    var y = await client.GetAsync("http://localhost:5297/limited");
    Console.WriteLine(y.StatusCode);
}