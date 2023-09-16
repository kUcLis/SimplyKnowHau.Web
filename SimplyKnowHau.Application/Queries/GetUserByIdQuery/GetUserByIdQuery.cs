using MediatR;
using SimplyKnowHau.Application.DTOs;


namespace SimplyKnowHau.Application.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public int UserId { get; set; }
    }
}
