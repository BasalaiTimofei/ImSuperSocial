using System.Collections.Generic;
using Legendary.Business.Models.Video;

namespace Legendary.Business.Interfaces
{
    public interface IVideoListService
    {
        List<VideoListDto> GetAllVideoList();
        VideoListDto GetVideoList(string id);
        VideoListDto GetRandomVideoList();
        void Dispose();
    }
}
