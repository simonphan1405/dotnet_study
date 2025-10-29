using ConsoleApp;

var c1 = new Class() { x = 10 };
var c2 = new Class() { x = 20 };

Console.WriteLine(c1.x);
Console.WriteLine(c2.x);

c2.x = 30;

Console.WriteLine(c1.x);
Console.WriteLine(c2.x);