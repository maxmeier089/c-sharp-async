using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ConcurrencyExamples
{
    class CollectionFixed : CollectionExample
    {

        internal ConcurrentDictionary<Guid, int> MyDictionary { get; private set; }


        internal override void Modify()
        {
            while (true)
            {
                int choice = random.Next(3);

                if (choice == 0)
                {
                    Guid key = Guid.NewGuid();
                    int value = random.Next(100);
                    MyDictionary[key] = value;
                    Console.WriteLine(value + " added");
                }
                else if (choice == 1)
                {
                    KeyValuePair<Guid, int> keyValuePair = MyDictionary.FirstOrDefault();

                    if (!keyValuePair.Equals(default(KeyValuePair<Guid, int>)))
                    {
                        if (MyDictionary.Remove(keyValuePair.Key, out int value))
                        {
                            Console.WriteLine(value + " removed");
                        }
                    }
                }
                else if (choice == 2)
                {
                    KeyValuePair<Guid, int> keyValuePair = MyDictionary.FirstOrDefault();

                    if (!keyValuePair.Equals(default(KeyValuePair<Guid, int>)))
                    {
                        Console.WriteLine(keyValuePair.Value + " read");
                    }
                }
            }
        }


        internal CollectionFixed()
        {
            MyDictionary = new ConcurrentDictionary<Guid, int>();
        }

    }
}
