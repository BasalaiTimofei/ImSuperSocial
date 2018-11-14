﻿using System;
using System.Linq;
using AutoMapper;
using Legendary.Business.Models;
using Legendary.Data.Models.Actor;

namespace Legendary.Business.Infrastructure.Mapping
{
    public class ActorMappingProfile : Profile
    {
        public ActorMappingProfile()
        {
            CreateMap<ActorDb, Actor>()
                .ForMember(f => f.Country, opt => opt.MapFrom(m => m.Country))
                .ForMember(f => f.AvgRating,
                    opt => opt.MapFrom(w =>
                        w.Rating.Count == 0 ? 50
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) > 50 ? 100
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) < -50 ? 0
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) + 50))
                .ReverseMap()
                .ForMember(f => f.Rating, opt => opt.Ignore())
                .ForMember(f => f.Country, opt => opt.MapFrom(m => m.Country));
        }
    }
}