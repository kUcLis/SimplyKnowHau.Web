using SimplyKnowHau.Domain.Entities;
using SimplyKnowHau.Domain.Interfaces;
using SimplyKnowHau.Infrastructure.Persistence;

namespace SimplyKnowHau.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SimplyKnowHauDbContext _context;

        public UserRepository(SimplyKnowHauDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Register(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
