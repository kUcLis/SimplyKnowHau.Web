using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyKnowHau.Application.AuthenticateModels;
using SimplyKnowHau.Application.Interfaces;
using SimplyKnowHau.Application.Queries.AuthenticateUserQuery;
using SimplyKnowHau.Application.Queries.GetUserByIdQuery;

namespace SimplyKnowHau.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserQuery userQuery)
        {
            var response = await _mediator.Send(userQuery);

            if (response == null)
                return Unauthorized(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpGet]
        [Route("getById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { UserId = userId });

            if(user == null)
                return BadRequest();

            return Ok(user);
        }
    }
}
