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
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
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
                    for(int i = 0; i < typeOfAccounts.Length; i++)
                    {
                        Console.WriteLine($"{i+1}: {typeOfAccounts[i]}");
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
                    break;
                case "3":
                    
                    break;
                default:
                    break;
            }
        }
    }
}
