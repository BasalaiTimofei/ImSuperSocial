using System;
using System.Collections.Generic;
using System.Dynamic;
using Legendary.Business.Models;

namespace Legendary.Business.Interfaces
{
    public interface ICountryService : IDisposable
    {
        void Create(Country country);
        void Delete(string countryId);
        void Update(string countryId, Country countryModel);
        Country Get(string countryId);
        List<Country> GetAll();
    }
}
