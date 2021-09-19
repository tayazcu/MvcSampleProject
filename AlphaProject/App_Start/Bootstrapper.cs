using AlphaProject.Infrastrature;
using AlphaProject.Repositories;
using AlphaProject.Service;
using AlphaProject.UnitOfWork;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaProject.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }
        private static void SetAutofacContainer()
        {
            #region Dependent injection injection map
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerDependency();
            
            #region ################### all injects ###################
            //builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerRequest();

            #endregion

            #region ################### Pattern ###################
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>));
            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>));
            #endregion

            #region ###################  AboutUs => ( Repositories - Services )  ################### 
            // Repositories
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
               .Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            #endregion

            IoCContainer.Register(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            #endregion
        }
    }
}