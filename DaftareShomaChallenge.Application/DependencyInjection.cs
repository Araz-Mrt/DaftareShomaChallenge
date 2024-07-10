using System.Reflection;
using DaftareShomaChallenge.Application.Contracts.Interfaces;
using DaftareShomaChallenge.Application.Services;
using DaftareShomaChallenge.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DaftareShomaChallenge.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IApplicationProductSaleReportService, ApplicationProductSaleReportService>();
        services.AddInfrastructureServices(configuration);

        return services;
    }
}