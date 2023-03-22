// See https://aka.ms/new-console-template for more information

using System.Reflection;
using static System.Console;


namespace ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Customer c = new Customer();
            
            // c.FirstName.SomeDynamicMethod(); // <== Does not compile
            // c.SecondName.SomeDynamicMethod();
            
            PropertyInfo firstNameProperty = typeof(Customer).GetProperty("FirstName");
            foreach (var attribute in firstNameProperty.CustomAttributes)
            {
                WriteLine(attribute);
            }
            
            WriteLine($"{firstNameProperty.PropertyType} FirstName");
            WriteLine();
            
            PropertyInfo secondNameProperty = typeof(Customer).GetProperty("SecondName");
            foreach (var attribute in secondNameProperty.CustomAttributes)
            {
                WriteLine(attribute);
            }
            
            WriteLine($"{secondNameProperty.PropertyType} FirstName");
            WriteLine();
            
            // See the Output_1.png file.
        }
    }
    
    public class Customer
    {
        public object FirstName { get; set; }
        public dynamic SecondName { get; set; }
    }
}