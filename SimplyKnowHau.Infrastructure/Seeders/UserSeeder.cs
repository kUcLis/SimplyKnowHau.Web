using SimplyKnowHau.Application.Interfaces;
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
        private readonly IPasswordHasher _passwordHasher;

        public UserSeeder(SimplyKnowHauDbContext context, IPasswordHasher passwordHasher)
        {
           _context = context;
           _passwordHasher = passwordHasher;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync())
            {
                if (!_context.Users.Any())
                {
                    var user = new User
                    {
                        Email = "admin@admin.pl",
                        PasswordHash = _passwordHasher.Hash("admin@admin.pl", "1Organki2"),
                        RoleId = 1,
                        EmailConfirm = true,
                        DateOfBirth = DateTime.Parse("03.06.1989")
                    };
                    

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
