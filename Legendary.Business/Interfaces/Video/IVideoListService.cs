using System;
using System.Collections.Generic;
using Legendary.Business.Models.Video;

namespace Legendary.Business.Interfaces.Video
{
    public interface IVideoListService : IDisposable
    {
        /// <summary>
        /// Get all small model video.
        /// </summary>
        /// <returns>A <see cref="List{VideoListDto}"/></returns>
        List<VideoSmallModel> GetAllVideoList();
        /// <summary>
        /// Get small model video by Id.
        /// </summary>
        /// <param name="id">Id video</param>
        /// <returns>A <see cref="Video"/></returns>
        VideoSmallModel GetVideoList(string id);
        /// <summary>
        /// Get small models video by actor Id.
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns><see cref="List{VideoListDto}"/></returns>
        List<VideoSmallModel> GetVideoByActor(string actorId);
        /// <summary>
        /// Get small model video by Category Id.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        List<VideoSmallModel> GetVideoByCategory(string categoryId);
        /// <summary>
        /// Get random small model video.
        /// </summary>
        /// <returns>A <see cref="Video"/></returns>
        VideoSmallModel GetRandomVideoList();
        /// <summary>
        /// Dispose
        /// </summary>
        void Dispose();
    }
}
