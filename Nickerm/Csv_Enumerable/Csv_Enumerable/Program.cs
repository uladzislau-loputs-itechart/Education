using System;


namespace Csv_Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\git\Education\Nickerm\Csv_Enumerable\cars.csv";
            var carRecord = new CsvEnumerable<Car>(path);
            carRecord.LogAll();
        }
    }
}
