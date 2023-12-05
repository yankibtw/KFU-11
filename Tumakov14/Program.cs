using System;

namespace Tumakov14
{
    internal class Program
    {
        static void Main(string[] args)
        {
        #if DEBUG_ACCOUNT
            Bank account = new Bank();
            account.accountHolder = "Ганиев Марат";
            account.ReplenishAccountBalance(500);
            account.DumpToScreen();
        #endif
        }
    }
}
