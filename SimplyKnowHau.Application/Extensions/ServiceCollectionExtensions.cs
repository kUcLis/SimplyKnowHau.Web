using Microsoft.Extensions.DependencyInjection;
using SimplyKnowHau.Application.Interfaces;
using SimplyKnowHau.Application.Mapping;
using SimplyKnowHau.Application.Queries.AuthenticateUserQuery;
using SimplyKnowHau.Application.Services;
using MediatR;

namespace SimplyKnowHau.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuthenticateUserQuery).Assembly));

            services.AddScoped<IPasswordHasher,PasswordHasher>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
