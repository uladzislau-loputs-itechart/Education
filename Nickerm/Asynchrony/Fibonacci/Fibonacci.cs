using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asynchrony
{
    class Fibonacci
    {
        private static void Fib(int number)
        {
            if (number == 0) Console.WriteLine(0);

            int prev = 0;
            int next = 1;
            for (int i = 1; i < number; i++)
            {
                int sum = prev + next;
                prev = next;
                next = sum;
            }
            Console.WriteLine(next);
        }

        public static async Task FibAsync(int number)
        {
            await Task.Run(() => Fib(number));
            await Task.Run(() => Fib(number));
            await Task.Run(() => Fib(number));
        }
    }
}
