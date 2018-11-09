using AutoMapper;
using Legendary.Business.Models.Video;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Mapping
{
    public class VideoMappingProfile : Profile
    {
        public VideoMappingProfile()
        {
            CreateMap<VideoDb, VideoListDto>();
            CreateMap<VideoDb, VideoItemDto>()
                .ForMember(q => q.Categories, opt => opt.MapFrom(w => w.Categories));
            CreateMap<VideoDb, VideoFullModel>()
                .ForMember(q => q.Categories, opt => opt.MapFrom(w => w.Categories));
        }
    }
}