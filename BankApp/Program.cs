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
            var myAccount = Bank.CreateAccount("test@test.com",
                TypeOfAccounts.Checking);

            Console.WriteLine($"AccountNumber: {myAccount.AccountNumber}, Account Type: {myAccount.AccountType}, Balance: {myAccount.Balance:C}, CreatedDate: {myAccount.CreatedDate}");

            var myAccount2 = Bank.CreateAccount("test2@tet.com", 
                TypeOfAccounts.Savings, 0.0M);
            Console.WriteLine($"AccountNumber: {myAccount2.AccountNumber}, Account Type: {myAccount2.AccountType}, Balance: {myAccount2.Balance:C}, CreatedDate: {myAccount2.CreatedDate}");

        }
    }
}
