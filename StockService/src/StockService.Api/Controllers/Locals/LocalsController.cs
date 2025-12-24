using Microsoft.AspNetCore.Mvc;
using StockService.Application.Locals.Commands;
using StockService.Application.Locals.Services.CreateLocalServices;
using StockService.Application.Locals.Services.GetLocalService;

namespace StockService.Api.Controllers.Locals;

public class LocalsController : BaseController
{
    private readonly ICreateLocalService _createLocalService;
    private readonly IGetLocalService _getLocalService;

    public LocalsController(ICreateLocalService createLocalService, IGetLocalService getLocalService)
    {
        _createLocalService = createLocalService;
        _getLocalService = getLocalService;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Guid> Create([FromRoute] Guid id)
    {
        return Ok(_getLocalService.Execute(id));
    }

    [HttpPost]
    public ActionResult<Guid> Create([FromBody] CreateLocalCommand command)
    {
        return Ok(_createLocalService.Execute(command));
    }

}