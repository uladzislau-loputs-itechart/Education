using System;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
             var fileLogger = new Logger(LogDestination.FileLogger);
             fileLogger.Error("some text1");
             var consoleLogger = new Logger();
             consoleLogger.Info("some info");
            consoleLogger.Error("some info");
            consoleLogger.Warning("some info");
        }
    }
}
