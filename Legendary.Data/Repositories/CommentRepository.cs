using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Legendary.Data.Context;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Repositories
{
    public class CommentRepository : IRepository<CommentDb>
    {
        private readonly LegendaryContext _legendaryContext;

        public CommentRepository(LegendaryContext legendaryContext)
        {
            _legendaryContext = legendaryContext;
        }

        public IEnumerable<CommentDb> GetAll()
        {
            return _legendaryContext.Comments.ToList();
        }

        public CommentDb Get(string id)
        {
            return _legendaryContext.Comments.First(f => string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<CommentDb> Find(Predicate<CommentDb> predicate)
        {
            var condition = new Func<CommentDb, bool>(predicate);
            return _legendaryContext.Comments.Where(condition).ToList();
        }

        public void Create(CommentDb comment)
        {
            comment.DateCreate = DateTime.Now;
            _legendaryContext.Comments.Add(comment);
        }

        public void Update(CommentDb comment)
        {
            _legendaryContext.Entry(comment).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            var comment = _legendaryContext.Comments.First(f => string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
            if (comment != null)
                _legendaryContext.Comments.Remove(comment);
        }
    }
}
