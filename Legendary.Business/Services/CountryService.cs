using System;
using System.Collections.Generic;
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
        public void Dispose()
        {
            _uow.Dispose();
        }

        public void Create(Country country)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string countryId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(string countryId, Country countryModel)
        {
            throw new System.NotImplementedException();
        }

        public Country Get(string countryId)
        {
            throw new System.NotImplementedException();
        }

        public List<Country> GetAll()
        {
            throw new System.NotImplementedException();
        }
        private bool CountryIsInDb(Predicate<CountryDb> condition, out IEnumerable<CountryDb> video)
        {
            video = _uow.CountryRepository.Find(condition);
            return video.Any();
        }
    }
}
