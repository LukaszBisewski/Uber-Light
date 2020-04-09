using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.DTO
{
    public class JwtDto         //Trzyma dane tokena
    {
        public string Token { get; set; }//chemy zwrócić token
        public long Expires { get; set; }//chemy zwrócić termin wygaśnięcia
    }
}
