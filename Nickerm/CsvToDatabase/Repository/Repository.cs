using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;
using System.Threading.Tasks;

namespace CsvToDatabase
{
    public class Repository<T> : IRepository<T>, IDisposable
    {
        public ILiteCollection<T> Collection { get; }

        private ILiteDatabase _db;

        public Repository( string strConnection)
        {
            _db ??= new LiteDatabase(strConnection);
            Collection = _db.GetCollection<T>(typeof(T).Name.ToString());
        }

        public virtual IEnumerable<T> All()
        {
            return Collection.FindAll(); 
        }

        public async virtual Task<IEnumerable<T>> AllAsync()
        {
            return await Task.Run(() => All());
        }

        public virtual void Create(T entity)
        {
            Collection.Insert(entity);
        }

        public async virtual void CreateAsync(T entity)
        {
            await Task.Run(()=> Create(entity));
        }

        public virtual bool Delete(int id)
        {
            return Collection.Delete(id);
        }

        public async virtual void DeleteAsync(int id)
        {
            await Task.Run(() => Delete(id));
        }

        public virtual T FindById(int id)
        {
            return Collection.FindById(id);
        }

        public async virtual Task<T> FindByIdAsync(int id)
        {
           return await Task.Run(() => FindById(id));
        }

        public virtual void Update(T entity)
        {
            Collection.Upsert(entity);
        }

        public async virtual void UpdateAsync(T entity)
        {
            await Task.Run(() => Update(entity));
        }

        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_db != null)
                        _db.Dispose();
                }
                _disposed = true;
            }
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}

