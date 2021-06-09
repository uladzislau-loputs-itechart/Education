using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using SharaMe.Models;

namespace SharaMe.Context
{
    class DataToDBInitializer : DropCreateDatabaseAlways<MyContext>
    {
        private List<Post> posts;
        private List<Tag> tags;
        private List<Category> categories;
        protected override void Seed(MyContext context)
        {
            GetUsers().ForEach(u => context.Users.Add(u));
            context.SaveChanges();         
            posts =  GetPosts();         
            tags = GetTags();
            categories = GetCategories();
            AddPostTag(context , posts, tags);
            AddPostCategory(context, posts, categories);
            context.SaveChanges();
            GetComments().ForEach(c => context.Comments.Add(c));
            context.SaveChanges();
        }

        private static List<User> GetUsers()
        {
            var users = new List<User>
            {
            new User{Name="Alexander",Email="AlexanderEmail@gmail.com",Hash="234o234uiiuuihev",Salt="234sdfsvsv", Photo = " path/to/file"},
            new User{Name="Victor",Email="VictorEmail@gmail.com",Hash="gfnf545gdfvdfv",Salt="746hgfbdfdf", Photo = " path/to/file"},
            new User{Name="Kiril",Email="KirilEmail@gmail.com",Hash="77575rfgdgdg",Salt="dfbdfbdfb4545dfd", Photo = " path/to/file"}
            };

            return users;
        }

