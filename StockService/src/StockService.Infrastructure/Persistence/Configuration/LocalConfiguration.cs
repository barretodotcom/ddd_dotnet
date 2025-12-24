using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockService.Domain.Locals.Entities;
using StockService.Domain.Locals.ValueObjects;

namespace StockService.Infrastructure.Persistence.Configuration;

public class LocalConfiguration : IEntityTypeConfiguration<Local>
{
    public void Configure(EntityTypeBuilder<Local> builder)
    {
        builder.ToTable("locals");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
                    l => l.Value,
                    l => new LocalId(l)
                );
        builder.Property(x => x.Name).HasColumnType("varchar(255)").IsRequired();
        builder.HasMany(l => l.Stocks).WithOne(s => s.Local).HasForeignKey(s => s.LocalId).HasPrincipalKey(l => l.Id);
    }
}