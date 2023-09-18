using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Application.Commands.DeleteUserCommand
{
    public class DeleteUserCommand : IRequest
    {
        public int UserId { get; }

        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }
    }
}
