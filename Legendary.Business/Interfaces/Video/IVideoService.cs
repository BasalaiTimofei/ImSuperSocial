using System;
using System.Collections.Generic;
using Legendary.Business.Models.Video;

namespace Legendary.Business.Interfaces.Video
{
    public interface IVideoService : IDisposable
    {
        /// <summary>
        /// Create a new Video.
        /// </summary>
        /// <param name="video">A Video Full model.</param>
        void CreateVideo(VideoFullModel video);
        /// <summary>
        /// Get a video by Id.
        /// </summary>
        /// <param name="id">Id video</param>
        /// <returns>A <see cref="VideoFullModel"/></returns>
        VideoFullModel GetVideo(string id);
        /// <summary>
        /// Get a List Video.
        /// </summary>
        /// <returns><see cref="List{VideoFullModel}"/></returns>
        List<VideoFullModel> GetListVideo();
        /// <summary>
        /// Delete video.
        /// </summary>
        /// <param name="id">Id video.</param>
        void DeleteVideo(string id);
        /// <summary>
        /// Update Video.
        /// </summary>
        /// <param name="videoId">Id Video.</param>
        /// <param name="video">Video full model.</param>
        VideoFullModel UpdateVideo(string videoId, VideoFullModel video);
    }
}