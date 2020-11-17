using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadingExamples
{
    class ParallelWork
    {


        static void DoWork()
        {
            Console.WriteLine("DoWork: " + Thread.CurrentThread.ManagedThreadId);

            // pretend to work...
            Thread.Sleep(1000);

            Console.WriteLine("Done!");
        }


        public static void WorkSync()
        {
            Console.WriteLine("WorkSync: " + Thread.CurrentThread.ManagedThreadId);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            DoWork();
            DoWork();
            DoWork();

            stopwatch.Stop();

            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);

            Console.ReadLine();
        }

        public static void WorkAsync()
        {
            Console.WriteLine("WorkAsync: " + Thread.CurrentThread.ManagedThreadId);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Thread t1 = new Thread(DoWork);
            Thread t2 = new Thread(DoWork);
            Thread t3 = new Thread(DoWork);

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            stopwatch.Stop();

            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);

            Console.ReadLine();
        }

    }
}
