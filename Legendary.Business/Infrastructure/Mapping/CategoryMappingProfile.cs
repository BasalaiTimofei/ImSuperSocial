using AutoMapper;
using Legendary.Business.Models;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Infrastructure.Mapping
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoryDb, CategoryDto>()
                .ForMember(q => q.Video, opt => opt.MapFrom(w => w.Video));
        }
    }
}
