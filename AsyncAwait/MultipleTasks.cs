using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class MultipleTasks
    {

        public async Task StartMultipleTasks()
        {
            // wait for *any* to complete
            Task<int>[] tasks = new Task<int>[] { NextWholeTensMillisecond(), NextPowerOfTwoMillisecond(), NextPrimeMillisecond() };

            int firstResult = await await Task.WhenAny(tasks);

            Console.WriteLine("First: " + firstResult + "\n");



            // wait for *all* to complete
            tasks = new Task<int>[] { NextWholeTensMillisecond(), NextPowerOfTwoMillisecond(), NextPrimeMillisecond() };

            int[] allResults = await Task.WhenAll(tasks);

            Console.WriteLine("Whole tens: " + allResults[0]);
            Console.WriteLine("Power of two: " + allResults[1]);
            Console.WriteLine("Prime: " + allResults[2]);

        }


        async Task<int> NextWholeTensMillisecond()
        {
            return await Task.Run(() =>
            {
                while (true)
                {
                    int currentSecond = DateTime.Now.Millisecond;

                    if (currentSecond % 10 == 0) return currentSecond;
                }
            });
        }

        async Task<int> NextPowerOfTwoMillisecond()
        {
            return await Task.Run(() =>
            {
                while (true)
                {
                    int currentSecond = DateTime.Now.Millisecond;

                    int n = 0;

                    while (true)
                    {
                        int power = (int)Math.Pow(2, n);

                        if (power > 999) break;

                        if (currentSecond == power) return currentSecond;

                        n++;
                    }
                }
            });
        }

        async Task<int> NextPrimeMillisecond()
        {
            return await Task.Run(() =>
            {
                while (true)
                {
                    int currentSecond = DateTime.Now.Millisecond;

                    bool isPrime = currentSecond > 1;

                    for (int n = 2; n < currentSecond; n++)
                    {
                        if (currentSecond % n == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime) return currentSecond;
                }
            });
        }

    }
}
