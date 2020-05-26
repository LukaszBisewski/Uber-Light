using Passenger.Infrastructure.Commands.Drivers.Models;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class UpdateDriver : AuthenticatedCommandBase //Update samochodu którym porusza się kierowca
    {
        public DriverVehicle Vehicle { get; set; }
    }
}
