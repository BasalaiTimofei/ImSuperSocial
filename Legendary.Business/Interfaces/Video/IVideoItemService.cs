using Legendary.Business.Models.Video;

namespace Legendary.Business.Interfaces
{
    public interface IVideoItemService
    {
        /// <summary>
        /// Get a video by Id.
        /// </summary>
        /// <param name="id">Id video.</param>
        /// <returns>A <see cref="VideoItemDto"/></returns>
        VideoItemDto GetVideoItem(string id);

        /// <summary>
        /// Dispose
        /// </summary>
        void Dispose();
    }
}