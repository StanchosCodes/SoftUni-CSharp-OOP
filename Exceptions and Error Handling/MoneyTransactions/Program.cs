using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] accounts = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, double> bankAccounts = new Dictionary<int, double>();

            foreach (string account in accounts)
            {
                string[] accountsInfo = account.Split('-');
                bankAccounts.Add(int.Parse(accountsInfo[0]), double.Parse(accountsInfo[1]));
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] cmdArgs = command.Split();

                    string type = cmdArgs[0];
                    int account = int.Parse(cmdArgs[1]);
                    double amount = double.Parse(cmdArgs[2]);

                    if (type == "Deposit")
                    {
                        bankAccounts[account] += amount;
                        Console.WriteLine($"Account {account} has new balance: {bankAccounts[account]:f2}");
                    }
                    else if (type == "Withdraw")
                    {
                        if (amount > bankAccounts[account])
                        {
                            throw new InvalidOperationException();
                        }
                        bankAccounts[account] -= amount;
                        Console.WriteLine($"Account {account} has new balance: {bankAccounts[account]:f2}");
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid command!");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
