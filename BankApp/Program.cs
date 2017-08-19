using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********Welcome to my bank!********");

            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all accounts");
                Console.WriteLine("5. Print transactions");
                Console.Write("Please select an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Good bye!");
                        return;
                    case "1":
                        Console.Write("Email address: ");
                        var emailAddress = Console.ReadLine();
                        var typeOfAccounts = Enum.GetNames(typeof(TypeOfAccounts));
                        for (int i = 0; i < typeOfAccounts.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}: {typeOfAccounts[i]}");
                        }
                        Console.Write("Please select the type of account: ");
                        var typeOfAccount = Convert.ToInt32(Console.ReadLine());
                        var accountType = (TypeOfAccounts)Enum.Parse(typeof(TypeOfAccounts),
                            typeOfAccounts[typeOfAccount - 1]);

                        Console.Write("Amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(emailAddress, accountType, amount);
                        Console.WriteLine($"AN: {account.AccountNumber}, TA: {account.AccountType}, Balance: {account.Balance}");
                        break;
                    case "2":
                        try
                        {
                            PrintAllAccounts();
                            Console.Write("Account number to do deposit? ");
                            var accountNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amount to deposit: ");
                            amount = Convert.ToDecimal(Console.ReadLine());

                            Bank.Deposit(accountNumber, amount);
                            Console.WriteLine("Deposit completed successfully");
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"Something went wrong. {ax.Message} ");
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine($"Something went wrong. Either account number or amount is invalid.");
                        }
                        break;
                    case "3":
                        try
                        {
                            PrintAllAccounts();
                            Console.Write("Account number to do withdraw? ");
                            var accountNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amount to withdraw: ");
                            amount = Convert.ToDecimal(Console.ReadLine());

                            Bank.Withdraw(accountNumber, amount);
                            Console.WriteLine("Withdraw completed successfully");
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"Something went wrong. {ax.Message} ");
                        }
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;

                    case "5":
                        try
                        {
                            PrintAllAccounts();
                            Console.Write("Account number to view transactions? ");
                            var accountNumber = Convert.ToInt32(Console.ReadLine());

                            var transactions = Bank.GetTransactionsByAccountNumber(accountNumber);
                            foreach (var transaction in transactions)
                            {
                                Console.WriteLine($"TN: {transaction.Id}, Description: {transaction.Description}, Type: {transaction.TypeOfTransaction}, Date: {transaction.TransactionDate}, Amount: {transaction.Amount}");
                            }
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"Something went wrong. {ax.Message} ");
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email address: ");
            var emailAddress = Console.ReadLine();
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException("Invalid email address.");
            }
            var myAccounts =
                Bank.GetAllAccountsByEmailAddress(emailAddress);

            foreach (var account in myAccounts)
            {
                Console.WriteLine($"AN: {account.AccountNumber}, AT: {account.AccountType}, Balance: {account.Balance:C}, CreatedDate: {account.CreatedDate}");
            }
            
        }
    }
}
