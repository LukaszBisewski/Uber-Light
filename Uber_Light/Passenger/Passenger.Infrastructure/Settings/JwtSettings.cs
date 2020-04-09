using System;
using System.Collections.Generic;
using System.Text;

/* Każde settindsy trzeba zarejestrowac w Settings Module*/

namespace Passenger.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string Key {get; set;}               //Bezpieczny klucz prywatny znany tylko naszej aplikacji którym będzie podpisywała nasze tokeny JWT i tworzyła pole Signature (weryfikacja tokenu)
        public string Issuer { get; set; }
        public int ExpiryMinutes { get; set; }       //Właściwość określająca czas życia naszego tokena
    }
}
