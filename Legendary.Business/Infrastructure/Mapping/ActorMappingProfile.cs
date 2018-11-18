using System;
using System.Linq;
using AutoMapper;
using Legendary.Business.Models.Actor;
using Legendary.Data.Models.Actor;

namespace Legendary.Business.Infrastructure.Mapping
{
    public class ActorMappingProfile : Profile
    {
        public ActorMappingProfile()
        {
            CreateMap<ActorDb, ActorFullModel>()
                .ForMember(f => f.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(f => f.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(f => f.Gender, opt => opt.MapFrom(m => m.Gender))
                .ForMember(f => f.ImgLink, opt => opt.MapFrom(m => m.ImgLink))
                .ForMember(f => f.Country, opt => opt.MapFrom(m => m.Country))
                .ForMember(f => f.AvgRating,
                    opt => opt.MapFrom(w =>
                        w.Rating.Count == 0 ? 50
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) > 50 ? 100
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) < -50 ? 0
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) + 50))
                .ReverseMap()
                .ForMember(f => f.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(f => f.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(f => f.Gender, opt => opt.MapFrom(m => m.Gender))
                .ForMember(f => f.ImgLink, opt => opt.MapFrom(m => m.ImgLink))
                .ForMember(f => f.Rating, opt => opt.Ignore())
                .ForMember(f => f.Country, opt => opt.MapFrom(m => m.Country));

            CreateMap<ActorDb, ActorSmallModel>()
                .ForMember(f => f.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(f => f.Name, opt => opt.MapFrom(m => m.Name))
                .ReverseMap()
                .ForMember(f => f.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(f => f.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(f => f.Country, opt => opt.Ignore())
                .ForMember(f => f.Gender, opt => opt.Ignore())
                .ForMember(f => f.ImgLink, opt => opt.Ignore())
                .ForMember(f => f.Rating, opt => opt.Ignore())
                .ForMember(f => f.Video, opt => opt.Ignore());
        }
    }
}