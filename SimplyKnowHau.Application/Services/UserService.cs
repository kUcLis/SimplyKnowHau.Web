using SimplyKnowHau.Application.AuthenticateModels;
using SimplyKnowHau.Application.Interfaces;
using SimplyKnowHau.Domain.Entities;
using SimplyKnowHau.Domain.Interfaces;


namespace SimplyKnowHau.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var users = await _userRepository.GetAllWithRoles();
            var user = users.FirstOrDefault(x => x.Email == request.Email && _passwordHasher.Verify(x.PasswordHash, request.Email, request.Password));
            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            var userDto = _mapper.Map<UserDto>(user);

            return new AuthenticateResponse(userDto, token);
        }
    }
}
