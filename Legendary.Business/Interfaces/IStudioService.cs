using System;
using System.Collections.Generic;
using Legendary.Business.Models;

namespace Legendary.Business.Interfaces
{
    public interface IStudioService : IDisposable
    {
        void Create(Studio studioModel);
        void Update(string studioId, Studio studioModel);
        void Delete(string studioId);
        Studio Get(string studioId);
        List<Studio> GetAll();
    }
}
