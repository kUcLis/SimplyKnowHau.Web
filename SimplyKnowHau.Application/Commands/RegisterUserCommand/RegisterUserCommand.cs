using MediatR;
using SimplyKnowHau.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Application.Commands.RegisterUserCommand
{
    public class RegisterUserCommand : UserDTO, IRequest<UserDTO>
    {
        public UserDTO UserDTO { get; }

        public RegisterUserCommand(UserDTO userDTO)
        {
            UserDTO = userDTO;
        }
    }
}
