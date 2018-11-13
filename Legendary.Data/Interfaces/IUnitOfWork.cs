using System;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<VideoDb> VideoRepository { get; }
        IRepository<CommentDb> CommentRepository { get; }
        IRepository<CategoryDb> CategoryRepository { get; }
        IRepository<ActorDb> ActorRepository { get; }
        void Save();
    }
}
