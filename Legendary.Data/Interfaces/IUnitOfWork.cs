using System;
using System.Threading.Tasks;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Country;
using Legendary.Data.Models.Rating;
using Legendary.Data.Models.Studio;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CommentDb> CommentRepository { get; }
        IRepository<CategoryDb> CategoryRepository { get; }
        IRepository<CountryDb> CountryRepository { get; }

        IRepository<VideoDb> VideoRepository { get; }

        IRepository<ActorDb> ActorRepository { get; }

        IRepository<StudioDb> StudioRepository { get; }

        Task Save();
    }
}