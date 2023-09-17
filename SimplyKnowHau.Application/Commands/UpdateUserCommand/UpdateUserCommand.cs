using MediatR;
using SimplyKnowHau.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Application.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<UserDTO>
    {
        public UserDTO UserDTO { get;}

        public UpdateUserCommand(UserDTO userDTO)
        {
            UserDTO = userDTO;
        }
    }
}
