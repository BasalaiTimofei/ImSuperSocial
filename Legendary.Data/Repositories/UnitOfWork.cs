using System;
using System.Threading.Tasks;
using Legendary.Data.Context;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Country;
using Legendary.Data.Models.Studio;
using Legendary.Data.Models.Video;
using Legendary.Data.Repositories.Actor;
using Legendary.Data.Repositories.Studio;
using Legendary.Data.Repositories.Video;

namespace Legendary.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LegendaryContext _legendaryContext;
        private VideoRepository _videoRepository;
        private CommentRepository _commentRepository;
        private CategoryRepository _categoryRepository;
        private ActorRepository _actorRepository;
        private CountryRepository _countryRepository;
        private StudioRepository _studioRepository;

        private bool _disposed;

        public UnitOfWork(LegendaryContext legendaryContext)
        {
            _legendaryContext = legendaryContext;
        }

        public IRepository<CountryDb> CountryRepository
        {
            get
            {
                if(_countryRepository == null)
                    _countryRepository = new CountryRepository(_legendaryContext);
                return _countryRepository;
            }
        }

        public IRepository<VideoDb> VideoRepository
        {
            get
            {
                if(_videoRepository == null)
                    _videoRepository = new VideoRepository(_legendaryContext);
                return _videoRepository;
            }
        }

        public IRepository<CommentDb> CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_legendaryContext);
                return _commentRepository;
            }
        }

        public IRepository<CategoryDb> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_legendaryContext);
                return _categoryRepository;
            }
        }

        public IRepository<ActorDb> ActorRepository
        {
            get
            {
                if (_actorRepository == null)
                    _actorRepository = new ActorRepository(_legendaryContext);
                return _actorRepository;
            }
        }

        public IRepository<StudioDb> StudioRepository
        {
            get
            {
                if(_studioRepository == null)
                    _studioRepository = new StudioRepository(_legendaryContext);
                return _studioRepository;
            }
        }

        public async Task Save()
        {
            await _legendaryContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                _legendaryContext.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}