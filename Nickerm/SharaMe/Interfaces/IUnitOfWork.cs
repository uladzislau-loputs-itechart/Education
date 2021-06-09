using System;
using System.Collections.Generic;
using System.Text;
using SharaMe.Repositories;

namespace SharaMe.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UserRepository User { get; }

        PostRepository Post { get; }

        CategoryRepository Category { get; }

        TagRepository Tag { get; }

        CommentRepository Comment { get; }

        void Save();
    }
}
