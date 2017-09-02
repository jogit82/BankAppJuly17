using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankApp.Tests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Withdraw_WithValidAmount_UpdatesBalance()
        {
            //arrange
            var beginningBalance = 11.99M;
            var withdrawAmount = 4.55M;
            var expected = 7.44M;
            var account = new Account();
            account.Deposit(beginningBalance);

            //act
            account.Withdraw(withdrawAmount);

            //assert
            var actual = account.Balance;
            Assert.AreEqual((double)expected, (double)actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Withdraw_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //arrange
            var beginningBalance = 11.99M;
            var withdrawAmount = -100.00M;
            var account = new Account();
            account.Deposit(beginningBalance);

            //act
            account.Withdraw(withdrawAmount);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Withdraw_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            //arrange
            var beginningBalance = 11.99M;
            var withdrawAmount = 20.01M;
            var account = new Account();
            account.Deposit(beginningBalance);

            //act
            account.Withdraw(withdrawAmount);

            //assert
        }

    }
}
