using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(string id);
        Task<List<T>> Find(Predicate<T> predicate);
        Task Create(T item);
        Task Update(T item);
        Task Delete(string id);
    }
}