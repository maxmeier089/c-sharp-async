using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConcurrencyExamples
{
    public enum PhilosopherState { Think, Eat }

    public abstract class Philosopher
    {


        public string Name { get; private set; }

        public PhilosopherState State { get; protected set; }
   


        public Chopstick Left { get; private set; }

        public Chopstick Right { get; private set; }


        public abstract void Think();

        public abstract void Eat();


        void Do()
        {
            while (true)
            {
                Think();
                Eat();
            }
        }


        public override string ToString()
        {
            string stateText = "";
            
            stateText += Left.Holder == this ? " < "  : "   ";

            stateText += Name;

            stateText += " " + (State == PhilosopherState.Eat ? " (E)" : " (T)");

            stateText += Right.Holder == this ? " > " : "   ";

            stateText += "|";

            return stateText;
        }



        readonly int MAX_WAIT_TIME = 33;

        protected readonly Random random = new Random();

        protected void WaitRandomTime()
        {
            Thread.Sleep(random.Next(MAX_WAIT_TIME));
        }


        protected Philosopher(string name, Chopstick left, Chopstick right)
        {
            Name = name;
            Left = left;
            Right = right;

            
            new Thread(() => { Do(); }).Start();
        }


    }
}
