using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<Asset> Assets { get; }

        IRepository<Category> Categories { get; }

        IRepository<Transaction> Transactions { get; }

        void Save();
    }
}
