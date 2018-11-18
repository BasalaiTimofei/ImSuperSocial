using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using Legendary.Business.Interfaces;
using Legendary.Business.Models;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Country;

namespace Legendary.Business.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CountryService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public void Create(Country country)
        {
            //TODO Проверить роль
            if (country == null
                || !CultureIsReal(country.CountryName)
                || CountryIsInDb(
                    c => string.Equals(c.Name, country.CountryName, StringComparison.InvariantCultureIgnoreCase),
                    out var countries))
                //TODO Вернуть ошибку о создании
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            _uow.CountryRepository.Create(_mapper.Map<CountryDb>(country));
            _uow.Save();
        }

        /// <inheritdoc/>
        public void Delete(string countryId)
        {
            //TODO Проверить роль
            if (countryId == null || !CountryIsInDb(
                    c => string.Equals(c.Id, countryId, StringComparison.InvariantCultureIgnoreCase),
                    out var countries))
                //TODO Вернуть ошибку о создании
                throw new NullReferenceException(); //RequestedResourceNotFoundException();
            
            _uow.CountryRepository.Delete(countryId);
            _uow.Save();
        }

        /// <inheritdoc/>
        public void Update(string countryId, Country countryModel)
        {
            //TODO Проверить роль
            if (countryId == null 
                || countryModel == null 
                    || !CountryIsInDb(
                        c => string.Equals(c.Id, countryId, StringComparison.InvariantCultureIgnoreCase),
                            out var countries))
                //TODO Вернуть ошибку о создании
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            countryModel.Id = countryId;
            _uow.CountryRepository.Update(_mapper.Map<CountryDb>(countryModel));
            _uow.Save();
        }

        /// <inheritdoc/>
        public Country Get(string countryId)
        {
            if(countryId == null)
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            var country = _uow.CountryRepository.Get(countryId);

            if (country == null)
                //TODO Вернуть ошибку о создании
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return _mapper.Map<CountryDb, Country>(country);
        }

        /// <inheritdoc/>
        public List<Country> GetAll()
        {
            var countries = _uow.CountryRepository.GetAll();

            if (countries == null || !countries.Any())
                //TODO Вернуть ошибку о создании
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return countries.Select(s => _mapper.Map<Country>(s)).ToList();

        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        private bool CountryIsInDb(Predicate<CountryDb> condition, out IEnumerable<CountryDb> country)
        {
            country = _uow.CountryRepository.Find(condition);
            return country.Any();
        }

        private bool CultureIsReal(string countryName)
        {
            var cultureList = new List<string>();

            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);

            foreach (var culture in cultures)
            {
                try
                {
                    var region = new RegionInfo(culture.LCID);

                    if (!(cultureList.Contains(region.EnglishName)))
                    {
                        cultureList.Add(region.EnglishName);
                    }
                }
                catch (ArgumentException ex)
                {
                    continue;
                }
            }
            return cultureList.Contains(countryName);
        }
    }
}
