using ConsoleApp;

var c1 = new Class() {  };

static void AssignX(int value)
{
    Class.x = value;
}

Console.WriteLine("c1 can not access x directly because x is static.");
Console.WriteLine($"Values of c1: x = {Class.x}");

Class.x = 30;
Console.WriteLine($"After assigning 30 to x, c1: x = {Class.x}.");

AssignX(1234);
Console.WriteLine($"After calling AssignX(1234), c1: x = {Class.x}.");

Class.F();
Console.WriteLine($"After calling Class.F(), c1: x = {Class.x}.");