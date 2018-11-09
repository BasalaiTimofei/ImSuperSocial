using Legendary.Business.Models.Video;

namespace Legendary.Business.Interfaces
{
    public interface IVideoService
    {
        /// <summary>
        /// Create a new Video.
        /// </summary>
        /// <param name="video">A Video Full model.</param>
        void CreateVideo(VideoFullModel video);
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
        void UpdateVideo(string videoId, VideoFullModel video);
        /// <summary>
        /// Dispose
        /// </summary>
        void Dispose();
    }
}