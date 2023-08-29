using SimplyKnowHau.Infrastructure.Extensions;
using SimplyKnowHau.Application.Extensions;
using SimplyKnowHau.Infrastructure.Seeders;
using SimplyKnowHau.Application;

namespace SimplyKnowHau.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Added AppSetings from json
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            // Infrastructure - DbContext,Seeders
            builder.Services.AddInfrastructure(builder.Configuration);

            //Application - Services
            builder.Services.AddApplication();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();



            // Scopes
            var scope = app.Services.CreateScope();

            var roleSeeder = scope.ServiceProvider.GetRequiredService<RoleSeeder>();
            await roleSeeder.Seed();
            var userSeeder = scope.ServiceProvider.GetRequiredService<UserSeeder>();
            await userSeeder.Seed();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}