using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Settings;

namespace Passenger.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly GeneralSettings _settings;
        private ICommandDispatcher _commandDispatcher;

        public UsersController(IUserService userService,
            ICommandDispatcher commandDispatcher, GeneralSettings settings) : base(commandDispatcher)
        {
            _settings = settings;
            _userService = userService;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get()              //zwróć wszystkich użytkowników
        {
            var users = await _userService.BrowseAsync();

            return Json(users);
        }

        //[Authorize(Policy = "admin")]
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }
        /* 
            nie wiem jak dzialasz, mam komende create user masz ja wykonac i chuj.

             
        */
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await DispatchAsync(command); // wywołanie do interfejscu IComandDispatcher który będzie wiedział co z nim zrobić.

            return Created($"users/{command.Email}", null);
        }
    }
}