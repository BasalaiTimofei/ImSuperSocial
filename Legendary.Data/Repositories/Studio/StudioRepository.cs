using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Legendary.Data.Context;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Studio;

namespace Legendary.Data.Repositories.Studio
{
    public class StudioRepository : IRepository<StudioDb>
    {
        private readonly LegendaryContext _legendaryContext;
        public StudioRepository(LegendaryContext legendaryContext)
        {
            _legendaryContext = legendaryContext;
        }

        public async Task<List<StudioDb>> GetAll()
        {
            return await _legendaryContext.Studio.ToListAsync();
        }

        public async Task<StudioDb> Get(string id)
        {
            return await _legendaryContext.Studio.FirstAsync(e =>
                string.Equals(e.Id, id, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<List<StudioDb>> Find(Predicate<StudioDb> predicate)
        {
            var condition = new Func<StudioDb, bool>(predicate);
            return await Task.Run(() => _legendaryContext.Studio.Where(condition).ToList());
        }

        public async Task Create(StudioDb item)
        {
            _legendaryContext.Studio.Add(item);
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Update(StudioDb item)
        {
            _legendaryContext.Entry(item).State = EntityState.Modified;
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var studio = await _legendaryContext.Studio.FirstAsync(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
            if (studio != null)
                _legendaryContext.Studio.Remove(studio);
            await _legendaryContext.SaveChangesAsync();
        }
    }
}