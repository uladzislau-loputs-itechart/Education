using System;
using System.Collections.Generic;
using System.Text;
using SharaMe.Models;
using SharaMe.Context;
using SharaMe.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace SharaMe.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        public MyContext db;

        public CommentRepository(MyContext context)
        {
            db = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments;
        }

        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }

        public void Create(Comment comment)
        {
            db.Comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            db.Entry(comment).State = EntityState.Modified;
        }

        public IEnumerable<Comment> Find(Func<Comment, Boolean> predicate)
        {
            return db.Comments.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment != null)
                db.Comments.Remove(comment);
        }
    }
}
