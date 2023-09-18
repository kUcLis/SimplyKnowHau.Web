using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimplyKnowHau.Application.Commands.DeleteUserCommand;
using SimplyKnowHau.Application.Commands.RegisterUserCommand;
using SimplyKnowHau.Application.Commands.UpdateUserCommand;
using SimplyKnowHau.Application.DTOs;
using SimplyKnowHau.Application.Queries.AuthenticateUserQuery;
using SimplyKnowHau.Application.Queries.GetAllUsersQuery;
using SimplyKnowHau.Application.Queries.GetUserByIdQuery;
using SimplyKnowHau.WebAPI.Attributes;

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

        [HttpGet("authenticate")]
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
            var user = await _mediator.Send(new GetUserByIdQuery (userId));

            if(user == null)
                return BadRequest(new {message = $"User {userId} was not found!"});

            return Ok(user);
        }

        [HttpGet]
        [Authorize]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery()); 

            return Ok(users);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO userDTOToRegister)
        {
            var registeredUser = await _mediator.Send(new RegisterUserCommand(userDTOToRegister));
            if (registeredUser == null)
                return BadRequest();
            return Ok(registeredUser);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO userDTOToUpdate)
        {
            var updatedUser = await _mediator.Send(new UpdateUserCommand(userDTOToUpdate));

            if (updatedUser == null)
                return BadRequest();

            return Ok(updatedUser);
        }

        [HttpDelete]
        [Route("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _mediator.Send(new DeleteUserCommand(userId));
            return Ok(new {Message = $"User {userId} deleted!"});
        }
    }
}
