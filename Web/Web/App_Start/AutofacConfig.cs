// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutofacConfig.cs" company="Erzasoft">
//   Copyright 2013 Erzasoft
// </copyright>
// <summary>
//   Defines the AutofacConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;
using Erzasoft.DataModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;

namespace Erzasoft.Web
{
    using System.Web;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;
    using Erzasoft.AutofacExtension;
    using Erzasoft.Repository;
    

    /// <summary>
    /// The autofac config.
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        /// The register autofac.
        /// Je potřeba zavolat z Global.asax Application_Start()
        /// </summary>
        public static void RegisterAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // Registrace pro filtry u akcí
            builder.RegisterFilterProvider();

            // Registrace controllerů
            builder.RegisterControllers(typeof(MvcApplication).Assembly).RegisterControllerData();

            // Registrace pro temp data
            builder.RegisterType<TempDataDictionary>().As<TempDataDictionary>().OnActivating(
                e =>
                    {
                        var con = e.Context.Resolve<IControllerDataContainer>();
                        e.ReplaceInstance(con.TempData);
                    }).InstancePerLifetimeScope().ExternallyOwned();

            // Registrace typů webu
            builder.RegisterModule(new AutofacWebTypesModule());

            // Registrace idependency interface
            builder.RegisterModule(new RegisterDependencyModule(new HttpServerUtilityWrapper(HttpContext.Current.Server)));

            // Registrace pro databázi
            builder.RegisterType<DataContext>().As<DbContext>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UnityOfWork>().As<IUnityOfWork>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(UserManager<>)).As(typeof(UserManager<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(UserStore<>)).As(typeof(IUserStore<>)).InstancePerLifetimeScope();            
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            // Registrace resolveru
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            app.UseAutofacMiddleware(container);
            //app.UseAutofacWebApi(GlobalConfiguration.Configuration);
            app.UseAutofacMvc();
        }
    }
}