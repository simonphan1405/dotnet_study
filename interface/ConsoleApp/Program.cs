namespace ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        IReadable consoleReadable = new ConsoleReadable();

        Console.WriteLine("Please enter an integer:");
        int userInt = consoleReadable.ReadInt();
        Console.WriteLine($"You entered the integer: {userInt}");

        Console.WriteLine("Please enter a string:");
        string userString = consoleReadable.ReadString();
        Console.WriteLine($"You entered the string: {userString}");
    }
}