﻿using System;
using System.Collections.Generic;
using Legendary.Business.Models.Studio;

namespace Legendary.Business.Interfaces
{
    public interface IStudioService : IDisposable
    {
        /// <summary>
        /// Add studio.
        /// </summary>
        /// <param name="studioModel"></param>
        void Create(StudioFullModel studioModel);
        /// <summary>
        /// Update studio.
        /// </summary>
        /// <param name="studioId"></param>
        /// <param name="studioModel"></param>
        void Update(string studioId, StudioFullModel studioModel);
        /// <summary>
        /// Delete studio.
        /// </summary>
        /// <param name="studioId"></param>
        void Delete(string studioId);
        /// <summary>
        /// Get studio by id.
        /// </summary>
        /// <param name="studioId"></param>
        /// <returns>A <see cref="StudioFullModel"/></returns>
        StudioFullModel Get_FullModel(string studioId);
        /// <summary>
        /// Get All studio(Full model).
        /// </summary>
        /// <returns><see cref="List{StudioFullModel}"/></returns>
        List<StudioFullModel> GetAll_FullModel();
        /// <summary>
        /// Get studio(Small model).
        /// </summary>
        /// <returns><see cref="List{StudioSmallModel}"/></returns>
        List<StudioSmallModel> GetAll_SmallModel();
        /// <summary>
        /// Get all studio by County
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns><see cref="List{StudioSmallModel}"/></returns>
        List<StudioFullModel> GetAll_By_Country_FullModel(string countryId);
    }
}
