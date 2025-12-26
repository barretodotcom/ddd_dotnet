using NNotificator.Abstractions;
using StockService.Application.Common.Result;
using StockService.Application.Products.Commands;
using StockService.Application.Products.Service.CreateProductService.Validator;
using StockService.Domain.Products.Entities;
using StockService.Domain.Products.Repositories;
using StockService.Domain.Products.ValueObjects;

namespace StockService.Application.Products.Service.CreateProductService;

public class CreateProductService : ICreateProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICreateProductValidatorService _createProductValidatorService;
    private readonly IResultService _resultService;

    public CreateProductService(IProductRepository productRepository, ICreateProductValidatorService createProductValidatorService, IResultService resultService, IEventPublisher eventPublisher)
    {
        _productRepository = productRepository;
        _createProductValidatorService = createProductValidatorService;
        _resultService = resultService;
        
    }

    public Product Execute(CreateProductCommand createProductCommand)
    {
        _createProductValidatorService.Validate(createProductCommand);
        
        if (_resultService.HasErrors()) return null;
        
        var productId = new ProductId(Guid.NewGuid());
        var product = new Product(productId, createProductCommand.Name);

        _productRepository.Add(product);
        _productRepository.SaveChanges();

        return product;
    }

}