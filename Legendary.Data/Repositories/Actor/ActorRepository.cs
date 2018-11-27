using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Legendary.Data.Context;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Actor;

namespace Legendary.Data.Repositories.Actor
{
    public class ActorRepository : IRepository<ActorDb>
    {
        private readonly LegendaryContext _legendaryContext;
        public ActorRepository(LegendaryContext legendaryContext)
        {
            _legendaryContext = legendaryContext;
        }

        public async Task<List<ActorDb>> GetAll()
        {
            return await _legendaryContext.Actors.ToListAsync();
        }

        public async Task<ActorDb> Get(string id)
        {
            return await _legendaryContext.Actors.FirstAsync(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<List<ActorDb>> Find(Predicate<ActorDb> predicate)
        {
            var condition = new Func<ActorDb, bool>(predicate);
            return await Task.Run(() => _legendaryContext.Actors.Where(condition).ToList());
        }

        public async Task Create(ActorDb item)
        {
            item.Id = Guid.NewGuid().ToString();
            _legendaryContext.Actors.Add(item);
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Update(ActorDb item)
        {
            _legendaryContext.Entry(item).State = EntityState.Modified;
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var actor = await _legendaryContext.Actors.FirstAsync(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
            if (actor != null)
                _legendaryContext.Actors.Remove(actor);
            await _legendaryContext.SaveChangesAsync();
        }
    }
}
