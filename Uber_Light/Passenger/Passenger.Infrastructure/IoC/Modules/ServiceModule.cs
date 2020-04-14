using Autofac;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                        .Where(x => x.IsAssignableTo<IService>())
                        .AsImplementedInterfaces()
                        .InstancePerLifetimeScope();                       //rejestrowany jako InstancePerLifetimeScope

            builder.RegisterType<Encrypter>()
                .As<IEncrypter>()
                .SingleInstance();                                          //rejestrowany jako pojedyńcza instancja 

            builder.RegisterType<JwtHandler>()
                .As<JwtHandler>()
                .SingleInstance();
        }
    }
}
