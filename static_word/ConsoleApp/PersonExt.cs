using System;

namespace ConsoleApp;

internal static class PersonExt
{
    public static void Print(this Person person)
    {
        Console.WriteLine($"Person ID: {person.Id}, Name: {person.Name}");
    }
}
