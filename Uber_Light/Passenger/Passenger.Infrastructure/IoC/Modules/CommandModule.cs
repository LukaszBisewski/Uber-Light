using System.Reflection;
using Autofac;
using Passenger.Infrastructure.Commands;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)        // Pobieramy plik DLL(cały kod źródłowy-assembly) Che miec assembly tylko do infrastruktury więc pobieram typ jakiejkolwiek klasy która
                .GetTypeInfo()                          // W tym Assembly siedzi. W tym przypadku kalsa CommandModule. Pobieram info o jej typie, i assembly.
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)    // Ta metoda przeskanuje cały projekt infrastructure w poszukiwaniu typów które nas interesują i zarejestruj AsCloseTypeOf
                   .AsClosedTypesOf(typeof(ICommandHandler<>))  // czyli jako implementacje interfejsu IComandHandler
                   .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>() // Zarejestruj Typ, czyli dla typu ComandDispatcher użyj interfejsu IcComanddispatcher.
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();            // Cykl życia per requset pojedyńczego użytkownika.
        }
    }
}