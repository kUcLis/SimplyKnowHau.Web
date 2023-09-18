using SimplyKnowHau.Domain.Entities;
using SimplyKnowHau.Domain.Interfaces;
using SimplyKnowHau.Infrastructure.Persistence;

namespace SimplyKnowHau.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SimplyKnowHauDbContext _context;
        public RoleRepository(SimplyKnowHauDbContext context) => _context = context; 

        public async Task<Role> Add(Role role)
        {
            await _context.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task Delete(Role role)
        {
            _context.Remove(role);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Role> GetAll()
        {
            return _context.Roles;
        }

        public async Task<Role?> GetById(int roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }

        public async Task<Role> Update(Role role)
        {
            _context.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }
    }
}
