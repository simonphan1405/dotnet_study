using System;

namespace ConsoleApp;

internal class ConsoleReadable: IReadable
{
    public int ReadInt()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    public string ReadString()
    {
        string? input = Console.ReadLine();
        return input ?? string.Empty;
    }
}
