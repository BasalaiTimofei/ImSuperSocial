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
    public class CategoryRepository : IRepository<CategoryDb>
    {
        private readonly LegendaryContext _legendaryContext;

        public CategoryRepository(LegendaryContext legendaryContext)
        {
            _legendaryContext = legendaryContext;
        }

        public async Task<List<CategoryDb>> GetAll()
        {
            return await _legendaryContext.Categories.ToListAsync();
        }

        public async Task<CategoryDb> Get(string id)
        {
            return await _legendaryContext.Categories.FirstAsync(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
        }
        
        public async Task<List<CategoryDb>> Find(Predicate<CategoryDb> predicate)
        {
            var condition = new Func<CategoryDb, bool>(predicate);
            return await Task.Run(() => _legendaryContext.Categories.Where(condition).ToList());
        }

        public async Task Create(CategoryDb category)
        {
            _legendaryContext.Categories.Add(category);
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Update(CategoryDb category)
        {
            _legendaryContext.Entry(category).State = EntityState.Modified;
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var category = await _legendaryContext.Categories.FirstAsync(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
            if (category != null)
                _legendaryContext.Categories.Remove(category);

            await _legendaryContext.SaveChangesAsync();
        }
    }
}
