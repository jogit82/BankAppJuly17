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
            var myAccount = new Account
            {
                EmailAddress = "test@test.com",
                AccountType = TypeOfAccounts.Checking
            };

            myAccount.Deposit(500.01M);

            Console.WriteLine($"AccountNumber: {myAccount.AccountNumber}, Account Type: {myAccount.AccountType}, Balance: {myAccount.Balance:C}, CreatedDate: {myAccount.CreatedDate}");

            var myAccount2 = new Account
            {
                AccountType = TypeOfAccounts.Savings
            };
            myAccount2.EmailAddress = "test2@test.com";
            //myAccount2.AccountType = TypeOfAccounts.Savings;
            Console.WriteLine($"AccountNumber: {myAccount2.AccountNumber}, Account Type: {myAccount2.AccountType}, Balance: {myAccount2.Balance:C}, CreatedDate: {myAccount2.CreatedDate}");

        }
    }
}
