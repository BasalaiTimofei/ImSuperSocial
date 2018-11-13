using System;
using Legendary.Data.Context;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LegendaryContext _legendaryContext;
        private VideoRepository _videoRepository;
        private CommentRepository _commentRepository;
        private CategoryRepository _categoryRepository;
        private ActorRepository _actorRepository;

        private bool _disposed;

        public UnitOfWork(LegendaryContext legendaryContext)
        {
            _legendaryContext = legendaryContext;
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

        public void Save()
        {
            _legendaryContext.SaveChanges();
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