using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockService.Domain.Products.Entities;
using StockService.Domain.Products.ValueObjects;

namespace StockService.Infrastructure.Persistence.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id)
            .HasConversion(
                l => l.Value,
                l => new ProductId(l)
                );
        builder.Property(l => l.Name).HasColumnType("varchar(255)");
        builder.HasMany(l => l.Stocks).WithOne(l => l.Product).HasForeignKey(l => l.ProductId)
            .HasPrincipalKey(l => l.Id);
    }
}