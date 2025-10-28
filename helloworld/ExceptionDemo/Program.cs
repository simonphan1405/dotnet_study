try
{
    Console.WriteLine("Starting Exception Demo...");
    Console.Write("n = ");
    int n = int.Parse(Console.ReadLine() ?? string.Empty);
    int result = 100 / n;

    Console.WriteLine($"100 / {n} = {result}");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Error: Division by zero is not allowed.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}