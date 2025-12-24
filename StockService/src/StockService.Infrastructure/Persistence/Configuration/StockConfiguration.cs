using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockService.Domain.Locals.ValueObjects;
using StockService.Domain.Products.ValueObjects;
using StockService.Domain.Stocks.Entities;
using StockService.Domain.Stocks.ValueObjects;

namespace StockService.Infrastructure.Persistence.Configuration;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("stocks");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
                l => l.Value,
                l => new StockId(l)                
                );
        builder.Property(x => x.LocalId)
            .HasConversion(
                l => l.Value,
                l => new LocalId(l)
            );
        builder.Property(x => x.ProductId)
            .HasConversion(
                l => l.Value,
                l => new ProductId(l)
            );
        builder.Property(x => x.Quantity);
        builder.HasOne(x => x.Product).WithMany(x => x.Stocks).HasForeignKey(l => l.ProductId).HasPrincipalKey(l => l.Id);
        builder.HasOne(x => x.Local).WithMany(x => x.Stocks).HasForeignKey(l => l.LocalId).HasPrincipalKey(l => l.Id);
    }

}