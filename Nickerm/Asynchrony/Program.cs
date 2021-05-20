using System;
using System.Threading.Tasks;

namespace Asynchrony
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await Fibonacci.FibAsync(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
