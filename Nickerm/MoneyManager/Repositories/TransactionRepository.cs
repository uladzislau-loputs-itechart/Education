using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;

namespace MoneyManager
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private Context db;

        public TransactionRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return db.Transactions;
        }

        public Transaction Get(int id)
        {
            return db.Transactions.Find(id);
        }

        public void Create(Transaction transaction)
        {
            db.Transactions.Add(transaction);
        }

        public void Update(Transaction transaction)
        {
            db.Entry(transaction).State = EntityState.Modified;
        }

        public IEnumerable<Transaction> Find(Func<Transaction, Boolean> predicate)
        {
            return db.Transactions.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction != null)
                db.Transactions.Remove(transaction);
        }

        public void DeleteTransInCurrentMonth(int id)
        {
            var result = from a in db.Assets 
                         join t in db.Transactions on a.Id equals t.AssetId
                         where t.Date.Month == DateTime.Today.Month && a.UserId == id
                         select t;
            db.Transactions.RemoveRange(result);
        }
    }
}
