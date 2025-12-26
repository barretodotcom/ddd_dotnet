using StockService.Application.Common.Result;

namespace StockService.Api.Controllers.Stocks;

public class StocksController : BaseController
{
    public StocksController(IResultService resultService) : base(resultService)
    {
        
    }
}