using System;
using System.Collections.Generic;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Create(T video);
        void Update(T video);
        void Delete(string id);
    }
}