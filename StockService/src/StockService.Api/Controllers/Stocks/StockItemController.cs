using Microsoft.AspNetCore.Mvc;
using StockService.Application.Common.Result;
using StockService.Application.Stocks.Services.CreateStockServices;
using StockService.Application.Stocks.StockItems.Commands;
using StockService.Application.Stocks.StockItems.Services.CreateStockItemService;
using StockService.Domain.Stocks.ValueObjects;

namespace StockService.Api.Controllers.Stocks;

public class StockItemController : BaseController
{
    private readonly ICreateStockItemService _createStockItemService;
    
    public StockItemController(ICreateStockItemService createStockItemService, IResultService resultService) : base(resultService)
    {
        _createStockItemService = createStockItemService;
    }

    [HttpPost("Stock/{stockId:guid}/Items")]
    public ActionResult Post(Guid stockId, [FromBody] CreateStockItemCommand command)
    {
        _createStockItemService.Execute(new StockId(stockId), command);

        if (_resultService.HasErrors())
            return BadRequest(_resultService.GetErrors());

        return Created();
    }

}