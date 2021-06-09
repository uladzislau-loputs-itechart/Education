using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager
{
    public interface IUnitOfWork : IDisposable
    {
        UserRepository User { get; }

        AssetRepository Asset { get; }

        CategoryRepository Category { get; }

        TransactionRepository Transaction { get; }

        void Save();
    }
}
