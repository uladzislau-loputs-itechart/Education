using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Csv_Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\git\Education\Nickerm\Csv_Enumerable\cars.csv";
            var carRecord = new CsvEnumerable<Car>(path);
            carRecord.TestCsvReader();
        }
    }
}
