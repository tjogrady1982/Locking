using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locking
{
    class Program
    {
        static void Main(string[] args)
        {
            var incremental = new DataStorage();
            var deadLock = new DataStorage();

            incremental.ConcurrencyTest();
            deadLock.DeadlockTest();


            Console.ReadLine();
        }
    }
}
