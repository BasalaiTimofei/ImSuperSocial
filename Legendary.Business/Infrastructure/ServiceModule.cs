using AutoMapper;
using Legendary.Business.Infrastructure.Mapping;
using Legendary.Business.Services;
using Legendary.Data.Context;
using Legendary.Data.Interfaces;
using Legendary.Data.Repositories;
using Ninject.Modules;

namespace Legendary.Business.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly LegendaryContext _legendaryContext;

        public ServiceModule(LegendaryContext legendaryContext)
        {
            _legendaryContext = legendaryContext;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_legendaryContext);

            Bind<IMapper>().ToMethod(ctx =>
                    new Mapper(new MapperConfiguration(cfg =>
                        cfg.AddProfile(new VideoMappingProfile()))))
                .WhenInjectedInto<VideoService>();

            Bind<IMapper>().ToMethod(ctx =>
                    new Mapper(new MapperConfiguration(cfg =>
                        cfg.AddProfile(new VideoMappingProfile()))))
                .WhenInjectedInto<VideoService>();

            Bind<IMapper>().ToMethod(ctx =>
                    new Mapper(new MapperConfiguration(cfg =>
                        cfg.AddProfile(new VideoMappingProfile()))))
                .WhenInjectedInto<VideoService>();

            Bind<IMapper>().ToMethod(ctx =>
                    new Mapper(new MapperConfiguration(cfx =>
                        cfx.AddProfile(new ActorMappingProfile()))))
                .WhenInjectedInto<ActorService>();

            Bind<IMapper>().ToMethod(ctx =>
                    new Mapper(new MapperConfiguration(cfg =>
                        cfg.AddProfile(new CountryMappingProfile()))))
                .WhenInjectedInto<CountryService>();

            Bind<IMapper>().ToMethod(ctx =>
                    new Mapper(new MapperConfiguration(cfg =>
                        cfg.AddProfile(new StudioMappingProfile()))))
                .WhenInjectedInto<StudioService>();

            Bind<IMapper>().ToMethod(ctx =>
                    new Mapper(new MapperConfiguration(cfg =>
                        cfg.AddProfile(new CategoryMappingProfile()))))
                .WhenInjectedInto<CategoryService>();
        }
    }
}
