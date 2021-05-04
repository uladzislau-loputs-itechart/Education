using System;

namespace LoggingTools

{
    public enum LogDestination
    {
        FileLogger,
        ConsoleLogger
    }
    public class Logger : ILogger
    {
        private ILoggerDestination logger;

        public Logger()
        {
            logger = new ConsoleLogger();
        }

        public Logger(LogDestination logDestination)
        {
            try
            {
                if (logDestination == LogDestination.ConsoleLogger)
                {
                    logger = new ConsoleLogger();
                }
                else
                {
                    logger = new FileLogger();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Error(string message)
        {
            logger.Log($"ERROR: {message}");
        }

        public void Error(Exception ex)
        {
            logger.Log($"ERROR: {ex.Message}");
        }

        public void Info(string message)
        {
            logger.Log($"Info: {message}");
        }

        public void Warning(string message)
        {
            logger.Log($"Warning: {message}");
        }
    }
}
