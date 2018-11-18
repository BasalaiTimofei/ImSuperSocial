using System;
using System.Collections.Generic;
using System.Dynamic;
using Legendary.Business.Models;

namespace Legendary.Business.Interfaces
{
    public interface ICountryService : IDisposable
    {
        /// <summary>
        /// Add Country.
        /// </summary>
        /// <param name="country"></param>
        void Create(Country country);
        /// <summary>
        /// Delete Country.
        /// </summary>
        /// <param name="countryId"></param>
        void Delete(string countryId);
        /// <summary>
        /// Update Country.
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="countryModel"></param>
        void Update(string countryId, Country countryModel);
        /// <summary>
        /// Get Country by Id.
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>A <see cref="Country"/></returns>
        Country Get(string countryId);
        /// <summary>
        /// Get Add country
        /// </summary>
        /// <returns><see cref="List{Country}"/></returns>
        List<Country> GetAll();
    }
}
