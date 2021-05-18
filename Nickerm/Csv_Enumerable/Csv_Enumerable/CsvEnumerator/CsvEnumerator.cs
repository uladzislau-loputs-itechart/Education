using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CsvHelper;

namespace Csv_Enumerable
{
    public class CsvEnumerator<T> : IEnumerator<T>
    {
        private List<T> records;

        public CsvEnumerator(List<T> records)
        {
            this.records = records;
        }
        int position = -1;

        public T Current 
        {
            get
            {
                try
                {
                    return records[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        object IEnumerator.Current => this.Current;

        private bool disposedValue = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                  
                }
            }

            this.disposedValue = true;
        }

        public bool MoveNext()
        {
            position++;
            return (position < records.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        ~CsvEnumerator()
        {
            Dispose(false);
        }
    }
}
