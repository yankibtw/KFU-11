using System;

namespace Tumakov13
{
    internal class BankTransaction
    {
        public DateTime DateTime { get; }
        public decimal SumOfTransaction { get; }

        public BankTransaction(decimal sumOfTransaction)
        {
            SumOfTransaction = sumOfTransaction;
            DateTime = DateTime.Now;
        }

    }
}