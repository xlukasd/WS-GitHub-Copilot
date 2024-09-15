using Bank.Domain;

namespace Exercise_Testing
{
    public class AccountTest
    {
        [Test]
        public void TestDeposit()
        {
            // Arrange
            Account account = new Account("1234567890", "John Doe", 1000);
            decimal depositAmount = 500;

            // Act
            account.Deposit(depositAmount);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(1500));
        }

        [Test]
        public void TestWithdraw()
        {
            // Arrange
            Account account = new Account("1234567890", "John Doe", 1000);
            decimal withdrawAmount = 300;

            // Act
            account.Withdraw(withdrawAmount);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(700));
        }

        [Test]
        public void TestNotEnoughBalance()
        {
            // Arrange
            Account account = new Account("1234567890", "John Doe", 1000);
            decimal withdrawAmount = 1500;

            // Act + Assert
            Assert.Throws<NotEnoughMoneyException>(() => account.Withdraw(withdrawAmount));
        }
    }
}
