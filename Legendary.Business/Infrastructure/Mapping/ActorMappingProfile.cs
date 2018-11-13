using AutoMapper;
using Legendary.Business.Models;
using Legendary.Data.Models.Actor;

namespace Legendary.Business.Infrastructure.Mapping
{
    public class ActorMappingProfile : Profile
    {
        public ActorMappingProfile()
        {
            CreateMap<ActorDb, ActorDto>();
        }
    }
}
