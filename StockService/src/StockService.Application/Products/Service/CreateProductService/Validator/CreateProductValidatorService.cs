using StockService.Application.Common.Result;
using StockService.Application.Products.Commands;
using StockService.Domain.Products.Repositories;

namespace StockService.Application.Products.Service.CreateProductService.Validator;

public class CreateProductValidatorService : ICreateProductValidatorService
{
    private readonly IProductRepository _productRepository;
    private readonly IResultService _resultService;

    public CreateProductValidatorService(IProductRepository productRepository, IResultService resultService)
    {
        _productRepository = productRepository;
        _resultService = resultService;
    }

    public void Validate(CreateProductCommand command)
    {
        var productExists = _productRepository.GetByName(command.Name);
        
        if (productExists != null)
            _resultService.AddMessage("There is already a product with that name.");

    }
    
}