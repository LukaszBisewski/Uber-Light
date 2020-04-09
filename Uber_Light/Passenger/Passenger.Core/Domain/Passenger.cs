using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Passenger
    { 
        
    public Guid Id { get; protected set; } //Id kierowcy.
    public Guid UserId { get; protected set; } //Id użytkownika.
    public Node Address { get; protected set; } //Miejsce w którym pasażer chce być pobrany.

    }
}