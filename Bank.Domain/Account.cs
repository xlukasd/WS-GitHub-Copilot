﻿namespace Bank.Domain
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }

        public Account(string accountNumber, string owner, decimal balance)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
    }
}
