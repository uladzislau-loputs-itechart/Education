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
            var property = typeof(Car).GetProperties();
            string result = "| ";
            DateTime date;
            foreach (var item in carRecord)
            {
                foreach (var prop in property)
                {
                    if (prop.PropertyType == typeof(DateTime))
                    {
                        date = (DateTime)prop.GetValue(item);
                        result += $" {date.ToString("dd.MM.yyyy")} |";
                    }
                    else
                    {
                        result += $" {prop.GetValue(item)} |";
                    }
                }
                Console.WriteLine($"{result}");
                result = "| ";
            }
        }
    }
}
