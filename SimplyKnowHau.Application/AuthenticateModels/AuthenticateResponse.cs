using SimplyKnowHau.Domain.Entities;

namespace SimplyKnowHau.Application.AuthenticateModels
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }

        public string Email { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }

        public Role Role { get; set; } = default!;

        public string Token { get; set; } = default!;

        public AuthenticateResponse(User user, string token)
        {
            UserId = user.UserId;

            Email = user.Email;

            DateOfBirth = user.DateOfBirth;

            Role = user.Role;

            Token = token;
        }
    }
}
