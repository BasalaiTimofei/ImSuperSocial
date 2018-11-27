using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<CommentDb>> GetAll()
        {
            return await _legendaryContext.Comments.ToListAsync();
        }

        public async Task<CommentDb> Get(string id)
        {
            return await _legendaryContext.Comments.FirstAsync(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<List<CommentDb>> Find(Predicate<CommentDb> predicate)
        {
            var condition = new Func<CommentDb, bool>(predicate);
            return await Task.Run(() => _legendaryContext.Comments.Where(condition).ToList());
        }

        public async Task Create(CommentDb comment)
        {
            comment.Id = Guid.NewGuid().ToString();
            comment.DateCreate = DateTime.Now;
            _legendaryContext.Comments.Add(comment);
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Update(CommentDb comment)
        {
            _legendaryContext.Entry(comment).State = EntityState.Modified;
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var comment = await _legendaryContext.Comments.FirstAsync(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
            if (comment != null)
                _legendaryContext.Comments.Remove(comment);
            await _legendaryContext.SaveChangesAsync();
        }
    }
}
