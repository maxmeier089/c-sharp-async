using System;
using System.Collections.Generic;
using System.Text;

namespace ConcurrencyExamples
{
    public class Chopstick
    {
        public Philosopher Holder { get; private set; }

        public void Take(Philosopher p)
        {
            Holder = p;
        }

        public void PutBack()
        {
            Holder = null;
        }

        public int Number { get; private set; }

        public Chopstick(int number)
        {
            Number = number;
        }
    

    }
}
