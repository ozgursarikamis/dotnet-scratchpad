using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp;

public static class DynamicCodingWithJson
{
    public static void Run()
    {
        const string customerJson = @"{
            ""FirstName"": ""Sarah"",
            ""SecondName"": ""Smith""
        }";
        
        dynamic customer = JsonConvert.DeserializeObject(customerJson);
        var firstName = customer.FirstName;
        var secondName = customer.SecondName;
        
        WriteLine($"Customer is {firstName} {secondName}");
    }
}