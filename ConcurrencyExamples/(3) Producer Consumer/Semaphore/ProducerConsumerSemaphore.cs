using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConcurrencyExamples
{
    class ProducerConsumerSemaphore : ProducerConsumer
    {

        readonly Semaphore Semaphore = new Semaphore(1, 1);

        protected override void Produce()
        {
            int currentNumber = 0;

            while (true)
            {
                Semaphore.WaitOne();

                if (SharedData == null)
                {
                    SharedData = currentNumber;
                    currentNumber = (currentNumber + 1) % 1000;   
                }

                Semaphore.Release();

                if (Sleep) Thread.Sleep(500);
            }
        }


        protected override void Consume()
        {
            while (true)
            {
                Semaphore.WaitOne();

                if (SharedData.HasValue)
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + SharedData.Value);
                    SharedData = null; 
                }

                Semaphore.Release();

                if (Sleep) Thread.Sleep(10);
            }
        }

    }
}
