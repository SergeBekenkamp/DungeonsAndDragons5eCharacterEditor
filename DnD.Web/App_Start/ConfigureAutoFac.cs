using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DnD.Datalayer.Context;
using DnD.Datalayer.Repositories;
using DnD.Service.Interfaces;
using DnD.Service.Services;

namespace DungeonsAndDragons.App_Start
{
    public class ConfigureAutoFac
    {

        public static IContainer ConfigureMvc()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DnDContext>().AsSelf().InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterEssentials(builder);
            return builder.Build();
        }

        /// <summary>
        /// Configure the basic container
        /// </summary>
        /// <returns>
        /// An <see cref="IContainer"/>.
        /// </returns>
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DnDContext>().AsSelf();

            RegisterEssentials(builder);

            return builder.Build();
        }

        /// <summary>
        /// Register types that are shared amongst all containers.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        private static void RegisterEssentials(ContainerBuilder builder)
        {
            
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(CrudService<>)).As(typeof(ICrudService<>));

            // Assembly scanning
            builder.RegisterAssemblyTypes(Assembly.Load("DnD.DataLayer"))
                .Where(t => t.Name.EndsWith("Repository") && !t.Name.StartsWith("BaseRe"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load("DnD.Service"))
                .Where(t => t.Name.EndsWith("Service") && !t.Name.StartsWith("CrudSer"))
                .AsImplementedInterfaces();
        }
    }
}