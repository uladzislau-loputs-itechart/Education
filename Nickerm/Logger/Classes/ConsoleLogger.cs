using System;

namespace Logger
{
    class ConsoleLogger : ILoggerDestination
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}