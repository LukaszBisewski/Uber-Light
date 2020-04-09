using System;
using System.Threading.Tasks;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverRouteService : IService
    {
        Task AddAsync(Guid userId, string name,                   //Dodaj ścieżkę                               
            double startLatitude, double startLongitude,
            double endLatitude, double endLongitude);
        Task DeleteAsync(Guid userId, string name);              //Usuń ścieżkę
    }
}