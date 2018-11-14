using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public IEnumerable<ActorDb> GetAll()
        {
            return _legendaryContext.Actors;
        }

        public ActorDb Get(string id)
        {
            return _legendaryContext.Actors.First(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<ActorDb> Find(Predicate<ActorDb> predicate)
        {
            var condition = new Func<ActorDb, bool>(predicate);
            return _legendaryContext.Actors.Where(condition).ToList();
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
            var actor = _legendaryContext.Actors.First(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
            if (actor != null)
                _legendaryContext.Actors.Remove(actor);
        }
    }
}
