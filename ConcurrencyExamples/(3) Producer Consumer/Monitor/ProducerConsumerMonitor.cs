using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConcurrencyExamples
{
    class ProducerConsumerMonitor : ProducerConsumer
    {

        protected override void Produce()
        {
            int currentNumber = 0;

            while (true)
            {
                bool locked = false;

                try
                {
                    Monitor.Enter(this, ref locked);

                    if (SharedData == null)
                    {
                        SharedData = currentNumber;
                        currentNumber = (currentNumber + 1) % 1000;
                    }
                }
                finally
                {
                    if (locked) Monitor.Exit(this);
                }

                if (Sleep) Thread.Sleep(500);
            }
        }


        protected override void Consume()
        {
            while (true)
            {
                bool locked = false;

                try
                {
                    Monitor.Enter(this, ref locked);

                    if (SharedData.HasValue)
                    {
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + SharedData.Value);
                        SharedData = null;
                    }
                }
                finally
                {
                    if (locked) Monitor.Exit(this);
                }

                if (Sleep) Thread.Sleep(10);
            }
        }

    }
}
