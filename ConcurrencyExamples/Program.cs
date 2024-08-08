using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConcurrencyExamples
{
    class Program
    {

        static void Main(string[] _)
        {
            ModifiedCollections();

            // BankAccount();

            // ProducerConsumer();

            //DiningPhilosophers();
        }

        private static void ModifiedCollections()
        {
            CollectionExample collectionExample = new CollectionFlawed();
            collectionExample.Start();
        }
   
        private static void BankAccount()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            BankAccount bankAccount = new BankAccountFlawed();

            BankAccountAccess a = new BankAccountAccess(bankAccount, "A");
            BankAccountAccess b = new BankAccountAccess(bankAccount, "B");

            Thread t1 = a.Start();
            Thread t2 = b.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("\n\nFinished!\n\nResults:\n");

            Console.WriteLine("A: " + a.TotalAmount.ToString("C"));
            Console.WriteLine("B: " + b.TotalAmount.ToString("C"));

            decimal expectedAmount = a.TotalAmount + b.TotalAmount;

            Console.WriteLine("A + B: " + expectedAmount.ToString("C"));

            Console.WriteLine("Actual Balance: " + bankAccount.Balance.ToString("C"));

            Console.WriteLine("Difference: " + (bankAccount.Balance - expectedAmount).ToString("C"));

            Console.WriteLine("\n\n\n");
        }


        private static void ProducerConsumer()
        {
            ProducerConsumer pc = new ProducerConsumerFlawed() { Sleep = true };
            pc.Start();
        }


        private static void DiningPhilosophers()
        {
            Chopstick c0 = new Chopstick(0);
            Chopstick c1 = new Chopstick(1);
            Chopstick c2 = new Chopstick(2);
            Chopstick c3 = new Chopstick(3);
            Chopstick c4 = new Chopstick(4);

            List<Philosopher> philosophers = new List<Philosopher>
            {
                new PhilosopherDeadlock("Platon", c4, c0),
                new PhilosopherDeadlock("Kant", c0, c1),
                new PhilosopherDeadlock("Sokrates", c1, c2),
                new PhilosopherDeadlock("Wittgenstein", c2, c3),
                new PhilosopherDeadlock("Sartre", c3, c4)
            };

            while (true)
            {
                string stateString = "|";

                foreach (Philosopher p in philosophers)
                {
                    stateString += p.ToString();
                }

                //Console.Clear();

                Console.WriteLine(stateString);

                Thread.Sleep(100);
            }
        }


    }
}
