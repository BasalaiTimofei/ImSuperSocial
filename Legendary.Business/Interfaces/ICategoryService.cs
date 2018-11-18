using System;
using System.Collections.Generic;
using Legendary.Business.Models;

namespace Legendary.Business.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        /// <summary>
        /// Add Category.
        /// </summary>
        /// <param name="category"></param>
        void Create(Category category);
        /// <summary>
        /// Update Category model.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="category"></param>
        void Update(string categoryId, Category category);
        /// <summary>
        /// Delete category.
        /// </summary>
        /// <param name="categoryId"></param>
        void Delete(string categoryId);
        /// <summary>
        /// Get category by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Category"/></returns>
        Category Get(string id);
        /// <summary>
        /// Get all Category.
        /// </summary>
        /// <returns><see cref="List{Category}"/></returns>
        List<Category> GetAll();
        /// <summary>
        /// Get Random Category.
        /// </summary>
        /// <returns>A <see cref="Category"/></returns>
        Category GetRandom();
    }
}