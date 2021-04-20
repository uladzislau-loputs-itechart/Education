using System;

namespace Logger

{
    public enum DestinationClass
    {
        ConsoleLogger,
        FileLogger
    }
    class Logger: ILogger
    {
        private ILogger logger;

        public Logger()
        {
            logger = new ConsoleLogger();
        }

        public Logger(DestinationClass destinationClass)
        {
            try 
            {
                if (destinationClass == DestinationClass.ConsoleLogger)
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
            logger.Error(message);
        }

        public void Error(Exception ex)
        {
            logger.Error(ex);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warning(message);
        }
    }
}
