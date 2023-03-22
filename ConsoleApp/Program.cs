// See https://aka.ms/new-console-template for more information
using static System.Console;


namespace ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            int i = 42;
            PrintMe(i);

            dynamic d;
            WriteLine("Create [i]nt or [d]ouble?");
            ConsoleKeyInfo choice = ReadKey(true);

            if (choice.Key == ConsoleKey.I)
            {
                d = 99;
            }
            else
            {
                d = 99.99;
            }

            PrintMe(d);

            d = long.MaxValue;
            PrintMe(d);
        }

        private static void PrintMe(int value)
        {
            WriteLine($"PrintMe(int) called value: {value}");
        }

        private static void PrintMe(long value)
        {
            WriteLine($"PrintMe(long) called value: {value}");
        }

        private static void PrintMe(dynamic value)
        {
            WriteLine($"PrintMe(dynamic) called with a {value.GetType()} value: {value}");
        }
    }
}