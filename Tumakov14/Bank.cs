using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Tumakov14
{
    internal enum BankTypes
    {
        Current,
        Saving
    }
    [Developer("Ganiev Marat", "KFU")]
    internal class Bank : IDisposable
    {
        private static uint accountNumberSeed = 0;
        private bool disposed = false;

        public uint accountNumber { get; }
        public decimal accountBalance { get; private set; }
        public BankTypes accountBankType { get; private set; }
        public string accountHolder { get; set; }

        public Queue<BankTransaction> AllTransactions = new Queue<BankTransaction>();
        public BankTransaction this[int index]
        {
            get
            {
                if (index < 0 || index >= AllTransactions.Count)
                {
                    throw new IndexOutOfRangeException("Элемент находится вне списка!");
                }

                return AllTransactions.ElementAt(index);
            }
        }

        /// upd:
        internal Bank(decimal accountBalance, BankTypes accountBankType)
        {
            accountNumber = GenerateAccountNumber();
            this.accountBalance = accountBalance;
            this.accountBankType = accountBankType;
        }
        // upd:
        internal Bank()
        {
            accountNumber = GenerateAccountNumber();
        }
        internal Bank(decimal accountBalance)
        {
            accountNumber = GenerateAccountNumber();
            this.accountBalance = accountBalance;
        }
        internal Bank(BankTypes accountBankType)
        {
            accountNumber = GenerateAccountNumber();
            this.accountBankType = accountBankType;
        }
        private uint GenerateAccountNumber()
        {
            accountNumberSeed++;
            return accountNumberSeed;
        }
        public void ReplenishAccountBalance(decimal accountBalance)
        {
            if (accountBalance >= 0)
            {
                this.accountBalance += accountBalance;
                BankTransaction replenishBalance = new BankTransaction(accountBalance);
                AllTransactions.Enqueue(replenishBalance);
            }
            else
                Console.WriteLine("Введено отрицательное значение!");
        }
        public void WithdrawAccountBalance(decimal accountBalance)
        {
            if (accountBalance <= this.accountBalance && accountBalance >= 0)
            {
                this.accountBalance -= accountBalance;
                BankTransaction withdrawBalance = new BankTransaction(accountBalance);
                AllTransactions.Enqueue(withdrawBalance);
            }
            else
                Console.WriteLine("Недостаточно денег на счете! Либо введено отрицательное значение!");
        }
        public void TransferMoneyToAnotherAccount(Bank secondAccount, uint sumOfTransfer)
        {
            if (sumOfTransfer > 0)
            {
                if (accountBalance > sumOfTransfer)
                {
                    accountBalance -= sumOfTransfer;
                    secondAccount.accountBalance += sumOfTransfer;
                    BankTransaction transferBalance = new BankTransaction(sumOfTransfer);
                    AllTransactions.Enqueue(transferBalance);
                    Console.WriteLine("Деньги успешно переведены!");
                }
                else
                    Console.WriteLine("На счете недостаточно средств!");
            }
            else
                Console.WriteLine("Введите положительное значение!!!");
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    using (StreamWriter writer = new StreamWriter("AllTransactions.txt"))
                    {
                        foreach (var transaction in AllTransactions)
                        {
                            writer.WriteLine($"{transaction.DateTime} {transaction.SumOfTransaction}");
                        }
                    }
                }
                disposed = true;
            }
        }
        ~Bank()
        {
            Dispose(false);
        }
        public static bool operator ==(Bank firstAccount, Bank secondAccount)
        {
            return ((firstAccount.accountBankType == secondAccount.accountBankType) & (firstAccount.accountBalance == secondAccount.accountBalance));
        }
        public static bool operator !=(Bank firstAccount, Bank secondAccount)
        {
            return !((firstAccount.accountBankType == secondAccount.accountBankType) & (firstAccount.accountBalance == secondAccount.accountBalance));
        }
        public override bool Equals(object obj)
        {
            if (obj is Bank)
            {
                Bank item = (Bank)obj;
                return this == item;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return accountBalance.GetHashCode() ^ accountBankType.GetHashCode() ^ accountNumber.GetHashCode();
        }
        public override string ToString()
        {
            return $"ID аккаунта: {accountNumber}\nБаланс аккаунта: {accountBalance}\nТип счёта: {accountBankType}";
        }

        [Conditional("DEBUG_ACCOUNT")]
        public void DumpToScreen()
        {
            Console.WriteLine($"Номер аккаунта: {accountNumber}\n" +
                              $"Баланс аккаунта: {accountBalance}\n" +
                              $"Тип банковского счёта: {accountBankType} \n" +
                              $"Владелец счета: {accountHolder}");

            Console.WriteLine("Транзакции:");
            foreach (var transaction in AllTransactions)
            {
                Console.WriteLine($"{transaction.DateTime} - {transaction.SumOfTransaction}");
            }
        }
    }
}