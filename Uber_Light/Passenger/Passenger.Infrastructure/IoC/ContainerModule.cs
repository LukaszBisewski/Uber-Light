using Autofac;
using Microsoft.Extensions.Configuration;
using Passenger.Infrastructure.IoC;
using Passenger.Infrastructure.IoC.Modules;
using Passenger.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.IoC
{
    // Trzyma wszystkie nasze moduły wewnętrze aby nie pisać tego każdorazowo w StartUpie 

    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;


        public ContainerModule(IConfiguration configuration) // W konstruktorze chcemy przekazać obiekt IConfiguration

        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new SettingsModule(_configuration));

        }
    }
}
