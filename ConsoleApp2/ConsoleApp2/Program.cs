using ConsoleApp2;
using System;

class Program
{
    static void Main()
    {
        //SavingsAccount savingAcc = new SavingsAccount();
        //savingAcc.Deposit(1000);
        //int[] a = new int[] { 1, 2, 3 };
        //int[] b = a;
        //b[0] = 5;
        //a[0] = 7;
        //Console.WriteLine(a == b); // True
        //int[] c = new int[] { 1, 2, 3 };
        //int[] d = new int[] { 1, 2, 3 };
        //Console.WriteLine(c == d); // False

        //Show(a);

        ////Base b1 = new Base(10);
        ////b1.Show();

        //Derived d1 = new Derived(5, "test");
        //d1.Show();

        ////Base b2 = new Derived(0, "test2");
        ////b2.Show();

        ////Person person = new Person();
        ////person.DisplayInfo();
        ///
        FileLogger logger = new FileLogger("log.txt");
        logger.LogError("This is an error message");

    }

    static void Show(int[] data)
    {
        double sum = 0;
        for (int i = 0; i < data.Length; i++)
        {
            sum += data[i];
        }
        Console.WriteLine($"Sum: {sum}");
    }
}

class Base
{
    public virtual void Show()
    {
        Console.WriteLine("Base.Show");
    }

    public Base(int num)
    {
        Console.WriteLine($"Base ctor num = {num}");
    }
}

class Derived : Base
{
    public override void Show()
    {
        base.Show();
        Console.WriteLine("Derived.Show");
    }
    public Derived(int num, string name) : base(num)
    {
        Console.WriteLine("Derived ctor" + name);
    }
}

abstract class BankAccount
{
    public string AccountNumber { get; set; } = default!;
    public double Balance { get; protected set; }

    // Abstract method (must be implemented by derived classes)
    public abstract void CalculateInterest();

    // Concrete method (shared implementation)
    public void Deposit(double amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited {amount:C}. New balance is {Balance:C}.");
    }

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew {amount:C}. New balance is {Balance:C}.");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}

interface ITransferrable
{
    void Transfer(double amount, BankAccount targetAccount);
}

class SavingsAccount : BankAccount, ITransferrable
{
    public override void CalculateInterest()
    {
        double interest = Balance * 0.03;
        Balance += interest;
        Console.WriteLine($"Interest of {interest:C} added. New balance is {Balance:C}.");
    }

    public void Transfer(double amount, BankAccount targetAccount)
    {
        if (amount <= Balance)
        {
            this.Withdraw(amount);
            targetAccount.Deposit(amount);
            Console.WriteLine($"Transferred {amount:C} to account {targetAccount.AccountNumber}.");
        }
        else
        {
            Console.WriteLine("Insufficient funds for transfer.");
        }
    }
}

class CheckingAccount : BankAccount, ITransferrable
{
    public override void CalculateInterest()
    {
        double interest = Balance * 0.01;
        Balance += interest;
        Console.WriteLine($"Interest of {interest:C} added. New balance is {Balance:C}.");
    }

    public void Transfer(double amount, BankAccount targetAccount)
    {
        if (amount <= Balance)
        {
            this.Withdraw(amount);
            targetAccount.Deposit(amount);
            Console.WriteLine($"Transferred {amount:C} to account {targetAccount.AccountNumber}.");
        }
        else
        {
            Console.WriteLine("Insufficient funds for transfer.");
        }
    }
}


class Person(string name)
{
    public string Name { get; } = name;
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
    }
}
