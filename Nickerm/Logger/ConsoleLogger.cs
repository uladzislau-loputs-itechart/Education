using System;

namespace Logger
{
    class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }

        public void Error(Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }

        public void Info(string message)
        {
            Console.WriteLine($"Info: {message}");
        }

        public void Warning(string message)
        {
            Console.WriteLine($"Warning: {message}");
        }
    }
}
