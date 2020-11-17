using System;
using System.Collections.Generic;
using System.Text;

namespace ConcurrencyExamples
{
    public class PhilosopherDeadlock : Philosopher
    {

        public override void Think()
        {
            State = PhilosopherState.Think;

            WaitRandomTime();
        }

        public override void Eat()
        {
            lock (Left)
            {
                Left.Take(this);

                lock (Right)
                {
                    Right.Take(this);

                    State = PhilosopherState.Eat;

                    WaitRandomTime();

                    Left.PutBack();  
                }

                Right.PutBack();
            }
        }


        public PhilosopherDeadlock(string name, Chopstick left, Chopstick right)
            : base(name, left, right)
        {
        }

    }
}
