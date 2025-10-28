var list = new List<string>();

ReadStrings(list);
Print(list);
Sort(list);
Print(list);

static void Sort(List<string> list)
{
    list.Sort();
}

static void Print(List<string> list)
{
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine();
}

static void ReadStrings(List<string> list)
{
    Console.WriteLine("Enter strings (empty line to finish):");
    while (true)
    {
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            break;
        }
        list.Add(input);
    }
}
