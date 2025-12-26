using StockService.Application.Products.Commands;
using StockService.Domain.Products.Entities;

namespace StockService.Application.Products.Service.CreateProductService;

public interface ICreateProductService
{
    Product Execute(CreateProductCommand command);
}