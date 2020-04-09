using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IVehicleProvider : IService
    {
        Task<IEnumerable<VehicleDto>> BrowseAsync(); //Pobierz wszystkie pojazdy
        Task<Vehicle> GetAsync(string brand, string name); //Skonstrułuj pojazd dla podanej nazwy
    }
}