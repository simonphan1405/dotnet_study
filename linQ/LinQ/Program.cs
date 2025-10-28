var dataSource = GetIntNumbers();

// var ns = from n in dataSource
//         where GreaterThanZero(n)
//         orderby n descending
//         select n;

var ns = dataSource
    .Where(n => GreaterThanZero(n))
    .OrderByDescending(n => n);

static bool GreaterThanZero(int n) => n > 0;

static IEnumerable<int> GetIntNumbers()
{
    var ns = new int[] { 3, 2, 1, 42, 7, 15, -23, 9, -12, 5, 18, -31, 27, 14, -8 };
    return ns;
}

static void Print(IEnumerable<int> values)
{
    foreach (var item in values)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("-----------");
}

Print(dataSource);
Print(ns);