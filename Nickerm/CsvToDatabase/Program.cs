using System;
using CsvEnumerableLib;
using LoggingTools;
using System.Threading.Tasks;

namespace CsvToDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string _strConnection = @"D:\git\Education\Nickerm\MyData.db";
            string pathToCsv = @"D:\git\Education\Nickerm\Csv_Enumerable\cars.csv";

            var carBD = new Repository<Car>(_strConnection);
            var logProxy = new LoggingProxy<IRepository<Car>>();
            var logInstance = logProxy.CreateInstance(carBD);
            //logInstance.All();
            var carRecord = new CsvEnumerable<Car>(pathToCsv);
            foreach (var record in carRecord)
            {
               carBD.Create(record);
            }
        }
    }
}
