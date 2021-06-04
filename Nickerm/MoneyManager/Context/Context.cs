using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace MoneyManager
{
    public class Context : DbContext
    {
        static Context()
        {
            Database.SetInitializer(new DataToDBInitializer());
        }
        public Context() : base("MoneyManagerDB")
        {
           
        }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Asset> Assets { get; set; }

        public virtual DbSet<Transaction> Transactions { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
    }
}
