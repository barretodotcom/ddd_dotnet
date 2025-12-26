using StockService.Application.Products.Commands;

namespace StockService.Application.Products.Service.CreateProductService.Validator;

public interface ICreateProductValidatorService
{
    void Validate(CreateProductCommand command);
}