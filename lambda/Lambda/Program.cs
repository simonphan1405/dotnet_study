// var sum = (int a, int b) => a + b;
// Func<int, int, string> sum = (a, b) => (a + b).ToString();
// Action<string> print = message => Console.WriteLine(message);

// var compare = object (int a, int b) => a > b ? 0 : "A";

// Console.WriteLine(sum(5, 10));
// print("This is a message from an Action delegate.");
// Console.WriteLine(compare(5, 10));
// Console.WriteLine(compare(10, 5));

int[] arr = [-2, 3, 0, -5, 8, 7];

Print((x) => x % 2 == 0, arr);

static void Print(Func<int, bool> f, int[] arr)
{
    foreach (var item in arr)
    {
        if (f(item))
        {
            Console.WriteLine(item);
        }
    }
}