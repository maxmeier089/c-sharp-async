using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class AsyncAwaitBasic
    {

        async Task HelloWorldAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Hello World!");
            });
        }


        async Task<int> DoAsync()
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(2000);

                int n = (new Random()).Next(9999);
                Console.WriteLine("DoAsync(): " + n);
                return n;
            });
        }


        public async Task CreateAndAwaitSomeTasks()
        {

            await HelloWorldAsync();


            _ = DoAsync();

            Console.WriteLine("Hello!");


            int result = await DoAsync();

            Console.WriteLine("Result: " + result);


            result = await Task.Run(() =>
            {
                Console.WriteLine("Anonymous: " + 3);
                return 3;
            });

            Console.WriteLine("Result: " + result);


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int result1 = await DoAsync();
            int result2 = await DoAsync();

            stopwatch.Stop();

            Console.WriteLine("Results: " + result1 + " & " + result2 + ". Time: " + stopwatch.ElapsedMilliseconds);


            stopwatch.Restart();

            Task<int> task1 = DoAsync();
            Task<int> task2 = DoAsync();

            result1 = await task1;
            result2 = await task2;

            stopwatch.Stop();

            Console.WriteLine("Results: " + result1 + " & " + result2 + ". Time: " + stopwatch.ElapsedMilliseconds);


            Console.WriteLine("Bye!");

        }
    }
}
