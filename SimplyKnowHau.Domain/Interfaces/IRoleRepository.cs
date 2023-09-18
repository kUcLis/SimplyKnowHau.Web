using SimplyKnowHau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> Add(Role role);

        IQueryable<Role> GetAll();

        Task<Role?> GetById(int id);

        Task<Role> Update(Role role);

        Task Delete(Role role);
    }
}
