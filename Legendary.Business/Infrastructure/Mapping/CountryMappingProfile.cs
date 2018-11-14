using AutoMapper;
using Legendary.Business.Models;
using Legendary.Data.Models.Country;

namespace Legendary.Business.Infrastructure.Mapping
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<CountryDb, Country>()
                .ForMember(f => f.CountryName, opt => opt.MapFrom(w => w.Name))
                .ReverseMap()
                .ForMember(f => f.Actors, opt => opt.Ignore())
                .ForMember(f => f.Name, opt => opt.MapFrom(w => w.CountryName))
                .ForMember(f => f.Studio, opt => opt.Ignore());
        }
    }
}
