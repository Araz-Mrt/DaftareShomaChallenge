using DaftareShomaChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaftareShomaChallenge.Infrastructure.Persistence.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasMany(o => o.OrderLines)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(o => o.Number).IsRequired();
        builder.Property(o => o.TotalPrice).IsRequired();
        builder.Property(o => o.Date).IsRequired();
    }
}