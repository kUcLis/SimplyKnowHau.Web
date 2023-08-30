using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyKnowHau.Application.AuthenticateModels;
using SimplyKnowHau.Application.Interfaces;

namespace SimplyKnowHau.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return Unauthorized(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
