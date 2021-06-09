using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;

namespace MoneyManager
{
    public class UserRepository : IRepository<User>
    {
        public Context db;

        public UserRepository(Context context)
        {
            db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public User GetUserByEmail(string email)
        {
            var result = from u in db.Users                        
                         where u.Email == email
                         select u.Id;
           return Get(result.First());
        }

        public IQueryable<AllUsers> GetAllUsers()
        {
            var result = from u in db.Users
                         orderby u.Name
                         select new AllUsers { Id= u.Id, Name = u.Name, Email = u.Email };
            return result;
        }

        public List<dynamic> GetUserBalance(int id)
        {
            var result = from u in db.Users
                         join a in db.Assets on u.Id equals a.UserId
                         join t in db.Transactions on a.Id equals t.AssetId
                         where u.Id == id
                         group t by t.AssetId into g
                         select new { g.Key, Balance = g.Sum(s => s.Amount) };
            //var balance = result.Sum();
            return result.ToList<dynamic>();
        }

        public List<dynamic> GetTransactionList(int id)
        {
            //var rez = from t in db.Transactions
            //          join c in db.Categories on t.CategoryId equals c.Id
            //          where c.ParentId != null
            //          select c.Name;

            var result = from u in db.Users
                         join a in db.Assets on u.Id equals a.UserId
                         join t in db.Transactions on a.Id equals t.AssetId
                         join c in db.Categories on t.CategoryId equals c.Id
                         where u.Id == id //&& c.ParentId != null
                         orderby t.Date descending
                         orderby a.Name
                         orderby c.Name
                         select new {AssetName = a.Name, categoryName = c.Name, categoryParentName = c.ParentId, t.Amount, t.Date, t.Comment };
            //var balance = result.Sum();
            return result.ToList<dynamic>();
        }

        public List<dynamic> GetAmount(int id, int type)
        {
            var result = from u in db.Users
                         join a in db.Assets on u.Id equals a.UserId
                         join t in db.Transactions on a.Id equals t.AssetId
                         join c in db.Categories on t.CategoryId equals c.Id
                         where u.Id == id && c.ParentId == null && type == c.Type && t.Date.Month == DateTime.Now.Month
                         orderby t.Amount descending
                         orderby c.Name
                         //group t by t.AssetId into g
                         select new {  categoryName = c.Name, t.Amount };
            //var balance = result.Sum();
            return result.ToList<dynamic>();
        }
    }
}
