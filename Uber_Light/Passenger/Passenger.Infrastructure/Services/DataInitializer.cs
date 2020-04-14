using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Passenger.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        private readonly IDriverRouteService _driverRouteService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserService userService, IDriverService driverService, ILogger<DataInitializer> logger, IDriverRouteService driverRouteService)
        {
            _userService = userService;
            _driverService = driverService;
            _logger = logger;
            _driverRouteService = driverRouteService;
        }
       
        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");
            var tasks = new List<Task>();                           //Nowa lista Taskó
            for (var i = 1; i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com", "secret", "user"));
                _logger.LogTrace($"Created New user: '{username}'.");
                tasks.Add(_driverService.CreateAsync(userId));
                tasks.Add(_driverService.SetVehicleAsync(userId, "BMW", "i8"));
                _logger.LogTrace($"Created New driver: '{username}'.");
                tasks.Add(_driverRouteService.AddAsync(userId, "Default route",
                    1, 1, 2, 2));
                tasks.Add(_driverRouteService.AddAsync(userId, "Job route",
                    3, 3, 5, 5));
                _logger.LogTrace($"Adding driver for: '{username}'.");
            }
            for (var i = 1; i <= 3; i++)                                                        // Tworzenie adminów
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                _logger.LogTrace($"Adding admin: '{username}'.");
                tasks.Add(_userService.RegisterAsync(userId, $"admin{i}@test.com", "secret", "admin"));
            }
            await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initialized.");
        }
    }
}