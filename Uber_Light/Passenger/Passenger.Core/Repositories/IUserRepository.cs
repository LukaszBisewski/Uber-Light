using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(Guid id);                    //Pobranie użytkownika po adresie email.
        Task<User> GetAsync(string email);              //Pobranie użytkownika po adresie Guid.
        Task<IEnumerable<User>> GetAllAsync();          //Stworzenie uzytkownika.
        Task AddAsync(User user);                       //Metoda która zapisze uzytkownika w bazie danych.
        Task UpdateAsync(User user);                    //Metoda która pobierze wszystkich użytkowników.
        Task RemoveAsync(Guid id);
    }
}
