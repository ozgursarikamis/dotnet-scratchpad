// See https://aka.ms/new-console-template for more information
using static System.Console;

int i = 42;
dynamic di = i;
int i2 = di;

WriteLine($"i = {i}, di = {di}, i2 = {i2}");

// string s = "Hello";
// dynamic ds = s;
// int x = ds;
//
// WriteLine($"x = {x}");

long l = 99;
dynamic dl = l;
int y = (int)dl;

WriteLine($"l = {l}, dl = {dl}, y = {y}");

dynamic z = "Hi There";
WriteLine($"z is a {z.GetType()} = {z}");

z = 42;
WriteLine($"z is a {z.GetType()} = {z}");

z = 3.14;
WriteLine($"z is a {z.GetType()} = {z}");