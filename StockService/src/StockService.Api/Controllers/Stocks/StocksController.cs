using Microsoft.AspNetCore.Mvc;
using StockService.Application.Common.Result;
using StockService.Application.Stocks.Commands;
using StockService.Application.Stocks.Queries;
using StockService.Application.Stocks.Services.CreateStockServices;
using StockService.Application.Stocks.Services.GetStockServices;
using StockService.Domain.Stocks.Entities;

namespace StockService.Api.Controllers.Stocks;

public class StocksController : BaseController
{
    private readonly ICreateStockService _createStockService;
    private readonly IGetStockService _getStockService;
    
    public StocksController(ICreateStockService createStockService, IGetStockService getStockService, IResultService resultService) : base(resultService)
    {
        _createStockService = createStockService;
        _getStockService = getStockService;
    }

    [HttpGet]
    public ActionResult<Stock> Get([FromQuery] GetStocksQuery query)
    {
        var stocks = _getStockService.Execute(query);

        return Ok(stocks);
    }

    [HttpPost]
    public ActionResult<Stock> Create([FromBody] CreateStockCommand command)
    {
        var stock = _createStockService.Execute(command);
        
        if (_resultService.HasErrors())
            return BadRequest(_resultService.GetErrors());

        return Ok(stock);
    }
    
}