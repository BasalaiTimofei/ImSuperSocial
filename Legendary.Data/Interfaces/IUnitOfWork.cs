using System;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<VideoDb> VideoRepository { get; }
        IRepository<CommentDb> CommentRepository { get; }
        IRepository<CategoryDb> CategoryRepository { get; }
        void Save();
    }
}
