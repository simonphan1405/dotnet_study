#pragma warning disable CA1050

// Top-level program demonstrating instance vs static methods.
Logger.LogInfo("Application starting...");

// Static utility method call (no instance required)
int fact5 = MathUtils.Factorial(5);
Console.WriteLine($"5! = {fact5}");

// Instance method usage (requires an object)
var calc = new Calculator();
int sum = calc.Add(10, 20);
Console.WriteLine($"Calculator instance Add: 10 + 20 = {sum}");

// Use SumOfArray so the method is exercised
int[] nums = [1, 2, 3, 4, 5 ];
int arrSum = calc.SumOfArray(nums);
Console.WriteLine($"Calculator SumOfArray: {string.Join(", ", nums)} = {arrSum}");

// BankAccount demonstrates static shared state, static factory, and instance behavior.
BankAccount.SetGlobalInterestRate(0.03m); // static method to change shared interest rate
var a1 = BankAccount.CreateWithBalance(1000m); // static factory
var a2 = BankAccount.CreateWithBalance(500m);

a1.ApplyMonthlyInterest(); // instance method uses static interest rate internally
a2.ApplyMonthlyInterest();

Console.WriteLine($"Account1 balance: {a1.Balance:C}");
Console.WriteLine($"Account2 balance: {a2.Balance:C}");
Console.WriteLine($"Total accounts created (static): {BankAccount.TotalAccounts}");

Logger.LogInfo("Application finished.");

// Public instance class: operates on per-object data
public class Calculator
{
    private int latestResult;

    // public instance method - needs an instance and can access instance fields
    public int Add(int a, int b)
    {
        latestResult = a + b;
        return latestResult;
    }

    // public instance method that uses a public static utility
    public int SumOfArray(int[] values)
    {
        // Uses static utility MathUtils.Sum
        return MathUtils.Sum(values);
    }
}

// Static utility class: stateless helpers, no instance required
public static class MathUtils
{
    // public static - utility, no access to instance state
    public static int Factorial(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);
        int r = 1;
        for (int i = 2; i <= n; i++) r *= i;
        return r;
    }

    public static int Sum(int[] values)
    {
        int s = 0;
        foreach (var v in values) s += v;
        return s;
    }
}

// Logger as a static facade for simple logging
public static class Logger
{
    // public static - global helper for logging
    public static void LogInfo(string message)
    {
        Console.WriteLine($"[INFO] {DateTime.Now:O} - {message}");
    }
}

// Class showing both static and instance members and a static factory
public class BankAccount
{
    private decimal balance;
    private static decimal globalInterestRate = 0.01m; // shared across all accounts
    private static int accountCounter = 0;

    public decimal Balance => balance;

    private BankAccount(decimal initial)
    {
        balance = initial;
        accountCounter++;
    }

    // public instance method - modifies this account's state
    public void Deposit(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(amount);
        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        if (amount > balance) throw new InvalidOperationException("Insufficient funds");
        balance -= amount;
    }

    // public instance method that uses static shared interest rate
    public void ApplyMonthlyInterest()
    {
        balance += balance * globalInterestRate / 12m;
    }

    // public static method - changes shared state for all accounts
    public static void SetGlobalInterestRate(decimal rate)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(rate);
        globalInterestRate = rate;
    }

    // public static factory - returns a new instance without exposing constructor semantics
    public static BankAccount CreateWithBalance(decimal initial)
    {
        return new BankAccount(initial);
    }

    // public static property exposing static info
    public static int TotalAccounts => accountCounter;
}