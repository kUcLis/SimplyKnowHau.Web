using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimplyKnowHau.Application.Queries.GetUserByIdQuery;

namespace SimplyKnowHau.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getById/{roleId}")]
        public async Task<IActionResult> GetUserById(int roleId)
        {
            var role = await _mediator.Send(new GetUserByIdQuery(roleId));

            if (role == null)
                return BadRequest(new { message = $"Role {roleId} was not found!" });

            return Ok(role);
        }
    }
}
