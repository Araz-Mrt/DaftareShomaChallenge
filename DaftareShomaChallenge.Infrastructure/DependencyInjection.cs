using DaftareShomaChallenge.Domain.Interfaces;
using DaftareShomaChallenge.Domain.Repositories;
using DaftareShomaChallenge.Infrastructure.Persistence;
using DaftareShomaChallenge.Infrastructure.Persistence.Initializers;
using DaftareShomaChallenge.Infrastructure.Persistence.Seeder;
using DaftareShomaChallenge.Infrastructure.Repositories;
using DaftareShomaChallenge.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DaftareShomaChallenge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<SeederService>();
        services.AddScoped<ApplicationDbContextInitializer>();
        services.AddScoped<IProductSaleReportService, ProductSaleReportService>();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });
        return services;
    }
}