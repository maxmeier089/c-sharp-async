using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class ReturnTypesAndExceptions
    {
        public static async Task StartExample()
        {
            await Task.Delay(100);

            try
            {
                ExceptionVoidAsync();

                // _ = ExceptionTaskAsync();

                // await ExceptionTaskAsync();

                // _ = ExceptionAwaitAsync();

                // await ExceptionAwaitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("StartExample exception caught!");
            }

            Console.WriteLine("StartExample finished.");

            Console.ReadLine();
        }


        public static async void ExceptionVoidAsync()
        {
            await Task.Delay(100);

            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ExceptionVoidAsync exception caught!");
                throw ex;
            }
        }

        public static async Task ExceptionTaskAsync()
        {
            await Task.Delay(100);

            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ExceptionTaskAsync exception caught!");
                throw ex;
            }
        }

        public static async Task ExceptionAwaitAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        throw new Exception();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Task exception caught!");
                        throw ex; // debugger will treat this as an unhandled exception! (though it is handled later)
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("ExceptionAwaitAsync exception caught!");
                throw ex;
            }
        }

    }
}
