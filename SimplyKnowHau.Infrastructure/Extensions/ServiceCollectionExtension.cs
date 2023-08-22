using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplyKnowHau.Infrastructure.Persistence;


namespace SimplyKnowHau.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimplyKnowHauDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SimplyKnowHau")));
        }
    }
}
