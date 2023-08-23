using SimplyKnowHau.Domain.Entities;
using SimplyKnowHau.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Infrastructure.Seeders
{
    public class UserSeeder
    {
        private readonly SimplyKnowHauDbContext _context;

        public UserSeeder(SimplyKnowHauDbContext context)
        {
           _context = context;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync())
            {
                if (!_context.Users.Any())
                {
                    var user = new User();
                    

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
