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
    public class TagRepository : IRepository<Tag>
    {
        public MyContext db;

        public TagRepository(MyContext context)
        {
            db = context;
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags;
        }

        public Tag Get(int id)
        {
            return db.Tags.Find(id);
        }

        public void Create(Tag tag)
        {
            db.Tags.Add(tag);
        }

        public void Update(Tag tag)
        {
            db.Entry(tag).State = EntityState.Modified;
        }

        public IEnumerable<Tag> Find(Func<Tag, Boolean> predicate)
        {
            return db.Tags.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag != null)
                db.Tags.Remove(tag);
        }

        //public List<Post> GetPostsByTag(int tagId)
        //{
        //    var posts = db.Tags
        //          .Where(t => t.Id == tagId).Include(p => p.Posts).Select(p => p.Posts)
        //          //.Include(u => u.Tags.Where(t => t.Id == tagId))
        //          .ToList();
        //    return posts;
        //}
    }
}
