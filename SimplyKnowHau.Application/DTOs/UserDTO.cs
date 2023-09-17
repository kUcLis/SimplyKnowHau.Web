using SimplyKnowHau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Application.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }

        public int RoleId { get; set; }

        public RoleDTO Role { get; set; } = null!;

        public bool EmailConfirm { get; set; } = false;
    }
}
