using System;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var fileLogger = new Logger(DestinationClass.FileLogger);
            fileLogger.Error("some text");
            var consoleLogger = new Logger();
            consoleLogger.Info("some info");
        }
    }
}
