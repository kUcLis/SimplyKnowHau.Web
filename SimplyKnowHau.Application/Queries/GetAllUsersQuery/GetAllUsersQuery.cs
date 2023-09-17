using MediatR;
using SimplyKnowHau.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Application.Queries.GetAllUsersQuery
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDTO>>
    {
    }
}
