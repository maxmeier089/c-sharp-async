using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConcurrencyExamples
{
    abstract class CollectionExample
    {

        protected readonly Random random = new Random();


        internal abstract void Modify();


        internal void Start()
        {
            Thread modifier1 = new Thread(Modify);
            Thread modifier2 = new Thread(Modify);

            modifier1.IsBackground = false;
            modifier2.IsBackground = false;

            modifier1.Start();
            modifier2.Start();
        }


    }
}