        private static List<Post> GetPosts()
        {
            var posts = new List<Post>
            {
            new Post{UserId = 1, Content = "Some content post1 from user1", Title = "Some title post1", Published = 1, Viewed = 10, Image = " path/to/file",
                CreatedAt =DateTime.Now, PublishedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Post{UserId = 1, Content = "Some content post2 from user1", Title = "Some title post2", Published = 1, Viewed = 15, Image = " path/to/file",
                CreatedAt =DateTime.Now, PublishedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Post{UserId = 2, Content = "Some content post3 from user2", Title = "Some title post3", Published = 1, Viewed = 20, Image = " path/to/file",
                CreatedAt =DateTime.Now, PublishedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Post{UserId = 2, Content = "Some content post4 from user2", Title = "Some title post4", Published = 1, Viewed = 25, Image = " path/to/file",
                CreatedAt =DateTime.Now, PublishedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Post{UserId = 2, Content = "Some content post5 from user2", Title = "Some title post5", Published = 1, Viewed = 30, Image = " path/to/file",
                CreatedAt =DateTime.Now, PublishedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Post{UserId = 3, Content = "Some content post6 from user3", Title = "Some title post6", Published = 1, Viewed = 35, Image = " path/to/file",
                CreatedAt =DateTime.Now, PublishedAt = DateTime.Now, UpdatedAt = DateTime.Now }

            };

            return posts;
        }

        private static List<Comment> GetComments()
        {
            var comments = new List<Comment>
            {
             new Comment{ PostId = 1, Content = "Some comment for post1", Published = 1, Title = "Some title comment1", 
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now},
             new Comment{ PostId = 1, Content = "Some comment for post1", Published = 1, Title = "Some title comment2",
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now, ParentId = 1},
             new Comment{ PostId = 2, Content = "Some comment for post2", Published = 1, Title = "Some title comment3",
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now},
             new Comment{ PostId = 3, Content = "Some comment for post3", Published = 1, Title = "Some title comment4",
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now},
             new Comment{ PostId = 3, Content = "Some comment for post3", Published = 1, Title = "Some title comment5",
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now, ParentId = 4},
             new Comment{ PostId = 3, Content = "Some comment for post3", Published = 1, Title = "Some title comment6",
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now, ParentId = 5},
             new Comment{ PostId = 4, Content = "Some comment for post4", Published = 1, Title = "Some title comment7",
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now},
             new Comment{ PostId = 4, Content = "Some comment for post4", Published = 1, Title = "Some title comment8",
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now, ParentId = 7},
             new Comment{ PostId = 5, Content = "Some comment for post5", Published = 1, Title = "Some title comment9",
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now},
             new Comment{ PostId = 5, Content = "Some comment for post5", Published = 1, Title = "Some title comment10",
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now, ParentId = 9},
             new Comment{ PostId = 5, Content = "Some comment for post5", Published = 1, Title = "Some title comment11",
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now, ParentId = 10},
             new Comment{ PostId = 6, Content = "Some comment for post6", Published = 1, Title = "Some title comment12",
                 PublishedAt = DateTime.Now, CreatedAt = DateTime.Now}
            };

            return comments;
        }

        private static List<Tag> GetTags()
        {
            var tags = new List<Tag>
            {
            new Tag{ Title = "Some tag1 title", Content = "Beauty"},
            new Tag{ Title = "Some tag2 title", Content = "Business"},
            new Tag{ Title = "Some tag3 title", Content = "Fashion"},
            new Tag{ Title = "Some tag4 title", Content = "Learn"},
            new Tag{ Title = "Some tag5 title", Content = "Music"},
            new Tag{ Title = "Some tag6 title", Content = "Nature"},
            new Tag{ Title = "Some tag7 title", Content = "People"},
            new Tag{ Title = "Some tag8 title", Content = "Photography"},
            new Tag{ Title = "Some tag9 title", Content = "Sports"},
            new Tag{ Title = "Some tag10 title", Content = "Technology"}
            };

            return tags;
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
            new Category{ Content = "Business"},
            new Category{ Content = "Photography"},
            new Category{ Content = "Sports"},
            new Category{ Content = "Technology"}
            };

            return categories;
        }

        private static void AddPostTag(MyContext context , List<Post> posts, List<Tag> tags)
        {

            posts[0].Tags.Add(tags[0]);
            posts[0].Tags.Add(tags[3]);
            posts[0].Tags.Add(tags[5]);
            posts[1].Tags.Add(tags[1]);
            posts[1].Tags.Add(tags[6]);
            posts[1].Tags.Add(tags[8]);
            posts[1].Tags.Add(tags[9]);
            posts[2].Tags.Add(tags[2]);
            posts[2].Tags.Add(tags[4]);
            posts[2].Tags.Add(tags[7]);
            posts[3].Tags.Add(tags[2]);
            posts[3].Tags.Add(tags[0]);
            posts[4].Tags.Add(tags[0]);
            posts[4].Tags.Add(tags[1]);
            posts[4].Tags.Add(tags[2]);
            posts[4].Tags.Add(tags[3]);
            posts[4].Tags.Add(tags[4]);
            posts[5].Tags.Add(tags[1]);
            posts[5].Tags.Add(tags[3]);
            posts[5].Tags.Add(tags[7]);

            context.Posts.Add(posts[0]);
            context.Posts.Add(posts[1]);
            context.Posts.Add(posts[2]);
            context.Posts.Add(posts[3]);
            context.Posts.Add(posts[4]);
            context.Posts.Add(posts[5]);
        }

        private static void AddPostCategory(MyContext context, List<Post> posts, List<Category> categories)
        {

            posts[0].Categories.Add(categories[0]);
            posts[0].Categories.Add(categories[1]);
            posts[0].Categories.Add(categories[3]);
            posts[1].Categories.Add(categories[1]);
            posts[1].Categories.Add(categories[2]);
            posts[2].Categories.Add(categories[0]);
            posts[2].Categories.Add(categories[2]);
            posts[2].Categories.Add(categories[3]);
            posts[3].Categories.Add(categories[0]);
            posts[3].Categories.Add(categories[3]);
            posts[4].Categories.Add(categories[1]);
            posts[4].Categories.Add(categories[2]);
            posts[5].Categories.Add(categories[0]);
            posts[5].Categories.Add(categories[1]);
            posts[5].Categories.Add(categories[2]);

            context.Posts.Add(posts[0]);
            context.Posts.Add(posts[1]);
            context.Posts.Add(posts[2]);
            context.Posts.Add(posts[3]);
            context.Posts.Add(posts[4]);
            context.Posts.Add(posts[5]);
        }
    }
}
