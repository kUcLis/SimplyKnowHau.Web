using MediatR;
using SimplyKnowHau.Application.DTOs;

namespace SimplyKnowHau.Application.Queries.GetRoleByIdQuery
{
    public class GetRoleByIdQuery : IRequest<RoleDTO>
    {
        public int RoleId { get;}

        public GetRoleByIdQuery(int roleId)
        {
            RoleId = roleId;
        }
    }
}
