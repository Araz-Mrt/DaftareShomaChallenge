using DaftareShomaChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaftareShomaChallenge.Infrastructure.Persistence.Configurations;

public class OrderLineConfigurations : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        builder.HasOne(ol => ol.Product)
            .WithMany().HasForeignKey(ol => ol.ProductId);

    }
}