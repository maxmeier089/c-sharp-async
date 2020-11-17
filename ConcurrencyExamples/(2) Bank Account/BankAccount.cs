using System;
using System.Collections.Generic;
using System.Text;

namespace ConcurrencyExamples
{
    /// <summary>
    /// Bank account with a balance and methods for adding rsp. removing money
    /// (no credit limit!)
    /// </summary>
    abstract class BankAccount
    {

        internal decimal Balance { get; set; }

        internal abstract void Deposit(decimal amount, string name);

        internal abstract void Widthdraw(decimal amount, string name);

        internal BankAccount()
        {
            Balance = 0m;
        }

    }
}
