using System;
using System.Collections.Generic;
using System.Text;
using SharaMe.Models;
using SharaMe.Context;
using SharaMe.Interfaces;
using System.Data.Entity;
using System.Linq;
using ShareMe.DTO_Models;

namespace SharaMe.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        public MyContext db;

        public PostRepository(MyContext context)
        {
            db = context;
        }

        public IEnumerable<Post> GetAll()
        {
            return db.Posts;
        }

        public Post Get(int id)
        {
            return db.Posts.Find(id);
        }

        public void Create(Post post)
        {
            db.Posts.Add(post);
        }

        public void Update(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
        }

        public IEnumerable<Post> Find(Func<Post, Boolean> predicate)
        {
            return db.Posts.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Post post = db.Posts.Find(id);
            if (post != null)
                db.Posts.Remove(post);
        }

        public List<Post> GetPostInfo(int id)
        {
            var posts = db.Posts
                    .Where(u => u.UserId == id).Include(u => u.User).Include(t => t.Tags).Include(c => c.Categories).Include(c => c.Comments)
                   .ToList();
            return posts;
            //foreach (var p in posts)
            //{
            //    Console.WriteLine($"{p.User?.Name} {p.Title} {p.Image} {p.PublishedAt} {p.Content} {p.Tags} {p.Categories} {p.Comments}");
            //    foreach (var c in p.Comments)
            //        Console.WriteLine($"{c.Title} {c.Content}");
            //}
        }

        public IQueryable<Post> GetMostPopularPosts()
        {
           return  db.Posts.OrderByDescending(Posts => Posts.Viewed);
        }

        public Tag GetPostsByTag(int tagId)
        {
            var posts = db.Tags
                    .Where(t => t.Id == tagId).Include(u => u.Posts)
                  .FirstOrDefault();
            return posts;
        }

        //public IQueryable<Post> GetPostsByTag(int tagId)
        //{
        //    var result = from p in db.Posts
        //                  where p.Tags.Any(t => t.Tag_Id == tagId)
        //                  select p ;
        //    return result;
        //}
    }
}
