using System;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, string email, JwtDto jwt) //metoda rozszerzająca dla Cache do przechowywania tokena
            => cache.Set(GetJwtKey(email), jwt, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache cache, string email)          //Pobieranie z cacha
            => cache.Get<JwtDto>(GetJwtKey(email));

        private static string GetJwtKey(string email)
            => $"{email}-jwt";
    }
}