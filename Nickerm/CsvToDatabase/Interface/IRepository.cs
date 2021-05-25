using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CsvToDatabase
{
    public interface IRepository<T>
    {
        void Create(T data);
        IEnumerable<T> All();
        T FindById(int id);
        void Update(T entity);
        bool Delete(int id);

    }
}
