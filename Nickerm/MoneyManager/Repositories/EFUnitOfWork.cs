using System;

namespace MoneyManager
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private Context db;
        private UserRepository userRepository;
        private AssetRepository assetRepository;
        private CategoryRepository categoryRepository;
        private TransactionRepository transactionRepository;

        public EFUnitOfWork()
        {
            db = new Context();
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Asset> Assets
        {
            get
            {
                if (assetRepository == null)
                    assetRepository = new AssetRepository(db);
                return assetRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public IRepository<Transaction> Transactions
        {
            get
            {
                if (transactionRepository == null)
                    transactionRepository = new TransactionRepository(db);
                return transactionRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
