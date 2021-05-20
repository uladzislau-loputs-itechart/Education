using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public class Worker
    {
        static Mutex mutexObj = new Mutex();

        private static Random _random = new Random();

        private static int _counter = 0;

        public static void DoWork(object msg)
        {
            mutexObj.WaitOne();

            Thread.Sleep(_random.Next(1, 4) * 300);
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine($"Message: {msg}; Counter: {_counter}; Inner iteration number: { i}");
            }
            _counter++;

            mutexObj.ReleaseMutex();
        }
    }
}
