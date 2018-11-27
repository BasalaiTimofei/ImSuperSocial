using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task Create(StudioFullModel studioModel)
        {
            //TODO Проверка на роль
            if (studioModel == null
                || StudioIsInDb(
                    s => string.Equals(s.Name, studioModel.Name, StringComparison.InvariantCultureIgnoreCase),
                    out var studio))
                //TODO Вернуть ошибку создания
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            studioModel.Id = Guid.NewGuid().ToString();
            await _uow.StudioRepository.Create(_mapper.Map<StudioDb>(studioModel));
        }

        /// <inheritdoc/>
        public async Task Update(string studioId, StudioFullModel studioModel)
        {
            //TODO Проверка на роль
            if (studioModel == null
                || studioId == null
                || !StudioIsInDb(s => string.Equals(s.Id, studioId, StringComparison.InvariantCultureIgnoreCase),
                    out var studio))
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            studioModel.Id = studioId;
            await _uow.StudioRepository.Update(_mapper.Map<StudioDb>(studioModel));
        }

        /// <inheritdoc/>
        public async Task Delete(string studioId)
        {
            //TODO Проверка на роль
            if (studioId == null
                || !StudioIsInDb(s => string.Equals(s.Id, studioId, StringComparison.InvariantCultureIgnoreCase),
                    out var studio))
                throw new NullReferenceException(); //RequestedResourceNotFoundException();
            
            await _uow.StudioRepository.Delete(studioId);
        }

        /// <inheritdoc/>
        public async Task<StudioFullModel> Get_FullModel(string studioId)
        {
            if (studioId == null)
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            var studio = await _uow.StudioRepository.Get(studioId);

            if (studio == null)
                //TODO Вернуть ошибку repository
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return _mapper.Map<StudioDb, StudioFullModel>(studio);
        }

        /// <inheritdoc/>
        public async Task<List<StudioFullModel>> GetAll_FullModel()
        {
            var studio = await _uow.StudioRepository.GetAll();
            if (studio == null || studio.Count == 0)
                //TODO Вернуть ошибку repository
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return studio.Select(s => _mapper.Map<StudioDb, StudioFullModel>(s)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<StudioSmallModel>> GetAll_SmallModel()
        {
            var studio = await _uow.StudioRepository.GetAll();
            if (studio == null || studio.Count == 0)
                //TODO Вернуть ошибку repository
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return studio.Select(s => _mapper.Map<StudioDb, StudioSmallModel>(s)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<StudioFullModel>> GetAll_By_Country_FullModel(string countryId)
        {
            if (countryId == null)
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            var studio = await _uow.StudioRepository.Find(s =>
                string.Equals(s.Cauntry.Id, countryId, StringComparison.InvariantCultureIgnoreCase));
            if(studio == null)
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return studio.Select(s => _mapper.Map<StudioDb, StudioFullModel>(s)).ToList();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
        ~StudioService()
        {
            Dispose();
        }

        private bool StudioIsInDb(Predicate<StudioDb> condition, out IEnumerable<StudioDb> studio)
        {
            studio = _uow.StudioRepository.Find(condition).Result;
            return studio.Any();
        }

    }
}
