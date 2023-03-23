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
        
        Customer customer = JsonConvert.DeserializeObject<Customer>(customerJson);
        var firstName = customer.FirstName;
        var secondName = customer.SecondName;
        
        WriteLine($"Customer is {firstName} {secondName}");
    }
}

public class Customer
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
}