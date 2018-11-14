﻿using System;
using System.Linq;
using AutoMapper;
using Legendary.Business.Models;
using Legendary.Data.Models.Studio;

namespace Legendary.Business.Infrastructure.Mapping
{
    public class StudioMappingProfile : Profile
    {
        public StudioMappingProfile()
        {
            CreateMap<StudioDb, Studio>()
                .ForMember(f => f.Country, opt => opt.MapFrom(m => m.Cauntry))
                .ForMember(q => q.AvgRating,
                    opt => opt.MapFrom(w =>
                        w.Rating.Count == 0 ? 50
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) > 50 ? 100
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) < -50 ? 0
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) + 50))
                .ReverseMap()
                .ForMember(f => f.Cauntry, opt => opt.Ignore())
                .ForMember(f => f.Rating, opt => opt.Ignore())
                .ForMember(f => f.Video, opt => opt.Ignore());
        }
    }
}
