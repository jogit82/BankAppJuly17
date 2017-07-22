using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public enum TypeOfAccounts
    {
        Checking,
        Savings,
        Loan,
        CD
    }
    /// <summary>
    /// This class describes a bank account
    /// </summary>
    public class Account
    {
        #region statics
        private static int lastAccountNumber = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Email address of the 
        /// person holding the account
        /// </summary>
        public string EmailAddress { get; set; }

        public int AccountNumber { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public TypeOfAccounts AccountType { get; set; }

        public decimal Balance { get; private set; }

        #endregion

        #region constructors
        public Account()
        {
            //lastAccountNumber = lastAccountNumber + 1;
            AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.Now;
        }

        //public Account(string emailAddress) : this()
        //{
        //    EmailAddress = emailAddress;
        //}

        //public Account(string emailAddress, TypeOfAccounts accountType) : this(emailAddress)
        //{
        //    AccountType = accountType;
        //}
        #endregion

        #region Methods
        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        /// <summary>
        /// Withdraw money from the bank
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        /// <returns>The new balance</returns>
        public decimal Withdraw(decimal amount)
        {
            Balance -= amount;
            return Balance;
        }
        #endregion
    }
}
