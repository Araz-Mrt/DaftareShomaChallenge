using DaftareShomaChallenge.Infrastructure.Persistence;
using DaftareShomaChallenge.Infrastructure.Persistence.Initializers;
using DaftareShomaChallenge.Infrastructure.Persistence.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DaftareShomaChallenge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrasturctureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<SeederService>();
        services.AddScoped<ApplicationDbContextInitializer>();
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });
        return services;
    }
}