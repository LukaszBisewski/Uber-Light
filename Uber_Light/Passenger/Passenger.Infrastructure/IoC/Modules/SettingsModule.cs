using Autofac;
using Passenger.Infrastructure.Settings;
using Passenger.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Passenger.Infrastructure.Mongo;
using Passenger.Infrastructure.EF;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;


        public SettingsModule(IConfiguration configuration)

        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>()) // Builder zarejestruj instancję, użyj metody GetSettings z Extensions
            .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>()) // Builder zarejestruj instancję, użyj metody GetSettings z Extensions
            .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>()) // Builder zarejestruj instancję, użyj metody GetSettings z Extensions
            .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<SqlSettings>())
            .SingleInstance();
        }
    }
}
