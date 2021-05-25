using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;
using System.Threading.Tasks;

namespace CsvToDatabase
{
    public class Repository<T> : IRepository<T>
    {
        public ILiteCollection<T> Collection { get; }

        private ILiteDatabase _db;

        public Repository( string strConnection)
        {
            _db ??= new LiteDatabase(strConnection);
            Collection = _db.GetCollection<T>(typeof(T).Name.ToString());
        }

        public IEnumerable<T> All()
        {
            return Collection.FindAll(); 
        }

        //public async void Create(T entity)
        //{
        //    try
        //    {
        //        await Task.Run(() => Collection.Insert(entity));
        //    }
        //    catch(Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public void Create(T entity)
        {
            Collection.Insert(entity);
        }

        public virtual bool Delete(int id)
        {
            return Collection.Delete(id);
        }

        public virtual T FindById(int id)
        {
            return Collection.FindById(id);
        }

        public virtual void Update(T entity)
        {
            Collection.Upsert(entity);
        }

        //private bool _disposed;
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //private void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            if (_db != null)
        //                _db.Dispose();
        //        }
        //        _disposed = true;
        //    }
        //}

        //~Repository()
        //{
        //    Dispose(false);
        //}
    }
}

