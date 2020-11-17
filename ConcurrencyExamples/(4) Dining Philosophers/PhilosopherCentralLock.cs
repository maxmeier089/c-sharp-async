using System;
using System.Collections.Generic;
using System.Text;

namespace ConcurrencyExamples
{
    class PhilosopherCentralLock : Philosopher
    {

        static readonly object LockObject = new object();


        public override void Think()
        {
            State = PhilosopherState.Think;

            WaitRandomTime();
        }

        public override void Eat()
        {
            lock (LockObject)
            {
                Left.Take(this);
                Right.Take(this);
                
                State = PhilosopherState.Eat;
                
                WaitRandomTime();
                
                Left.PutBack();
                Right.PutBack();
            }
        }


        public PhilosopherCentralLock(string name, Chopstick left, Chopstick right)
            : base(name, left, right)
        {
        }

    }
}
