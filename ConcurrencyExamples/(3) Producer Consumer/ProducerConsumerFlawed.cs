using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyExamples
{
    class ProducerConsumerFlawed : ProducerConsumer
    {

        protected override void Produce()
        {
            int currentNumber = 0;

            while (true)
            {
                if (SharedData == null)
                {
                    SharedData = currentNumber;
                    currentNumber = (currentNumber + 1) % 1000; 
                }

                if (Sleep) Thread.Sleep(500);
            }
        }


        protected override void Consume()
        {
            while (true)
            {
                if (SharedData.HasValue)
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + SharedData.Value);
                    SharedData = null;
                }

                if (Sleep) Thread.Sleep(10);
            }
        }

    }
}
