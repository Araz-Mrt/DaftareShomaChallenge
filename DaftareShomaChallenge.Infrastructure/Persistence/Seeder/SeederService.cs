using DaftareShomaChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaftareShomaChallenge.Infrastructure.Persistence.Seeder;

public class SeederService
{
    private readonly ApplicationDbContext _context;

    public SeederService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await SeedProductsAsync();
    }

    private async Task SeedProductsAsync()
    {
        if (!await _context.Products.AnyAsync())
        {
            await _context.Products.AddRangeAsync(GenerateProducts());
            await _context.SaveChangesAsync();
        }
    }
    private List<Product> GenerateProducts()
    {
        return new List<Product>()
        {
            new ("p1",25000),
            new ("p2",35000),
            new ("p3",45000),
            new ("p4",5000),
            new ("p5",50000),
        };
    }
}