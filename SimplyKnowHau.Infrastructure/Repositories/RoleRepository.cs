using SimplyKnowHau.Domain.Entities;
using SimplyKnowHau.Domain.Interfaces;

namespace SimplyKnowHau.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public Task<Role> Add(Role role)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Role role)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Role?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Update(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
