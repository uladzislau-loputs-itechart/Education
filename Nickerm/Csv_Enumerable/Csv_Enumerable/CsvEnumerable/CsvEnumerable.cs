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

        public CsvEnumerable(string path)
        {
            try
            {
                using (var fileReader = new StreamReader(path))
                using (var csv_records = new CsvReader(fileReader, CultureInfo.InvariantCulture))
                {
                    records = csv_records.GetRecords<T>().ToList();
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
