using System;
using System.Threading;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main(string[] _)
        {
            while (true)
            {

                new Thread(() => { Console.Write("Hello "); }).Start();

                new Thread(() => { Console.Write("World! "); }).Start();

                Console.ReadLine();

                Console.WriteLine();

            }
        }
    }
}
