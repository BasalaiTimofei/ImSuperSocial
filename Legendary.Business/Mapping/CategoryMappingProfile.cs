using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Legendary.Business.Models;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Mapping
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoryDb, CategoryDto>()
                .ForMember(m => m.VideoId, opt => opt.MapFrom(m => m.Video.))
        }
    }
}
