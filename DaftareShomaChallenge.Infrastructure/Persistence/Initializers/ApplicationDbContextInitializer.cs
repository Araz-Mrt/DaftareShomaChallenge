using DaftareShomaChallenge.Infrastructure.Persistence.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DaftareShomaChallenge.Infrastructure.Persistence.Initializers;

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitializeAsync()
    {
        try
        {
            _logger.LogInformation("Initializing database");

            await _context.Database.MigrateAsync();
            _logger.LogInformation("initializing database Completed");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }
    public async Task SeedAsync(IServiceProvider serviceProvider)
    {
        try
        {
            _logger.LogInformation("Trying to seed data");
            await TrySeedAsync(serviceProvider);
            _logger.LogInformation("Trying to seed data Completed");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var _seederService = serviceProvider.GetRequiredService<SeederService>();
        await _seederService.SeedAsync();
    }
}