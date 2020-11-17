using System;
using System.Collections.Generic;
using System.Text;

namespace ConcurrencyExamples
{
    public class PhilosopherFixed : Philosopher
    {

        static readonly object LockObject = new object();


        public override void Think()
        {
            State = PhilosopherState.Think;

            WaitRandomTime();
        }

        public override void Eat()
        {
            while (true)
            {
                lock (LockObject)
                {
                    if (Left.Holder == null && Right.Holder == null)
                    {
                        Left.Take(this);
                        Right.Take(this);
                        break;
                    }
                }
            }

            State = PhilosopherState.Eat;

            WaitRandomTime();

            Left.PutBack();
            Right.PutBack();
        }


        public PhilosopherFixed(string name, Chopstick left, Chopstick right)
            :base(name, left, right)
        { 
        }

    }
}
