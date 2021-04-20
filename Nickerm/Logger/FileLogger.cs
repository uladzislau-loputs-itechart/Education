using System;
using System.IO;

namespace Logger
{
    class FileLogger : ILogger
    {
        private string writePath = @"D:\.NET\FirstProject\LogFile.txt";

        private void FileWriter(string message)
        {
            using (StreamWriter sw = new StreamWriter(writePath, true))
            {
                sw.WriteLineAsync(message);
            }
        }
        public void Error(string message)
        {
            FileWriter($"ERROR: {message}");
        }

        public void Error(Exception ex)
        {
            FileWriter($"ERROR: {ex.Message}");
        }

        public void Info(string message)
        {
            FileWriter($"Info: {message}");
        }

        public void Warning(string message)
        {
            FileWriter($"Warning: {message}");
        }
    }
}
