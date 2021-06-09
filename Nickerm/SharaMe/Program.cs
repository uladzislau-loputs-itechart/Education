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
                        var userId = 3;

                        var post1 = entity.Post.GetPostInfo(userId);
                        foreach (var p in post1)
                            Console.WriteLine($"{p.User?.Name} {p.Title} {p.Image} {p.PublishedAt} {p.Content} {p.Tags} {p.Categories} {p.Comments}");
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                        var post2 = entity.Post.GetMostPopularPosts();
                        foreach (var p in post2)
                            Console.WriteLine($" {p.Viewed}  {p.Title} {p.Image} {p.PublishedAt} {p.Content} {p.Tags} {p.Categories} {p.Comments}");
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

                        var tagId = 1;
                        var tag = entity.Tag.GetPostsByTag(tagId);
                        foreach (var p in tag.Posts)
                            Console.WriteLine($" {p.Id} {p.Viewed}  {p.Title} {p.Image} {p.PublishedAt} {p.Content}");
                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
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
