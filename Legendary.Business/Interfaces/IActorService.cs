using System;
using System.Collections.Generic;
using Legendary.Business.Models;

namespace Legendary.Business.Interfaces
{
    public interface IActorService : IDisposable
    {
        /// <summary>
        /// Create a Actor.
        /// </summary>
        /// <param name="actor"></param>
        void CreateActor(Actor actor);
        /// <summary>
        /// Update a Acter model.
        /// </summary>
        /// <param name="actorId"></param>
        /// <param name="actor"></param>
        void UpadteActor(string actorId, Actor actor);
        /// <summary>
        /// Delete a Actor by Id.
        /// </summary>
        /// <param name="id"></param>
        void DeleteActor(string id);
        /// <summary>
        /// Get a Actor by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Actor"/></returns>
        Actor GetActor(string id);
        /// <summary>
        /// Get all Actors.
        /// </summary>
        /// <returns><see cref="List{ActorDto}"/></returns>
        List<Actor> GetAllActors();
        void Dispose();
    }
}
