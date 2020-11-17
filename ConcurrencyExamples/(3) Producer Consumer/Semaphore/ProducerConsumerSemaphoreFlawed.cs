using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConcurrencyExamples
{
    class ProducerConsumerSemaphoreFlawed : ProducerConsumer
    {

        int Semaphore = 0;


        protected override void Produce()
        {
            int currentNumber = 0;

            while (true)
            {
                while (Semaphore > 0)
                {
                    Thread.Sleep(10);
                }
                
                Semaphore++;

                if (Semaphore > 1)
                {
                    Console.WriteLine("OH NO!!!");
                }

                if (SharedData == null)
                {
                    SharedData = currentNumber;
                    currentNumber = (currentNumber + 1) % 1000;       
                }

                Semaphore--;

                if (Sleep) Thread.Sleep(500);
            }
        }


        protected override void Consume()
        {
            while (true)
            {
                while (Semaphore > 0)
                {
                    Thread.Sleep(10);
                }

                Semaphore++;

                if (Semaphore > 1)
                {
                    Console.WriteLine("OH NO!!!");
                }

                if (SharedData.HasValue)
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + SharedData.Value);
                    SharedData = null;
                }

                Semaphore--;

                if (Sleep) Thread.Sleep(10);
            }
        }

    }
}
