using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadingExamples
{
    class ThreadCreation
    {

        public void CreateSomeThreads()
        {

            Console.WriteLine("CreateSomeThreads: " + Thread.CurrentThread.ManagedThreadId);


            // method
            Thread thread1 = new Thread(MyMethod) { IsBackground = false };
            thread1.Start();


            // static method
            Thread thread2 = new Thread(MyStaticMethod) { IsBackground = false };
            thread2.Start();


            // anonymous method
            Thread thread3 = new Thread(() =>
            {
                Console.WriteLine("Anonymous method: " + Thread.CurrentThread.ManagedThreadId);
            })
            { IsBackground = false };
            thread3.Start();


            // method with parameter
            Thread thread4 = new Thread(new ParameterizedThreadStart(MyMethodWithParameter)) { IsBackground = false };
            thread4.Start("Yo");

        }


        void MyMethod()
        {
            Console.WriteLine("MyMethod: " + Thread.CurrentThread.ManagedThreadId);
        }

        static void MyStaticMethod()
        {
            Console.WriteLine("MyStaticMethod: " + Thread.CurrentThread.ManagedThreadId);
        }

        void MyMethodWithParameter(object o)
        {
            Console.WriteLine("MyMethodWithParameter: " + Thread.CurrentThread.ManagedThreadId + ", parameter: " + (o != null ? o.ToString() : "null"));
        }


    }
}
