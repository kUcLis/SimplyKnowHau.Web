using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplyKnowHau.Domain.Interfaces;
using SimplyKnowHau.Infrastructure.Persistence;
using SimplyKnowHau.Infrastructure.Repositories;
using SimplyKnowHau.Infrastructure.Seeders;

namespace SimplyKnowHau.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimplyKnowHauDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SimplyKnowHau")));

            //Seeders
            services.AddScoped<RoleSeeder>();
            services.AddScoped<UserSeeder>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}
