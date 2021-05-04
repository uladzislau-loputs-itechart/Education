using System;

namespace LoggingTools
{
    class ConsoleLogger : ILoggerDestination
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}