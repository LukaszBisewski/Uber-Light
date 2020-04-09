using Passenger.Infrastructure.Commands.Drivers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class UpdateDriver : AuthenticatedCommandBase //Zaktualizwanie samochodu którym się porusza kierowca
    {
        public DriverVehicle Vehicle { get; set; }
    }
}
