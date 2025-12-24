using StockService.Domain.Common.Repositories;
using StockService.Domain.Stocks.ValueObjects;
using StockService.Domain.Locals.ValueObjects;
using StockService.Domain.Products.ValueObjects;
using StockService.Domain.Stocks.Entities;

namespace StockService.Domain.Stocks.Repositories;

public interface IStockRepository : IRepository<Stock, StockId>
{
    Stock? Get(LocalId localId, ProductId productId);
}