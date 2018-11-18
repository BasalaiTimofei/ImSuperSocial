using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Legendary.Business.Interfaces;
using Legendary.Business.Models.Actor;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Actor;

namespace Legendary.Business.Services
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _uow;
        private readonly  IMapper _mapper;
        public ActorService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }


        /// <inheritdoc/>
        public void Create(ActorFullModel actor)
        {
            //TODO Проверить роль

            if (actor == null
                || ActorIsInDb(a => string.Equals(a.Name, actor.Name, StringComparison.InvariantCultureIgnoreCase),
                    out var actors))
                //TODO Вернуть ошибку создания
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            actor.Id = Guid.NewGuid().ToString();
            _uow.ActorRepository.Create(_mapper.Map<ActorDb>(actor));

            _uow.Save();
        }

        /// <inheritdoc/>
        public void Upadte(string actorId, ActorFullModel actor)
        {
            //TODO Проверить роль

            if (actor == null 
                || actorId == null 
                  || !ActorIsInDb(
                      f => string.Equals(f.Id, actorId, StringComparison.InvariantCultureIgnoreCase),
                        out var actors))
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            actor.Id = actorId;

            _uow.ActorRepository.Update(_mapper.Map<ActorDb>(actor));
            _uow.Save();
        }

        /// <inheritdoc/>
        public void Delete(string id)
        {
            //TODO Проверить роль

            if(id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            _uow.ActorRepository.Delete(id);
            _uow.Save();
        }

        /// <inheritdoc/>
        public ActorFullModel GetActorFullModel(string id)
        {
            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var actor = _uow.ActorRepository.Get(id);
            if (actor == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<ActorDb, ActorFullModel>(actor);
        }

        /// <inheritdoc/>
        public List<ActorFullModel> GetAllActorFullModels()
        {
            var actors = _uow.ActorRepository.GetAll();
            if (actors == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return actors.Select(s => _mapper.Map<ActorFullModel>(s)).ToList();
        }

        public List<ActorFullModel> GetActorFullModelByCountry(string countryId)
        {
            if (countryId == null ||
                !ActorIsInDb(w => string.Equals(w.Id, countryId, StringComparison.InvariantCultureIgnoreCase),
                    out var actors))
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return actors.Select(s => _mapper.Map<ActorFullModel>(s)).ToList();
        }

        public List<ActorSmallModel> GetAllActorSmallModel()
        {
            var actors = _uow.ActorRepository.GetAll();
            if (actors == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return actors.Select(s => _mapper.Map<ActorSmallModel>(s)).ToList();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        private bool ActorIsInDb(Predicate<ActorDb> condition, out IEnumerable<ActorDb> video)
        {
            video = _uow.ActorRepository.Find(condition);
            return video.Any();
        }
    }
}
