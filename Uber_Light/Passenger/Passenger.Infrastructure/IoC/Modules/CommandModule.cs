using System.Reflection;
using Autofac;
using Passenger.Infrastructure.Commands;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)        // Pobieramy plik DLL(cały kod źródłowy-assembly) Che miec assembly tylko do infrastruktury więc pobieram typ jakiej kolwek klasy która     2
                .GetTypeInfo()                          // w tym Assembly siedzi w tym przypadku kalsa CommandModule. Pobieram info o jej typie, i assembly.
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)    //Ta metoda przeskanuje cały projekt infrastructure w poszukiwaniu typów które nas interesują i zarejestruj AsCloseTypeOf
                   .AsClosedTypesOf(typeof(ICommandHandler<>))  // czyli jako implementacje interfejsu IComandHandler
                   .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>() //Zarejestruj Typ, czyli dla typu comanddispatcher użyj interfejsu IcComanddispatcher.   1
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();            // cykl życia per requset pojedyńczego użytkownika
        }
    }
}