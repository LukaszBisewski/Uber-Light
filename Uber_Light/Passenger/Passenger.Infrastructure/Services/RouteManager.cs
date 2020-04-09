using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class RouteManager : IRouteManager
    {

        private static readonly Random Random = new Random();                       //Zmienna losowa


        public async Task<string> GetAddressAsync(double latitude, double longitude)      //Zwróci stringa 
            => await Task.FromResult($"Sample address {Random.Next(100)}.");


        public  double CalculateDistance(double startLatitude, double startLongitude, double endLatitude, double endLongitude)        //Zwróci losową odległość od 500 do 10000 tys m.
            => Random.Next(500, 10000);
        
    }
}
