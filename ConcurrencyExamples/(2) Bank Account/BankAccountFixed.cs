using System;
using System.Collections.Generic;
using System.Text;

namespace ConcurrencyExamples
{
    class BankAccountFixed : BankAccount
    {

        internal override void Deposit(decimal amount, string name)
        {
            lock (this)
            {
                Balance += amount;
                Console.WriteLine(name + ": + " + amount.ToString("C"));
            }
        }

        internal override void Widthdraw(decimal amount, string name)
        {
            lock (this)
            {
                Balance -= amount;
                Console.WriteLine(name + ": - " + amount.ToString("C"));
            }
        }

        internal BankAccountFixed()
            :base()
        {
        }

    }
}
