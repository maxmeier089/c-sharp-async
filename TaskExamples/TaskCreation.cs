using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExamples
{
    class TaskCreation
    {

        public void CreateSomeTasks()
        {

            Console.WriteLine("CreateSomeTasks" + ": " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-"));

            // method
            Task.Run(MyMethod);


            // static method
            Task.Run(MyStaticMethod);


            // anonymous method
            Task.Run(() =>
            {
                Console.WriteLine("Anonymous method: " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-"));
            });


            // method with parameter
            Task task = new Task(MyMethodWithParameter, "Yo");
            task.Start();


            // method with return type
            Task<int> intTask = Task.Run(MyIntMethod);
            int result = intTask.Result;
            Console.WriteLine("Result: " + result);


            // anonymous method with return type
            result = Task.Run(() => { return 99; }).Result;
            Console.WriteLine("Result: " + result);


            // task wait
            Task t0 = Task.Run(() => { Console.WriteLine("T1"); });
            Task t1 = Task.Delay(1000);
            Task t2 = Task.Delay(500);

            Task[] tasks = new Task[] { t0, t1, t2 };

            // wait for any task to complete
            int index = Task.WaitAny(tasks);
            Console.WriteLine("First task to complete: " + index);

            // wait for all tasks to complete
            Task.WaitAll(tasks);
            Console.WriteLine("Now all tasks have completed!");


            // task cancellation with a boolean variable
            Console.WriteLine("Task cancellation (manual)");

            bool tasksRunning = true;

            void doSomething()
            {
                Random r = new Random();

                while (tasksRunning)
                {
                    Console.WriteLine("work...");

                    // wait 1 second
                    Task.Delay(1000).Wait();

                    if (r.Next(10) == 0)
                    {
                        Console.WriteLine("Cancel!");
                        tasksRunning = false;
                    }
                }
            }

            Task.WaitAll(new Task[] { Task.Run(doSomething), Task.Run(doSomething), Task.Run(doSomething) });


            // task cancellation with a CancellationToken
            Console.WriteLine("Task cancellation (CancellationToken)");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            cancellationToken.Register(() => { Console.WriteLine("Cancel!"); });

            void doSomethingElse()
            {
                Random r = new Random();

                while (true)
                {
                    Console.WriteLine("work...");

                    // wait 1 second
                    Task.Delay(1000).Wait();

                    if (r.Next(10) == 0)
                    {
                        cancellationTokenSource.Cancel();
                    }

                    try
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
            }

            Task.WaitAll(new Task[] { Task.Run(doSomethingElse), Task.Run(doSomethingElse), Task.Run(doSomethingElse) });


            // background worker
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }


        void MyMethod()
        {
            Console.WriteLine("MyMethod: " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-"));
        }

        int MyIntMethod()
        {
            Console.WriteLine("MyIntMethod: " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-"));
            return 7;
        }

        static void MyStaticMethod()
        {
            Console.WriteLine("MyStaticMethod: " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-"));
        }

        void MyMethodWithParameter(object o)
        {
            Console.WriteLine("MyMethodWithParameter: " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-") + ", parameter: " + (o != null ? o.ToString() : "null"));
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("BackgroundWorker: " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-"));
        }

    }
}
