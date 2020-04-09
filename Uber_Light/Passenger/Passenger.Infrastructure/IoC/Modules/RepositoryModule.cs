using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                    .Where(x => x.IsAssignableTo<IRepository>())
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}
