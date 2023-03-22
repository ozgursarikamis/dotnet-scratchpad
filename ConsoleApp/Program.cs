// See https://aka.ms/new-console-template for more information
using static System.Console;

int i = 42;
dynamic di = i;
int i2 = di;

WriteLine($"i = {i}, di = {di}, i2 = {i2}");

string s = "Hello";
dynamic ds = s;
int x = ds;

WriteLine($"x = {x}");