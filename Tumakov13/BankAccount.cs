using System;

namespace Tumakov13
{
    internal class BankAccount
    {
        public uint AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
        public BankTypes AccountBankType { get; set; }

        public BankAccount(uint accountNumber, decimal accountBalance, BankTypes accountBankType)
        {
            AccountNumber = accountNumber;
            AccountBalance = accountBalance;
            AccountBankType = accountBankType;
        }
        public void ReplenishAccountBalance(decimal accountBalance)
        {
            if (accountBalance > 0)
                AccountBalance += accountBalance;
            else
                Console.WriteLine("Введите корректное значение!");
        }
        public void WithdrawAccountBalance(decimal accountBalance)
        {
            if (accountBalance > 0 && AccountBalance > accountBalance)
                AccountBalance -= accountBalance;
            else
                Console.WriteLine("Введите корректное значение!");
        }
    }
}
