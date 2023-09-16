using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimplyKnowHau.Application.AuthenticateModels;
using SimplyKnowHau.Application.Interfaces;
using SimplyKnowHau.Domain.Entities;
using SimplyKnowHau.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Application.Queries.AuthenticateUserQuery
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, AuthenticateResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly AppSettings _appSettings;

        public AuthenticateUserQueryHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _appSettings = appSettings.Value;
        }
        public async Task<AuthenticateResponse> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllWithRoles();
            var user = users.FirstOrDefault(x => x.Email == request.Email && _passwordHasher.Verify(x.PasswordHash, request.Email, request.Password));
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
