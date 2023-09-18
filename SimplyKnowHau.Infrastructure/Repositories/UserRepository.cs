using Microsoft.EntityFrameworkCore;
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

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public async Task<List<User>> GetAllWithRoles()
        {
            return await _context.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FindAsync(email);
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Register(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(User user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
