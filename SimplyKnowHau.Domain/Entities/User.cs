

namespace SimplyKnowHau.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; } = default!;

        public string PasswordHash { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; } 

        public bool EmailConfirm { get; set; } = false;
    }
}
