using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConcurrencyExamples
{
    /// <summary>
    /// Randomly deposit and withdraw money from a bank account
    /// </summary>
    class BankAccountAccess
    {

        readonly BankAccount BankAccount;

        internal decimal TotalAmount { get; private set; }

        readonly string Name;

        readonly Random random = new Random();


        internal void Access()
        {
            for (int n = 0; n < 100; n++)
            {
                decimal amount = random.Next(1000);

                if (random.Next(3) < 2)
                {
                    BankAccount.Deposit(amount, Name);
                    TotalAmount += amount;
                }
                else
                {
                    BankAccount.Widthdraw(amount, Name);
                    TotalAmount -= amount;
                }  
            }
        }

        internal Thread Start()
        {
            Thread thread = new Thread(Access)
            {
                IsBackground = false
            };

            thread.Start();

            return thread;
        }

        internal BankAccountAccess(BankAccount bankAccount, string name)
        {
            this.BankAccount = bankAccount;
            Name = name;
            TotalAmount = 0M;
        }

    }
}
