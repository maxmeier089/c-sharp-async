using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConcurrencyExamples
{
    abstract class ProducerConsumer
    {

        /// <summary>
        /// Property accessed by multiple threads
        /// </summary>
        protected int? SharedData { get; set; }


        /// <summary>
        /// Produce data
        /// </summary>
        protected abstract void Produce();


        /// <summary>
        /// Consume data
        /// </summary>
        protected abstract void Consume();


        /// <summary>
        /// Indicates if threads should go to sleep after access
        /// </summary>
        internal bool Sleep = false;



        /// <summary>
        /// Start producer and consumer threads
        /// </summary>
        internal void Start()
        {
            // create threads
            Thread producer1 = new Thread(Produce);
            Thread consumer1 = new Thread(Consume);
            Thread consumer2 = new Thread(Consume);

            // threads shoulds keep the application alive
            producer1.IsBackground = false;
            consumer1.IsBackground = false;
            consumer2.IsBackground = false;

            // go
            producer1.Start();
            consumer1.Start();
            consumer2.Start();
        }

    }

}
