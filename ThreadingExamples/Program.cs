using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingExamples
{
    class Program
    {

        static void Main(string[] args)
        {
            // (new ThreadCreation()).CreateSomeThreads();

            //Greet.Greet1();
            //Console.WriteLine();
            //Greet.Greet2();

            // PrintNumbers.PrintSomeNumbersInParallel();

            ParallelWork.WorkSync();
            ParallelWork.WorkAsync();
        }


    }
}
