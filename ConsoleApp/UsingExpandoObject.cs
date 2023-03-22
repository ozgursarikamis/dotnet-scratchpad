using System.Dynamic;

namespace ConsoleApp;

public static class UsingExpandoObject
{
    public static void Run()
    {
        // Replace Dictionary<string, string> with ExpandoObject
        dynamic customer = new ExpandoObject();
        customer.ID = "42";
        
        // now customer has a property named ID
        WriteLine(customer.ID);
        
        WriteLine("enter 'done' to complete adding properties");
        
        string propertyName = GetPropertyName();
        while (propertyName != "done")
        {
            string propertyValue = GetPropertyValue();
            // RuntimeBinderException:
            // 'System.Dynamic.ExpandoObject' does not contain a definition for 'Add'
            customer.Add(propertyName, propertyValue);
            propertyName = GetPropertyName();
        }
        
        WriteLine("\nCUSTOMER PROPERTIES:");
        foreach (var item in customer)
        {
            WriteLine($"{item.Key} : {item.Value}");
        }
        WriteLine("\n\nPress [Enter] to exit");
    }

    private static string GetPropertyValue()
    {
        Write("Please enter attribute Name: ");
        return ReadLine();
    }

    private static string GetPropertyName()
    {
        Write("Please enter attribute Value: ");
        return ReadLine();
    }
}