using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locking
{
    class DataStorage
    {
        private class DataStore { public int Value { get; set; } }

        private DataStore store = new DataStore();
        private DataStore extraStore = new DataStore();

        public void ConcurrencyTest()
        {
            var thread1 = new Thread(IncrementTheValue);
            var thread2 = new Thread(SubtractTheValue);
            var thread3 = new Thread(IncrementTheValue);
            var thread4 = new Thread(SubtractTheValue);



            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();


            Console.WriteLine($"Final value: {store.Value}");
            Console.WriteLine($"Final value: {extraStore.Value}");
        }

        public void DeadlockTest()
        {
            var thread3 = new Thread(SubtractTheValue);
            var thread4 = new Thread(SubtractTheValue);

            thread3.Start();
            thread4.Start();

            thread3.Join();
            thread4.Join();

            Console.WriteLine($"Final value: {extraStore.Value}");
        }

        private void IncrementTheValue()
        {
            lock (extraStore)
            {


                lock (store)
                {
                    extraStore.Value++;
                    store.Value++;
                }
            }
        }

        private void SubtractTheValue()
        {
            lock (store)
            {



                lock (extraStore)
                {
                    extraStore.Value--;
                    store.Value--;
                }
            }

        }
    }
}
