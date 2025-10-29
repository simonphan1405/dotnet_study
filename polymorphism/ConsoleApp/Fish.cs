namespace ConsoleApp;

internal class Fish: Animal
{
    public sealed override void Move()
    {
        Console.WriteLine("Fish is swimming");
    }
}
