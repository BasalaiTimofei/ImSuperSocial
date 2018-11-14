using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Legendary.Data.Context;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Country;

namespace Legendary.Data.Repositories
{
    public class CountryRepository : IRepository<CountryDb>
    {
        private readonly LegendaryContext _legendaryContext;
        public CountryRepository(LegendaryContext legendaryContext)
        {
            _legendaryContext = legendaryContext;
        }

        public IEnumerable<CountryDb> GetAll()
        {
            return _legendaryContext.Country;
        }

        public CountryDb Get(string id)
        {
            return _legendaryContext.Country.First(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<CountryDb> Find(Predicate<CountryDb> predicate)
        {
            var condition = new Func<CountryDb, bool>(predicate);
            return _legendaryContext.Country.Where(condition).ToList();
        }

        public void Create(CountryDb item)
        {
            _legendaryContext.Country.Add(item);
        }

        public void Update(CountryDb item)
        {
            _legendaryContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            var coutry =
                _legendaryContext.Country.First(f =>
                    string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
            if (coutry != null)
                _legendaryContext.Country.Remove(coutry);
        }
    }
}