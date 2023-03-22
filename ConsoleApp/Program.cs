// See https://aka.ms/new-console-template for more information
using static System.Console;

OutputTimeStaticBinding();
WriteLine("==================================");
OutputTimeDynamicBinding();
WriteLine("==================================");
OutputDynamicRuntimeError();

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

void OutputDynamicRuntimeError()
{
    dynamic dt = DateTime.Now;
    
    // This will throw a RuntimeBinderException:
    string time = dt.IsItCoffeeTime();
    WriteLine(time);
}
