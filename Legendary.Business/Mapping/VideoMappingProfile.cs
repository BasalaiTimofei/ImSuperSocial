using AutoMapper;
using Legendary.Business.Models.Video;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Mapping
{
    public class VideoMappingProfile : Profile
    {
        public VideoMappingProfile()
        {
            CreateMap<VideoDb, VideoItemDto>();
            CreateMap<VideoDb, VideoListDto>();
        }
    }
}