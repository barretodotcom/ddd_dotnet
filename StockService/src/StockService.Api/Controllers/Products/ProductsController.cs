using Microsoft.AspNetCore.Mvc;
using StockService.Application.Common.Result;
using StockService.Application.Products.Commands;
using StockService.Application.Products.Service.CreateProductService;
using StockService.Domain.Products.Entities;

namespace StockService.Api.Controllers.Products;

public class ProductsController : BaseController
{
    private readonly ICreateProductService _createProductService;

    public ProductsController(ICreateProductService createProductService, IResultService resultService) : base(resultService)
    {
        _createProductService = createProductService;
    }

[HttpPost]
    public ActionResult<Product> Create([FromBody] CreateProductCommand command)
    {
        var product = _createProductService.Execute(command);
        
        if (_resultService.HasErrors())
            return BadRequest(_resultService.GetErrors());
        
        return Ok(product);
    }

}