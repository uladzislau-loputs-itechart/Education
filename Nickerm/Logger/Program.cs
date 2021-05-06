using System;
using LoggingTools;
using System.Dynamic;

namespace CustomLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var mouse = new Mouse();
            var logProxy = new LoggingProxy<IMouse>();
            var logM = logProxy.CreateInstance(mouse);
            logM.Sound();
            logM.Move();
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
            Console.WriteLine("Mouse make sound");
        }

        public void Move()
        {
            Console.WriteLine("Mouse is move");
        }
    }
}
