using Autofac;
using Passenger.Infrastructure.Settings;
using Passenger.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;


namespace Passenger.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;


        public SettingsModule(IConfiguration configuration) // W konstruktorze chcemy przekazać obiekt IConfiguration

        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>()) // builder zarejestruj instancję, użyj metody GetSettings z Extensions
            .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>()) // builder zarejestruj instancję, użyj metody GetSettings z Extensions
            .SingleInstance();
            /* W tym module mówimy zarejestruj mi instancję jako singleton.
            * Weź z naszej konfiguracji i użyj metodę rozszerzajacą get Setiings ==> przejdź do metody
            */
        }
    }
}
