using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public static class Bank
    {
        private static BankModel db = new BankModel();
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
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static Account[] GetAllAccountsByEmailAddress(string emailAddress)
        {
            return db.Accounts.
                Where(a => a.EmailAddress == emailAddress).ToArray();
        }

        public static Account GetAccountByAccountNumber(int accountNumber)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber)
                .FirstOrDefault();

            if (account == null)
            {
                throw new ArgumentException("Invalid account number.");
            }
            return account;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            account.Deposit(amount);
            db.Entry(account).CurrentValues.SetValues(account);
            db.SaveChanges();

            var transaction = new Transaction
            {
                TypeOfTransaction = TransactionType.Credit,
                TransactionDate = DateTime.Now,
                Amount = amount,
                Description = "Deposit",
                AccountNumber = accountNumber
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            account.Withdraw(amount);
            db.Entry(account).CurrentValues.SetValues(account);
            db.SaveChanges();

            var transaction = new Transaction
            {
                TypeOfTransaction = TransactionType.Debit,
                TransactionDate = DateTime.Now,
                Amount = amount,
                Description = "Withdraw",
                AccountNumber = accountNumber
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static void EditAccount(Account modifiedAccount)
        {
            var oldAccount = GetAccountByAccountNumber(modifiedAccount.AccountNumber);
            db.Entry(oldAccount).CurrentValues.SetValues(modifiedAccount);
            db.SaveChanges();
        }

        public static Transaction[] GetTransactionsByAccountNumber(int accountNumber)
        {
            return db.Transactions
                .Where(t => t.AccountNumber == accountNumber)
                .OrderByDescending(t => t.TransactionDate)
                .ToArray();
        }

        public static Transaction GetTransactionById(int id)
        {
            return db.Transactions.Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
