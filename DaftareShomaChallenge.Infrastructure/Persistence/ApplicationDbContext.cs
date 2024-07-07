using DaftareShomaChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaftareShomaChallenge.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }

    #region overrides
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
    #endregion

}