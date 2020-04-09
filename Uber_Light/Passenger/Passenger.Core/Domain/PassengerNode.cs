﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class PassengerNode // PassangerNode[punkt zabrania pasażera] Klasa reprezentuje, że pasażer się zgłosił i trzeba go odebrać. 
    {
        public Node Node { get; protected set; } //W jakim miejscu pobrać pasażera.
        public Passenger Passenger { get; protected set; } 
    }
}
