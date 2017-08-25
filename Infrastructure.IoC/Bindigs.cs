using Domain.Interface.Domain;
using Domain.Interface.Infrastructure;
using Domain.Interface.Repositories;
using Domain.Services;
using Infrastructure.Data.Configuration;
using Infrastructure.Data.Repositories;
using Microsoft.Practices.ServiceLocation;
using Autofac;
using Autofac.Core;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Builder;

namespace Infrastructure.IoC
{
    public class Bindigs
    {
        public static ContainerBuilder Start()
        {
            var build = new ContainerBuilder();
            
            // Infrastructure                   
            build.RegisterType<ManagerContext>().As<IManagerContext>();
            build.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            build.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

            //
            build.RegisterType<DapperRepository>().As<IDapperRepository>().InstancePerLifetimeScope();
            build.RegisterType<AdoRepository>().As<IAdoRepository>().InstancePerLifetimeScope();
            build.RegisterType<ApiRepository>().As<IApiRepository>().InstancePerLifetimeScope();
            build.RegisterType<RepositoryUsuario>().As<IRepositoryUsuario>().InstancePerLifetimeScope();

            // Domain
            build.RegisterType<DomainServicesUsuario>().As<IDomainServiceUsuario>().InstancePerLifetimeScope();

            // Aplicacao
            //todo

            // Service Locator                        
            //ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            return build;
        }
    }

    
}
