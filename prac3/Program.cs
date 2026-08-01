using System;
using System.Collections.Generic;

class Expense
{
    public string Category { get; set; }
    public double Amount { get; set; }
}

class Program
{
    static void Main()
    {
        List<Expense> expenses = new List<Expense>();

        while (true)
        {
            Console.WriteLine("\n1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Choice: ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Category: ");
                        string category = Console.ReadLine();

                        Console.Write("Enter Amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        if (amount <= 0)
                            throw new Exception("Amount must be greater than 0.");

                        expenses.Add(new Expense
                        {
                            Category = category,
                            Amount = amount
                        });

                        Console.WriteLine("Expense Added Successfully.");
                        break;

                    case 2:
                        Console.WriteLine("\nExpenses:");
                        double total = 0;

                        foreach (var e in expenses)
                        {
                            Console.WriteLine($"Category: {e.Category}, Amount: {e.Amount}");
                            total += e.Amount;
                        }

                        Console.WriteLine("Total Expense: " + total);
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter valid numeric input.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}