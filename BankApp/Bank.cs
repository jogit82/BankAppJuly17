using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        public static string Name { get; set; }

        static Bank()
        {
            Name = "My Bank";
        }

        public static Account CreateAccount(string emailAddress, 
            TypeOfAccounts accountType, decimal amount = 0.0M)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            if (amount > 0)
            {
                account.Deposit(amount);
            }
            accounts.Add(account);
            return account;
        }
    }
}
