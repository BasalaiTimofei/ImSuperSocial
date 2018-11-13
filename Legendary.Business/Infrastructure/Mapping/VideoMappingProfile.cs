﻿using System;
using System.Linq;
using AutoMapper;
using Legendary.Business.Models.Video;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Infrastructure.Mapping
{
    public class VideoMappingProfile : Profile
    {
        public VideoMappingProfile()
        {
            CreateMap<VideoDb, VideoListDto>();
            CreateMap<VideoDb, VideoItemDto>()
                .ForMember(q => q.Categories, opt => opt.MapFrom(w => w.Categories))
                .ForMember(q => q.AvgRating,
                    opt => opt.MapFrom(w =>
                        w.Rating.Count == 0 ? 50
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) > 50 ? 100
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) < -50 ? 0
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) + 50))
                .ReverseMap()
                .ForMember(q => q.Rating, opt => opt.Ignore());
            CreateMap<VideoDb, VideoFullModel>()
                .ForMember(q => q.Categories, opt => opt.MapFrom(w => w.Categories))
                .ForMember(q => q.AvgRating,
                    opt => opt.MapFrom(w =>
                        w.Rating.Count == 0 ? 50
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) > 50 ? 100
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) < -50 ? 0
                        : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) + 50))
                .ReverseMap()
                .ForMember(q => q.Rating, opt => opt.Ignore())
                .ForMember(q => q.Comments, opt => opt.Ignore())
                .ForMember(q => q.DateCreate, opt => opt.Ignore());
        }
    }
}