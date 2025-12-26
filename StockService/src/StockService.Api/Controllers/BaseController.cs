using Microsoft.AspNetCore.Mvc;
using StockService.Application.Common.Result;

namespace StockService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected readonly IResultService _resultService;

    public BaseController(IResultService resultService)
    {
        _resultService = resultService;
    }

}