namespace ConsoleApp;

public static class UsingExpandoObject
{
    public static void Run()
    {
        // Replace Dictionary<string, string> with ExpandoObject
        var customer = new Dictionary<string, string>();
        customer.Add("ID", "42");
        
        WriteLine("enter 'done' to complete adding properties");
        
        string propertyName = GetPropertyName();
        while (propertyName != "done")
        {
            string propertyValue = GetPropertyValue();
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