using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Csv_Enumerable
{
    public class CsvEnumerable<T> : IEnumerable<T>
    {
        private List<T> records;
        private string path;

        public CsvEnumerable(string path)
        {
            this.path = path;
        }

        public void TestCsvReader()
        {
            try
            {
                using (var fileReader = new StreamReader(path))
                using (var csv_records = new CsvReader(fileReader, CultureInfo.InvariantCulture))
                {
                    records = csv_records.GetRecords<T>().ToList();

                    var property = typeof(T).GetProperties();
                    string result = "| ";
                    DateTime date;
                    foreach (var item in records)
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CsvEnumerator<T>(records);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
