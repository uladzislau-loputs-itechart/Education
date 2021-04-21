using System;
using System.IO;

namespace Logger
{
    class FileLogger : ILoggerDestination
    {
        private string writePath = @"D:\.NET\FirstProject\LogFile.txt";

        public void Log(string message)
        {
            using (StreamWriter sw = new StreamWriter(writePath, true))
            {
                sw.WriteLineAsync(message);
            }
        }
    }
}