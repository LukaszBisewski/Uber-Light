using Passenger.Core.Domain;
using Passenger.Infrastructure.Commands.Drivers.Models;
using System;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class CreateDriver : AuthenticatedCommandBase
    {
          public DriverVehicle Vehicle { get; set; }
  
    }
}