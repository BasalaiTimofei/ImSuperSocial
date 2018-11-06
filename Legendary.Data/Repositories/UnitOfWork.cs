using System;
using Legendary.Data.Context;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LegendaryContext _legendaryContext;
        private VideoRepository _videoRepository;
        private CommentRepository _commentRepository;
        private CategoryRepository _categoryRepository;
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
