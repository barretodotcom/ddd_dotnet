using Microsoft.EntityFrameworkCore;
using StockService.Domain.Common.Repositories;
using StockService.Domain.Products.Entities;
using StockService.Domain.Products.Repositories;
using StockService.Domain.Products.ValueObjects;
using StockService.Infrastructure.Persistence.AppDbContexts;

namespace StockService.Infrastructure.Persistence.Repositories;

public class ProductRepository : Repository<Product, ProductId>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}