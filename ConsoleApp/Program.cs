// See https://aka.ms/new-console-template for more information
using static System.Console;

OutputTimeStaticBinding();
WriteLine("==================================");
OutputTimeDynamicBinding();

void OutputTimeStaticBinding()
{
    DateTime dt = DateTime.Now;
    string time = dt.ToLongTimeString();
    WriteLine(time);
}

void OutputTimeDynamicBinding()
{
    dynamic dt = DateTime.Now;
    string time = dt.ToLongTimeString();
    WriteLine(time);
}