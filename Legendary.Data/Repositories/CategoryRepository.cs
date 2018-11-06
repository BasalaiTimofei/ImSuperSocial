﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public IEnumerable<CategoryDb> GetAll()
        {
            return _legendaryContext.Categories.ToList();
        }

        public CategoryDb Get(string id)
        {
            return _legendaryContext.Categories.Find(id);
        }

        public IEnumerable<CategoryDb> Find(Func<CategoryDb, bool> predicate)
        {
            return _legendaryContext.Categories.Where(predicate).ToList();
        }

        public void Create(CategoryDb category)
        {
            _legendaryContext.Categories.Add(category);
        }

        public void Update(CategoryDb category)
        {
            _legendaryContext.Entry(category).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            var category = _legendaryContext.Categories.Find(id);
            if (category != null)
                _legendaryContext.Categories.Remove(category);
        }
    }
}
