using SimplyKnowHau.Domain.Entities;
using SimplyKnowHau.Infrastructure.Persistence;


namespace SimplyKnowHau.Infrastructure.Seeders
{
    public class RoleSeeder
    {
        private readonly SimplyKnowHauDbContext _context;

        public RoleSeeder(SimplyKnowHauDbContext context) 
        {
            _context = context;
        }


        public async Task Seed()
        {
            if(await _context.Database.CanConnectAsync())
            {
                if(!_context.Roles.Any())
                {
                    var roles = new List<Role>
                    {
                       new Role{RoleName = "Admin" },
                       new Role{RoleName = "Vet"},
                       new Role{RoleName = "Clinic worker"},
                       new Role{RoleName = "User"}
                    };

                    _context.Roles.AddRange(roles);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
