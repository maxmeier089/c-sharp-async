using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {

        async static Task Main(string[] args)
        {

            await new AsyncAwaitBasic().CreateAndAwaitSomeTasks();

            // await ReturnTypesAndExceptions.StartExample();

            // await new MultipleTasks().StartMultipleTasks();

        }

    }
}
