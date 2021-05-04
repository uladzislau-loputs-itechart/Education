using System;
using LoggingTools;
using System.Dynamic;

namespace CustomLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            //var fileLogger = new Logger(LogDestination.FileLogger);
            //fileLogger.Error("some text1");
            //var consoleLogger = new Logger();
            //consoleLogger.Info("some info");
            //consoleLogger.Error("some info");
            //consoleLogger.Warning("some info");

            var mouse = new Mouse();
            var logProxy = new LoggingProxy<IMouse>();
            var logM = logProxy.CreateInstance(mouse);
            logM.Sound();
            logM.Sound1();
            //logM.MouseCount(23);
            //logM.MousePet("Pete","White-Black",2);

        }
    }


    class Mouse: IMouse
    {
        public int MouseCount(decimal legs)
        {
            return (int)Math.Ceiling( legs / 4);
        }

        public object MousePet(string name, string color, int colorCount)
        {
            dynamic pet = new ExpandoObject();
            pet.Name = name;
            pet.Color = color;
            pet.ColorCount = colorCount;
            return pet;
        }

        public void Sound()
        {
            Console.WriteLine("Pe pe pe");
        }

        public void Sound1()
        {
            Console.WriteLine("asasasasas");
        }
    }
}
