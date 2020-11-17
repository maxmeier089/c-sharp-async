using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class LockAndWait
    {

        static readonly object lockObject = new object();

        public async static Task LockInsideAwait()
        {
            int n = await Task.Run(() =>
            {
                lock (lockObject)
                {
                    return 2;
                }
            });
        }

        public async static Task WaitInsideLock()
        {
            //lock (lockObject)
            //{
            int n = await Task.Run(() =>
            {
                return 2;
            });
            //}
        }

    }
}
