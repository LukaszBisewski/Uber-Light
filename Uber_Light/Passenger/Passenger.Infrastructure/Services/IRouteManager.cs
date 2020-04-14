using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IRouteManager : IService //Klient w formie testowej
    {
        Task<string> GetAddressAsync(double latitude, double longitude);//Pobierz adress
        double CalculateDistance(double startLatitude, double startLongitude, double endLatitude, double endLongitude); //Przeliczanie odległości pomiędzy współrzędnymi
    }
}
