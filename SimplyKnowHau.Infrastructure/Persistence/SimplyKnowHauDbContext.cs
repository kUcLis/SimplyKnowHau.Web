using Microsoft.EntityFrameworkCore;
using SimplyKnowHau.Domain.Entities;

namespace SimplyKnowHau.Infrastructure.Persistence
{
    public class SimplyKnowHauDbContext : DbContext
    {
        public SimplyKnowHauDbContext(DbContextOptions<SimplyKnowHauDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
