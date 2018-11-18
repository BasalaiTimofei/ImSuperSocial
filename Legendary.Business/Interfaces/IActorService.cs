using System;
using System.Collections.Generic;
using Legendary.Business.Models;
using Legendary.Business.Models.Actor;

namespace Legendary.Business.Interfaces
{
    public interface IActorService : IDisposable
    {
        /// <summary>
        /// Create a Actor.
        /// </summary>
        /// <param name="actor"></param>
        void Create(ActorFullModel actor);
        /// <summary>
        /// Update a Actor model.
        /// </summary>
        /// <param name="actorId"></param>
        /// <param name="actor"></param>
        void Upadte(string actorId, ActorFullModel actor);
        /// <summary>
        /// Delete a Actor by Id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);
        /// <summary>
        /// Get a Actor by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="ActorFullModel"/></returns>
        ActorFullModel GetActorFullModel(string id);
        /// <summary>
        /// Get all Actors(Full model).
        /// </summary>
        /// <returns><see cref="List{ActorFullModel}"/></returns>
        List<ActorFullModel> GetAllActorFullModels();
        /// <summary>
        /// Get collection actors by Country
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns><see cref="List{ActorFullModel}"/></returns>
        List<ActorFullModel> GetActorFullModelByCountry(string countryId);
        /// <summary>
        /// Get All actors(Small model)
        /// </summary>
        /// <returns><see cref="List{ActorSmallModel}"/></returns>
        List<ActorSmallModel> GetAllActorSmallModel();
    }
}
