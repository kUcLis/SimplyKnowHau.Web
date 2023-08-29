using SimplyKnowHau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Application.AuthenticateModels
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }

        public string Email { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }

        public Role Role { get; set; } = default!;

        public string Token { get; set; } = default!;
    }
}
