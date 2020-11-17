using System;
using System.Collections.Generic;
using System.Text;

namespace ConcurrencyExamples
{
    public class PhilosopherResourceHierarchy : Philosopher
    {

        public override void Think()
        {
            State = PhilosopherState.Think;

            WaitRandomTime();
        }

        public override void Eat()
        {
            Chopstick lower, higher;
            
            if (Left.Number < Right.Number)
            {
                lower = Left;
                higher = Right;
            }
            else
            {
                lower = Right;
                higher = Left;
            }

            lock (lower)
            {
                lower.Take(this);

                lock (higher)
                {
                    higher.Take(this);

                    State = PhilosopherState.Eat;

                    WaitRandomTime();

                    higher.PutBack();
                }

                lower.PutBack();
            }
        }


        public PhilosopherResourceHierarchy(string name, Chopstick left, Chopstick right)
            : base(name, left, right)
        {
        }

    }
}
