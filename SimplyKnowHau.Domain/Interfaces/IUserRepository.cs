using SimplyKnowHau.Domain.Entities;


namespace SimplyKnowHau.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Register(User user);

        IQueryable<User> GetAll();
        Task<List<User>> GetAllWithRoles();

        Task<User?> GetByEmail(string email);

        Task<User?> GetById(int id);

        Task<User> Update(User user);

        Task Delete(User user);
    }
}
