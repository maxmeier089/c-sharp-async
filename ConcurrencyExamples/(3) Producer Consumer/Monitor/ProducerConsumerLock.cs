using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConcurrencyExamples
{
    class ProducerConsumerLock : ProducerConsumer
    {

        protected override void Produce()
        {
            int currentNumber = 0;

            while (true)
            {
                lock (this)
                {
                    if (SharedData == null)
                    {
                        SharedData = currentNumber;
                        currentNumber = (currentNumber + 1) % 1000;
                    }
                }

                if (Sleep) Thread.Sleep(500);
            }
        }


        protected override void Consume()
        {
            while (true)
            {
                lock (this)
                {
                    if (SharedData.HasValue)
                    {
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + SharedData.Value);
                        SharedData = null;
                    }
                }

                if (Sleep) Thread.Sleep(10);
            }
        }
    }
}
