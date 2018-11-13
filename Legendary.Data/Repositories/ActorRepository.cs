using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Legendary.Data.Context;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Actor;

namespace Legendary.Data.Repositories
{
    public class ActorRepository : IRepository<ActorDb>
    {
        private readonly LegendaryContext _legendaryContext;
        public ActorRepository(LegendaryContext legendaryContext)
        {
            _legendaryContext = legendaryContext;
        }

        public IEnumerable<ActorDb> GetAll()
        {
            return _legendaryContext.Actors;
        }

        public ActorDb Get(string id)
        {
            return _legendaryContext.Actors.Find(id);
        }

        public IEnumerable<ActorDb> Find(Func<ActorDb, bool> predicate)
        {
            return _legendaryContext.Actors.Where(predicate).ToList();
        }

        public void Create(ActorDb item)
        {
            _legendaryContext.Actors.Add(item);
        }

        public void Update(ActorDb item)
        {
            _legendaryContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            var actor = _legendaryContext.Actors.Find(id);
            if (actor != null)
                _legendaryContext.Actors.Remove(actor);
        }
    }
}
