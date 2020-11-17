using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadingExamples
{
    class PrintNumbers
    {

        public static void PrintSomeNumbersInParallel()
        {
            for (int t = 0; t < 3; t++)
            {
                Thread thread = new Thread(PrintSomeNumbers);
                thread.Start();
            }
        }

        static void PrintSomeNumbers()
        {
            for (int n = 0; n < 10; n++)
            {
                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId + ": " + n);
            }
        }

    }
}
