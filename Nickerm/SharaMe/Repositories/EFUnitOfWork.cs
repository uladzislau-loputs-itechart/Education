using System;
using System.Collections.Generic;
using System.Text;
using SharaMe.Context;
using SharaMe.Repositories;
using SharaMe.Interfaces;

namespace SharaMe.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private MyContext db;
        private UserRepository userRepository;
        private PostRepository postRepository;
        private CategoryRepository categoryRepository;
        private TagRepository tagRepository;
        private CommentRepository commentRepository;

        public EFUnitOfWork()
        {
            db = new MyContext();
        }
        public UserRepository User
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public PostRepository Post
        {
            get
            {
                if (postRepository == null)
                    postRepository = new PostRepository(db);
                return postRepository;
            }
        }

        public CategoryRepository Category
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public TagRepository Tag
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(db);
                return tagRepository;
            }
        }

        public CommentRepository Comment
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
