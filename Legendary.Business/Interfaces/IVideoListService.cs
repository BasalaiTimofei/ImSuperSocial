﻿using System.Collections.Generic;
using Legendary.Business.Models.Video;

namespace Legendary.Business.Interfaces
{
    public interface IVideoListService
    {
        /// <summary>
        /// Get all small model video.
        /// </summary>
        /// <returns>A <see cref="List{VideoListDto}"/></returns>
        List<VideoListDto> GetAllVideoList();
        /// <summary>
        /// Get small model video by Id.
        /// </summary>
        /// <param name="id">Id video</param>
        /// <returns>A <see cref="VideoListDto"/></returns>
        VideoListDto GetVideoList(string id);
        /// <summary>
        /// Get random small model video.
        /// </summary>
        /// <returns>A <see cref="VideoListDto"/></returns>
        VideoListDto GetRandomVideoList();
        /// <summary>
        /// Dispose
        /// </summary>
        void Dispose();
    }
}
