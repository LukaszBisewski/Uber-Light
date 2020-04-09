using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.Services
{
    public interface IJwtHandler // odpowiedzialny za generowanie tokenów po stronie API.
    {
        JwtDto CreateToken(Guid userId, string role);// Handletr zwróci JwtDto. Stwórz token dla podanego adresu email i roli.
    }
}
