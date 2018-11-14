using System;
using System.Collections.Generic;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        IEnumerable<T> Find(Predicate<T> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(string id);
    }
}