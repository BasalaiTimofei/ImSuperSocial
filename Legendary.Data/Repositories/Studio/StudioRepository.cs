using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public IEnumerable<StudioDb> GetAll()
        {
            return _legendaryContext.Studio;
        }

        public StudioDb Get(string id)
        {
            return _legendaryContext.Studio.First(e =>
                string.Equals(e.Id, id, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<StudioDb> Find(Predicate<StudioDb> predicate)
        {
            var condition = new Func<StudioDb, bool>(predicate);
            return _legendaryContext.Studio.Where(condition).ToList();
        }

        public void Create(StudioDb item)
        {
            _legendaryContext.Studio.Add(item);
        }

        public void Update(StudioDb item)
        {
            _legendaryContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            var studio = _legendaryContext.Studio.First(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
            if (studio != null)
                _legendaryContext.Studio.Remove(studio);
        }
    }
}