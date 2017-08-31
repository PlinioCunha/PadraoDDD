using Domain.Interface.Domain;
using Domain.Interface.Infrastructure;
using Domain.Interface.Repositories;
using Domain.Services;
using Infrastructure.Data.Configuration;
using Infrastructure.Data.Repositories;
using Autofac;
using Domain.Services.Email;
using Domain.Interface.Domain.Email;
using Domain.Interface.Domain.Log;
using Domain.Services.Log;

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
            build.RegisterGeneric(typeof(Data.Repositories.GenericRepository<>)).As(typeof(Domain.Interface.Repositories.GenericRepository<>)).InstancePerLifetimeScope();

            // 
            build.RegisterType<DapperRepository>().As<IDapperRepository>().InstancePerLifetimeScope();
            build.RegisterType<AdoRepository>().As<IAdoRepository>().InstancePerLifetimeScope();
            build.RegisterType<ApiRepository>().As<IApiRepository>().InstancePerLifetimeScope();
            
            // Domain Services
            build.RegisterType<DomainServiceUsuario>().As<IDomainServiceUsuario>().InstancePerLifetimeScope();
            build.RegisterType<DomainEmailServices>().As<IDomainServiceEmail>().InstancePerLifetimeScope();
            build.RegisterType<DomainServiceLogger>().As<IDomainServiceLogger>().InstancePerLifetimeScope();
            build.RegisterType<DomainServiceTarefa>().As<IDomainServiceTarefa>().InstancePerLifetimeScope();

            // Aplicacao
            //todo

            // Service Locator                        
            //ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            return build;
        }
    }

    
}

