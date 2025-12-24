using Microsoft.EntityFrameworkCore;
using StockService.Domain.Locals.ValueObjects;
using StockService.Domain.Products.ValueObjects;
using StockService.Domain.Stocks.Entities;
using StockService.Domain.Stocks.Repositories;
using StockService.Domain.Stocks.ValueObjects;
using StockService.Infrastructure.Persistence.AppDbContexts;

namespace StockService.Infrastructure.Persistence.Repositories;

public class StockRepository : Repository<Stock, StockId>, IStockRepository
{
    public StockRepository(AppDbContext context) : base(context)
    {
    }

    public Stock? Get(LocalId localId, ProductId productId)
    {
        return DbSet.FirstOrDefault(x => x.ProductId == productId && x.LocalId == localId);
    }
}