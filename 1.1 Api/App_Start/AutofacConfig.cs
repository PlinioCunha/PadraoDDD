using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Autofac.Extras.CommonServiceLocator;

namespace _1._1_Api.App_Start
{
    //[assembly: PostApplicationStartMethod()]
    public class AutofacConfig
    {
        public static void Initialize()
        {
            //IContainer container;
            //var builder = new ContainerBuilder();
            
            
            //builder = Infrastructure.IoC.Bindigs.Start();
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //container = builder.Build();
            
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            ////ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }


       
    }
}