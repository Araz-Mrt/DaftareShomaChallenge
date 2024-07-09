using DaftareShomaChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DaftareShomaChallenge.Infrastructure.Persistence.Seeder;

public class SeederService
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly ILogger<SeederService> _logger;

    public SeederService(ApplicationDbContext context, IConfiguration configuration, ILogger<SeederService> logger)
    {
        _context = context;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task SeedAsync()
    {
        if (!await DatabaseHasDataAsync())
        {
            var sqlFileName = _configuration["SeedData:SqlFilePath"];
            if (string.IsNullOrEmpty(sqlFileName))
            {
                throw new KeyNotFoundException("SQlFilePath key not found in configuration");
            }

            var sqlQuery = await ReadSqlFileAsync(sqlFileName);
            await ExecuteSqlRawAsync(sqlQuery);
        }
    }

    private async Task<bool> DatabaseHasDataAsync()
        => await _context.Orders.AnyAsync();

    private async Task<string> ReadSqlFileAsync(string filePath)
    {
        if (!File.Exists(filePath))
        {
            _logger.LogError("SQL file not found at path: {filePath}", filePath);
            throw new FileNotFoundException($"SQL file not found at path: {filePath}");
        }
        using var reader = new StreamReader(filePath);
        return await reader.ReadToEndAsync();
    }
    private async Task ExecuteSqlRawAsync(string sqlQuery)
    {
        _logger.LogInformation("Executing application seeder query");

        _ = await _context.Database.ExecuteSqlRawAsync(sqlQuery);
        _logger.LogInformation("Executing application seeder query Completed");
    }
}