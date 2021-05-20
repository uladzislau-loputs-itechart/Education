using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {            
            try
            {
                Parallel.For(0, 10, i => { Worker.DoWork(i); });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }         
        }

    }
}
