using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<CountryDb>> GetAll()
        {
            return await _legendaryContext.Country.ToListAsync();
        }

        public async Task<CountryDb> Get(string id)
        {
            return await _legendaryContext.Country.FirstAsync(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<List<CountryDb>> Find(Predicate<CountryDb> predicate)
        {
            var condition = new Func<CountryDb, bool>(predicate);
            return await Task.Run(() =>  _legendaryContext.Country.Where(condition).ToList());
        }

        public async Task Create(CountryDb item)
        {
            item.Id = Guid.NewGuid().ToString();
            _legendaryContext.Country.Add(item);
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Update(CountryDb item)
        {
            _legendaryContext.Entry(item).State = EntityState.Modified;
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var coutry =
                await _legendaryContext.Country.FirstAsync(f =>
                    string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
            if (coutry != null)
                _legendaryContext.Country.Remove(coutry);

            await _legendaryContext.SaveChangesAsync();
        }
    }
}