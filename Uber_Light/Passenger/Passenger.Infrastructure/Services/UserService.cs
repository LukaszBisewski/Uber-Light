using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Exceptions;

namespace Passenger.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task LoginAsync(string email, string password)                   //Metoda odpowiedzialna za logowanie. 1.Pobierzemy użytkonika z repo. 2. Porównuje czy hasło jest poprawne.
        {                                                                             // Flow Logowania Tworzymy Hasha na podstawie naszego przekazanego hasła
            var user = await _userRepository.GetAsync(email);                         //Porównujemy z Hashem zapisanym na koncie naszego użytkownika 
            if (user != null)
                {
                    throw new ServiceException(ErrorCodesServices.InvalidCredentials,
                    "Invalid credentials");
                }

            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == hash)
                {
                    return;
                }

                    throw new ServiceException(ErrorCodesServices.InvalidCredentials,
                    "Invalid credentials");

        }

        public async Task RegisterAsync(Guid userId, string email, string username, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new ServiceException(ErrorCodesServices.EmailinUse, $"User with email: '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);                              //W metodzie Rejestracji generujemy Salt i Hash
            var hash = _encrypter.GetHash(password, salt);                        //W metodzie Rejestracji generujemy Salt i Hash
            user = new User(userId, email, username, password, hash, salt);                         //Tutaj hasha przekazujemy jako Hasło
            await _userRepository.AddAsync(user);
        }
        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.BrowseAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }
    }
}
