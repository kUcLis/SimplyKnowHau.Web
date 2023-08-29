using Microsoft.Extensions.DependencyInjection;
using SimplyKnowHau.Application.Interfaces;
using SimplyKnowHau.Application.Services;

namespace SimplyKnowHau.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher,PasswordHasher>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
