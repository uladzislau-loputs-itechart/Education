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

        public IQueryable<PostInfo> GetPostInfo(int id)
        {
            var result = from u in db.Users
                         join p in db.Posts on u.Id equals p.UserId
                         //join t in db.Tags on p.Id equals t.Id
                         //join c in db.Categories on p.Id equals c.Id
                         where u.Id == id
                         orderby p.UpdatedAt
                         select new PostInfo { Name = u.Name, Title = p.Title, Image = p.Image, PublishedAt = p.PublishedAt, Published = p.Published, Content = p.Content, };
                         //Tags = from t in db.Tags
                         //       where t.Posts.Any(po => po.Post_Id == p.Id)
                         //       select t };// comments, tags, categories
            return result;
        }

        public IQueryable<Post> GetMostPopularPosts()
        {
           return  db.Posts.OrderBy(Posts => Posts.Viewed);
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
