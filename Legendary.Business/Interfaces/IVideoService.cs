using Legendary.Business.Models.Video;

namespace Legendary.Business.Interfaces
{
    public interface IVideoService
    {
        void CreateVideo(VideoFullModel video);
        void DeleteVideo(string id);
        void UpdateVideo(string videoId, VideoFullModel video);
    }
}