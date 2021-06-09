using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using SharaMe.Models;

namespace SharaMe.Context
{
    public class MyContext : DbContext
    {
        static MyContext()
        {
            Database.SetInitializer(new DataToDBInitializer());
        }
        public MyContext() : base("ShareMeDB")
        {

        }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }
    }
}
