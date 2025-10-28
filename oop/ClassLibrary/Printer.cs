namespace ClassLibrary;

public class Printer
{
    private string name;
    public Printer()
    {
        name = string.Empty;
        Console.WriteLine("--- NEW PRINTER CREATED ---");
    }

    public Printer(string name)
    {
        this.name = name;
        Console.WriteLine($"--- NEW PRINTER CREATED: {name} ---");
    }
    
    public void Print(string message)
    {
        Console.WriteLine(message);
    }
}
