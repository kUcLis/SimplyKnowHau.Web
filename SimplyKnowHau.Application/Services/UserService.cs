using SimplyKnowHau.Domain.Entities;
using SimplyKnowHau.Domain.Interfaces;


namespace SimplyKnowHau.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetById (int id)
        {
            return await _userRepository.GetById(id);
        }
    }
}
