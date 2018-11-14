using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Legendary.Business.Interfaces;
using Legendary.Business.Models;
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
        public void CreateActor(Actor actor)
        {
            //TODO Проверить роль

            if (actor == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            actor.Id = Guid.NewGuid().ToString();
            _uow.ActorRepository.Create(_mapper.Map<ActorDb>(actor));

            var dbActor = _uow.ActorRepository.Get(actor.Id);
            if (dbActor == null)
                //TODO Вернуть ошибку создания в репозитории.
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            _uow.Save();
        }

        /// <inheritdoc/>
        public void UpadteActor(string actorId, Actor actor)
        {
            //TODO Проверить роль

            if (actor == null || actorId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();        

            var dbVideo = _uow.VideoRepository.Get(actorId);
            if (ActorIsInDb(
                f => string.Equals(f.Id, actorId, StringComparison.InvariantCultureIgnoreCase), out var actors))
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            actor.Id = actorId;

            _uow.ActorRepository.Update(_mapper.Map<ActorDb>(actor));
            _uow.Save();
        }

        /// <inheritdoc/>
        public void DeleteActor(string id)
        {
            //TODO Проверить роль

            if(id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            _uow.ActorRepository.Delete(id);
            _uow.Save();
        }

        /// <inheritdoc/>
        public Actor GetActor(string id)
        {
            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var actor = _uow.ActorRepository.Get(id);
            if (actor == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<ActorDb, Actor>(actor);
        }

        /// <inheritdoc/>
        public List<Actor> GetAllActors()
        {
            var actors = _uow.ActorRepository.GetAll();
            if (actors == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var actorsDto = actors.Select(s => _mapper.Map<Actor>(s)).ToList();
            return actorsDto;
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
