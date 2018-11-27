using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Legendary.Business.Models.Video;

namespace Legendary.Business.Interfaces
{
    public interface IVideoService : IDisposable
    {
        /// <summary>
        /// Create a new Video.
        /// </summary>
        /// <param name="video">A Video Full model.</param>
        Task Create(VideoFullModel video);
        /// <summary>
        /// Delete video.
        /// </summary>
        /// <param name="id">Id video.</param>
        Task Delete(string id);
        /// <summary>
        /// Update Video.
        /// </summary>
        /// <param name="videoId">Id Video.</param>
        /// <param name="video">Video full model.</param>
        Task Update(string videoId, VideoFullModel video);
        /// <summary>
        /// Gets a video by Id.
        /// </summary>
        /// <param name="id">Id video</param>
        /// <returns>A <see cref="Task{VideoFullModel}"/></returns>
        Task<VideoFullModel> Get_FullModel(string id);
        /// <summary>
        /// Gets a List Video.
        /// </summary>
        /// <returns><see cref="List{VideoFullModel}"/></returns>
        Task<List<VideoFullModel>> GetAll_FullModel();
        /// <summary>
        /// Gets video(ItemModel) by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{VideoItemModel}"/></returns>
        Task<VideoItemModel> Get_ItemModel(string id);
        /// <summary>
        /// Gets Random video(ItemModel).
        /// </summary>
        /// <returns>A <see cref="Task{VideoItemModel}"/></returns>
        Task<VideoItemModel> GetRandom_ItemModel();
        /// <summary>
        /// Gets all video(SmallModel).
        /// </summary>
        /// <returns><see cref="List{VideoSmallModel}"/></returns>
        Task<List<VideoSmallModel>> GetAll_SmallModel();
        /// <summary>
        /// Gets video(SmallModel) by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{VideoSmallModel}"/></returns>
        Task<VideoSmallModel> Get_SmallModel(string id);
        /// <summary>
        /// Gets video(SmallModel) by Actor.
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns><see cref="List{VideoSmallModel}"/></returns>
        Task<List<VideoSmallModel>> Get_ByActor_SmallModel(string actorId);
        /// <summary>
        /// Gets video(SmallModel) by Category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns><see cref="List{VideoSmallModel}"/></returns>
        Task<List<VideoSmallModel>> Get_ByCategory_SmallModel(string categoryId);
        /// <summary>
        /// Gets video(SmallModel) by Studio.
        /// </summary>
        /// <param name="studioId"></param>
        /// <returns><see cref="List{VideoSmallModel}"/></returns>
        Task<List<VideoSmallModel>> Get_ByStudio_SmallModel(string studioId);
        /// <summary>
        /// Gets Random video(SmallModel).
        /// </summary>
        /// <returns>A <see cref="Task{VideoSmallModel}"/></returns>
        Task<VideoSmallModel> GetRandom_SmallModel();
    }
}