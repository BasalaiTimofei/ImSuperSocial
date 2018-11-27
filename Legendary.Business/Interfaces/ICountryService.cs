using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Legendary.Business.Models;

namespace Legendary.Business.Interfaces
{
    public interface ICountryService : IDisposable
    {
        /// <summary>
        /// Add Country.
        /// </summary>
        /// <param name="country"></param>
        Task Create(Country country);
        /// <summary>
        /// Delete Country.
        /// </summary>
        /// <param name="countryId"></param>
        Task Delete(string countryId);
        /// <summary>
        /// Update Country.
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="countryModel"></param>
        Task Update(string countryId, Country countryModel);
        /// <summary>
        /// Get Country by Id.
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>A <see cref="Country"/></returns>
        Task<Country> Get(string countryId);
        /// <summary>
        /// Get Add country
        /// </summary>
        /// <returns><see cref="List{Country}"/></returns>
        Task<List<Country>> GetAll();
    }
}
