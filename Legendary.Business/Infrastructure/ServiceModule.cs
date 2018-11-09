using System;
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
        }
    }
}
