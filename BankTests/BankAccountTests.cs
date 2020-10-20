using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debet_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debetAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Maxime Verstuyft", beginningBalance);

            // Act
            account.Debet(debetAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debeted correctly");
        }

        [TestMethod]
        public void Debet_whenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debetAmount = 20.00;
            BankAccountTests account = new BankAccountTests("Mr. Maxime Verstuyft", beginningBalance);


            try
            {
                account.Debet(debetAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebetAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
            // Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debet(debetAmount));
        }
    }
}
