using SimplyKnowHau.Domain.Entities;


namespace SimplyKnowHau.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Register(User user);

        Task<User> GetById(int id);
    }
}
