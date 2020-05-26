using System;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Passenger.Infrastructure.IoC;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Settings;
using Passenger.Api.Framework;
using NLog.Web;
using NLog.Extensions.Logging;
using Passenger.Infrastructure.Mongo;
using Passenger.Infrastructure.EF;

namespace Passenger.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(cfg =>
                {
                    cfg.SaveToken = true;
                    cfg.RequireHttpsMetadata = false;
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["jwt:issuer"],
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));

            services.AddMemoryCache();
            services.AddMvc()
                    .AddJsonOptions(x => x.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented);
            services.AddEntityFrameworkInMemoryDatabase()
                     .AddEntityFrameworkSqlServer()
                     .AddDbContext<PassengerContext>();
            
            var builder = new ContainerBuilder();
  
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(Configuration));
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {

            loggerFactory.AddNLog();
            app.AddNLogWeb();
            env.ConfigureNLog("Nlog.config");

            MongoConfigurator.Initialize();
            app.UseAuthentication();
            var generalSettings = app.ApplicationServices.GetService<GeneralSettings>();
            if (generalSettings.SeedData)
            {
                var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
                dataInitializer.SeedAsync();
            }
            app.UseExceptionMiddleware();
            app.UseMvc();
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}