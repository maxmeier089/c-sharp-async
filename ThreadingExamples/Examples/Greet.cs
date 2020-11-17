using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadingExamples
{
    class Greet
    {

        public static void Greet1()
        {
            Console.WriteLine("Hi!");

            HowAreYou();

            Console.WriteLine("Bye!");
        }

        public static void Greet2()
        {
            Console.WriteLine("Hi!");

            Thread thread = new Thread(HowAreYou) { IsBackground = false };
            thread.Start();

            Console.WriteLine("Bye!");
        }

        static void HowAreYou()
        {
            Console.WriteLine("How are you?");
        }

    }
}
