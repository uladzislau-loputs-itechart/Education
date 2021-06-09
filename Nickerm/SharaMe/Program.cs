using System;
using SharaMe.Context;
using SharaMe.Repositories;
using SharaMe.Models;
using System.Collections.Generic;
using System.Linq;

namespace SharaMe
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        Console.WriteLine("Объекты успешно сохранены");

                        var entity = new EFUnitOfWork();
                        var post = new Post
                        {
                            UserId = 1,
                            Content = "Some content post from user1",
                            Title = "Some title post",
                            Published = 1,
                            Viewed = 10,
                            Image = " path/to/file",
                            CreatedAt = DateTime.Now,
                            PublishedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        };
                        var tag = new Tag() { Content = "sdvsfvvf", Title = "sdcsdc"};
                        //List<Tag> tags = db.Tags.ToList();
                        //tags.Add(tag);
                        //post.Tags =  tags;
                        //db.Posts.Add(post);
                        //db.SaveChanges();
                        entity.Post.Create(post);
                        //entity.Tag.Create(tag);
                        entity.Save();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
