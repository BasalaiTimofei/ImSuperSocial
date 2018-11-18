using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Legendary.Business.Interfaces;
using Legendary.Business.Models.Studio;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Studio;

namespace Legendary.Business.Services
{
    public class StudioService : IStudioService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StudioService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        /// <inheritdoc/>
        public void Create(StudioFullModel studioModel)
        {
            //TODO Проверка на роль
            if (studioModel == null
                || StudioIsInDb(
                    s => string.Equals(s.Name, studioModel.Name, StringComparison.InvariantCultureIgnoreCase),
                    out var studio))
                //TODO Вернуть ошибку создания
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            studioModel.Id = Guid.NewGuid().ToString();
            _uow.StudioRepository.Create(_mapper.Map<StudioDb>(studioModel));
            _uow.Save();
        }

        /// <inheritdoc/>
        public void Update(string studioId, StudioFullModel studioModel)
        {
            //TODO Проверка на роль
            if (studioModel == null
                || studioId == null
                || !StudioIsInDb(s => string.Equals(s.Id, studioId, StringComparison.InvariantCultureIgnoreCase),
                    out var studio))
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            studioModel.Id = studioId;
            _uow.StudioRepository.Update(_mapper.Map<StudioDb>(studioModel));
            _uow.Save();
        }

        /// <inheritdoc/>
        public void Delete(string studioId)
        {
            //TODO Проверка на роль
            if (studioId == null
                || !StudioIsInDb(s => string.Equals(s.Id, studioId, StringComparison.InvariantCultureIgnoreCase),
                    out var studio))
                throw new NullReferenceException(); //RequestedResourceNotFoundException();
            
            _uow.StudioRepository.Delete(studioId);
            _uow.Save();
        }

        /// <inheritdoc/>
        public StudioFullModel GetStudioFullModel(string studioId)
        {
            if (studioId == null)
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            var studio = _uow.StudioRepository.Get(studioId);

            if (studio == null)
                //TODO Вернуть ошибку repository
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return _mapper.Map<StudioDb, StudioFullModel>(studio);
        }

        /// <inheritdoc/>
        public List<StudioFullModel> GetAllStudioFullModels()
        {
            var studio = _uow.StudioRepository.GetAll();
            if (studio == null || studio.Count() == 0)
                //TODO Вернуть ошибку repository
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return studio.Select(s => _mapper.Map<StudioDb, StudioFullModel>(s)).ToList();
        }

        /// <inheritdoc/>
        public List<StudioSmallModel> GetAllStudioSmallModel()
        {
            var studio = _uow.StudioRepository.GetAll();
            if (studio == null || studio.Count() == 0)
                //TODO Вернуть ошибку repository
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return studio.Select(s => _mapper.Map<StudioDb, StudioSmallModel>(s)).ToList();
        }

        /// <inheritdoc/>
        public List<StudioSmallModel> GetAllStudioSmallModelByCountry(string countryId)
        {
            if (countryId == null
                || !StudioIsInDb(s => string.Equals(s.Cauntry.Id, countryId, StringComparison.InvariantCultureIgnoreCase), out var studio))
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return studio.Select(s => _mapper.Map<StudioDb, StudioSmallModel>(s)).ToList();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
        private bool StudioIsInDb(Predicate<StudioDb> condition, out IEnumerable<StudioDb> studio)
        {
            studio = _uow.StudioRepository.Find(condition);
            return studio.Any();
        }

    }
}
