using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static async Task Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    await Task.Run(() => Worker.DoWork(i));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
