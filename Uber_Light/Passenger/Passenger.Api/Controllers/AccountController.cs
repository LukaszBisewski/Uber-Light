using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly JwtHandler _jwtHandler;

        public AccountController(ICommandDispatcher commandDispatcher,
            JwtHandler jwtHandler)
            : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
        }

        //[HttpGet]
        //[Route("token")]
        //public IActionResult Get()
        //{
        //    var token = _jwtHandler.CreateToken("user1@email.com", "admin");

        //    return Json(token);
        //}

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
    }
}