using StockService.Domain.Common.Repositories;
using StockService.Domain.Products.Entities;
using StockService.Domain.Products.ValueObjects;

namespace StockService.Domain.Products.Repositories;

public interface IProductRepository : IRepository<Product, ProductId>
{
    public Product? GetByName(string name);
}