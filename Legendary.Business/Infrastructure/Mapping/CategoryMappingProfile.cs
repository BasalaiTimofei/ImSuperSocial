using System;
using System.Linq;
using AutoMapper;
using Legendary.Business.Models;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Infrastructure.Mapping
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoryDb, Category>()
                .ForMember(f => f.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(f => f.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(f => f.ImgLink, opt => opt.MapFrom(m => m.ImgLink))
                .ForMember(f => f.Rating,
                    opt => opt.MapFrom(w =>
                        w.Rating.Count == 0 ? 50
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) > 50 ? 100
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) < -50 ? 0
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) + 50))
                .ReverseMap()
                .ForMember(f => f.Rating, opt => opt.Ignore())
                .ForMember(f => f.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(f => f.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(f => f.ImgLink, opt => opt.MapFrom(m => m.ImgLink));

        }
    }
}